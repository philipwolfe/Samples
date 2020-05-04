using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UrlBuddy
{
    partial class MainForm : Form
	{
		#region PInvoke declarations

		[DllImport("User32.dll")]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        [DllImport("User32.dll")]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int Msg, IntPtr wParam, IntPtr lParam);

		#endregion

        private string		_url;						// The last URL copied to the clipboard
		private string		_text;						// The text to show on the form
		private bool		_loading = true;			// Indicates that we are loading
		private IntPtr		_nextClipboardViewer;		// The next clipboard in the Windows clipboard chain
		private const int	c_recentUrlsMax = 10;		// Maximum number of entries in the Recent URLs menu

        public MainForm()
        {
            InitializeComponent();
            CreateEventHandlers();
			LoadRecentUrls();

            notifyIcon.Text = Application.ProductName;
        }

        /// <summary>
        /// Wires up event handlers and forwards calls to more interesting methods.
        /// </summary>
		private void CreateEventHandlers()
        {
            exitMenuItem.Click += delegate
            {
                Close();
            };

            showLastUrlMenuItem.Click += delegate
            {
                ShowForm();
            };

            notifyIcon.DoubleClick += delegate
            {
                // Only show the form if we've successfully retrieved a URL.
				if (_url != null)
                {
                    ShowForm();
                }
            };

            timer.Tick += delegate
            {
                timer.Stop();
                FadeDownTo(0);
            };
        }

		/// <summary>
		/// Draws the icon and text onto the form.
		/// </summary>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			// Determine where to position the form on the screen.
			int left = 64;
			int width = Width - left - 10;

			// Vertically center the page title and trim with a trailing ellipsis if necessary.
			StringFormat stringFormat = (StringFormat)StringFormat.GenericDefault.Clone();
			stringFormat.LineAlignment = StringAlignment.Center;
			stringFormat.Trimming = StringTrimming.EllipsisWord;

			// Draw the page title.
			RectangleF rect = new RectangleF(left, 5, width, 30);
			e.Graphics.DrawString(_text, new Font(Font, FontStyle.Bold), SystemBrushes.WindowText, rect, stringFormat);

			// Change the trimming to better handle paths.
			stringFormat.Trimming = StringTrimming.EllipsisPath;
			
			// Draw the URL.
			rect = new RectangleF(left, 34, width, 16);
			e.Graphics.DrawString(_url, Font, SystemBrushes.WindowText, rect, stringFormat);

			// Finally, draw the icon.
			e.Graphics.DrawIcon(Properties.Resources.GlobeIconBig, 0, 3);
		}

		/// <summary>
		/// Fades-in the form.
		/// </summary>
		private void ShowForm()
		{
			// Set location every time in case they change resolution.
			Screen desktop = Screen.PrimaryScreen;
			Location = new Point(desktop.WorkingArea.Width - Width - 10, desktop.WorkingArea.Height - Height - 10);
			
			Visible = true;
			FadeUpTo(80);
			timer.Start();
		}

		/// <summary>
		/// Checks the clipboard for a URL.
		/// </summary>
        private void CheckClipboard()
        {
            IDataObject dataObject;

            try
            {
                dataObject = Clipboard.GetDataObject();
            }
            catch
            {
				// Please don't try this at home.
                return;
            }

            if (dataObject != null)
            {
                if (dataObject.GetDataPresent(DataFormats.Text))
                {
                    string data = dataObject.GetData(DataFormats.Text) as string;

                    if (data != null)
                    {
                        data = data.Trim();

                        if (data.StartsWith("http"))
                        {
							// Replace carriage returns, linefeeds, the common "quote" character (>)
							// and spaces.
                            data = data.Replace("\r", "").Replace("\n", "");
                            data = data.Replace(">", "").Replace(" ", "");

							// If the data is different from the URL we captured last, 
							// 
							if (data != _url)
							{
								showLastUrlMenuItem.Enabled = true;  // The menu is disabled when the app starts.
								_url = data;
								_text = "Contacting web site...";
								Refresh();
								ShowForm();
								SetPageTitle();
							}
                        }
                    }
                }
            }
        }

		/// <summary>
		/// Gets the web page source and looks for the title. 
		/// </summary>
		private void SetPageTitle()
		{
			bool textIsTitle = false;

			try
			{
				WebRequest req = WebRequest.Create(_url);
				using (WebResponse resp = req.GetResponse())
				using (Stream stream = resp.GetResponseStream())
				using (StreamReader sr = new StreamReader(stream))
				{
					string html = sr.ReadToEnd().Replace("\r", "").Replace("\n", "");

					Regex re = new Regex("<title>(?<title>.*)</title>", RegexOptions.IgnoreCase);
					Match m = re.Match(html);

					if (m.Success)
					{
						_text = HttpUtility.HtmlDecode(m.Groups["title"].Value);
						textIsTitle = true;
					}
					else
					{
						_text = "(No page title)";
					}
				}
			}
			catch
			{
				_text = "(Could not retrieve title)";
			}
			

			Invalidate(true);
			AddUrlToMenu(textIsTitle);
		}

		/// <summary>
		/// Adds the URL to the Recent URLs menu.
		/// </summary>
		/// <param name="textIsTitle">Indicates that the _text field is the title of the web page.</param>
		private void AddUrlToMenu(bool textIsTitle)
		{
			// The Recent URLs menu item is disabled at launch.
			recentUrlsMenuItem.Enabled = true;

			// If the URL already exists in the menu, remove it. We'll be adding it
			// to the top of the list.
			foreach (UrlMenuItem menuItem in recentUrlsMenuItem.DropDownItems)
			{
				if (menuItem.UrlInfo.Url == _url)
				{
					recentUrlsMenuItem.DropDownItems.Remove(menuItem);
					break;
				}
			}

			UrlInfo urlInfo = textIsTitle ? new UrlInfo(_url, _text) : new UrlInfo(_url);
			UrlMenuItem newMenuItem = new UrlMenuItem(urlInfo);

			// Add new menu item to top of list.
			recentUrlsMenuItem.DropDownItems.Insert(0, newMenuItem);

			// Remove the extra URL if we've added one too many.
			if (recentUrlsMenuItem.DropDownItems.Count > c_recentUrlsMax)
			{
				recentUrlsMenuItem.DropDownItems.RemoveAt(c_recentUrlsMax);
			}
		}

		protected override void OnClick(EventArgs e)
		{
			FadeDownTo(0);
			Process.Start(_url);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Opacity = 0;
			// Sign up for clipboard change notifications from the operating system.
			_nextClipboardViewer = SetClipboardViewer(Handle);
			_loading = false;
		}

		protected override void OnClosed(EventArgs e)
		{
			// Remove ourselves from OS clipboard notifications
			ChangeClipboardChain(Handle, _nextClipboardViewer);
			SaveRecentUrls();

			base.OnClosed(e);
		}

		private void LoadRecentUrls()
		{
			String recentUrlsXml = Properties.Settings.Default.RecentUrls;
			
			if (!string.IsNullOrEmpty(recentUrlsXml))
			{
				XmlSerializer xs = new XmlSerializer(typeof(List<UrlInfo>));
				List<UrlInfo> urlInfos = (List<UrlInfo>)xs.Deserialize(new StringReader(recentUrlsXml));

				foreach (UrlInfo urlInfo in urlInfos)
				{
					recentUrlsMenuItem.DropDownItems.Add(new UrlMenuItem(urlInfo));
				}

				recentUrlsMenuItem.Enabled = true;
			}
		}

		private void SaveRecentUrls()
		{
			List<UrlInfo> urlInfos = new List<UrlInfo>();

			foreach (UrlMenuItem menuItem in recentUrlsMenuItem.DropDownItems)
			{
				urlInfos.Add(menuItem.UrlInfo);
			}

			XmlSerializer xs = new XmlSerializer(typeof(List<UrlInfo>));
			StringWriter sw = new StringWriter();
			xs.Serialize(sw, urlInfos);

			Properties.Settings.Default.RecentUrls = sw.ToString();
			Properties.Settings.Default.Save();
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			timer.Stop();
			FadeUpTo(100);
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (!Bounds.Contains(PointToScreen(Cursor.Position)))
			{
				FadeDownTo(80);
				timer.Start();
			}

			base.OnMouseLeave(e);
		}

		private void FadeUpTo(int max)
		{
			for (int i = Int32Opacity; i <= max; i += 5)
			{
				SetOpacityAndWait(i);
			}
		}

		private void FadeDownTo(int min)
		{
			for (int i = Int32Opacity; i >= min; i -= 5)
			{
				SetOpacityAndWait(i);
			}
		}

		private void SetOpacityAndWait(int opacity)
		{
			Opacity = opacity / 100d;
			Refresh();						
			Thread.Sleep(20);
		}

		private int Int32Opacity
		{
			get { return (int)(Opacity * 100); }
		}

		/// <summary>
		/// Handles the clipboard calls from the operating system and forwards them
		/// to our methods when appropriate.
		/// </summary>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0308: // WM_DRAWCLIPBOARD
                    if (!_loading)
                    {
                        CheckClipboard();
                    }
                    SendMessage(_nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    break;

                case 0x030D: // WM_CHANGECBCHAIN
                    if (m.WParam == _nextClipboardViewer)
                    {
                        _nextClipboardViewer = m.LParam;
                    }
                    else
                    {
                        SendMessage(_nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                    }
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}