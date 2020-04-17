//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace ControlsAll
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>

	public partial class Pane1 : StackPanel
	{
		System.Windows.Controls.Button btn, btn1, btn2, btn3, btn4;
		System.Windows.Controls.TextBlock txt;
		System.Windows.Controls.CheckBox cb;
		System.Windows.Controls.ComboBox combo;
		System.Windows.Controls.ComboBoxItem cbi1, cbi2, cbi3;
		System.Windows.Controls.ContextMenu contextmenu;
		System.Windows.Controls.Primitives.ScrollBar hscrollb, vscrollb;
		System.Windows.Controls.Menu menu;
		System.Windows.Controls.MenuItem mi, mia, mib, mib1, mib1a;
		System.Windows.Controls.Slider hslider;
		System.Windows.Controls.ListBox lb;
		System.Windows.Controls.ListBoxItem li1, li2, li3;
		System.Windows.Controls.RadioButton rb1, rb2, rb3;
		System.Windows.Controls.Primitives.RepeatButton rpbtn;
                System.Windows.Controls.TextBox txtb;
		System.Windows.Controls.Primitives.Thumb thumb;
                System.Windows.Controls.ToolBar tbar, tbar1;
                System.Windows.Controls.ToolBarTray tbartray;
	        System.Windows.Controls.ToolTip ttp;


		Int32 Num;

	private void ChangeButton(object sender, RoutedEventArgs e)
		{
		spanel2.Children.Clear();
		btn = new Button();
                btn.Width = 50;
                btn.HorizontalAlignment = HorizontalAlignment.Left;
                btn.Content = "Button";
	        spanel2.Children.Add(btn);
		txt = new TextBlock();
                txt.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
                txt.Text = "Buttons are the most basic of user interface elements. They respond to the Click event. When a button's state changes its appearance changes also. Move the cursor over the button and click the button to see changes.";
                txt.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
                spanel2.Children.Add(txt);
		}
       private void ChangeCheckBox(object sender, RoutedEventArgs e)
		{
                  spanel2.Children.Clear();
                  cb = new CheckBox();
                  cb.Content = "CheckBox";
                  spanel2.Children.Add(cb);
                  txt = new TextBlock();
                  txt.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
                  txt.Text = "Check boxes allow users to select and clear options. The user's selection is indicated by a check mark in the box. Clicking a check box switches its state and appearance. Click the box to see the changes in appearance.";
                  spanel2.Children.Add(txt);
		}
        private void ChangeComboBox(object sender, RoutedEventArgs e)
        {
            spanel2.Children.Clear();
            combo = new ComboBox();
            combo.Width = 80;
            combo.HorizontalAlignment = HorizontalAlignment.Left;
            cbi1 = new ComboBoxItem();
            cbi1.Content = "Item 1";
            combo.Items.Add(cbi1);
            cbi2 = new ComboBoxItem();
            cbi2.Content = "Item 2";
            combo.Items.Add(cbi2);
            cbi3 = new ComboBoxItem();
            cbi3.Content = "Item 3";
            combo.Items.Add(cbi3);
            spanel2.Children.Add(combo);
            txt = new TextBlock();
            txt.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
            txt.Text = "The combo box is a composite control that presents users with a list of options. The contents can be shown and hidden as the control expands and collapses. In its default state the list is collapsed. The user clicks a button to see the complete list of options.";
            spanel2.Children.Add(txt);
        }
        private void ChangeContextMenu(object sender, RoutedEventArgs e)
        { 
            spanel2.Children.Clear();
            btn = new Button();
            btn.Width = 150;
            btn.HorizontalAlignment = HorizontalAlignment.Left;
            btn.Content = "Button with ContextMenu";
            contextmenu = new ContextMenu();
            mi = new MenuItem();
            mi.Header = "Item 1";
            contextmenu.Items.Add(mi);
            mia = new MenuItem();
            mia.Header = "Item 2";
            contextmenu.Items.Add(mia);
            btn.ContextMenu = contextmenu;
            spanel2.Children.Add(btn);
            txt = new TextBlock();
            txt.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
            txt.Text = "A context menu enables you to present users with a list of items that specify commands or options associated with a particular control - for example, a button. Users right-click the control to make the menu appear. Typically, clicking a menu item opens a submenu or causes an application to carry out a command. The part of this application that presents the list of the controls for you to select is a context menu attached to a button.";
            spanel2.Children.Add(txt);
        }
        private void ChangeScrollBar(object sender, RoutedEventArgs e)
        {
            spanel2.Children.Clear();
            hscrollb = new ScrollBar();
            hscrollb.Orientation = Orientation.Horizontal;
            spanel2.Children.Add(hscrollb);
            txt = new TextBlock();
            txt.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
            txt.Text = "A horizontal scroll bar is a composite control that encapsulates several buttons (thumb and two repeat buttons) to expose horizontal scrolling functionality in a user interface.";
            spanel2.Children.Add(txt);
        }
        private void ChangeSlider(object sender, RoutedEventArgs e)
        {
            spanel2.Children.Clear();
            hslider = new Slider();
            hslider.Orientation = Orientation.Horizontal;
            spanel2.Children.Add(hslider);
            txt = new TextBlock();
            txt.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
            txt.Text = "A horizontal slider control, lets a user select from a range of values by moving a thumb. A slider is used to gradually modify a value (range selection). A slider is commonly used in volume controls, but it can be used anywhere a value has a minimum, a maximum, and an increment.";
            spanel2.Children.Add(txt);
        }
        
        private void ChangeListBox(object sender, RoutedEventArgs e)
        {
            spanel2.Children.Clear();
            lb = new ListBox();
            lb.Width = 80;
            lb.HorizontalAlignment = HorizontalAlignment.Left;
            li1 = new ListBoxItem();
            li1.Content = "Item 1";
            lb.Items.Add(li1);
            li2 = new ListBoxItem();
            li2.Content = "Item 2";
            lb.Items.Add(li2);
            li3 = new ListBoxItem();
            li3.Content = "Item 3";
            lb.Items.Add(li3);
            spanel2.Children.Add(lb);
            txt = new TextBlock();
            txt.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
            txt.Text = "A list box provides a means for organizing a group of items and allowing a user to select those items. A list box provides several options for customizing how items in the control are selected. Also, list boxes are used and encapsulated by other controls.  For example, combo box uses a list box in its internal implementation.";
            spanel2.Children.Add(txt);
        }
        private void ChangeMenu(object sender, RoutedEventArgs e)
        {
            spanel2.Children.Clear();
            menu = new Menu();
            menu.Width = 50;
            menu.HorizontalAlignment = HorizontalAlignment.Left;
            menu.Background = System.Windows.Media.Brushes.LightBlue;
            mi = new MenuItem();
            mi.Header = "File";
            menu.Items.Add(mi);
            mia = new MenuItem();
            mia.Header = "New";
            mi.Items.Add(mia);
            mib = new MenuItem();
            mib.Header = "Open";
            mi.Items.Add(mib);
            mib1 = new MenuItem();
            mib1.Header = "Recently Opened";
            mib.Items.Add(mib1);
            mib1a = new MenuItem();
            mib1a.Header = "Text.xaml";
            mib1.Items.Add(mib1a);
            spanel2.Children.Add(menu);
            txt = new TextBlock();
            txt.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
            txt.Text = "Menus present a list of items that specify commands or options for an application. Typically, clicking a menu item opens a submenu or causes an application to carry out a command.";
            spanel2.Children.Add(txt);
        }
        private void ChangeRadioButton(object sender, RoutedEventArgs e)
        {
            spanel2.Children.Clear();
            rb1 = new RadioButton();
            rb1.Content = "Radio Button 1";
            spanel2.Children.Add(rb1);
            rb2 = new RadioButton();
            rb2.Content = "Radio Button 2";
            spanel2.Children.Add(rb2);
            rb3 = new RadioButton();
            rb3.Content = "Radio Button 3";
            spanel2.Children.Add(rb3);
            txt = new TextBlock();
            txt.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
            txt.Text = "A radio button can be selected, but not cleared, by a user. The button must be cleared programmatically.";
            spanel2.Children.Add(txt);
        }
        private void ChangeRepeatButton(object sender, RoutedEventArgs e)
        {
            spanel2.Children.Clear();
            rpbtn = new RepeatButton();
            rpbtn.Width = 50;
            rpbtn.HorizontalAlignment = HorizontalAlignment.Left;
            rpbtn.Width = (100);
            rpbtn.Height = (25);
            rpbtn.Content = "Increase";
            rpbtn.Delay = (100);
            rpbtn.Interval = (50);
            spanel2.Children.Add(rpbtn);
            btn = new Button();
            btn.Content = "0";
            System.Windows.Controls.Canvas.SetLeft(btn, (120));
            btn.Width = 50;
            btn.HorizontalAlignment = HorizontalAlignment.Left;
            spanel2.Children.Add(btn);
            txt = new TextBlock();
            txt.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
            txt.Text = "A repeat button is a control that is similar to a button. However, repeat buttons give you control over when and how the Click event is fired. The repeat button fires its Click event repeatedly from the time it is pressed until it is released. The Delay property determines when the event begins firing. You can control the interval of the repetitions with the Interval property. If you press the example repeat button the content value of the button on the right increases until it reachs 100 and then the value is reset.";
            spanel2.Children.Add(txt);
            rpbtn.Click += (Increase);
        }

        void Increase(object sender, RoutedEventArgs e)
        {
            Num = Convert.ToInt32(btn.Content);
            btn.Content = ((Num + 1).ToString());
            if (Num >= 100)
            {
                btn.Content = "0";
            }
        }
       
        private void ChangeTextBox(object sender, RoutedEventArgs e)
        {
            spanel2.Children.Clear();
            txtb = new TextBox();
            txtb.Width = 50;
            txtb.HorizontalAlignment = HorizontalAlignment.Left;
            txtb.Text = "This is a text box.";
            spanel2.Children.Add(txtb);
            txt = new TextBlock();
            txt.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
            txt.Text = "A text box provides an editable region that accepts text input. Enter some text in the sample text box.";
            spanel2.Children.Add(txt);
        }
        private void ChangeThumb(object sender, RoutedEventArgs e)
        {
            spanel2.Children.Clear();
            thumb = new Thumb();
            thumb.Width = 20;
            thumb.HorizontalAlignment = HorizontalAlignment.Left;
            spanel2.Children.Add(thumb);
            vscrollb = new ScrollBar();
            vscrollb.Orientation = Orientation.Vertical;
            vscrollb.HorizontalAlignment = HorizontalAlignment.Left;
            vscrollb.Width = (20);
            vscrollb.Height = (80);
            Canvas.SetLeft(vscrollb, (50));
            spanel2.Children.Add(vscrollb);
            txt = new TextBlock();
            txt.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
            txt.Text = "A thumb is typically used in combination with other elements to create encapsulated components, such as scroll bars and sliders. For example, a thumb element enables basic drag functionality for a scroll bar (by creating a scroll box) or resizable window (by creating a window corner). The example shows a thumb and a thumb as it is typically used as an element of a scroll bar.";
            spanel2.Children.Add(txt);
        }
        private void ChangeToolBar(object sender, RoutedEventArgs e)
        {
            spanel2.Children.Clear();
            tbartray = new ToolBarTray();
            tbar = new ToolBar();
            btn = new Button();
            btn.Content = "File";
            tbar.Items.Add(btn);
            btn1 = new Button();
            btn1.Content = "Edit";
            tbar.Items.Add(btn1);
            tbar1 = new ToolBar();
            btn2 = new Button();
            btn2.Content = "Format";
            tbar1.Items.Add(btn2);
            btn3 = new Button();
            btn3.Content = "View";
            tbar1.Items.Add(btn3);
            btn4 = new Button();
            btn4.Content = "Help";
            tbar1.Items.Add(btn4);
            tbartray.ToolBars.Add(tbar);
            tbartray.ToolBars.Add(tbar1);
            spanel2.Children.Add(tbartray);
            txt = new TextBlock();
            txt.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
            txt.Text = "ToolBars are containers for a group of commands or controls. Usually tool bars are placed inside tool bar trays to manage their layout. The example shows two tool bars inside a tool bar tray.";
            spanel2.Children.Add(txt);
        }
        private void ChangeToolTip(object sender, RoutedEventArgs e)
        {
            spanel2.Children.Clear();
            btn = new Button();
            btn.Width = 150;
            btn.HorizontalAlignment = HorizontalAlignment.Left;
            btn.Content = "Button with ToolTip";
            ttp = new ToolTip();
            ttp.Content = "Some useful information.";
            btn.ToolTip = (ttp);
            spanel2.Children.Add(btn);
            txt = new TextBlock();
            txt.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
            txt.Text = "ToolTips are small popup windows that show up after particular events are fired in the system or a user hovers over a control. ToolTips can have one or more lines of text, as well as images, and embedded elements, but they do not take focus. The purpose is to present information to the user while not taking focus. Hover over the button control to see the tool tip.";
            spanel2.Children.Add(txt);
        }
        
        

    }
}
 
	
