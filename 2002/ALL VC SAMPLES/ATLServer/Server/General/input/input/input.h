 // input.h : Defines the ATL Server request handler class
//
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Classes Reference and related electronic
// documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft C++ Libraries products.

#pragma once

#include "validation.h" 
#include "atlrx.h" //ATL regular expression support

[ request_handler("Default") ]
class CinputHandler
{
private:
	// Put private members here
	bool valid_input[NUMBER_OF_FORM_VARS];
	CString errorMsg;
	
protected:
	// Put protected members here

public:
	// Put public members here
	HTTP_CODE ValidateAndExchange()
	{
		CAtlRegExp<CAtlRECharTraitsA> atlRegExp;
		CAtlREMatchContext<CAtlRECharTraitsA> atlRematchContext;
		const CHttpRequestParams& FormFields = m_HttpRequest.GetFormVars();

		//loop through all of the required form variables defined in validation.h
		for (int i=0; i<NUMBER_OF_FORM_VARS; i++) 
		{
			CValidateContext c;
	
			valid_input[i] = false;  //pessimistic approach - assume the input is invalid until proven otherwise
    
			//Perform a two-part validation check against this specific form variable
			//		(1) Length - results from built-in Validate() method to enforce string length
			//		(2) Content - regex matching to make sure the string complies with a known good pattern

			// (1) This built in validation routine validates the string length
			FormFields.Validate(theForm[i].name, (LPCSTR*)NULL, 0, 256, &c);

			// (2) Sets up regular expression class to match against the pattern defined for this form variable
			if (atlRegExp.Parse(theForm[i].atl_regex) != REPARSE_ERROR_OK)
				return HTTP_FAIL; //server error - theForm[i].at_regex was not a parseable regular expression
			
			// Only mark the form variable valid if Validate was successful and the string matches the regular expression.
			if ( c.ParamsOK() && atlRegExp.Match(FormFields.Lookup(theForm[i].name),&atlRematchContext) )
			{
				//it matched, so the value of this form variable is valid
				valid_input[i] = true;
			}
			else
			{
				//failed the test, so append corresponding error message
				errorMsg += "<li>";
				errorMsg += theForm[i].error;
				errorMsg += "</li>\n";
			}
		}

		// Set the content-type
		m_HttpResponse.SetContentType("text/html");
	
		return HTTP_SUCCESS;
	}

	[ tag_name(name = "ValidInput") ]
	HTTP_CODE OnValidInput(void)
	{
		//Return true if and only if every form field was validated
		for (int i=0;i<NUMBER_OF_FORM_VARS;i++)
		{
			if (!valid_input[i]) 
			{
				return HTTP_S_FALSE;
			}
		}

		return HTTP_SUCCESS;
	}

	[ tag_name("RegexTests") ]
	HTTP_CODE OnRegexTests(void)
	{
		//loop through and print out regex tests
		//now output a JScript regular expression based validation test for each form element
		for (int i=0; i<NUMBER_OF_FORM_VARS; i++)
		{
            m_HttpResponse << "\t\t\tif (submission.elements[i].name==\"" << theForm[i].name << "\")\n";
			m_HttpResponse << "\t\t\t{\n";
			m_HttpResponse << "\t\t\t   if (!/" << theForm[i].regex << "/.test(submission.elements[i].value))\n";
			m_HttpResponse << "\t\t\t   {\n";
			m_HttpResponse << "\t\t\t      error_message += \"" << theForm[i].error << "\\n\";\n";
			m_HttpResponse << "\t\t\t   }\n";
			m_HttpResponse << "\t\t\t}\n";
		}
		return HTTP_SUCCESS;
	}

	[ tag_name(name = "ShowErrors") ]
	HTTP_CODE OnShowErrors(void)
	{
		//Only proceed if form variables were even submitted
		if ((m_HttpRequest.GetFormVars()).Lookup(theForm[0].name))
		{
			//if an error message was constructed in ValidateAndExchange, display it
			if (errorMsg.GetLength()>0)
			{
				m_HttpResponse << "\n\n<b>Please correct the following errors:</b><ul>" << errorMsg << "</ul>\n\n";
			}
		}

		return HTTP_SUCCESS;
	}
		
	[ tag_name(name="Input") ]
	HTTP_CODE OnInput(char * inputName)
	{
		//this function shields the HTML designer from the input element details
		if (!strncmp(inputName,"Title",5))
		{
			//build a select box using the titles array (from validation.h)
			m_HttpResponse << "<select name=\"Title\">\n";
			for (int i=0; i<(sizeof(titles)/sizeof(char*)); i++)
			{
				m_HttpResponse << "\t<option value=\"" << titles[i] << "\">" << titles[i] << "</option>\n";
			}
			m_HttpResponse << "</select>";
			return HTTP_SUCCESS;
		}
		else if (!strncmp(inputName,"State",5))
		{
			//create a dropdown select box based on the values supplied in validation.h
			m_HttpResponse << "<select name=\"State\">\n";
			for (int i=0; i<(sizeof(postalCodeValues)/sizeof(char*)); i++)
			{
				m_HttpResponse << "\t<option value=\"" << postalCodeValues[i] << "\">" << postalCodeNames[i] << "</option>\n";
			}
			m_HttpResponse << "</select>";
			return HTTP_SUCCESS;
		}
		else
		{
			//all the other input types in this form are simple input boxes
			m_HttpResponse << "<input name=\"" << inputName << "\">";
			return HTTP_SUCCESS;
		}
	}

}; // class CinputHandler
