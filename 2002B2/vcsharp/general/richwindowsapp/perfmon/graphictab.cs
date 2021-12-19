using System;

namespace PerfMon
{
	/// <summary>
	/// Summary description for GraphicTab.
	/// Used to hold the DisplayPanels of a category
	/// For each monitored category, a new GraphicTab will be inserted into the TabControl
	/// </summary>
	public class GraphicTab : System.Windows.Forms.TabPage
	
	//The GraphicTab is a TabPage component
	{
		//Those will propagate to all Displays on the graphicTab

		//Drawing line tickness
		public int LineTickness=0;
		//Number of display rows
		public int Rows=0;
		//Number of displays columns
		public int Columns = 0;
		//Time interval to redraw graphics
		public int Frequency =0;
		//No of draw points/display
		public int Density =0;
		//The displays will show the graphics on timer
		public System.Timers.Timer Ticker=new System.Timers.Timer();
		//GraphicTab key. This should be unique (CategoryName)
		public string Key=null;
		//Keep a pointer to the DisplayPanel designated as host for other Displays
		public DisplayPanel Host = null;
		//Explicit constructor
		public GraphicTab(string TabText, int tmpLineTickness, int tmpRows, int tmpColumns, int tmpFrequency, int tmpDensity )
		{
			Text=TabText;
			AutoScroll=true;
			Key=TabText;
			Ticker.Enabled=false;
			//Set all displays properties
			SetDisplayProperties(tmpLineTickness,tmpRows,tmpColumns,tmpFrequency,tmpDensity);

			//Set the timer's event
			Ticker.Tick += new System.EventHandler(Ticker_Tick);
			Ticker.Enabled=true;
			
		}
		//Browse through all the displays and set their positon raltive to this
		public void ResizeDisplays()
		{
			foreach(DisplayPanel DP in Controls)
				DP.SetPosition();
		}

		//Call the Draw method on all displays
		protected void Ticker_Tick(object sender, System.EventArgs e)
		{
			foreach(DisplayPanel DP in Controls)DP.Draw();	
		}
		

		//Set the displays properties
		public void SetDisplayProperties(int  tmpLineTickness, int tmpRows, int tmpColumns, int tmpFrequency,int tmpDensity)
		{
			
			LineTickness=tmpLineTickness;
			Rows=tmpRows;
			Columns=tmpColumns;
			Frequency=tmpFrequency;
			Density=tmpDensity;
			Ticker.Interval=Frequency*1000;
			foreach(DisplayPanel DP in Controls)DP.SetPosition();
			
		}
		//Check whethet two displays are overlapping or not
		//If yes then on MouseUp event from the ActivePanel, the ActivePanel will merge with the ovelapped display
		//Consider two displays overlapping iif one overlaps the center of the other. This way you're sure no three displays can overlap
		public void CheckIntersect(DisplayPanel ActivePanel )
		{
			Host=null;
			System.Drawing.Point pCenter = new System.Drawing.Point(ActivePanel.Right-(ActivePanel.Width)/2, ActivePanel.Bottom-(ActivePanel.Height)/2);
			foreach(DisplayPanel DP in Controls )
			{
				//Get its center
				int x = DP.Right-(DP.Width /2);
				int y= DP.Bottom-(DP.Height)/2;
				System.Drawing.Point center = new System.Drawing.Point(x,y) ;
				//Check if they intersect
				if(System.Math.Abs (center.X-pCenter.X)<(ActivePanel.Width/2 ) && System.Math.Abs (center.Y-pCenter.Y)<(ActivePanel.Height/2 ) && !DP.Equals(ActivePanel))
				{
					DP.BackColor=System.Drawing.Color.Black;
					Host = DP;
					break;
				}
				else
				{
					//haven't found a host
					DP.BackColor=System.Drawing.Color.White;
					Host=null;
				}
			}
		}
		
		//Merge two displays
		public void MergeDisplays(DisplayPanel Guest)
		{
			if(Host!=null)
			{
				string tmpKey=null;
				Controls.Remove(Guest);
				Host.GuestDisplays.Add(Guest.Key,Guest);
				//If the Guest had guests... then poure all of them in the Host display 
				foreach(DisplayPanel dp in Guest.GuestDisplays.Values )
				{
					tmpKey = dp.PC.CategoryName + dp.PC.CounterName + dp.PC.InstanceName;
					Host.GuestDisplays.Add(tmpKey,dp);
					dp.ShowData=false;//Only the Guest will show its data
				}
				Guest.GuestDisplays.Clear();
				Guest.Visible=false;
				ResizeDisplays();
				Host.BackColor=System.Drawing.Color.White;
				Host.ShowData=false; 
				//Let the newlly added guest to show its data
				Guest.ShowData=true;
			}
		}

		//Elliminate a display from the GraphicTab
		//If this is the last display the the GraphicTab itself will be removed
		//If the display contains some guests then the display stays but will be replaced by the first guest
		public void RemoveDisplay(string DPKey )
		{
			foreach(DisplayPanel dp in Controls )
			{
			
				if (dp !=null)
				{
					if(dp.Key.Equals(DPKey))
					{
						if (dp.GuestDisplays.Count>0)
						{
								
							dp.ReplaceMe((DisplayPanel)dp.GuestDisplays.GetByIndex(0));
							foreach(DisplayPanel tmpDP in dp.GuestDisplays.Values)
								tmpDP.ShowData=false;

							dp.ShowData=true;
							break;
						}
						else
						{
							Controls.Remove(dp);
							foreach(DisplayPanel DP in Controls ) DP.SetPosition();
						}
					}
					else 
					{
						dp.GuestDisplays.Remove(DPKey);
						foreach(DisplayPanel tmpDP in dp.GuestDisplays.Values)tmpDP.ShowData=false;
						dp.ShowData=true;
						
					}
				}
			}
		}
	}
}
