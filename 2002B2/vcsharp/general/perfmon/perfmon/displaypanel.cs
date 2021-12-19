using System;

namespace PerfMon
{
	/// <summary>
	/// Summary description for DisplayPanel.
	/// used for plotting the graphics for the selected PerformanceCounters.
	/// Initially, each selected PerformanceCounter will have its data drawn on a separate DisplayPanel.
	/// Any DisplayPanel can plot data for more than one PerformanceCounter.
	/// </summary>
	/// 
	
	public class DisplayPanel : System.Windows.Forms.Panel
	{
		//The DisplayPanel is a Panel control

		//The local PerformanceCounter
		public  System.Diagnostics.PerformanceCounter PC=null;
		//Parent GraphicTab
		private GraphicTab ParentTab=null;		
		//The number of points to be drawn
		private int NoOfPoints=0;
		//History of the last "NoOfPoints" PC values
		public double [] PCValues=null;
		//Last PCValue drawn. Need circular indexing
		public int LastDrawIndex=0;
		//The control labels / panels
		private System.Windows.Forms.Label NameLabel=null;
		private System.Windows.Forms.Label ValueLabel=null;
		private System.Windows.Forms.Panel ScalePanel=null;
		//Used for display movements
		private int mX=0;
		private int mY=0;
		//The initial position - used to bring the display back.
		private System.Drawing.Point Origin;
		//The maximum value of the PC ever encountered
		public double MaxVal=0;
		//The collection of displays held as guests of this. Their graphics will be drawn on the same display
		public System.Collections.SortedList GuestDisplays = null;
		//Used to produce new colors (for new Guests)
		private int Red,Green, Blue;
		//Only one of the displays will show its data. This is used in case there are Guests to this
		public bool ShowData;
		//The current working value
		private double NewPCValue;
		//Explicit constructor
		public DisplayPanel(System.Diagnostics.PerformanceCounter tmpPC, GraphicTab tmpParentPage )
		{

			PC=tmpPC;
			GuestDisplays=new System.Collections.SortedList(); //System.Collections.Hashtable();
			ParentTab= tmpParentPage;
			NoOfPoints= ParentTab.Density;
			PCValues=new double[NoOfPoints];
			AddControls();
			SetPosition();
			BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			//Add the mouse events
			MouseDown += new System.Windows.Forms.MouseEventHandler(Display_MouseDown);
			MouseUp += new System.Windows.Forms.MouseEventHandler(Display_MouseUp);
			MouseMove += new System.Windows.Forms.MouseEventHandler(Display_MouseMove);
			mX=mY=-1;
			ShowData=true;
		}

		//Get the initial origin point
		private void SetOrigin()
		{
			Origin = new System.Drawing.Point(Left,Top);
		}
		//Set the original position
		//Check the last display position and place itself next to that
		//Anchor property doesn't really work in this case since we have to keep equal propertions without overlapping displays
		public void SetPosition()
		{
			int LocationX=0;
			int LocationY=0;
			int MyPos=0;
			int RowNo=0;
			int ColNo=0;
			int PosOffset=3;
			ParentTab.AutoScroll=false;
			Size = new System.Drawing.Size( (int)ParentTab.Size.Width/ParentTab.Columns-10, (int)ParentTab.Size.Height/ParentTab.Rows -10);
			foreach ( DisplayPanel dp in ParentTab.Controls)
			{
				
				if(dp.Key.Equals(Key) )break;
				MyPos++;
			}
			//find out the row no. and col no. to use
			RowNo = (int)MyPos/ParentTab.Columns;
			ColNo = MyPos % ParentTab.Columns;
			//get the new location
			LocationX = ColNo * Width+PosOffset ;
			LocationY =  (Height + PosOffset)*RowNo;
			Location=new System.Drawing.Point(LocationX,LocationY );
			BackColor=System.Drawing.Color.White;
			Visible=true;
			SetControlsPosition();
			ParentTab.AutoScroll=true;
			RebuildArray();
			foreach(DisplayPanel DP in GuestDisplays.Values )DP.RebuildArray();
			SetOrigin();
		}
		
