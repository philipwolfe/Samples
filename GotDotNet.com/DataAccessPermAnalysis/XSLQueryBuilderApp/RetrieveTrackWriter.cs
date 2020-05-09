using System;
using System.Xml;
using System.Text;
using System.Collections;

namespace XSLQueryBuilderApp
{
	public class RetrieveTrackWriter: TrackWriter 
	{
		private RetrieveTrack _track;
		private Table relationsTableRoot;
		private bool firstWriteFlag;
		private StringBuilder previousFieldsConditions;

		public RetrieveTrackWriter():this(null) {}
		public RetrieveTrackWriter(XSLTextWriter iOutput):base(iOutput)
		{
		}

		public override ITrack track
		{
			get 
			{
				return _track;
			}

			set 
			{
				if(value is RetrieveTrack)
					_track = (RetrieveTrack)value;
				else
					_track = null;
			}
		}

		protected override void writeInternalParams() 
		{
			writeIntersect();
			writeNoMerge();
			writeParamRetrieve();
		}

		private void writeIntersect() 
		{
			if(_track.intersect)
				output.WriteString("_intersect");
		}

		private void writeNoMerge() 
		{
			if(_track.noMerge)
				output.WriteString("_noMerge");
		}

		private void writeParamRetrieve() 
		{
			if(_track.paramRetrieve)
				output.WriteString("_paramRetrieve");
		}

		protected override void writeTrackBody() 
		{
			if(_track.bindProfile)
				writeBVQQuery();
			else
				writeSimpleQuery();
		}

		private void writeBVQQuery() 
		{
			BVQEncapsulationWriter encapsulationWriter = new BVQEncapsulationWriter();

			encapsulationWriter.output = output;
			encapsulationWriter.profileableTrack = _track;
			encapsulationWriter.writeBVQHeader("recordSet");
			writeSimpleQuery();
			encapsulationWriter.writeBVQFooter();
		}

		private void writeSimpleQuery() 
		{
			relationsTableRoot = generateTableRelationsTree();
			writeSelectSection();
			writeFromSection();
			if(isWhereRequired()) 
				writeWhereSection();
		}

		private Table generateTableRelationsTree() 
		{
			Table root;
			
			ShortNamesGenerator.getGenerator().reset();
			root = new Table(
				ShortNamesGenerator.getGenerator().generateShortName(_track.mainTable),
				_track.mainTable
				);

			foreach(IField aField in _track.dataFields)
				root.insertFieldToPath(aField);
			foreach(IField aField in _track.profileFields)
				root.insertFieldToPath(aField);

			return root;
		}

		private void writeSelectSection() 
		{
			RetrieveDataSectionWriter writer;

			output.WriteStartTextElement();
			output.WriteString("SELECT '<Item id=''' || ");
			writePK();
			output.WriteString(" || '''>' || \n");
			output.WriteEndTextElement();
			if(_track.dataFields.Count > 0) 
			{
				writer = new RetrieveDataSectionWriter(_track,relationsTableRoot,output);
				writer.writeSubSection();
			}
			output.WriteTextElement("'</Item>' as XMLData \n");
		}

		private void writePK() 
		{
			IEnumerator pkPartEnum = _track.mainTablePK.GetEnumerator();
			
			if(pkPartEnum.MoveNext()) 
			{
				output.WriteString(relationsTableRoot.label + "." + (string)pkPartEnum.Current);
				while(pkPartEnum.MoveNext()) 
				{
					output.WriteString(" || ';' || ");
					output.WriteString(relationsTableRoot.label + "." + (string)pkPartEnum.Current);
				}
			}
		}
	
		private void writeFromSection() 
		{
			output.WriteStartTextElement();
			output.WriteString("FROM ");
			output.WriteString(getTableLabeledDefinition(relationsTableRoot));
			output.WriteEndTextElement();
			foreach(Table childTable in relationsTableRoot.referencingTables.Values) 
				writeNestedTablesFrom(childTable);

		}

		private string getTableLabeledDefinition(Table table) 
		{
			return (table.name + " " + table.label);
		}

		private void writeNestedTablesFrom(Table tableToWrite) 
		{
			writeSubTreeFieldsIfClause(tableToWrite);
			output.WriteString(" , " + getTableLabeledDefinition(tableToWrite));
			foreach(Table childTable in tableToWrite.referencingTables.Values)
				writeNestedTablesFrom(childTable);
			output.WriteEndIfClause();
		}

		private void writeSubTreeFieldsIfClause(Table tableToWrite) 
		{
			output.WriteStartIfClause();
			writeSubTreeFields(tableToWrite);
			output.WriteEndAttribute();
		}

		private void writeSubTreeFields(Table subTreeRoot) 
		{
			firstWriteFlag = true;
			subTreeRoot.enumSubTree(new TableMethod(writeTableFields));
		}

		private void writeTableFields(Table tableToWrite) 
		{
			writeFields(tableToWrite.fields);
		}

		private void writeFields(ICollection fieldsCollection) 
		{
			if(firstWriteFlag)
				firstWriteFlag = !writeFieldsOrSeparated(fieldsCollection);
			else
				writeFieldsOrPrefaced(fieldsCollection);
		}

