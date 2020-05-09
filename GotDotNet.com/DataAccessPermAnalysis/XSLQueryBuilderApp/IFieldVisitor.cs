using System;

namespace XSLQueryBuilderApp
{
	public interface IFieldVisitor
	{
		void visit(UnTypedField field);
		void visit(StringField field);
		void visit(DateField field);
		void visit(NumberField field);
	}
}