		//In case the density changes, the PCValues has to change as well
	
		public void RebuildArray()
		{
			if(NoOfPoints!=ParentTab.Density)
			{
				NoOfPoints=ParentTab.Density;
				PCValues = new double[NoOfPoints];
			}
			
		}
		//Set the controls Locations on the display
		public void SetControlsPosition()
		{
			int BorderWidth=15;
			NameLabel.BackColor=ValueLabel.BackColor=ScalePanel.BackColor=System.Drawing.Color.Black;
			NameLabel.ForeColor=ValueLabel.ForeColor=ScalePanel.ForeColor=System.Drawing.Color.White;
			NameLabel.Text = PC.CounterName + " **** " + PC.InstanceName;
			NameLabel.Size=new System.Drawing.Size(Width,BorderWidth);
			NameLabel.Location=new System.Drawing.Point(0,0);
			NameLabel.Visible=true;
			ValueLabel.Text="0";
			ValueLabel.Size=new System.Drawing.Size(Width,BorderWidth);
			ValueLabel.Location=new System.Drawing.Point(0,Height-BorderWidth);
			ValueLabel.Visible=true;
			ScalePanel.Text="0";
			ScalePanel.Size=new System.Drawing.Size(2 * BorderWidth ,Height);
			ScalePanel.Location=new System.Drawing.Point (Width-BorderWidth,0 );
			ScalePanel.Visible=true;
		}

		//Insert the display controls in the DisplayPanel
		private void AddControls()
		{
			
			NameLabel=new System.Windows.Forms.Label();
			ValueLabel = new System.Windows.Forms.Label();
			ScalePanel=new System.Windows.Forms.Panel();
			Controls.Add(NameLabel);
			Controls.Add(ValueLabel);
			Controls.Add(ScalePanel);
			SetControlsPosition();
		}
		

		//Draw the Graphics on this display
		//The guests graphics will also be drawn on the same display
		public void Draw()
		{
			
			int LoopIndex =0;
			int CurrentIndex=LastDrawIndex;
			int HeightOffset =(ValueLabel.Height*2)+10;
			int VisibleHeight = Height-HeightOffset;
			int VisibleWidth = ScalePanel.Left;
			int CorrectedIndex=0;
			double SegmentLength =0;
			
			System.Drawing.PointF[] points=null;
			System.Windows.Forms.TabControl TC=null;
			System.Drawing.Graphics Graphic =null;
			System.Drawing.Pen pen=null;
			
			NewPCValue	=	PC.NextValue();

			double [] CorrectedValues=new Double[NoOfPoints];

			LastDrawIndex =(LastDrawIndex+1)% NoOfPoints;
			points = new System.Drawing.PointF[NoOfPoints];

			PCValues[CurrentIndex]=NewPCValue;
			
			if (MaxVal<NewPCValue)MaxVal = NewPCValue;
			
			TC = (System.Windows.Forms.TabControl) ParentTab.Parent;

			//Draw only if is the active tab
			
			if( TC.SelectedIndex==ParentTab.TabIndex)
			{
				for(LoopIndex=0;LoopIndex<NoOfPoints;LoopIndex++)
				{
					CorrectedIndex=(LoopIndex+LastDrawIndex)%NoOfPoints;
					if (MaxVal>0)
						CorrectedValues[LoopIndex]= (PCValues[CorrectedIndex]/MaxVal)* VisibleHeight;
					else
						CorrectedValues[LoopIndex]=0;

				}
				
				SegmentLength =(double) VisibleWidth /NoOfPoints;
				for(LoopIndex=0;LoopIndex<NoOfPoints;LoopIndex++)
				{
					points[LoopIndex]=new System.Drawing.PointF((float)((LoopIndex+1)*SegmentLength) , (float)(VisibleHeight-(CorrectedValues[LoopIndex]-HeightOffset/2) ) );
				}
				
				//Draw the entire graphic
				Graphic= CreateGraphics(); 
				pen = new System.Drawing.Pen(System.Drawing.Color.Red,(float)ParentTab.LineTickness);
				Graphic.Clear(BackColor);
				Graphic.DrawLines(pen,points);
		
				//Draw the last value
				if (ShowData)
					DrawScale(this,CorrectedValues, HeightOffset,VisibleHeight,System.Drawing.Color.Red);	
			}

			//Get the Guests involved
			//Draw the graphic for each Guest Display
			Red=Green=Blue=0;
			foreach(DisplayPanel DP in GuestDisplays.Values )
			{
				
				
					CorrectedValues=DP.Values(VisibleHeight);
					if( TC.SelectedIndex==ParentTab.TabIndex) 
					{
						for(LoopIndex=0;LoopIndex<NoOfPoints;LoopIndex++)
						{
							points[LoopIndex]=new System.Drawing.PointF((float)((LoopIndex+1)*SegmentLength) , (float)(VisibleHeight-(CorrectedValues[LoopIndex]-HeightOffset/2) ) );
						}
						//Draw the entire graphic
						Graphic= CreateGraphics(); 
						System.Drawing.Color color = NextColor();
						pen = new System.Drawing.Pen(color,(float)ParentTab.LineTickness);
						Graphic.DrawLines(pen,points);
						if (DP.ShowData)
							DrawScale(DP,CorrectedValues, HeightOffset,VisibleHeight,color);
					}
			}	
		}

