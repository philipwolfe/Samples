#include "Scribble.h"
#include "ScribbleView.h"
#include "ScribbleDoc.h"


//Stroke 
	Stroke:: Stroke(int nPenWidth)
	{
		penWidth = nPenWidth;
		pointArray = new ArrayList();
	}
	Stroke::~Stroke()
	{
	}

	void Stroke::DrawStroke(Graphics* g)
	{		
		Pen* myPen = new Pen(Color::Black, (float)penWidth);
		for(int i=1; i < pointArray->Count; i++)
		{			
			__box Point* p1 = dynamic_cast<__box Point*> (pointArray->Item[i-1]);
			__box Point* p2 = dynamic_cast<__box Point*> (pointArray->Item[i]);

			g->DrawLine(myPen,*p1,*p2);
		}
		myPen->Dispose();
	}

	void Stroke::FinishStroke()
	{
		if(pointArray->Count == 0)
		{
			boundingRect.Size = Size::Empty;
			return;
		}

		__box Point* pt = dynamic_cast<__box Point*> (pointArray->Item[0]);
		boundingRect =  Rectangle (pt->X,pt->Y,0,0);

		for(int i=1; i < pointArray->Count; i++)
		{
			pt = dynamic_cast<__box Point*> (pointArray->Item[i]);
			boundingRect = Rectangle::FromLTRB(Min(boundingRect.Left, pt->X),Min(boundingRect.Top, pt->Y),Max(boundingRect.Right, pt->X) ,Max(boundingRect.Bottom, pt->Y));
		}
		boundingRect.Inflate(Size((int)penWidth,(int)penWidth));
		return;			
	}
		

	//ScribbleDoc

	ScribbleDoc:: ScribbleDoc(MainWindow* mainWin)
    {
        //
        // TODO: Add Constructor Logic here
        //				
			isDirty= false;
			thickPen=false;
			thinWidth=2;
			thickWidth=5;
			strokeList = new ArrayList() ;
			viewList = new ArrayList();
			ReplacePen();

			//Set the ID to be the current count + 1. This is so that the ID starts with 1
			docID = MainWindow::documentCount+1;
			//Create a view (Form) for this document
			ScribbleView* view = new ScribbleView(this,mainWin);
			viewList->Add(view);
			view->Show();
						
    }

	ScribbleDoc::~ScribbleDoc()
	{
	}

	Stroke* ScribbleDoc:: NewStroke()
	{
		Stroke*  s = new Stroke(penWidth);
		strokeList->Add(s);
		isDirty = true; //Now that the doc is modified, set the dirty flag
		return s;
	}

	void ScribbleDoc:: ReplacePen()
	{
		penWidth = thickPen ? thickWidth : thinWidth;
		currentPen = new Pen(Color::Black , (float)penWidth);
	}

	void ScribbleDoc::SaveDocument(String* fileName)
	{
		try 
		{			
			Stream* s = File::Open(fileName,FileMode::Create);
			BinaryFormatter* b = new BinaryFormatter();
			b->Serialize(s,strokeList);
			s->Close();				
			//Now that the doc is saved, its no more dirty
			isDirty = false;
		}
	
		catch(Exception* ex)
		{
			MessageBox::Show(ex->ToString());
		}
	}

	void ScribbleDoc::OpenDocument(String* fileName)
	{
		try 
		{
			Stream* s =  File::Open(fileName,FileMode::Open);
			BinaryFormatter* b = new BinaryFormatter();
			strokeList = dynamic_cast<ArrayList*>(b->Deserialize(s));
			s->Close();						
		}	
		catch(Exception* ex)
		{
			MessageBox::Show(ex->ToString());
		}
	}

	Pen* ScribbleDoc::GetCurrentPen()
	{
		return currentPen;
	}
	

	//Updates all the views of the document with the new data
	void ScribbleDoc::UpdateAllViews(ScribbleView* sender,Stroke* newStroke)
	{		
		ScribbleView* view;
		
		for(int i=0; i < viewList->Count ; i++)
		{
			view = dynamic_cast<ScribbleView*> (viewList->Item[i]);	

			if(view->Equals(sender))
				continue;

			//If this is for a new stroke
			if(newStroke)
			{
				view->Invalidate(newStroke->GetBoundingRectangle());							   
			}
			else
			{
				//must be ClearAll,hence invalidate the entire region
				view->Invalidate();
			}
			view->Update();
		}			
	}

	// Deletes the contents of the document
	void ScribbleDoc::DeleteContents()
	{		
		strokeList->Clear();
		UpdateAllViews(0,0);				
	}
