using System;
using System.Web;
using System.Web.UI;

namespace SimpleControlSamples {

    public enum MessageSize {

        Small = 0,
        Medium = 1,
        Large = 2
    }

    public class SimpleProperty : Control {

       private String      _message;
       private MessageSize _messageSize;
       private int         _iterations = 1;

       public String Message {
           get {
              return _message;
           }
           set {
              _message = value;
           }
       }

       public MessageSize MessageSize {
           get {
              return _messageSize;
           }
           set {
              _messageSize = value;
           }
       }

       public int Iterations {
           get {
              return _iterations;
           }
           set {
              _iterations = value;
           }
       }

       protected override void Render(HtmlTextWriter output) {

           String htmlSize;

           if (_messageSize == MessageSize.Small)
              htmlSize="H5";
           else if (_messageSize == MessageSize.Medium) 
              htmlSize="H3";
           else
              htmlSize="H1";

           for (int i=0; i<_iterations; i++) {
              output.Write("<" + htmlSize + ">" + _message + "</" + htmlSize + ">");
           }
       }
    }    
}