		public double NewValue
		{
			get
			{
				return this.NewPCValue;
			}
		}
		//Called from Draw
		//Used to show the last drawn value of the selected PerfCounter
		private void DrawScale(DisplayPanel DP,double[] CorrectedValues,int HeightOffset, int VisibleHeight, System.Drawing.Color color)
		{
			//Draw the last value on the scale
			System.Drawing.Graphics Graphic =null;
			System.Drawing.Pen pen=null;
			float x1 = 0.0f;
			float x2=0.0f;
			float y1=(float)ScalePanel.Height-(HeightOffset/2);
			float y2=(float)(VisibleHeight-(CorrectedValues[NoOfPoints-1]-HeightOffset/2) );

			NameLabel.Text=DP.PC.CounterName + " *** " + DP.PC.InstanceName;

			ValueLabel.Text=DP.NewValue.ToString();
			
			Graphic = ScalePanel.CreateGraphics();
			Graphic.Clear(System.Drawing.Color.Black);
			pen = new System.Drawing.Pen(color,ScalePanel.Width);
			if(y2>=y1)y2 = y1-ParentTab.LineTickness;
			Graphic.DrawLine(pen,x1,y1,x2,y2 );
		}

		//Returns the corrected (to the scale) accumulated  values
		//Used to draw the guest graphics 
		public double[] Values(int Scale)
		{
			int LoopIndex =0;
			int CurrentIndex=0;
			int CorrectedIndex=0;
			double [] CorrectedValues=null;

			this.NewPCValue=PC.NextValue();
			CurrentIndex=LastDrawIndex;
			LastDrawIndex =(LastDrawIndex+1)% NoOfPoints;
			PCValues[CurrentIndex]=NewPCValue;

			CorrectedValues=new Double[NoOfPoints];

			if(MaxVal<NewPCValue)MaxVal=NewPCValue;

			for(LoopIndex=0;LoopIndex<NoOfPoints;LoopIndex++)
			{
				CorrectedIndex=(LoopIndex+LastDrawIndex)%NoOfPoints;
				if (MaxVal>0)
					CorrectedValues[LoopIndex]= (PCValues[CorrectedIndex]/MaxVal)* Scale;
				else
					CorrectedValues[LoopIndex]=0;
			}
			return CorrectedValues;
		}

		//Two possible actions on MouseDown:
		// 1. Move the display to merge with other (left button)
		// 2. See the MenuItems list to switch displays (right button)

