// File: Checkout.cpp
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#include "StdAfx.h"
#include "Checkout.h"
#include "Commands.h"
#include "Helpers.h"

HTTP_CODE CCheckoutHandler::ValidateAndExchange()
{
    using VCUE::OpenCommandRowset;
    using VCUE::SendError;
    using VCUE::GetSession;
    using VCUE::GetLoginId;

    HRESULT hr = E_UNEXPECTED;

    // Set the content-type of the response.
    m_HttpResponse.SetContentType("text/html");

    // Get the session ID of the current user.
    LPCSTR szSessionId = GetLoginId(m_HttpRequest);
    if (!szSessionId)
    {
        // User doesn't have valid cookie, redirect to login page.
        m_HttpResponse.Redirect("login.srf");
        return HTTP_SUCCESS_NO_PROCESS;
    }

    // Get the session.
    CComPtr<ISession> spSession;
    hr = GetSession(m_spServiceProvider, szSessionId, &spSession);
    if (FAILED(hr))
    {
        return SendError(m_HttpResponse, "An error occurred while obtaining the session object.");
    }

    // Get the user name.
    CComVariant varUserName;
    hr = spSession->GetVariable("UserName", &varUserName);
    if (FAILED(hr))
    {
        return SendError(m_HttpResponse, "An error occurred while obtaining a session variable.");
    }

    // Get the user name as a string.
    CStringA strUserName = varUserName;

    // Commit the order to the database.
    hr = CommitOrder(m_spServiceProvider, spSession, strUserName);
    if (FAILED(hr))
    {
        return SendError(m_HttpResponse, "An error occurred while writing the order to the database.");
    }

    // Get the email address of the user.
    CCommandGetEmail cmdGetEmail;
    hr = cmdGetEmail.SetUserName(strUserName);
    if (FAILED(hr))
    {
        return SendError(m_HttpResponse, "An error occurred. The user name is too long.");
    }

    hr = OpenCommandRowset(m_spServiceProvider, cmdGetEmail);
    if (FAILED(hr))
    {
        return SendError(m_HttpResponse, "An error occurred while accessing the database.");
    }

    hr = cmdGetEmail.MoveFirst();
    if ((S_OK != hr) || (cmdGetEmail.m_dwEmailStatus != DBSTATUS_S_OK))
    {
        return SendError(m_HttpResponse, "An error occurred. Unable to obtain email address.");
    }

    // Create the confirmation message
    CMimeMessage msgConfirmation;
    BOOL bSuccess = msgConfirmation.SetSender(MAIL_SENDER_ADDRESS);
    if (bSuccess)
    {
        bSuccess = msgConfirmation.SetDisplayName("ATL Server Tutorial");
        if (bSuccess)
        {
            bSuccess = msgConfirmation.AddRecipient(cmdGetEmail.m_Email, cmdGetEmail.m_Email);
            if (bSuccess)
            {
                bSuccess = msgConfirmation.SetSubject("Order Confirmation");
                if (bSuccess)
                {
                    bSuccess = msgConfirmation.AddText("Your order has been received and will be shipped to you ASAP");
                }
            }
        }
    }

    if (!bSuccess)
    {
        return SendError(m_HttpResponse, "An error occurred while creating the confirmation message.");
    }

    // Open a connection to the SMTP mail server.
    CSMTPConnection smtpConnection;
    if (!smtpConnection.Connect(MAIL_SERVER_NAME))
    {
        return SendError(m_HttpResponse, "An error occurred connecting to the SMTP server. Make sure that SERVER_NAME (defined in stdafx.h) is set correctly.");
    }
    
    // Send the confirmation message.
    if (!smtpConnection.SendMessage(msgConfirmation))
    {
        return SendError(m_HttpResponse, "An error occurred while trying to sending the confirmation email message.");
    }

    // Create a perfmon counter for number of orders
    // Remember to regsvr32 your application dll (tutorial.dll)
    CComPtr<ITutorialPerformanceService> spService;
    hr = GetPerformanceService(&spService);
    if (SUCCEEDED(hr))
    {
        hr = spService->AddOrder();
    }

    if (FAILED(hr))
    {
        return SendError(m_HttpResponse, "An error occurred while creating a PerfMon counter.");
    }

    return HTTP_SUCCESS;    
}

HRESULT CCheckoutHandler::CommitOrder(IServiceProvider* pServiceProvider, ISession* pSession, const CStringA& strUserName)
{
    using VCUE::OpenCommandRowset;

    // Initialize variables.
    HRESULT hr = E_UNEXPECTED;
    HSESSIONENUM hSession = NULL;
    POSITION posSession = NULL;

    // Get the session variable enumeration handle.
    hr = pSession->BeginVariableEnum(&posSession, &hSession);
    if (FAILED(hr))
        return hr;

    // Get the first variable.
    char szProductId[MAX_VARIABLE_NAME_LENGTH];
    CComVariant varQuantity;
    hr = pSession->GetNextVariable(&posSession, &varQuantity, hSession, szProductId, sizeof(szProductId));
    if (FAILED(hr))
        return hr;

    // Build a regular expression for matching decimal integers
    CRegularExpression regularExpression;
    if (regularExpression.Parse("^\\d+$") != REPARSE_ERROR_OK)
        return E_UNEXPECTED;

    CStringA strOrder;
    CMatchContext matchContext;
    while (hr == S_OK)
    {
        // Append session variables to order string if
        // name is a decimal integer string and value
        // is a variant of type long (VT_I4).
        if (regularExpression.Match(szProductId, &matchContext))    
        {
            if (VT_I4 == V_VT(&varQuantity))
            {
                strOrder.Append(szProductId);
                strOrder.Append("\t");
                strOrder.Append(CStringA(varQuantity));
                strOrder.Append("\n");
            }
        }

        // Check whether all session variables have been examined.
        if (!posSession)
            break;

        // Get the next session variable.
        varQuantity.Clear();
        hr = pSession->GetNextVariable(&posSession, &varQuantity, hSession, szProductId, sizeof(szProductId));
    }

    if (SUCCEEDED(hr))
    {
        // Commit the order to the database.
        CCommandCreateOrder cmdNewOrder;
        hr = cmdNewOrder.SetUserName(strUserName);
        if (SUCCEEDED(hr))
        {
            hr = cmdNewOrder.SetOrder(strOrder);
            if (SUCCEEDED(hr))
            {
                hr = OpenCommandRowset(pServiceProvider, cmdNewOrder);
            }
        }
    }

    return hr;
}

HRESULT CCheckoutHandler::GetPerformanceService(ITutorialPerformanceService** ppService)
{
    using VCUE::QueryService;

    HRESULT hr = E_UNEXPECTED;

    // Get the performance service.
    CComPtr<ITutorialPerformanceService> spService;
    hr = QueryService(m_spServiceProvider, &spService);

    if (FAILED(hr))
    {
        // Failed to get an existing performance service, so create
        // the service and register it with the ISAPI DLL.
        hr = CTutorialPerformanceService::CreateInstance(&spService);
        if (SUCCEEDED(hr))
        {
            hr = m_spExtension->AddService(
                __uuidof(ITutorialPerformanceService),
                __uuidof(ITutorialPerformanceService),
                spService,
                _pModule->GetModuleInstance());

            if (S_FALSE == hr)
            {
                // The service was already added, release the
                // new service and obtain the one from the ISAPI
                // extension.
                spService.Release();
                hr = QueryService(m_spServiceProvider, &spService);
            }
        }
    }

    *ppService = spService.Detach();
    return hr;
}