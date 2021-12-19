
namespace LocalizedControls {

    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using System.Threading;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;


    internal class ResourceFactory {
	static ResourceManager _rm;

	public static ResourceManager RManager {
	    get {
		if(_rm == null) {
		    _rm = new ResourceManager( "LocalizedStrings",
					       Assembly.GetExecutingAssembly(),
					       null,
					       true );
		}
		return _rm;
	    }
	}
    }
    


    public class LocalizedButton : Button {
	override protected void Render (HtmlTextWriter writer) {
	    Text = ResourceFactory.RManager.GetString(Text);
	    base.Render(writer);
	}
    }
    
}

