using System;
using System.Collections;

namespace XSLQueryBuilderApp
{
	public class DeleteTrackWriter:TrackWriter
	{

		private DeleteTrack _track;
		private string mainTableShortName;
		private NonJoinProfileWriter profileWriter;

		public DeleteTrackWriter():this(null){}
		public DeleteTrackWriter(XSLTextWriter iOutput):base(iOutput)
		{
			profileWriter = new NonJoinProfileWriter();
		}

		public override ITrack track
		{
			get 
			{
				return _track;
			}

			set 
			{
				if(value is DeleteTrack)
					_track = (DeleteTrack)value;
				else
					_track = null;
			}
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
			encapsulationWriter.writeBVQHeader("");
			writeSimpleQuery();
			encapsulationWriter.writeBVQFooter();
		}

		private void writeSimpleQuery() 
		{
			generateMainTableShortName();
			writeDeleteFromSection();
			writeDeleteProfileSection();
		}

		private void generateMainTableShortName() 
		{
			ShortNamesGenerator generator = ShortNamesGenerator.getGenerator();

			generator.reset();
			mainTableShortName = generator.generateShortName(_track.mainTable);
		}

		private void writeDeleteFromSection() 
		{
			output.WriteTextElement("DELETE FROM " + _track.mainTable + " " + mainTableShortName + "\n");
		}

		private void writeDeleteProfileSection() 
		{
			profileWriter.mainTableLabel = mainTableShortName;
			profileWriter.profileableTrack = _track;
			profileWriter.output = output;
			profileWriter.writeProfile();
		}
	}
}
