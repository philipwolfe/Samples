using System;
using System.Web;
using System.Web.UI;
using System.Collections;

namespace Acme
{
    public class Calendar : Control, IPostBackEventHandler, IPostBackDataHandler
    {
        private String[]              monthNames = new String[12];
        private DateTime              currentDate = DateTime.Now;
        private String                backColor = "#dcdcdc";
        private String                foreColor = "#eeeeee";

        protected override void OnInit(EventArgs E) 
        {
            // Todo: We should remove the need to call this
            Page.RegisterRequiresPostBack(this);
            Page.RegisterPostBackScript();

            currentDate = DateTime.Now;

            monthNames[0] = "January";
            monthNames[1] = "February";
            monthNames[2] = "March";
            monthNames[3] = "April";
            monthNames[4] = "May";
            monthNames[5] = "June";
            monthNames[6] = "July";
            monthNames[7] = "August";
            monthNames[8] = "September";
            monthNames[9] = "October";
            monthNames[10] = "November";
            monthNames[11] = "December";
        }

        protected override void LoadState(Object viewState)
        {
            // If we've done a post-back, the old date will be available to us

            if (null != viewState)
            {
                currentDate = DateTime.Parse((String) viewState);
            }
        }

        public void RaisePostBackEvent(String eventArgument)
        {
            //Page.Response.Write("RaisePostBackEvent Called!!!");

            if (eventArgument == null)
            {
                return;
            }

            // Keep track of old date (for event firing purposes)

            DateTime oldDate = currentDate;

            // Todo: We should have post-back take two arguments: eventname and eventarguments

            if (String.Compare("NavNextMonth", eventArgument, true) == 0)
            {
                currentDate = currentDate.AddMonths(1);
            }
            else if (String.Compare("NavPrevMonth", eventArgument, true) == 0)
            {
                currentDate = currentDate.AddMonths(-1);
            }
            else
            {
                int daySelected = Int32.Parse(eventArgument);
                currentDate = new DateTime(currentDate.Year, currentDate.Month, daySelected);
            }
        }

        protected override Object SaveState()
        {
            // Save CurrentDate out as view state for postback scenarios

            return currentDate.ToString();
        }

        protected override void Render(HtmlTextWriter output)
        {
            //Response.Write(Page.Request.UserAgent);

            if ((Page.Request.UserAgent != null)&&(Page.Request.UserAgent.IndexOf("MSIE 5.5") != -1))
               RenderUpLevel(output);
            else
               RenderDownLevel(output);
        }

        protected void RenderUpLevel(HtmlTextWriter output)
        {
            output.WriteLine("<input name='" + UniqueID + "_CurrentDate' id='" + UniqueID + "_CurrentDate' type=hidden>");
            output.WriteLine("<span id='" + UniqueID + "'></span>");
            output.WriteLine("<script language=jscript>drawcalendar('" + UniqueID + "', '" + Int32.Format(currentDate.Year, null) + "/" + Int32.Format(currentDate.Month, null) + "/" + Int32.Format(currentDate.Day, null) + "');</script>");
        }

