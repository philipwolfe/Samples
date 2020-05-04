
 Simple beta project to view traffic cameras from web sites.
 
Right now 3 states can be selected, Washington, California,and Oregon.
Washington has nearly all the camera links I could find. I have not
finished Oregon yet.  California is only a placeholder at this time.

All needed data is stored in embedded files.  The performance of IO.Stream
and filestream is quite good, so no arrays were needed for the text info.

I was unable to find a good custom control to scroll multiple labels uniformly,
so I use two labels above and below the state route number labels, and then
I scroll all the SR Labels uniformly with the changed value from a scroll bar.
They go behind the two cover labels.

Its a crude method, but it does the job.


When setting the camera image using the Image.FromStream method, an
occaisonal argument exception is thrown.  Per MSDN documentation, when 
using the Image.FromStream method, ArgumentExceptions are thrown 
when the stream does not have a valid image format.

  I believe that this argument exception occurs when the Image.FromStream
method fires while a new traffic image is being uploaded to the 
URL from the web server.

  I put together a list of fixed images from the internet that don't change.
They are located in California's files, under DescNWTest.txt, and NWTest.txt. 
I loaded them and when repeatedly scrolled thru up and down in the Camera
listbox, and I did not get any argument exception.
  
  

To do/Items to fix:
    Add more camera links, and maybe more states.
    Make a custom label control, that allows scrolling multiple labels,
    to replace the crude method that is currently used.



Inquiries and Comments welcome: Hamfiles@yahoo.com
