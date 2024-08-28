CREATE PROCEDURE dbo.InsertOnDbConfiguration
    @ServerName nvarchar(128),
    @DbName nvarchar(128),
    @Ownername nvarchar(128),
    @CreateDate datetime,
    @CompatibilityLevel tinyint,
    @CollationTypeName nvarchar(128),
    @UserAccessDesc nvarchar(60),
    @IsReadOnly bit,
    @IsAutoCloseOn bit,
    @IsAutoShrinkOn bit,
    @StateDesc nvarchar(60),
    @IsInStandby bit,
    @IsCleanlyShutdown bit,
    @IsSupplementalLoggingEnabled bit,
    @SnapshotIsolationStateDesc nvarchar(60),
    @IsReadCommittedSnapshotOn bit,
    @RecoveryModelDesc nvarchar(60),
    @PageVerifyOptionDesc nvarchar(60),
    @IsAutoCreateStatsOn bit,
    @IsAutoCreateStatsIncrementalOn bit,
    @IsAutoUpdateStatsOn bit,
    @IsAutoUpdateStatsAsyncOn bit,
    @IsAnsiNullDefaultOn bit,
    @IsAnsiNullsOn bit,
    @IsAnsiPaddingOn bit,
    @IsAnsiWarningsOn bit,
    @IsArithabortOn bit,
    @IsConcatNullYieldsNullOn bit,
    @IsNumericRoundabortOn bit,
    @IsQuotedIdentifierOn bit,
    @IsRecursiveTriggersOn bit,
    @IsCursorCloseOnCommitOn bit,
    @IsLocalCursorDefault bit,
    @IsFulltextEnabled bit,
    @IsTrustworthyOn bit,
    @IsDbChainingOn bit,
    @IsParameterizationForced bit,
    @IsMasterKeyEncryptedByServer bit,
    @IsQueryStoreOn bit,
    @IsPublished bit,
    @IsSubscribed bit,
    @IsMergePublished bit,
    @IsDistributor bit,
    @IsSyncWithBackup bit,
    @ServiceBrokerGuid uniqueidentifier,
    @IsBrokerEnabled bit,
    @LogReuseWait tinyint,
    @LogReuseWaitDesc nvarchar(60),
    @IsDateCorrelationOn bit,
    @IsCdcEnabled bit,
    @IsEncrypted bit,
    @IsHonorBrokerPriorityOn bit,
    @ReplicaId uniqueidentifier,
    @GroupDatabaseId uniqueidentifier,
    @ResourcePoolId int,
    @DefaultLanguageLcId smallint,
    @DefaultLanguageName nvarchar(128),
    @DefaultFulltextLanguageLcId int,
    @DefaultFulltextLanguageName nvarchar(128),
    @IsNestedTriggersOn bit,
    @IsTransformNoiseWordsOn bit,
    @TwoDigitYearCutoff smallint,
    @Containment tinyint,
    @ContainmentDesc nvarchar(60),
    @TargetRecoveryTimeInSeconds int,
    @DelayedDurabilityDesc nvarchar(60),
    @IsMemoryOptimizedElevateToSnapshotOn bit,
    @IsFederationMember bit,
    @IsRemoteDataArchiveEnabled bit,
    @IsMixedPageAllocationOn bit,
    @IsTemporalHistoryRetentionEnabled bit,
    @CatalogCollationTypeDesc nvarchar(60),
    @PhysicalDatabaseName nvarchar(128),
    @IsResultSetCachingOn bit,
    @IsAcceleratedDatabaseRecoveryOn bit,
    @IsTempDbSpillToRemoteStore bit,
    @IsStalePageDetectionOn bit,
    @IsMemoryOptimizedEnabled bit,
    @RecordTimeStamp datetime
