namespace Asterisk.NET.FastAGI.Scripts
{
	class AGINoAction : BaseAGIScript
	{
		public AGINoAction()
			: base()
		{
		}
		public override void Service(AGIRequest request, AGIChannel channel)
		{
			base.SayNumber("893");
			base.Hangup();
		}
	}
}
