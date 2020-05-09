using System;
using System.Collections;

namespace XSLQueryBuilderApp
{
	public abstract class TreeNodeModel
	{
		protected ArrayList _childNodes;
		protected bool _initialExposeOccured;

		public TreeNodeModel() 
		{
			_childNodes = new ArrayList();
			_initialExposeOccured = false;
		}

		public abstract string label 
		{
			get;
		}

		public ArrayList childNodes 
		{
			get 
			{
				return _childNodes;
			}
		}

		public bool initialExposeOccured 
		{
			get 
			{
				return _initialExposeOccured;
			}
		}

		public abstract bool mayBeSelected 
		{
			get;
		}

		public virtual void onInitialExpose(){_initialExposeOccured = true;}
		public abstract IField generateSelection();
	}
}
