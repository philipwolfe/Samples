-----------------------------------------------------------------------
--  This file is part of the NetFx3.com web site samples.
-- 
--  Copyright (C) Microsoft Corporation.  All rights reserved.
-- 
--  This source code is intended only as a supplement to Microsoft
--  Development Tools and/or on-line documentation.  See these other
--  materials for detailed information regarding Microsoft code samples.
-- 
--  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
--  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
--  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
--  PARTICULAR PURPOSE.
-----------------------------------------------------------------------

IF OBJECT_ID('[dbo].[GetTypeInstance]') IS NOT NULL
	DROP PROCEDURE [dbo].[GetTypeInstance]
IF OBJECT_ID('[dbo].[GetWorkflowTypeInstance]') IS NOT NULL
	DROP PROCEDURE [dbo].[GetWorkflowTypeInstance]
IF OBJECT_ID('[dbo].[GetTrackedEventsForWorkflowInstance]') IS NOT NULL
	DROP PROCEDURE [dbo].[GetTrackedEventsForWorkflowInstance]
IF OBJECT_ID('[dbo].[EnumerateTrackedWorkflowInstances]') IS NOT NULL
	DROP PROCEDURE [dbo].[EnumerateTrackedWorkflowInstances]
IF OBJECT_ID('[dbo].[GetAddActivityActionsForWorkflowInstance]') IS NOT NULL
	DROP PROCEDURE [dbo].[GetAddActivityActionsForWorkflowInstance]
IF OBJECT_ID('[dbo].[GetRemovedActivityActionsForWorkflowInstance]') IS NOT NULL
	DROP PROCEDURE [dbo].[GetRemovedActivityActionsForWorkflowInstance]
GO


CREATE PROCEDURE [dbo].[GetTypeInstance]		
    @identity	bigint
AS
 BEGIN
    SELECT
    type.TypeId,
    type.TypeFullName,
    type.AssemblyFullName

    FROM           
    Type type

    WHERE type.TypeId = @identity
 END
GO

CREATE PROCEDURE [dbo].[GetWorkflowTypeInstance]		
    @identity	bigint
AS
 BEGIN
    SELECT
    type.TypeId,
    type.TypeFullName,
    type.AssemblyFullName,
    workflow.WorkflowDefinition

    FROM           
    Type type
    INNER JOIN Workflow workflow on type.TypeId = workflow.WorkflowTypeId

    WHERE type.TypeId = @identity
 END
GO


CREATE PROCEDURE [dbo].[GetTrackedEventsForWorkflowInstance]
    @workflowInternalInstanceId	bigint
AS
 BEGIN
    SET NOCOUNT ON

    SELECT
    activityInstance.ActivityInstanceId,
    activityInstance.QualifiedName,
    activityInstance.ContextGuid,
    activityInstance.ParentContextGuid,
    activityStatus.ExecutionStatusId,
    activityStatus.EventDateTime

    FROM           
    ActivityInstance activityInstance 
    INNER JOIN ActivityExecutionStatusEvent activityStatus on activityStatus.ActivityInstanceId = activityInstance.ActivityInstanceId

    WHERE
    activityInstance.WorkflowInstanceInternalId = @workflowInternalInstanceId
	
    ORDER BY 
    activityStatus.EventDateTime
 END
GO

CREATE PROCEDURE [dbo].[EnumerateTrackedWorkflowInstances] 
AS
 BEGIN
    SET NOCOUNT ON

    SELECT
    instance.WorkflowInstanceInternalId,
    instance.WorkflowInstanceId,
    instance.WorkflowTypeId,
    type.TypeFullName,
    type.TypeFullName,
    instance.CallPath,
    instance.InitializedDateTime,
    instance.CallerInstanceId

    FROM           
    WorkflowInstance instance
    INNER JOIN Type type on instance.WorkflowTypeId = type.TypeId
 END
GO

CREATE PROCEDURE [dbo].[GetAddActivityActionsForWorkflowInstance]
    @workflowInternalInstanceId	bigint
AS
 BEGIN
    SET NOCOUNT ON

    SELECT
    addedActivity.WorkflowInstanceEventId,
    addedActivity.QualifiedName,
    addedActivity.ParentQualifiedName,
    addedActivity.AddedActivityAction,
    addedActivity.[Order]

    FROM           
    AddedActivity addedActivity 

    WHERE
    addedActivity.WorkflowInstanceInternalId = @workflowInternalInstanceId
	
    ORDER BY 
    addedActivity.WorkflowInstanceEventId,
    addedActivity.[Order]
 END
GO

CREATE PROCEDURE [dbo].[GetRemovedActivityActionsForWorkflowInstance]
    @workflowInternalInstanceId	bigint
AS
 BEGIN
    SET NOCOUNT ON

    SELECT
    removedActivity.WorkflowInstanceEventId,
    removedActivity.QualifiedName,
    removedActivity.ParentQualifiedName,
    removedActivity.RemovedActivityAction,
    removedActivity.[Order]

    FROM           
    RemovedActivity removedActivity 

    WHERE
    removedActivity.WorkflowInstanceInternalId = @workflowInternalInstanceId
	
    ORDER BY 
    removedActivity.WorkflowInstanceEventId,
    removedActivity.[Order]
 END
GO