AS
BEGIN
	EXEC [dbo].[sp_createDbConfiguration]
    EXEC('USE [OGRIT-DB]')
    INSERT INTO [dbo].[DbConfiguration]
           ([ServerName]
           ,[DbName]
           ,[Ownername]
           ,[CreateDate]
           ,[CompatibilityLevel]
           ,[CollationTypeName]
           ,[UserAccessDesc]
           ,[IsReadOnly]
           ,[IsAutoCloseOn]
           ,[IsAutoShrinkOn]
           ,[StateDesc]
           ,[IsInStandby]
           ,[IsCleanlyShutdown]
           ,[IsSupplementalLoggingEnabled]
           ,[SnapshotIsolationStateDesc]
           ,[IsReadCommittedSnapshotOn]
           ,[RecoveryModelDesc]
           ,[PageVerifyOptionDesc]
           ,[IsAutoCreateStatsOn]
           ,[IsAutoCreateStatsIncrementalOn]
           ,[IsAutoUpdateStatsOn]
           ,[IsAutoUpdateStatsAsyncOn]
           ,[IsAnsiNullDefaultOn]
           ,[IsAnsiNullsOn]
           ,[IsAnsiPaddingOn]
           ,[IsAnsiWarningsOn]
           ,[IsArithabortOn]
           ,[IsConcatNullYieldsNullOn]
           ,[IsNumericRoundabortOn]
           ,[IsQuotedIdentifierOn]
           ,[IsRecursiveTriggersOn]
           ,[IsCursorCloseOnCommitOn]
           ,[IsLocalCursorDefault]
           ,[IsFulltextEnabled]
           ,[IsTrustworthyOn]
           ,[IsDbChainingOn]
           ,[IsParameterizationForced]
           ,[IsMasterKeyEncryptedByServer]
           ,[IsQueryStoreOn]
           ,[IsPublished]
           ,[IsSubscribed]
           ,[IsMergePublished]
           ,[IsDistributor]
           ,[IsSyncWithBackup]
           ,[ServiceBrokerGuid]
           ,[IsBrokerEnabled]
           ,[LogReuseWait]
           ,[LogReuseWaitDesc]
           ,[IsDateCorrelationOn]
           ,[IsCdcEnabled]
           ,[IsEncrypted]
           ,[IsHonorBrokerPriorityOn]
           ,[ReplicaId]
           ,[GroupDatabaseId]
           ,[ResourcePoolId]
           ,[DefaultLanguageLcId]
           ,[DefaultLanguageName]
           ,[DefaultFulltextLanguageLcId]
           ,[DefaultFulltextLanguageName]
           ,[IsNestedTriggersOn]
           ,[IsTransformNoiseWordsOn]
           ,[TwoDigitYearCutoff]
           ,[Containment]
           ,[ContainmentDesc]
           ,[TargetRecoveryTimeInSeconds]
           ,[DelayedDurabilityDesc]
           ,[IsMemoryOptimizedElevateToSnapshotOn]
           ,[IsFederationMember]
           ,[IsRemoteDataArchiveEnabled]
           ,[IsMixedPageAllocationOn]
           ,[IsTemporalHistoryRetentionEnabled]
           ,[CatalogCollationTypeDesc]
           ,[PhysicalDatabaseName]
           ,[IsResultSetCachingOn]
           ,[IsAcceleratedDatabaseRecoveryOn]
           ,[IsTempDbSpillToRemoteStore]
           ,[IsStalePageDetectionOn]
           ,[IsMemoryOptimizedEnabled]
           ,[RecordTimeStamp])
     VALUES
           (@ServerName
           ,@DbName
           ,@Ownername
           ,@CreateDate
           ,@CompatibilityLevel
           ,@CollationTypeName
           ,@UserAccessDesc
           ,@IsReadOnly
           ,@IsAutoCloseOn
           ,@IsAutoShrinkOn
           ,@StateDesc
           ,@IsInStandby
           ,@IsCleanlyShutdown
           ,@IsSupplementalLoggingEnabled
           ,@SnapshotIsolationStateDesc
           ,@IsReadCommittedSnapshotOn
           ,@RecoveryModelDesc
           ,@PageVerifyOptionDesc
           ,@IsAutoCreateStatsOn
           ,@IsAutoCreateStatsIncrementalOn
           ,@IsAutoUpdateStatsOn
           ,@IsAutoUpdateStatsAsyncOn
           ,@IsAnsiNullDefaultOn
           ,@IsAnsiNullsOn
           ,@IsAnsiPaddingOn
           ,@IsAnsiWarningsOn
           ,@IsArithabortOn
           ,@IsConcatNullYieldsNullOn
           ,@IsNumericRoundabortOn
           ,@IsQuotedIdentifierOn
           ,@IsRecursiveTriggersOn
           ,@IsCursorCloseOnCommitOn
           ,@IsLocalCursorDefault
           ,@IsFulltextEnabled
           ,@IsTrustworthyOn
           ,@IsDbChainingOn
           ,@IsParameterizationForced
           ,@IsMasterKeyEncryptedByServer
           ,@IsQueryStoreOn
           ,@IsPublished
           ,@IsSubscribed
           ,@IsMergePublished
           ,@IsDistributor
           ,@IsSyncWithBackup
           ,@ServiceBrokerGuid
           ,@IsBrokerEnabled
           ,@LogReuseWait
           ,@LogReuseWaitDesc
           ,@IsDateCorrelationOn
           ,@IsCdcEnabled
           ,@IsEncrypted
           ,@IsHonorBrokerPriorityOn
           ,@ReplicaId
           ,@GroupDatabaseId
           ,@ResourcePoolId
           ,@DefaultLanguageLcId
           ,@DefaultLanguageName
           ,@DefaultFulltextLanguageLcId
           ,@DefaultFulltextLanguageName
           ,@IsNestedTriggersOn
           ,@IsTransformNoiseWordsOn
           ,@TwoDigitYearCutoff
           ,@Containment
           ,@ContainmentDesc
           ,@TargetRecoveryTimeInSeconds
           ,@DelayedDurabilityDesc
           ,@IsMemoryOptimizedElevateToSnapshotOn
           ,@IsFederationMember
           ,@IsRemoteDataArchiveEnabled
           ,@IsMixedPageAllocationOn
           ,@IsTemporalHistoryRetentionEnabled
           ,@CatalogCollationTypeDesc
           ,@PhysicalDatabaseName
           ,@IsResultSetCachingOn
           ,@IsAcceleratedDatabaseRecoveryOn
           ,@IsTempDbSpillToRemoteStore
           ,@IsStalePageDetectionOn
           ,@IsMemoryOptimizedEnabled
           ,@RecordTimeStamp)
END
GO
