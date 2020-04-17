//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

namespace Samples.Controls
{
    [ToolboxData("<{0}:FieldControl runat=\"server\" />")]
    public class FieldControl : WebControl, INamingContainer
    {
        public enum Alignment
        {
            Top,
            Left
        }

        private string dataSourceKey, optionDataSourceKey;
        private WebControl dataControl = null;
        private Label label = null;

        public FieldControl()
            : base()
        {
            this.Width = new Unit("50px");
            this.Height = new Unit("22px");
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.dataSourceKey = string.Format("{0}$DataSource", this.ID);
            this.optionDataSourceKey = string.Format("{0}$OptionDataSource", this.ID);
        }

        [Description("Gets or sets the DataRow which to be edited")] 
        [Category("Data")] 
        [Browsable(false)]
        public DataRow DataSource
        {
            get
            {
                object obj = this.Page.Session[dataSourceKey];

                return obj == null ? null : (DataRow)obj;
            }
            set
            {
                this.Page.Session[this.dataSourceKey] = value;
            }
        }

        [Description("Gets Orientation sets the object used to display build the option ListItems ")]
        [Category("Data")]
        [Browsable(false)]
        public object OptionDataSource
        {
            get
            {
                return this.Page.Session[optionDataSourceKey];
            }
            set
            {
                this.Page.Session[this.optionDataSourceKey] = value;
            }
        }

        [Description("Gets or sets the name of the column or property of the datasource to display")]
        [Category("Data")] 
        public string DataTextField
        {
            get
            {
                object obj = this.ViewState["dataTextField"];

                return (obj != null) ? obj.ToString() : string.Empty;
            }
            set
            {
                this.ViewState["dataTextField"] = value;
            }
        }

        [Description("Gets or sets the alignment of the caption")]
        [Category("Layout")] 
        public Alignment CaptionAlignment
        {
            get
            {
                object obj = this.ViewState["captionAlignment"];

                return (obj != null) ? (Alignment) obj : Alignment.Left;
            }
            set
            {
                this.ViewState["captionAlignment"] = value;
            }
        }

        [Description("Gets or sets the width of the field used to display the data")]
        [Category("Layout")] 
        public Unit DataControlWidth
        {
            get
            {
                object obj = this.ViewState["dataControlWidth"];

                return (obj != null) ? (Unit)obj : new Unit(string.Empty);
            }
            set
            {
                this.ViewState["dataControlWidth"] = value;
            }
        }

        [Description("Gets or sets the width of the caption")]
        [Category("Layout")] 
        public Unit CaptionWidth
        {
            get
            {
                object obj = this.ViewState["captionWidth"];

                return (obj != null) ? (Unit)obj : new Unit(string.Empty);
            }
            set
            {
                this.ViewState["captionWidth"] = value;
            }
        }

        [Description("Gets or sets the caption")]
        [Category("Appearance")] 
        public string Caption
        {
            get
            {
                object obj = this.ViewState["caption"];

                return (obj != null) ? obj.ToString() : string.Empty;
            }
            set
            {
                this.ViewState["caption"] = value;
            }
        }

        [Description("Gets or sets the column or property of the datasource that is used for the text of each ListItem option")]
        [Category("Data")] 
        public string OptionTextField
        {
            get
            {
                object obj = this.ViewState["optionTextField"];

                return (obj != null) ? obj.ToString() : string.Empty;
            }
            set
            {
                this.ViewState["optionTextField"] = value;
            }
        }

        [Description("Gets or sets the column or property of the datasource that is used for the value of each ListItem option")]
        [Category("Data")]  
        public string OptionValueField
        {
            get
            {
                object obj = this.ViewState["optionValueField"];

                return (obj != null) ? obj.ToString() : string.Empty;
            }
            set
            {
                this.ViewState["optionValueField"] = value;
            }
        }

        [Description("Gets or sets whether the field to be edited is a lookup")]
        [Category("Behaviour")] 
        public bool IsLookup
        {
            get
            {
                object obj = this.ViewState["isLookup"];

                return (obj != null) ? (bool)obj : false;
            }
            set
            {
                this.ViewState["isLookup"] = value;
            }
        }

        [Description("Gets or sets whether the field is required")]
        [Category("Behaviour")] 
        public bool IsRequired
        {
            get
            {
                object obj = this.ViewState["isRequired"];

                return (obj != null) ? (bool)obj : false;
            }
            set
            {
                this.ViewState["isRequired"] = value;
            }
        }

        [Description("Gets or sets the validation group")]
        [Category("Behaviour")] 
        public string ValidationGroup
        {
            get
            {
                object obj = this.ViewState["validationGroup"];

                return (obj != null) ? obj.ToString() : string.Empty;
            }
            set
            {
                this.ViewState["validationGroup"] = value;
            }
        }

        [Description("Gets or sets the validation display")]
        [Category("Behaviour")] 
        public ValidatorDisplay ValidationDisplay
        {
            get
            {
                object obj = this.ViewState["validationDisplay"];

                return (obj != null) ? (ValidatorDisplay)obj : ValidatorDisplay.Dynamic;
            }
            set
            {
                this.ViewState["validationDisplay"] = value;
            }
        }

        private DataColumn GetColumn()
        {
            string dataTextField = this.DataTextField;
            DataRow dataSource = this.DataSource;

            DataColumn column = null;

            if (dataSource != null)
            {
                if (string.IsNullOrEmpty(dataTextField))
                {
                    //Use the first column
                    column = dataSource.Table.Columns[0];
                }
                else
                {
                    //Use the specified column
                    column = dataSource.Table.Columns[dataTextField];
                }
            }

            return column;
        }

