
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.ServiceModel.Samples;

public partial class Default : System.Web.UI.Page
{
    private WeatherServiceClient client;

    protected void Page_Load(Object sender, EventArgs e)
    {
        // capture a reference to the cached client.  This reference will stay with this page for the
        // lifetime of the page.
        // we want to use this same instance of the client for calling BeginGetWeatherData and EndGetWeatherData
        // in order for any exceptions on the client to bubble up
        // if we didn't do this, there is a chance that the Global.Client instance could be
        // replaced and we may mask certain error conditions
        this.client = Global.Client;

        // This page is marked Async='true' so we need to 
        // setup the begin and end event handlers for asynchronous processing of the
        // PreRender step in the page lifecycle
        BeginEventHandler bh = new BeginEventHandler(this.BeginGetWeather);
        EndEventHandler eh = new EndEventHandler(this.EndGetWeather);
        AddOnPreRenderCompleteAsync(bh, eh);
    }

    IAsyncResult BeginGetWeather(Object src, EventArgs args, AsyncCallback cb, Object state)
    {
        string[] localities = { "Los Angeles", "Rio de Janeiro", "New York", "London", "Paris", "Rome", "Cairo", "Beijing" };
        
        // invoke the client asynchronously
        return client.BeginGetWeatherData(localities, cb, state);
    }

    void EndGetWeather(IAsyncResult ar)
    {
        WeatherData[] myData = null;

        try
        {
            // call EndGetWeatherData with the IAsyncResult in order to get the results of the call
            myData = this.client.EndGetWeatherData(ar);
        }
        catch
        {
            Global.Client = null;
            throw;
        }

        // bind the results to the datagrid
        dataGrid1.DataSource = myData;
        dataGrid1.DataBind();
    }
}
