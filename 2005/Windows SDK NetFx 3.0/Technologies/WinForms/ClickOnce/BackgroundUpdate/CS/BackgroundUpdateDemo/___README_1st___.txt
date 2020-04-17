
!!!! IMPORTANT !!!!

BackgroundUpdateDemo Sample

This sample demonstrates the use of the System.Deployment ClickOnce APIs
to show how an application can do its own deployment version checking as 
opposed to using the default functionality provided by the ClickOnce system.

When you publish ClickOnce applications using Visual Studio 2005, you tell 
the application to look for new versions by clicking "The application should 
check for updates" in the Updates dialog on the Project properties Publish tab.
ClickOnce will check for a new version, but will not download the new version
until the next time you run the application. 

This BackgroundUpdateDemo sample, turns OFF the default version checking, and 
does the check on its own via a call to UpdateAsync() and starts downloading 
the new version RIGHT AWAY if one is detected.

In order to see this work:

1. Publish the BackgroundUpdateDemo application using the 
     Project Properties... Publish tab in Visual Studio 2005. 
     Upon successfully publishing the app, Publish.htm will appear

2. Install the app locally by clicking 'launch' on Publish.htm. Leave it 
      running, and continue with Step 3.

3. Repeat Step 1, but do NOT install this new version.

4. Now, ALT-Tab back to the running app.
      Note the Currently Running Version number on the main form.

5. Click Updates / Start and wait 1 minute.
      The app will automatically download and install the new version
      from the deployment server and restart itself. Note the incremented
      version number.

Note:
If when publishing this application, Visual Studio reports an "Unable to find 
manifest signing certificate in the certificate store" error, perform the steps 
below.

Prior to publishing this application, You will need to sign the manifest. 
1. Open the Signing tab in Project properties
2. Check the 'Sign the ClickOnce manifests' CheckBox
3. Click the 'Create Test Certificate...' button
4. Enter a password when prompted.

At this point, the BackgroundUpdateDemo_TemporaryKey.pfk will have been 
created and added to the BackgroundUpdateDemo project. You can now 
publish the application.

For more information on certificates and signing manifests, refer to the 
Visual Studio 2005 documentation.

