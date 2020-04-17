//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
using System;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Microsoft.Samples.LoadFromXAML
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        // dictionary with some preloaded xaml programs (displayed in the combo)
        IDictionary<string, string> samples = new Dictionary<string, string>()
        {
            { "<Enter your custom Xaml code in the text box below>", "<write your xaml here>" },

            { 
                "Hello world (Sequence and WriteLine activities)", 
               @"<Sequence xmlns=""http://schemas.microsoft.com/netfx/2009/xaml/activities"">
                   <WriteLine Text=""Hello World""/>
                 </Sequence>" 
            },
        
            { 
             "Generate Random Number (using Invoke Method activity)", 
            @"<InvokeMethod x:TypeArguments=""x:Int32"" MethodName=""Next"" xmlns=""http://schemas.microsoft.com/netfx/2009/xaml/activities"" xmlns:s=""clr-namespace:System;assembly=mscorlib"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
                 <InvokeMethod.TargetObject>
                    <InArgument x:TypeArguments=""s:Random"">
                       <Literal x:TypeArguments=""s:Random"">
                          <s:Random />
                       </Literal>
                    </InArgument>
                 </InvokeMethod.TargetObject>
              </InvokeMethod>"
            }            
        };

        public Window1()
        {
            InitializeComponent();

            // fill the samples combo
            foreach (string key in samples.Keys)
            {
                comboBox1.Items.Add(key);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            this.txtXaml.Text = samples[comboBox1.SelectedItem.ToString()];
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // create stream with textbox contents
                StringBuilder data = new StringBuilder();
                Stream stream = new MemoryStream(ASCIIEncoding.Default.GetBytes(txtXaml.Text));

                // invoke workflow
                WorkflowElement wf = WorkflowXamlServices.Load(stream);
                IDictionary<string, object> results = WorkflowInvoker.Invoke(wf);                

                // show results
                txtResults.Text = "Workflow Executed";
                txtResults.Text += "\r\nReturned data:";
                if (results.Count > 0)
                {
                    foreach (string key in results.Keys)
                    {
                        txtResults.Text += string.Format("\r\n    {0} : {1}", key, results[key]);
                    }
                }
                else
                {
                    txtResults.Text += "\r\n    <no data returned>";
                }
            }
            catch (Exception ex)
            {
                txtResults.Text = string.Format("Error executing the Xaml. Exception type: {0}\r\nDetails:\r\n--------\r\n{1}", ex.GetType().FullName, ex.ToString());
            }
        }
    }
}
