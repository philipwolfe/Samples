<%@ Page Language="C#" %>
<%@ Register TagPrefix="AWS" Namespace="AWS" Assembly="FilePickerControl" %>

<html>
<head>
</head>
<body>
	<img src="fplogo.gif">
	<h2><font face="arial">AWS HTML Picker 1.5 Demo<font></h2> 
	<p>
		<font face="arial" size=2>
			Click the Browse button (yellow folder) and select any file within your IIS www root directory and its subdirectories. You can also upload and delete files, create and delete folders if you have write permissions.
		<font>
	<p>
		<font face="arial" size=2>
		<I>Note:</I> Make sure you have cookies turned on - the component require them in order to work properly.
		</font>
	</p>

	<p>
    <form runat="server">
		<font face="arial" size=2>
			<B>File Name:</B> <AWS:FilePicker id="FilePicker1" runat="server" fpAllowDelete="True" fpAllowCreateDirs="True" fpAllowUpload="True" fpUseAppRelPath=True/>
		<font>
    </form>
	<P>
		<font face="arial" size=2>
			Visit <a href="http://www.awsystems.biz">AWS Web Site</a> for more cool components for your web applications!
		<font>
	</P>

</body>
</html>