        protected override void OnPreRender(EventArgs E)
        {
            String DHTMLFunction = "";
          
            DHTMLFunction += "<script language='JavaScript'> \n";
            DHTMLFunction += "   function drawcalendar(calname, newDate) \n";
            DHTMLFunction += "   { \n";
            DHTMLFunction += "     var CurrentDate = new Date(newDate);\n";
            DHTMLFunction += "     var MonthArray = new Array('January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December');\n";
            DHTMLFunction += "     var MonthDays = new Array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);\n";             
            DHTMLFunction += "     var calText;\n";
            DHTMLFunction += "     calText = '<table bgcolor=#dcdcdc border=0 height=190 valign=top>';\n";
            DHTMLFunction += "     calText = calText + '<tr><td>';\n";
            DHTMLFunction += "     calText = calText + '<center>';\n";
            DHTMLFunction += "     calText = calText + \"<a href='javascript:drawcalendar(\\\"\" + calname + \"\\\", \\\"\" + CurrentDate.getFullYear() + \"/\" + CurrentDate.getMonth() + \"/\" + CurrentDate.getDate() + \"\\\")'>\";\n";
            DHTMLFunction += "     calText = calText + '<img src=/quickstart/aspplus/images/left4.gif width=11 height=11 border=0></a>';\n";
            DHTMLFunction += "     calText = calText + '    <b>' + MonthArray[CurrentDate.getMonth()] + ' ' + CurrentDate.getFullYear() + '</b>';\n";
            DHTMLFunction += "     calText = calText + \"   <a href='javascript:drawcalendar(\\\"\" + calname + \"\\\", \\\"\" + CurrentDate.getFullYear() + \"/\" + (CurrentDate.getMonth() + 2) + \"/\" + CurrentDate.getDate() + \"\\\")'>\";\n";
            DHTMLFunction += "     calText = calText + '<IMG SRC=/quickstart/aspplus/images/right4.gif width=11 height=11 border=0></a>';\n";
            DHTMLFunction += "     calText = calText + '</center>';\n";
            DHTMLFunction += "     calText = calText + '</td></tr>';\n";
            DHTMLFunction += "     calText = calText + '<tr valign=top><td valign=top>';\n";
            DHTMLFunction += "     calText = calText + '<table border=1 bgcolor=#eeeeee height=160>';\n";
            DHTMLFunction += "     calText = calText + '<tr height=20>';\n";
            DHTMLFunction += "     calText = calText + '   <td align=right width=23> Sun </td>';\n";
            DHTMLFunction += "     calText = calText + '   <td align=right width=23> Mon </td>';\n";
            DHTMLFunction += "     calText = calText + '   <td align=right width=23> Tue </td>';\n";
            DHTMLFunction += "     calText = calText + '   <td align=right width=23> Wed </td>';\n";
            DHTMLFunction += "     calText = calText + '   <td align=right width=23> Thu </td>';\n";
            DHTMLFunction += "     calText = calText + '   <td align=right width=23> Fri </td>';\n";
            DHTMLFunction += "     calText = calText + '   <td align=right width=23> Sat </td>';\n";
            DHTMLFunction += "     calText = calText + '</tr>';\n";
            DHTMLFunction += "     calText = calText + '<tr>';\n";
            DHTMLFunction += "     var numDays  = MonthDays[CurrentDate.getMonth()];\n";
            DHTMLFunction += "     var firstDay = new Date(1999, 8, 1).getDay();\n";
            DHTMLFunction += "     for (var x=0; x<firstDay; x++)\n";
            DHTMLFunction += "     {\n";
            DHTMLFunction += "         calText = calText + '<td align=right width=23></td>'\n";
            DHTMLFunction += "     }\n";
            DHTMLFunction += "     for (var x=1; x<=numDays; x++) \n";
            DHTMLFunction += "     { \n";
            DHTMLFunction += "         if (CurrentDate.getDate() == x) \n";
            DHTMLFunction += "         { \n";
            DHTMLFunction += "             calText = calText + '<td align=right width=23>';\n";
            DHTMLFunction += "             calText = calText + '<font color=red><b><u>' + x + '</u></b></font>';\n";
            DHTMLFunction += "             calText = calText + '</td>';\n";
            DHTMLFunction += "         }\n";
            DHTMLFunction += "         else \n";
            DHTMLFunction += "         { \n";
            DHTMLFunction += "             calText = calText + '<td align=right width=23>';\n";
            DHTMLFunction += "             calText = calText + \"<a href='javascript:drawcalendar(\\\"\" + calname + \"\\\", \\\"\" + CurrentDate.getFullYear() + \"/\" + (CurrentDate.getMonth()+1) + \"/\" + x + \"\\\")'>\" + x + \"</a>\";";
            DHTMLFunction += "             calText = calText + '</td>';\n";
            DHTMLFunction += "         }\n";               
            DHTMLFunction += "         if (((firstDay+x) % 7) == 0)\n";
            DHTMLFunction += "         {\n";
            DHTMLFunction += "             calText = calText + '</tr><tr>';\n";
            DHTMLFunction += "         }\n";
            DHTMLFunction += "     }\n";
            DHTMLFunction += "     calText = calText + '</tr>';";
            DHTMLFunction += "     calText = calText + '</table></td></tr></table>';";
            DHTMLFunction += "     var CalendarSpan = document.all(calname);";
            DHTMLFunction += "     if (CalendarSpan != null)";
            DHTMLFunction += "        CalendarSpan.innerHTML = calText;";
            DHTMLFunction += "     var CalendarValue = document.all(calname + '_CurrentDate');";
            DHTMLFunction += "     if (CalendarValue != null)";
            DHTMLFunction += "        CalendarValue.value = '' + (CurrentDate.getMonth() + 1) + '/' + CurrentDate.getDate() + '/' + CurrentDate.getFullYear();";
            DHTMLFunction += "   } \n";
            DHTMLFunction += "</script>\n";

            if ((Page.Request.UserAgent != null)&&(Page.Request.UserAgent.IndexOf("MSIE 5.5") != -1))
               Page.RegisterClientScriptBlock("ACME_CALENDAR_DHTML", DHTMLFunction);
        }

