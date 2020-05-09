using System;
using System.Collections;

namespace XSLQueryBuilderApp
{
	public class FieldProfileTemplateAdvisor
	{

		private class ProfileTemplateQuery : IFieldVisitor
		{
			public string result;

			public void visit(UnTypedField field) 
			{
				result = "ItemsClause";
			}

			public void visit(StringField field) 
			{
				result = "ItemsClauseString";
			}

			public void visit(DateField field) 
			{
				result = "DateClause";
			}

			public void visit(NumberField field) 
			{
				if(field.ordinal)
					result = "OrdinalClause";
				else
					result = "ItemsClause";
			}
		}

		private class BVQParamTemplateQuery : IFieldVisitor 
		{
			public string result;

			public void visit(UnTypedField field) 
			{
				result = "BVQParamItemsClause";
			}

			public void visit(StringField field) 
			{
				result = "BVQParamItemsClauseString";
			}

			public void visit(DateField field) 
			{
				result = "BVQParamItemsClauseString";
			}

			public void visit(NumberField field) 
			{
				result = "BVQParamItemsClause";
			}
		
		}

		private ProfileTemplateQuery profileTemplateQuery;
		private BVQParamTemplateQuery paramTemplateQuery;

		public FieldProfileTemplateAdvisor()
		{
			profileTemplateQuery = new ProfileTemplateQuery();
			paramTemplateQuery = new BVQParamTemplateQuery();
		}

		private string getTypeTemplate(IField field) 
		{
			field.accept(profileTemplateQuery);
			return profileTemplateQuery.result;
		}

		public void writeProfileTemplate(IField field,XSLTextWriter output,bool bind) 
		{
			output.WriteCallNameTemplate(
				(bind ? "BVQ":"simple") +
				getTypeTemplate(field)
			);
		}


		public void collectProfileTypeTemplates(Hashtable collection,IProfileableTrack profilableTrack) 
		{
			string typeTemplate;
			string paramTemplate;

			if(profilableTrack.bindProfile) 
			{
				foreach(IField field in profilableTrack.profileFields) 
				{
					
					typeTemplate = "BVQ" + getTypeTemplate(field);	
					if(!collection.ContainsKey(typeTemplate))
						collection.Add(typeTemplate,typeTemplate);
					paramTemplate = getBVQParamTemplate(field);
					if(!collection.ContainsKey(paramTemplate))
						collection.Add(paramTemplate,paramTemplate);
				}
			} 
			else 
			{
				foreach(IField field in profilableTrack.profileFields) 
				{
					
					typeTemplate = "simple" + getTypeTemplate(field);	
					if(!collection.ContainsKey(typeTemplate))
						collection.Add(typeTemplate,typeTemplate);

				}
			}
		}

		public string getBVQParamTemplate(IField field) 
		{
			field.accept(paramTemplateQuery);
			return paramTemplateQuery.result;
		}
	}
}
