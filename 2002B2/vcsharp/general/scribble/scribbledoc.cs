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
using System.Collections;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary ;
using System.Windows.Forms ;

// class Stroke
// A stroke is a series of connected points in the scribble drawing.
// A scribble document may have multiple strokes.

// Mark this class with Serializable attribute because this needs to be serialized to disk
[Serializable] public class Stroke  {
		public float		penWidth; // one pen width applies to entire stroke
		public ArrayList 	pointArray = new ArrayList(); // series of connected points
		public Rectangle	boundingRect; //smallest rect that surrounds all
											// of the points in the stroke
		
		public Stroke(float nPenWidth) 
		{
			penWidth = nPenWidth;			
		}

		public Rectangle GetBoundingRectangle() {
			return boundingRect;
		}
		public void FinishStroke()
		{
			// Calculate the bounding rectangle.  It's needed for smart
			// repainting.
			if (pointArray.Count==0)
			{
				boundingRect.Size = Size.Empty;
				return;
			}
			Point pt = (Point) pointArray[0];
			boundingRect = new Rectangle(pt.X , pt.Y, 0, 0);

			for (int i=1; i < pointArray.Count; i++)
			{
				// If the point lies outside of the accumulated bounding
				// rectangle, then inflate the bounding rect to include it.
				pt = (Point)pointArray[i];			
				boundingRect = Rectangle.FromLTRB(Min(boundingRect.Left, pt.X),Min(boundingRect.Top, pt.Y),Max(boundingRect.Right, pt.X) ,Max(boundingRect.Bottom, pt.Y));
			}

			// Add the pen width to the bounding rectangle.  This is necessary
			// to account for the width of the stroke when invalidating
			// the screen.
			boundingRect.Inflate(new Size((int)penWidth, (int)penWidth));
			return;

		}

		public void DrawStroke(Graphics g)
		{
			try{
				Pen myPen = new Pen(Color.Black , penWidth);
				for(int i=1; i < pointArray.Count; i++)
				{
					g.DrawLine(myPen,(Point)pointArray[i-1],(Point)pointArray[i]);
				}	
				myPen.Dispose();			
			}
			catch (Exception ex){
				MessageBox.Show(ex.ToString());
			}
		}
	
		public int Min(int x,int y)
		{
			return (x < y) ? x : y;
		}

		public int Max(int x,int y)
		{
			return  (x > y) ? x : y;
		}
}
		

/// <summary>
///    Summary description for Doc.
/// </summary>
public class ScribbleDoc
{
	// The document keeps track of the current pen width on
	// behalf of all views. We'd like the user interface of
	// Scribble to be such that if the user chooses the Draw
	// Thick Line command, it will apply to all views, not just
	// the view that currently has the focus.

	public bool thickPen;	// TRUE if current pen is thick
	protected uint penWidth;// current user-selected pen width
	public uint thinWidth;
	public uint thickWidth;

	public int docID; // ID to display it on the view

	protected Pen  currentPen;// pen created according to user-selected pen style (width)
    
	public ArrayList strokeList = new ArrayList() ;
	public ArrayList viewList = new ArrayList();
	public bool isDirty;

	
    public ScribbleDoc(MainWindow mainWin)
    {
		isDirty= false;
		
		thickPen=false;
		thinWidth=2;
		thickWidth=5;
		ReplacePen();
		

		//Set the ID to be the current count + 1. This is so that the ID starts with 1
		docID = MainWindow.documentCount+1;
		//Create a view (Form) for this document
		ScribbleView view = new ScribbleView(this,mainWin);
		viewList.Add(view);		
		view.Show();				
    }

	public Stroke NewStroke()
	{
		Stroke  s = new Stroke(penWidth);
		strokeList.Add(s);
		isDirty = true; //Now that the doc is modified, set the dirty flag
		return s;
	}

	public void ReplacePen()
	{
		penWidth = thickPen ? thickWidth : thinWidth;
		currentPen = new Pen(Color.Black , penWidth);
	}

	//Save the document
	public void SaveDocument(string fileName)
	{
		try 
		{
			Stream s = File.Open(fileName,FileMode.Create);
			BinaryFormatter b = new BinaryFormatter();
			b.Serialize(s,strokeList);
			s.Close();			
			//Now that the doc is saved, its no more dirty
			isDirty = false;
		}
	
		catch(Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}

	//Open the document
	public void OpenDocument(string fileName)
	{
		try 
		{
			Stream s = File.Open(fileName,FileMode.Open);
			BinaryFormatter b = new BinaryFormatter();
			strokeList = (ArrayList)b.Deserialize(s);
			s.Close();						
		}	
		catch(Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}	

	public Pen GetCurrentPen()
	{
		return currentPen;
	}

	//Updates all the views of the document with the new data
	public void UpdateAllViews(ScribbleView sender,Stroke newStroke)
	{		
		ScribbleView view;
		
		for(int i=0; i < viewList.Count ; i++)
		{
			view = (ScribbleView)viewList[i];	

			if(view.Equals(sender))
				continue;

			//If this is for a new stroke
			if(newStroke != null)
			{
				view.Invalidate(newStroke.GetBoundingRectangle());							   
			}
			else
			{
				//must be ClearAll,hence invalidate the entire region
				view.Invalidate();
			}
			view.Update();
		}			
	}

	// Deletes the contents of the document
	public void DeleteContents()
	{
		strokeList.Clear();
		UpdateAllViews(null,null);				
	}

}
}
