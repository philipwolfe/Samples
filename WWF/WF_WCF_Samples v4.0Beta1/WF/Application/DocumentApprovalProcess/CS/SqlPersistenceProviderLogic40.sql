USE SampleInstanceStore
GO

set ANSI_NULLS on
GO
set QUOTED_IDENTIFIER on
GO

if exists (select * from sys.objects where object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[GetInstanceAndLockErrorInfo]') AND type in (N'P', N'PC'))
	drop procedure [System.ServiceModel.Persistence].[GetInstanceAndLockErrorInfo]
GO

create procedure [System.ServiceModel.Persistence].[GetInstanceAndLockErrorInfo]
@instanceId uniqueidentifier,
@isLoadOperation bit =0
as
begin
		declare @existingOwner uniqueidentifier
		declare @leaseHolderInfo varbinary(max)
		declare @Result int
		set @Result = 0		
						 
		select  top 1 @existingOwner=[LockOwner] 
		from [Instances] where [Id] = @instanceId
		
		if @@rowcount=1
		begin
			
		        select  top 1 @leaseHolderInfo=[LeaseHolderInfo]
				from [LeaseHolders]
				where ([Id]=@existingOwner)
			
				if ((@@ROWCOUNT=1) OR (@isLoadOperation<>1))-- if we aren't loading that means the instance was unlocked so the operation
															-- should fail
				begin
					set @Result = 2; -- Did not have lock
					select @Result as 'Result', @instanceId, @leaseHolderInfo
				end
				else
				begin
					set @Result = -1 -- can't find owner, retry on load..
				end
			
		end
		else
		begin			
			set @Result = 1; -- Instance not found
			select @Result as 'Result', @InstanceId
		end
		
		return @Result
end
GO

GRANT EXECUTE ON [System.ServiceModel.Persistence].[GetInstanceAndLockErrorInfo] TO [System.ServiceModel.Persistence.PersistenceUsers]
GO

if exists (select * from sys.objects where object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[CheckInstanceLock]') AND type in (N'P', N'PC'))
	drop procedure [System.ServiceModel.Persistence].[CheckInstanceLock]
GO
create procedure [System.ServiceModel.Persistence].[CheckInstanceLock]
	@id uniqueidentifier,
	@hostId uniqueidentifier,
	@isLockedMode bit,
	@result int output
as
begin
	set nocount on;
	set transaction isolation level read committed;
	
	declare @now datetime
	
	set @result=0
	set @now = getutcdate();
	

	if not exists (select top 1 [Instances].[Id]		
		from [Instances],[LeaseHolders] 				
		where ([Instances].[Id] = @id) AND ((([Instances].[LockOwner] = @hostId) AND 
											([Instances].[LockOwner]=[LeaseHolders].[Id])
												AND ([LeaseHolders].[LeaseExpiration]>= @now)) OR
											((@isLockedMode=0) and ([Instances].[LockOwner] is null)))
		)
	begin
		exec @result = [System.ServiceModel.Persistence].[GetInstanceAndLockErrorInfo] @id
	end
end
GO
GRANT EXECUTE ON [System.ServiceModel.Persistence].[CheckInstanceLock] TO [System.ServiceModel.Persistence.PersistenceUsers]
GO
-- 
--
-- DeleteInstance
--
if exists (select * from sys.objects where object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[DeleteInstance]') AND type in (N'P', N'PC'))
	drop procedure [System.ServiceModel.Persistence].[DeleteInstance]
GO
create procedure [System.ServiceModel.Persistence].[DeleteInstance]
	@id uniqueIdentifier,
	@hostId uniqueIdentifier,
	@isLockedMode bit,
	@result int output
as
begin
	set nocount on;
	set transaction isolation level read committed
	
	declare @now datetime;	
	set @now = getutcdate();	

	delete from [Instances]
	from [Instances],[LeaseHolders]
	where ([Instances].[Id] = @id) AND ((([Instances].[LockOwner] = @hostId) AND 
										([Instances].[LockOwner]=[LeaseHolders].[Id])
											AND ([LeaseHolders].[LeaseExpiration]>= @now)) OR
										((@isLockedMode=0) and ([Instances].[LockOwner] is null)))

	if @@rowcount = 1
	begin
		delete from [Keys]
		where [InstanceId]=@id		
		
		set @result = 0; -- Success
	end
	else
	begin
		exec @result = [System.ServiceModel.Persistence].[GetInstanceAndLockErrorInfo] @id
	end

	if (@result=0)
		select @result as 'Result'
end
GO
GRANT EXECUTE ON [System.ServiceModel.Persistence].[DeleteInstance] TO [System.ServiceModel.Persistence.PersistenceUsers]
GO

--
-- LoadInstance
--
if exists (select * from sys.objects where object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[LoadInstance]') AND type in (N'P', N'PC'))
	drop procedure [System.ServiceModel.Persistence].[LoadInstance]
GO
create procedure [System.ServiceModel.Persistence].[LoadInstance]
	@id uniqueidentifier,
	@lockInstance bit,
	@hostId uniqueidentifier,
	@isLockedMode bit,
	@result int output
as
begin
	set nocount on;

	set transaction isolation level read committed;

	
	
	declare @now datetime
	set @result = 0;

	if (@isLockedMode = 'FALSE') OR (@lockInstance = 'FALSE')
	begin
			select  @result as 'Result', [Instances].[Id], [Data], [XmlData]
			from  [Instances]  
			where [Instances].[Id] = @id;
			
		if @@rowcount = 0
		begin
			set @result = 1; -- Instance not found
			select @result as 'Result', @id
		end
		else
		begin
			--Return its associated keys (A dummy key is added as a placeholder in case the instance didnt have any keys)
			select N'00000000-0000-0000-0000-000000000000'
			union
			select [Id]
			from  [Keys]
			where [InstanceId]= @id
		end
	end
	else
	begin
AttemptLoadInstance:
		set @now = getutcdate();

		update [Instances] 
		set
			[LockOwner] = @hostId,
			[MachineName] = HOST_NAME()
		from [Instances], [LeaseHolders]
	 where ([Instances].[Id] = @id) AND ( ([Instances].[LockOwner] is NULL) OR
										   ([Instances].[LockOwner] = @hostId) OR
										  (([Instances].[LockOwner]=[LeaseHolders].[Id])
											AND ([LeaseHolders].[LeaseExpiration]< @now)))


		if @@rowcount = 1
		begin
			set @result=0

			select  @result as 'Result', [Instances].[Id], [Data], [XmlData]
			from [Instances]  
			where [Instances].[Id] = @id;
			
			--Return its associated keys (A dummy key is added as a placeholder in case the instance didnt have any keys)
			select N'00000000-0000-0000-0000-000000000000'
			union
			select[Id]
			from  [Keys]
			where [InstanceId]= @id
		end
		else
		begin
			exec @result = [System.ServiceModel.Persistence].[GetInstanceAndLockErrorInfo] @id,1
			if (@result=-1)
			begin
				GOTO AttemptLoadInstance
			end

		end


	end
--	if (@result=0)
--		select @result as 'Result'
end
GO
GRANT EXECUTE ON [System.ServiceModel.Persistence].[LoadInstance] TO [System.ServiceModel.Persistence.PersistenceUsers]
GO

--
-- CreateInstance
--
if exists (select * from sys.objects where object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[CreateInstance]') AND type in (N'P', N'PC'))
	drop procedure [System.ServiceModel.Persistence].[CreateInstance]
GO
create procedure [System.ServiceModel.Persistence].[CreateInstance]
	@id uniqueidentifier,
	@instanceType uniqueidentifier,
	@instance varbinary(max) = NULL,
	@instanceXml xml = NULL,	
	@status	tinyint,
	@blockingBookmarks nvarchar(max),
	@statusReason nvarchar(max),
	@unlockInstance bit,
	@hostId uniqueidentifier,
	@isLockedMode bit,
	@result int OUTPUT
as
begin
	set nocount on;

	set transaction isolation level read committed;

	set @result = 0;

	declare @now datetime,@newOwner uniqueidentifier;
	set @now = getutcdate();
	
	if @isLockedMode = 'FALSE' OR @unlockInstance = 'TRUE'
	begin
		set @newOwner = NULL;
	end
	else 
	begin
		set @newOwner = @hostId;
	end


	insert into [Instances] ([Id], [InstanceType], [Data],[XmlData], [Status], [BlockingBookmarks], [StatusReason], [MachineName], [CreationTime], [ModificationTime], [LockOwner])
		values (@id, @instanceType, @instance, @instanceXml, @status, @blockingBookmarks, @statusReason, HOST_NAME(), @now, @now, @newOwner);
	
	if @@rowcount = 0
	begin
		if exists(select top 1 1  from [Instances] where [Id] = @id)
		begin
			set @result = 5; -- The instance already existed.	
			select @result as 'Result', @id		
		end
		else 
			set @result = 99; -- Some other non-fatal error caused us not to insert
			select @result as 'Result', @id		
	end
	if (@result=0)
		select @result as 'Result'
end
GO
GRANT EXECUTE ON [System.ServiceModel.Persistence].[CreateInstance] TO [System.ServiceModel.Persistence.PersistenceUsers]
GO

--
-- UpdateInstance
--
if exists (select * from sys.objects where object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[UpdateInstance]') AND type in (N'P', N'PC'))
	drop procedure [System.ServiceModel.Persistence].[UpdateInstance]
GO
create procedure [System.ServiceModel.Persistence].[UpdateInstance]
	@id uniqueidentifier,
	@instance varbinary(max) = NULL,
	@instanceXml xml = NULL,
	@status	tinyint,
	@blockingBookmarks nvarchar(max),
	@statusReason nvarchar(max),
	@unlockInstance bit,
	@hostId uniqueidentifier,
	@isLockedMode bit,
	@result int OUTPUT
as
begin
	set nocount on;

	set transaction isolation level read committed;

	set @result = 0;

	declare @newOwner uniqueidentifier, @now datetime;
	set @now=GETUTCDATE()
	
	if @isLockedMode='FALSE' OR @unlockInstance = 'TRUE'
	begin
		set @newOwner = NULL;
	end
	else 
	begin
		set @newOwner = @hostId;
	end

	update [Instances] set
		[Data] = @instance,		
		[XmlData]=@instanceXml,
		[Status]=@status,
		[BlockingBookmarks]=@blockingBookmarks,
		[StatusReason]=@statusReason,
		[MachineName] = HOST_NAME(),
		[ModificationTime] = @now,
		[LockOwner] = @newOwner
		from [Instances],[LeaseHolders]
		where ([Instances].[Id] = @id) AND ((([Instances].[LockOwner] = @hostId) AND 
										([LeaseHolders].[Id]=[Instances].[LockOwner])AND
										 ([LeaseHolders].[LeaseExpiration]>= @now)) OR
										((@isLockedMode=0) AND ([Instances].[LockOwner] is null)))
	

	if @@rowcount = 0
	begin
	
		exec @result = [System.ServiceModel.Persistence].[GetInstanceAndLockErrorInfo] @id
	end
	if (@result=0)
		select @result as 'Result'
end
GO
GRANT EXECUTE ON [System.ServiceModel.Persistence].[UpdateInstance] TO [System.ServiceModel.Persistence.PersistenceUsers]
GO

--
-- UnlockInstance
--
if exists (select * from sys.objects where object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[UnlockInstance]') AND type in (N'P', N'PC'))
	drop procedure [System.ServiceModel.Persistence].[UnlockInstance]
GO
create procedure [System.ServiceModel.Persistence].[UnlockInstance]
	@id uniqueIdentifier,
	@hostId uniqueIdentifier,
	@isLockedMode bit,
	@result int output
as
begin
	set nocount on;

	set transaction isolation level read committed

	declare @now datetime;
	set @now = getutcdate();

	update [Instances] set
		[LockOwner] = NULL,
		[MachineName] = HOST_NAME()
	from [Instances],[LeaseHolders]
	where ([Instances].[Id] = @id) AND ((([Instances].[LockOwner] = @hostId) AND 
									([LeaseHolders].[Id]=[Instances].[LockOwner])AND
									 ([LeaseHolders].[LeaseExpiration]>= @now)) OR
									((@isLockedMode=0) AND ([Instances].[LockOwner] is NULL)))


	if @@rowcount = 1
		set @result = 0; -- Success
	else
	begin
		exec @result = [System.ServiceModel.Persistence].[GetInstanceAndLockErrorInfo] @id
	end
	if (@result=0)
		select @result as 'Result'
end
GO
GRANT EXECUTE ON [System.ServiceModel.Persistence].[UnlockInstance] TO [System.ServiceModel.Persistence.PersistenceUsers]
GO

if exists (select * from sys.objects where object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[InsertKey]') AND type in (N'P', N'PC'))
	drop procedure [System.ServiceModel.Persistence].[InsertKey]
GO

create procedure [System.ServiceModel.Persistence].[InsertKey]
	@key uniqueidentifier,
	@instanceId uniqueidentifier,
	@scopeName nvarchar(max),
	@keyData nvarchar(max),		
	@hostId uniqueIdentifier,
	@isLockedMode bit,
	@result int output
as
begin
	set nocount on;

	set transaction isolation level read committed;	
	set @result=0	
	
	insert into [Keys]([Id],[InstanceId],[ScopeName],[KeyData])
		values (@key,@instanceId,@scopeName,@keyData)

	if @@rowcount = 0
		begin
			if exists(select Top 1 1 from [Keys] where [Id] = @key)			
			begin				
				set @result = 3; --- key already exists
				select @result as 'Result', @key
			end
			else 
			begin							
				set @result = 99; -- Some other non-fatal error caused us not to insert
				select @result as 'Result', @key
			end
		end
	
	if (@result=0)
		select @result as 'Result'
end
GO
GRANT EXECUTE ON [System.ServiceModel.Persistence].[InsertKey] TO [System.ServiceModel.Persistence.PersistenceUsers]
GO
if exists (select * from sys.objects where object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[DeleteKey]') AND type in (N'P', N'PC'))
	drop procedure [System.ServiceModel.Persistence].[DeleteKey]
GO

create procedure [System.ServiceModel.Persistence].[DeleteKey]
	@key uniqueidentifier,
	@instanceId uniqueidentifier,
	@hostId uniqueIdentifier,
	@isLockedMode bit,
	@result int output
as
begin
	set nocount on;
	set transaction isolation level read committed;
	
	delete from [Keys]
	where [Id]=@key
	if @@rowcount = 1
	begin
		set @result = 0; 
	end
	else
	begin
		if NOT exists (select 1  from [Keys] where [Id] = @key)
			begin
				
				set @result = 4 -- key not exists
				select @result as 'Result', @key
			end	
	end
		
	if (@result=0)
		select @result as 'Result'
end
GO
GRANT EXECUTE ON [System.ServiceModel.Persistence].[DeleteKey] TO [System.ServiceModel.Persistence.PersistenceUsers]
GO

if exists (select * from sys.objects where object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[LoadOrCreate]') AND type in (N'P', N'PC'))
	drop procedure [System.ServiceModel.Persistence].[LoadOrCreate]
GO

create procedure [System.ServiceModel.Persistence].[LoadOrCreate]
	@key uniqueidentifier,
	@scopeName nvarchar(max),
	@keyData nvarchar(max),
	@instanceType uniqueidentifier,	
	@status tinyint,
	@unlockInstance bit,
	@hostId uniqueidentifier,
	@isLockedMode bit,
	@operationType int, -- 0=LoadOrCreateByKey,1=LoadOrCreateByInstance, 2=LoadByKey, 3=LoadByInstance
	@instanceId uniqueidentifier output,
	@isNewlyAquiriedLock bit output,
	@isNewInstance bit output,
	@result int output
as
begin
	set nocount on;
	set transaction isolation level read committed;

	declare @LoadedResult bit

	set @LoadedResult=0	
	set @isNewlyAquiriedLock=1
	set @result=0

	
	declare @now datetime,  @newOwner uniqueidentifier;
	set @now = getutcdate();
	
	if @isLockedMode= 'FALSE' OR @unlockInstance = 'TRUE'
	begin
		set @newOwner = NULL;
	end
	else 
	begin
		set @newOwner=@hostId
	end

	-- if keyed operation get	instance id
	if (@operationType=0) or (@operationType=2)
	begin
		select @instanceId = [InstanceId]
						from [Keys]
						where [Id]=@key
		if (@@rowcount=0)
		begin
			if (@operationType=2)
			begin
				set @result= 4 -- key not exist
				select @result as 'Result', @key 
				
			end
			else
			begin
				insert into [keys]
				([Id],[InstanceId],[ScopeName],[KeyData])
				values(@key,@instanceId,@scopeName,@keyData)
				
				if (@@rowcount=0)
				begin
						select @instanceId = [InstanceId]
						from [Keys]
						where [Id]=@key
						if (@@rowcount=0)
						begin
							set @result=99
						end
				end
			end		
		end
	end	

	if (@result=0)
	begin
		declare @oldOwner table (oldOwner uniqueidentifier NULL)
AttemptLoadOrCreate:

		update [Instances] -- try and lock the instance as if it is a load operation
			set 				
				[ModificationTime]=@now,
				[LockOwner]=@newOwner,
				[MachineName] = HOST_NAME()
			output deleted.[LockOwner] into @oldOwner
			from [Instances], [LeaseHolders]
			where ([Instances].[Id] = @instanceId) AND ( ([Instances].[LockOwner] is NULL) OR
												   ([Instances].[LockOwner] = @hostId) OR
												  (([Instances].[LockOwner]=[LeaseHolders].[Id])
													AND ([LeaseHolders].[LeaseExpiration]< @now)))
				
			if @@rowcount=0
			begin
				-- if we can't load lets create a new instance and take the lock for it

				insert into [Instances] ([Id], [InstanceType], [Status], [MachineName], [CreationTime], [ModificationTime], [LockOwner])
				values (@instanceId, @instanceType, @status, HOST_NAME(), @now, @now, @newOwner);

				if (@@rowcount=1)
				begin
					
					if (@operationType=0) or (@operationType=1) -- inserted new instance for create or load operation, Success!!
					begin
							set @isNewInstance=1
							set @isNewlyAquiriedLock=1
							set @result=0
					end
					else -- we managed to insert an instance for a Load operation, set result=instance not found and rollback transaction
					begin
						set @result=1 --instance not found
						select @result as 'Result', @instanceId as 'InstanceId'
					end
				end
				else
				begin -- if loading existing instance & inserting new instance fails, then instance is locked
					exec @result = [System.ServiceModel.Persistence].[GetInstanceAndLockErrorInfo] @instanceId, 1
					
  					if (@result=-1)
					begin
						GOTO AttemptLoadOrCreate;
					end

				end		
			end		
			else -- we loacked existing instance
			begin
				set @isNewInstance=0
				set @result=0
				set @LoadedResult=1

				select top 1 @isNewlyAquiriedLock = case 
											when  ((oldOwner is null) or (oldOwner!=@hostId)) then 1
											else 0
										end	
				from @oldOwner
				select @result as 'Result',[Id],[Data],[XmlData],@isNewInstance, @isNewlyAquiriedLock												
				from [Instances]  
				where [Instances].[Id] = @instanceId;
			
				--Return its associated keys (A dummy key is added as a placeholder in case the instance didnt have any keys)
				select N'00000000-0000-0000-0000-000000000000'
				union
				select [Id]
				from  [Keys]
				where [InstanceId]= @instanceId
			end
	end	

	if (@result=0) and (@LoadedResult!=1)
		select @result as 'Result', @instanceId,null,null, @isNewInstance,@isNewlyAquiriedLock 
end
GO
GRANT EXECUTE ON [System.ServiceModel.Persistence].[LoadOrCreate] TO [System.ServiceModel.Persistence.PersistenceUsers]
GO

if exists (select * from sys.objects where object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[InsertLeaseHolder]') AND type in (N'P', N'PC'))
	drop procedure [System.ServiceModel.Persistence].[InsertLeaseHolder]
GO
create procedure [System.ServiceModel.Persistence].[InsertLeaseHolder]
	@hostId uniqueidentifier,
	@hostTimeout int,
	@hostInfo varbinary(max)
as
begin
	set nocount on;

	set transaction isolation level read committed;
	
	declare @now datetime,@leaseExpiration datetime
	
	set @now = getutcdate();

	if @hostTimeout = 0
		set @leaseExpiration = '9999-12-31T23:59:59';
	else 
		set @leaseExpiration = dateadd(second, @hostTimeout, @now);

	insert into [LeaseHolders]
		([Id],[LeaseExpiration],[LeaseHolderInfo])
	values
		(@hostId,@leaseExpiration,@hostInfo)
	
end
GO
GRANT EXECUTE ON [System.ServiceModel.Persistence].[InsertLeaseHolder] TO [System.ServiceModel.Persistence.PersistenceUsers]
GO



if exists (select * from sys.objects where object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[DeleteLeaseHolder]') AND type in (N'P', N'PC'))
	drop procedure [System.ServiceModel.Persistence].[DeleteLeaseHolder]
GO

create procedure [System.ServiceModel.Persistence].[DeleteLeaseHolder]
	@hostId uniqueidentifier
as
begin
	set nocount on;

	set transaction isolation level read committed;

	update [Instances]
	set	[LockOwner] = NULL,
		[MachineName] = HOST_NAME()
	where [LockOwner]= @hostId

	delete from [LeaseHolders]
	where [Id]=@hostId
end
GO

GRANT EXECUTE ON [System.ServiceModel.Persistence].[DeleteLeaseHolder] TO [System.ServiceModel.Persistence.PersistenceUsers]
GO

if exists (select * from sys.objects where object_id = OBJECT_ID(N'[System.ServiceModel.Persistence].[ExtendLease]') AND type in (N'P', N'PC'))
	drop procedure [System.ServiceModel.Persistence].[ExtendLease]
GO
create procedure [System.ServiceModel.Persistence].[ExtendLease]
	@hostId uniqueidentifier,
	@hostTimeout int		
as
begin
	set nocount on;

	set transaction isolation level read committed;
	
	declare @now datetime,@leaseExpiration datetime, @lastExpirationTime datetime
	declare @result int
	
	set @now = getutcdate();
	set @result=0
	
	if @hostTimeout = 0
		set @leaseExpiration = '9999-12-31T23:59:59';
	else 
		set @leaseExpiration = dateadd(second, @hostTimeout, @now);

	select @lastExpirationTime = [LeaseExpiration]
	from [LeaseHolders]
	where ([Id]=@hostId)
	
	if (@@rowcount=1) 
	begin
		if (@lastExpirationTime>=@now)
		begin
				update  [LeaseHolders]
				set [LeaseExpiration]=@leaseExpiration
				where ([Id]=@hostId)
			
		end
		else -- we are beyond the expiration time, so delete the owner
		begin
			set @result= -1
			exec [DeleteLeaseHolder] @hostId			
		end
		
	end
	else -- the row has been deleted
	begin
		set @result= -1
	end
	
	select @result
	
end
GO
GRANT EXECUTE ON [System.ServiceModel.Persistence].[ExtendLease] TO [System.ServiceModel.Persistence.PersistenceUsers]
GO