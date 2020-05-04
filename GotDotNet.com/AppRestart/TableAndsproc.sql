USE TEST
GO


/****** Object:  Table [dbo].[LogItems]    Script Date: 12/27/2006 12:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LogItems](
	[EventID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_LogItems_EventID]  DEFAULT (newid()),
	[LogDateTime] [datetime] NULL,
	[App_Name] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Source] [char](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Message] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Form] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[QueryString] [varchar](2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TargetSite] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StackTrace] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Referer] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Data] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Path] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_LogItems] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  Stored Procedure dbo.usp_WebAppLogsInsert    Script Date: 5/30/2006 4:51:57 PM ******/        
CREATE PROC [dbo].[usp_WebAppLogsInsert]        
        
@EventID UNIQUEIDENTIFIER,        
@source varchar(100),        
@LogDateTime dateTime,        
@Message varchar(1000),        
@Form varchar(4000),        
@QueryString varchar(2000),        
@TargetSite varchar(300),        
@StackTrace varchar(4000),        
@Data varchar(500) = NULL,      
@Referer varchar(250) = null,  
@App_Name varchar(100) = null,
@Path varchar(1000) = null        
AS        
        
        
INSERT INTO LOGITEMS        
(          
EventId,        
Source, LogDateTime,Message,Form,QueryString,TargetSite,StackTrace,Referer,Data, [App_Name],Path)        
Values (         
@EventId,        
@Source,        
@LogDateTime,        
@Message,        
@Form,        
@QueryString,        
@TargetSite,        
@StackTrace,        
@Referer,      
@Data,  
@App_Name,
@Path
)    

Select @@IDENTITY AS PKID
    
/****** Object:  StoredProcedure [dbo].[GetLogItemById]    Script Date: 12/27/2006 12:03:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetLogItemById]

@EventId UNIQUEIDENTIFIER

AS

Select * from dbo.LogItems where EventId = @EventId



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_LogItems](
@EventID UNIQUEIDENTIFIER = null ,
@App_Name varchar(100) = null ,
@Message varchar (1000) = null,
@Referer varchar (250) = null,
@StackTrace varchar (4000) = null,
@Source CHAR(100) = NULL ,
@BeginDate DateTime = null,
@EndDate dateTime = null,
@TargetSite varchar(300) =null,
@Path Varchar(1000) = null

)
AS 


SELECT * FROM dbo.LogItems  
WHERE 1=1
AND 1 =

CASE	WHEN @EventId IS NOT NULL AND  EventId = @EventID THEN 1
WHEN @EventId IS NULL THEN 1	END 
AND 1 =	CASE WHEN @App_Name IS NOT NULL and [APP_NAME] = @App_Name THEN 1
WHEN @App_Name IS NULL THEN 1 END
AND 1 = CASE WHEN @BeginDate IS NOT NULL and LogDateTime >=@BeginDate THEN 1
WHEN @BeginDate IS NULL THEN 1 END
AND 1 = CASE WHEN @EndDate IS NOT NULL  and LogDateTime <=@EndDate THEN 1
WHEN @EndDate IS NULL THEN 1 END
AND 1 = CASE WHEN @Message IS NOT NULL and Message like '%'+@Message+'%' THEN 1
WHEN @Message IS NULL THEN 1 END
AND 1 = CASE WHEN @StackTrace IS NOT NULL and StackTrace like '%'+@StackTrace+'%' THEN 1
WHEN @StackTrace IS NULL THEN 1 END
AND 1 = CASE WHEN @Referer IS NOT NULL and Referer like '%'+@Referer+'%' THEN 1
WHEN @Referer IS NULL THEN 1 END
AND 1 = CASE WHEN @Source IS NOT NULL and Source like '%'+@Source+'%' THEN 1
WHEN @source IS NULL THEN 1 END

AND 1 = CASE WHEN @TargetSite IS NOT NULL and TargetSite like '%'+@TargetSite+'%' THEN 1
WHEN @TargetSite IS NULL THEN 1 END

AND 1 = CASE WHEN @Path IS NOT NULL and Path like '%'+@Path+'%' THEN 1
WHEN @Path IS NULL THEN 1 END

GO


CREATE PROC dbo.GetProviderEvents

AS
SELECT * FROM dbo.ASPNET_WebEvent_Events


GO