		private void writeFieldsOrPrefaced(ICollection fieldsCollection) 
		{
			foreach(IField field in fieldsCollection) 
				output.WriteString(" or " + getFieldPath(field));
		}

		private bool writeFieldsOrSeparated(ICollection fieldsCollection) 
		{
			IEnumerator enumerator = fieldsCollection.GetEnumerator();

			if(enumerator.MoveNext()) 
			{
				output.WriteString(getFieldPath((IField)enumerator.Current));
				while(enumerator.MoveNext()) 
					output.WriteString(" or " + getFieldPath((IField)enumerator.Current));
				return true;
			} 
			else
				return false;
		}

		private string getFieldPath(IField field) 
		{
			return
				"Request/" + 
				(_track.dataFields.Contains(field) ? "Data":"Profile") +
				"/" + field.label;
		}

		private bool isWhereRequired() 
		{
			return (
				_track.profileFields.Count > 0 
				|| 
				relationsTableRoot.referencingTables.Count > 0
				);
		}

		private void writeWhereSection() 
		{
			output.WriteStartIfClause();
			writeWhereCondition();
			output.WriteEndAttribute();
			output.WriteTextElement(" WHERE \n");
			writeWhereJoinSection();
			writeWhereProfileSection();
			output.WriteEndIfClause();
		}

		private void writeWhereCondition() 
		{
			firstWriteFlag = true;
			foreach(Table childTable in relationsTableRoot.referencingTables.Values) 
				childTable.enumSubTree(new TableMethod(writeTableFields));
			writeFields(_track.profileFields);
		}

		private void writeWhereJoinSection() 
		{
			initFieldsCollection();
			foreach(Table childTable in relationsTableRoot.referencingTables.Values) 
			{
				writeChildTableJoin(childTable);
				collectTableFieldsForPreviousAnd(childTable);
			}
		}

		private void initFieldsCollection()
		{
			previousFieldsConditions = new StringBuilder();
		}

		private void writeChildTableJoin(Table tableToWrite) 
		{
			writeSubTreeFieldsIfClause(tableToWrite);
			writeConditionedAndForPreviousFields();
			writeTableJoinClause(tableToWrite);
			foreach(Table grandChildTable in tableToWrite.referencingTables.Values)
				writeNestedTablesJoin(grandChildTable);
			output.WriteEndIfClause();
		}

		private void writeConditionedAndForPreviousFields() 
		{
			if(previousFieldsConditions.Length != 0) 
			{
				output.WriteStartIfClause();
				output.WriteString(previousFieldsConditions.ToString());
				output.WriteEndAttribute();
				output.WriteString(" AND ");
				output.WriteEndIfClause();
			}
		}

		private void writeNestedTablesJoin(Table tableToWrite) 
		{
			writeSubTreeFieldsIfClause(tableToWrite);
			writeTableJoinClause(tableToWrite);
			foreach(Table childTable in tableToWrite.referencingTables.Values)
				writeNestedTablesJoin(childTable);
			
			output.WriteEndIfClause();
		}

		private void writeTableJoinClause(Table tableToWrite) 
		{
			output.WriteString(
				tableToWrite.label + "." + tableToWrite.referenceToParent.fieldName +
				" = " + 
				tableToWrite.referenceToParent.parent.label + "." + 
				tableToWrite.referenceToParent.parentFieldName);
		}

		private void collectTableFieldsForPreviousAnd(Table tableToCollect) 
		{
			firstWriteFlag = (previousFieldsConditions.Length == 0);
			tableToCollect.enumSubTree(new TableMethod(appendTableFields));				
		}

		private void appendTableFields(Table tableToAppend) 
		{
			ICollection fieldsCollection = tableToAppend.fields;
			if(firstWriteFlag)
				firstWriteFlag = !appendTableFieldsOrSeparated(fieldsCollection);
			else
				appendTableFieldsOrPrefaced(fieldsCollection);
		}

		private void appendTableFieldsOrPrefaced(ICollection fieldsCollection) 
		{
			foreach(IField field in fieldsCollection) 
				previousFieldsConditions.Append(" or " + getFieldPath(field));

		}

		private bool appendTableFieldsOrSeparated(ICollection fieldsCollection) 
		{
			IEnumerator enumerator = fieldsCollection.GetEnumerator();

			if(enumerator.MoveNext()) 
			{
				previousFieldsConditions.Append(getFieldPath((IField)enumerator.Current));
				while(enumerator.MoveNext()) 
					previousFieldsConditions.Append(" or " + getFieldPath((IField)enumerator.Current));
				return true;
			} 
			else
				return false;
		}

		private void internalTableJoinClause(Table tableToWrite) 
		{
			output.WriteString(" AND ");
			writeTableJoinClause(tableToWrite);
		}

		private void writeWhereProfileSection() 
		{
			RetrieveProfileSectionWriter writer;

			if(_track.profileFields.Count > 0) 
			{
				output.WriteStartIfClause();
				output.WriteString("Request/Profile/*");
				output.WriteEndAttribute();
				writeConditionedAndForPreviousFields();
				writer = new RetrieveProfileSectionWriter(_track,relationsTableRoot,output);
				writer.writeSubSection();
				output.WriteEndIfClause();
			}
		}
	}
}
