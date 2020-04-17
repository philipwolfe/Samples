1. Prerequisites for using this sample
======================================

Microsoft SQL Server 2005 Express Edition or better
Microsoft Visual Studio 2005 Professional or Team Editions
.NET Framework 3.0 Runtime Components: http://www.microsoft.com/downloads/details.aspx?FamilyId=10CC340B-F857-4A14-83F5-25634C3BF043&displaylang=en
Visual Studio 2005 Extensions for Windows Workflow Foundation: http://www.microsoft.com/downloads/details.aspx?FamilyId=5D61409E-1FA3-48CF-8023-E8F38E709BA6&displaylang=en


2. Deploying the sample
=======================

Before running the solution you will need to set up the Tracking and Persistance objects which are being used by Windows Workflow Foundation. You will need to set up a new database to host the objects before you execute the scripts in step 2.

For our solution, it is suggested that you set up 1 database for tracking named WorkflowTracking, and 1 database for persistance named WorkflowPersistance

1. Browse to the Windows Workflow Foundation installation directory, and locate the SQL folder. By default this will be installed to C:\Windows\Microsoft.NET\Framework\v3.0\Windows Workflow Foundation\SQL\EN

2. Connect to your SQL Server instance and use your created database. Execute the scripts in the following order:

	- SqlPersistenceService_Schema.sql
	- SqlPersistenceService_Logic.sql
	- Tracking_Logic.sql
	- Tracking_Schema.sql

2. Update the connection strings in the app.config file for the ExpenseHost application. 

	- Search for the following configuration block:

	<WorkflowRuntimeConfig>
		<Services>
			<add type="System.Workflow.Runtime.Hosting.SqlWorkflowPersistenceService, System.Workflow.Runtime, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" ConnectionString="Initial Catalog=WorkflowPersistence;Data Source=.;Integrated Security=SSPI;"/>
			<add type="System.Workflow.Runtime.Tracking.SqlTrackingService, System.Workflow.Runtime, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" ConnectionString="Initial Catalog=WorkflowTracking;Data Source=.;Integrated Security=SSPI;" IsTransactional="false" UseDefaultProfile="true" TrackXomlDocument="True"/>
		</Services>
	</WorkflowRuntimeConfig>

	- Update the ConnectionString under the ConnectionString attribute of each Service node.
