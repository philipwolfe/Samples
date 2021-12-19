//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.

//THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.

namespace Scribble
{
using System;
using System.IO ;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


/// <summary>
///    Summary description for Form2.
/// </summary>
public class ScribbleView : System.Windows.Forms.Form
{
    /// <summary> 
    ///    Required designer variable
    /// </summary>
    private System.ComponentModel.Container components;
	private ScribbleDoc myDoc;
	private MainWindow mainWin;

	public Point previousPoint;	// the last mouse pt in the stroke in progress
	public Stroke currentStroke;// the stroke in progress

    public ScribbleView(ScribbleDoc doc,MainWindow parent)
    {
		//
        // Required for Win Form Designer support
        //
        InitializeComponent();
		this.myDoc  = doc;
		this.MdiParent = parent; //Make this view Mdi child of the main window
		mainWin = parent;	
		this.Text = "ScribbleDoc"+ doc.docID.ToString() + ":" + doc.viewList.Count.ToString();
	
    }

    /// <summary>
    ///    Clean up any resources being used
    /// </summary>
    public override void Dispose()
    {		
		if (components != null) 
		{
			components.Dispose();
		}
        base.Dispose();        
    }

    /// <summary>
    ///    Required method for Designer support - do not modify
    ///    the contents of this method with the code editor
    /// </summary>
    private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.Text = "ScribbleDoc";
		this.BackColor  = Color.White;
		this.MouseDown += new MouseEventHandler(MouseDownHandler);
		this.MouseMove  += new MouseEventHandler(MouseMoveHandler);
		this.MouseUp  += new MouseEventHandler(MouseUpHandler);
		this.Paint += new PaintEventHandler (PaintHandler);
		this.Closing  += new CancelEventHandler (ClosingHandler);
		this.Closed  += new EventHandler (ClosedHandler);

		//@design this.TrayLargeIcon = true;
		//@design this.TrayHeight = 0;
			
	}

	private void MouseDownHandler(Object sender,MouseEventArgs e)
	{
		if(!this.Capture)
			return;

		try{
			Point p = new Point(e.X,e.Y);
			currentStroke = myDoc.NewStroke();
			currentStroke.pointArray.Add(p);// Add first point to the new stroke			
			previousPoint = p;
			
			this.Capture = true; // Capture the mouse until button up						
		}
		catch(Exception ex) {
			MessageBox.Show(ex.ToString());
		}

	}


	private void MouseMoveHandler(Object sender,MouseEventArgs e)
	{
		if(!this.Capture)
			return;

		try{			
			Point p = new Point(e.X , e.Y);			
			currentStroke.pointArray.Add(p);
			Graphics g = this.CreateGraphics();
			g.DrawLine(myDoc.GetCurrentPen(),previousPoint,p);

			previousPoint = p;							
		}
		catch (Exception ex) { 
			MessageBox.Show(ex.ToString());			
        }

	}


	private void MouseUpHandler(Object sender,MouseEventArgs e)
	{	
		//If the current stroke is null, ignore this event
		if(currentStroke==null)
			return;

		try{
			Point p= new Point(e.X,e.Y);
			currentStroke.pointArray.Add(p);
			Graphics g = this.CreateGraphics();
			g.DrawLine(myDoc.GetCurrentPen(),previousPoint,p);
					
			previousPoint=p;	
			// Tell the stroke item that we're done adding points to it.
			// This is so it can finish computing its bounding rectangle.
			currentStroke.FinishStroke();			
			
			// Now that a stoke is added, inform all the views of the document about this
			myDoc.UpdateAllViews(this,currentStroke);       
		
			this.Capture = false;
		
		}
		catch (Exception ex) { 
			MessageBox.Show(ex.ToString());			
        }

	}

	private void PaintHandler(Object sender, PaintEventArgs e)
	{
		Rectangle rectClip = e.ClipRectangle;;
		rectClip.Inflate(1,1);
		Rectangle rectStroke;
				      
		for(int i=0; i < myDoc.strokeList.Count; i++)
		{
			Stroke st = (Stroke)myDoc.strokeList[i];
			rectStroke = st.GetBoundingRectangle();
			rectStroke.Inflate(1, 1); // avoid rounding to nothing
			if (!rectStroke.IntersectsWith(rectClip))
				continue;
			st.DrawStroke(e.Graphics) ;						
		}		
	}

	public void ClosingHandler(Object sender, CancelEventArgs e)
	{
		if(myDoc.isDirty && myDoc.viewList.Count == 1)
		{
			DialogResult save = MessageBox.Show("Do you want to Save changes ?","Scribble",MessageBoxButtons.YesNoCancel);
			if(save == DialogResult.Yes)
			{
				SaveFileDialog saveDlg = new SaveFileDialog();
				saveDlg.Filter = "Scribble Files (*.scb)|*.scb|All Files (*.*)|*.*";
				saveDlg.DefaultExt = ".scb";
				//saveDlg.FileName = "Scribb1.scb";
				DialogResult res = saveDlg.ShowDialog ();
				
				if(res == DialogResult.OK)
				{
					myDoc.SaveDocument(saveDlg.FileName);	
					myDoc.viewList.Remove(this);
					this.MdiParent=null;// remove this view(child) from the parent list
				}
				else if(res == DialogResult.Cancel)
					e.Cancel = true;
					
			}
				
			else if(save == DialogResult.Cancel)
					e.Cancel = true; //If user selected 'Cancel',don't close the form
			
			else if(save == DialogResult.No)
			{
				myDoc.viewList.Remove(this);
				this.MdiParent=null;				
			}
				
		}
		else
		{
			myDoc.viewList.Remove(this);	
			this.MdiParent=null;
		}		
	}

	public void ClosedHandler(Object sender,EventArgs e)
	{		
		//If there are no child views, then disable menu and toolbar items
		if(mainWin.MdiChildren.Length   == 0 )
			mainWin.DisableItems();					
	}
	
	public ScribbleDoc GetDocument()
	{
		return myDoc;
	}	

}
}
