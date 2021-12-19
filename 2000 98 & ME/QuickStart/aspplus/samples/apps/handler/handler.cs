
using System.Web;

namespace Acme {

    public class SimpleHandler : IHttpHandler {
    
        public void ProcessRequest(HttpContext context) {
            context.Response.Write("Hello World!");
        }

        public bool IsReusable() {
            return true;
        } 
    }
}