		private void Display_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			
			SendToBack();
			//Move the display
			if(e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				Cursor=System.Windows.Forms.Cursors.Hand;
				mX=e.X;
				mY=e.Y;
			}
			//Show the MenuItems
			else if(e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				string miText=null;
				System.Windows.Forms.MenuItem	mi;
				ContextMenu= new System.Windows.Forms.ContextMenu();
				miText=PC.CounterName + " *** " + PC.InstanceName;
				mi	=	new System.Windows.Forms.MenuItem(miText, new EventHandler(ChangeDisplay) );
				ContextMenu.MenuItems.Add(mi);
				//Read all the "guest" displays and add them in the menu list
				foreach(DisplayPanel DP in GuestDisplays.Values )
				{
					miText=DP.PC.CounterName + " *** " + DP.PC.InstanceName;
					mi	=	new System.Windows.Forms.MenuItem(miText, new EventHandler(ChangeDisplay) );
					ContextMenu.MenuItems.Add(mi);
				}
				//Pop up the menu list
				ContextMenu.Show(this,new  System.Drawing.Point(e.X,e.Y));
			}

			
			
		}

		//If the left mouse button is pushed the user wants to move the displays
		private void Display_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{	
				if (mX!=-1 || mY!=-1)
				{
					Left += e.X-mX;
					Top += e.Y-mY;
					ParentTab.CheckIntersect(this); ;
				}
				
				
			}
		}
		//If the mouse button was "left" then see if the user wants to merge to diplays
		private void Display_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button==System.Windows.Forms.MouseButtons.Left)
			{
				Cursor=System.Windows.Forms.Cursors.Default;
				Location=Origin;
				mX=mY=-1;
				if(ParentTab.Controls.Count>1) ParentTab.MergeDisplays(this);
			}
			
		}
		//Get the next unused color
		private System.Drawing.Color NextColor()
		{
			//Try to get as many different colors as possible
			if(Red==0 && Green==0 && Blue==0)Green=255;
			else if(Green==0) 
			{Red /=4;Green = 255;}
			else if (Blue<50)
			{Red /=2;Blue= 255;Green/=2;}
			else if (Blue >=200 && Blue <= 255)
			{Blue /=2;Red/=2;Green/=2;}
			else
			{
				Red += 119;
				Red = Red %255;
				Blue += 53;
				Blue = Blue%255;
				Green +=61;
				Green = Green % 255;
			}
			//Avoid very light colors
			if(Red>240 && Green>240 && Blue>240)
			{
				Red = (Red + 91)%255;
				Green = (Green + 53)%255;
				Blue = (Blue + 41)%255;
			}
			return System.Drawing.Color.FromArgb(Red,Green,Blue);
		}

		//Called by the mouse rightClick
		//Selects the one PerfCounter for which the data is shown
		protected void ChangeDisplay (object sender, EventArgs e)
		{
			System.Windows.Forms.MenuItem mi = (System.Windows.Forms.MenuItem)sender;
			
			string CounterName= mi.Text.Substring(0,mi.Text.IndexOf("*")-1).Trim();
			string InstanceName = mi.Text.Substring(mi.Text.LastIndexOf("*")+1).Trim();
			
			foreach(DisplayPanel DP in GuestDisplays.Values)DP.ShowData=false;
			ShowData=false;

			foreach(DisplayPanel DP in GuestDisplays.Values)
			{
				if (DP.PC.CounterName.Equals(CounterName))
				{
					if(DP.PC.InstanceName != null)
						if( DP.PC.InstanceName.Equals(InstanceName))
						{
							DP.ShowData=true;
							return;
						}
						else
						{
							DP.ShowData=true;
							return;
						}
				}
			}
			ShowData=true;
			

		}
		
		//Since the key is composite I prefere to use a property-get
		public string Key
		{
			get{return PC.CategoryName + PC.CounterName + PC.InstanceName;}
		}

		//Called from the Parent when a Display is replaced by one of the Guests
		//Used to "split" a Display from a group
		public void ReplaceMe(DisplayPanel ChildDP)
		{
			PCValues = ChildDP.PCValues;
			PC=ChildDP.PC;
			LastDrawIndex=ChildDP.LastDrawIndex;
			MaxVal=ChildDP.MaxVal;
			ParentTab.Controls.Remove(this);
			ParentTab.Controls.Add(this);
			GuestDisplays.Remove(ChildDP.Key);
			
		}
	}
}
