//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Workflow.ComponentModel.Design;

namespace ExpenseActivities
{
    //[ActivityDesignerThemeAttribute(typeof(AmbientTheme), Xml = GetManagerDesigner.ThemeXml)]
    [ActivityDesignerTheme(typeof (GetManagerActivityDesignerTheme))]
    public class GetManagerDesigner : ActivityDesigner
    {
        //protected override ReadOnlyCollection<DesignerAction> DesignerActions
        //{
        //    get
        //    {
        //        List<DesignerAction> DesignerActionList = new List<DesignerAction>();

        //        //This is for the    configuration error on an activity
        //        DesignerActionList.Add(new DesignerAction(this, 1, "Insert Text Here!"));
        //        return DesignerActionList.AsReadOnly();
        //    }
        //}
        //protected override void OnExecuteDesignerAction(DesignerAction designerAction)
        //{
        //    if (designerAction.ActionId == 1)
        //        System.Windows.Forms.MessageBox.Show(designerAction.Text);
        //}

        //// callback for a context Menu item when a user right clicks on the
        //// activity
        //private void CustomContextMenuEvent(object sender, EventArgs e)
        //{
        //    System.Windows.Forms.MessageBox.Show("This is the action from my Context Menu");
        //}

        //protected override ActivityDesignerVerbCollection Verbs
        //{
        //    get
        //    {
        //        ActivityDesignerVerbCollection newVerbs = new ActivityDesignerVerbCollection();
        //        newVerbs.AddRange(base.Verbs);
        //        newVerbs.Add(new ActivityDesignerVerb(this, DesignerVerbGroup.General, "Custom Context Menu", new EventHandler(CustomContextMenuEvent)));
        //        return newVerbs;
        //    }
        //}
    }


    //public sealed class GetManagerDesigner : ActivityDesigner 
    //{
    //#region Theme Initializer XML
    //internal const string ThemeXml =
    //    "<AmbientTheme xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/workflow\"" +
    //    " ApplyTo=\"ExpenseActivities.GetManagerDesigner\"" +
    //    //" BackColorStart = \"0x0000FFFF\"" +
    //    //" BackColorEnd = \"0x1111FFFF\"" +
    //    //" BackgropundStyle = \"1\"" +
    //    " BorderColor = \"0x2222FFFF\"" +
    //    " />";
    //#endregion

    //protected override void Initialize(Activity activity)
    //{
    //    base.Initialize(activity);

    // Change the designer theme for this activity
    //this.DesignerTheme.BackColorStart = Color.White;
    //this.DesignerTheme.BackColorEnd = ColorTranslator.FromHtml("#B4EE88");
    //this.DesignerTheme.BackgroundStyle = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
    //this.DesignerTheme.BorderColor = ColorTranslator.FromHtml("#4C94C4");
    //}
    //}

    internal sealed class GetManagerActivityDesignerTheme : ActivityDesignerTheme
    {
        public GetManagerActivityDesignerTheme(WorkflowTheme theme)
            : base(theme)
        {
            BackColorStart = Color.White;
            BackColorEnd = ColorTranslator.FromHtml("#B4EE88");
            BackgroundStyle = LinearGradientMode.Vertical;
            BorderColor = ColorTranslator.FromHtml("#4C94C4");
        }
    }
}