        protected override void CreateChildControls()
        {
            DataRow dataSource = this.DataSource;
            string caption = this.Caption;

            if (dataSource == null)
            {
                this.label = new Label();
                this.label.Text = "Error";

                Label errorLabel = new Label();
                errorLabel.Text = "No datasource has been set";

                this.dataControl = errorLabel;
            }
            else
            {
                DataColumn column = this.GetColumn();
  
                if (this.IsLookup)
                {
                    //Use a dropdownlist
                    DropDownList dropDownList = new DropDownList();

                    dropDownList.DataSource = this.OptionDataSource;
                    dropDownList.DataTextField = this.OptionTextField;
                    dropDownList.DataValueField = this.OptionValueField;
                    dropDownList.DataBind();

                    object obj = dataSource[column];

                    //Select the current item
                    ListItem item = dropDownList.Items.FindByValue(obj.ToString());

                    if (item != null)
                    {
                        item.Selected = true;
                    }

                    dropDownList.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);

                    this.dataControl = dropDownList;
                }
                else
                {
                    if (column.DataType == typeof(Boolean))
                    {
                        CheckBox checkBox = new CheckBox();

                        object obj = dataSource[column];
                        checkBox.Checked = (obj != DBNull.Value) ? Convert.ToBoolean(obj) : false;
                        checkBox.CheckedChanged += new EventHandler(checkBox_CheckedChanged);

                        this.dataControl = checkBox;


                    }
                    else if (column.DataType == typeof(DateTime))
                    {
                        Calendar calendar = new Calendar();

                        object obj = dataSource[column];

                        if (obj == DBNull.Value)
                        {
                            calendar.SelectedDate =
                                calendar.VisibleDate = Convert.ToDateTime(obj);
                        }
                        else
                        {
                            calendar.SelectedDate =
                                calendar.VisibleDate = DateTime.Now;
                        }

                        calendar.SelectionChanged += new EventHandler(calendar_SelectionChanged);

                        this.dataControl = calendar;
                    }
                    else
                    {
                        //Just use a textbox
                        TextBox textBox = new TextBox();

                        object obj = dataSource[column];
                        textBox.Text = (obj != DBNull.Value) ? obj.ToString() : string.Empty;
                        textBox.TextChanged += new EventHandler(textBox_TextChanged);

                        this.dataControl = textBox;
                    }
                }

                this.label = new Label();

                string dataTextField = this.DataTextField;

                if (string.IsNullOrEmpty(caption))
                {
                    //Use the column name
                    this.label.Text =
                        caption = column.ColumnName;
                }
                else
                {
                    //Use the specified caption
                    this.label.Text = caption;
                }
            }

            //Layout the control
            switch (this.CaptionAlignment)
            {
                case Alignment.Top:
                    this.Controls.Add(this.LayoutTop());
                    break;
                default:
                    this.Controls.Add(this.LayoutLeft());
                    break;
            }

            //Set the control sizes
            this.label.Width = this.CaptionWidth;
            this.dataControl.Width = this.DataControlWidth;

            //Add a validator if the field is required
            //We only want to add the validator if the datatype requires a textbox to display
            if (this.IsRequired &&
                this.dataControl is TextBox)
            {
                this.dataControl.ID = "dataControl";

                RequiredFieldValidator validator = new RequiredFieldValidator();
                validator.ControlToValidate = this.dataControl.ID;
                validator.ValidationGroup = this.ValidationGroup;
                validator.ErrorMessage = string.Format("{0} is a required field", caption);
                validator.Display = this.ValidationDisplay;
                this.Controls.Add(validator);
            }
        }

        private void SetValue(object value)
        {
            DataColumn column = this.GetColumn();

            if (column.DataType == typeof(bool))
            {
                this.DataSource[column] = Convert.ToBoolean(value);
            }
            else if (column.DataType == typeof(DateTime))
            {
                this.DataSource[column] = Convert.ToDateTime(value);
            }
            else
            {
                this.DataSource[column] = value.ToString();
            }
        }

        void textBox_TextChanged(object sender, EventArgs e)
        {
            this.SetValue(((TextBox)sender).Text);
        }

        void dropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetValue(((DropDownList)sender).SelectedValue);
        }

        void calendar_SelectionChanged(object sender, EventArgs e)
        {
            this.SetValue(((Calendar)sender).SelectedDate);
        }

        void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.SetValue(((CheckBox)sender).Checked);
        }

        private Table LayoutLeft()
        {
            Table table = new Table();
            table.Width = this.Width;
            TableRow row = null;
            TableCell cell = null;

            row = new TableRow();

            cell = new TableCell();
            cell.Controls.Add(this.label);
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Controls.Add(this.dataControl);
            row.Cells.Add(cell);

            table.Rows.Add(row);

            return table;
        }

        private Table LayoutTop()
        {
            Table table = new Table();
            table.Width = this.Width;
            TableRow row = null;
            TableCell cell = null;

            row = new TableRow();
            cell = new TableCell();
            cell.Controls.Add(this.label);
            row.Cells.Add(cell);
            table.Rows.Add(row);

            row = new TableRow();
            cell = new TableCell();
            cell.Controls.Add(this.dataControl);
            row.Cells.Add(cell);
            table.Rows.Add(row);

            return table;
        }
    }
}