        protected void RenderDownLevel(HtmlTextWriter output)
        {
            // Output Calendar Header
          
            output.WriteLine("<table bgcolor=" + backColor + " border=0 height=190 valign=top><tr><td>");
            output.WriteLine("<table bgcolor=" + backColor + " border=0 height=190 valign=top>");
            output.WriteLine("<tr><td>");
            output.WriteLine("<center>");
            output.WriteLine("    <a href=\"javascript:" + Page.GetPostBackEventReference(this, "NavPrevMonth") + "\">");
            output.WriteLine("<img src=/quickstart/aspplus/images/left4.gif width=11 height=11 border=0></a>");
            output.WriteLine("    <b>" + monthNames[currentDate.Month-1] + " " + Int32.Format(currentDate.Year, null) + "</b>");
            output.WriteLine("    <a href=\"javascript:" + Page.GetPostBackEventReference(this, "NavNextMonth") + "\">"); 
            output.WriteLine("<IMG SRC=/quickstart/aspplus/images/right4.gif width=11 height=11 border=0></a>");
            output.WriteLine("</center>");
            output.WriteLine("</td></tr>");
            output.WriteLine("<tr valign=top><td valign=top>");
            output.WriteLine("<table border=1 bgcolor=" + foreColor + " height=160>");
            output.WriteLine("<tr height=20>");
            output.WriteLine("   <td align=right width=23> Sun </td>");
            output.WriteLine("   <td align=right width=23> Mon </td>");
            output.WriteLine("   <td align=right width=23> Tue </td>");
            output.WriteLine("   <td align=right width=23> Wed </td>");
            output.WriteLine("   <td align=right width=23> Thu </td>");
            output.WriteLine("   <td align=right width=23> Fri </td>");
            output.WriteLine("   <td align=right width=23> Sat </td>");
            output.WriteLine("</tr>");
            output.WriteLine("<tr>");

            // Calculate how many days are in the month

            int numDays  = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);

            // Calculate what day of week the first day of the month is on

            int firstDay = new DateTime(currentDate.Year, currentDate.Month, 1).DayOfWeek;

            // Pre-Day Padding

            for (int x=0; x<firstDay; x++)
            {
                output.WriteLine("<td align=right width=23></td>");
            }

            // Output each day

            for (int x=1; x<=numDays; x++)
            {
                if (currentDate.Day == x)
                {
                    output.Write("<td align=right width=23>");
                    output.Write("<font color=red><b><u>" + Int32.Format(x, null) + "</u></b></font>");
                    output.WriteLine("</td>");
                }
                else
                {
                    output.Write("<td align=right width=23>");
                    output.Write("<a href=\"javascript:" + Page.GetPostBackEventReference(this, Int32.Format(x, null)) + "\">");
                    output.Write(Int32.Format(x, null) + "</a>");
                    output.WriteLine("</td>");
                }                

                // PerPage row break as appropriate
                if (((firstDay+x) % 7) == 0)
                {
                    output.WriteLine("</tr><tr>");
                }
            }

            output.WriteLine("</tr>");
            output.WriteLine("</table></td></tr></table></table>");
        }

        public DateTime Date
        {
            get
            {
                return currentDate;
            }
            set
            {
                currentDate = value;
            }
        }

        public String BackColor
        {
            get
            {
                return backColor;
            }
            set
            {
                backColor = value;
            }
        }

        public String ForeColor
        {
            get
            {
                return foreColor;
            }
            set
            {
                foreColor = value;
            }
        }

        // Todo: We should eliminate the need for a control developer to do stub 
        // implementations of the below standard IPostDataHandler Methods

        public bool LoadPostData(String postDataKey, NameValueCollection values)
        {
            String clientDate = values[UniqueID + "_CurrentDate"];
    
            if (clientDate != null)
               currentDate = DateTime.Parse(clientDate);

            return false;
        }

        public void RaisePostDataChangedEvent() 
        {

        }
    }
}