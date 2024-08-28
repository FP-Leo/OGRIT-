# Your SQL query as a multi-line string
sql_query = """
CREATE TABLE [dbo].[DbConfiguration](
	[ServerName] [nvarchar](128) NOT NULL,
	[DbName] [nvarchar](128) NOT NULL,
	[Ownername] [nvarchar](128) NULL,
	[CreateDate] [datetime] NOT NULL,
	[CompatibilityLevel] [tinyint] NOT NULL,
	[CollationTypeName] [nvarchar](128) NULL,
	[UserAccessDesc] [nvarchar](60) NULL,
	[IsReadOnly] [bit] NULL,
	[IsAutoCloseOn] [bit] NOT NULL,
	[IsAutoShrinkOn] [bit] NULL,
	[StateDesc] [nvarchar](60) NULL,
	[IsInStandby] [bit] NULL,
	[IsCleanlyShutdown] [bit] NULL,
	[IsSupplementalLoggingEnabled] [bit] NULL,
	[SnapshotIsolationStateDesc] [nvarchar](60) NULL,
	[IsReadCommittedSnapshotOn] [bit] NULL,
	[RecoveryModelDesc] [nvarchar](60) NULL,
	[PageVerifyOptionDesc] [nvarchar](60) NULL,
	[IsAutoCreateStatsOn] [bit] NULL,
	[IsAutoCreateStatsIncrementalOn] [bit] NULL,
	[IsAutoUpdateStatsOn] [bit] NULL,
	[IsAutoUpdateStatsAsyncOn] [bit] NULL,
	[IsAnsiNullDefaultOn] [bit] NULL,
	[IsAnsiNullsOn] [bit] NULL,
	[IsAnsiPaddingOn] [bit] NULL,
	[IsAnsiWarningsOn] [bit] NULL,
	[IsArithabortOn] [bit] NULL,
	[IsConcatNullYieldsNullOn] [bit] NULL,
	[IsNumericRoundabortOn] [bit] NULL,
	[IsQuotedIdentifierOn] [bit] NULL,
	[IsRecursiveTriggersOn] [bit] NULL,
	[IsCursorCloseOnCommitOn] [bit] NULL,
	[IsLocalCursorDefault] [bit] NULL,
	[IsFulltextEnabled] [bit] NULL,
	[IsTrustworthyOn] [bit] NULL,
	[IsDbChainingOn] [bit] NULL,
	[IsParameterizationForced] [bit] NULL,
	[IsMasterKeyEncryptedByServer] [bit] NOT NULL,
	[IsQueryStoreOn] [bit] NULL,
	[IsPublished] [bit] NOT NULL,
	[IsSubscribed] [bit] NOT NULL,
	[IsMergePublished] [bit] NOT NULL,
	[IsDistributor] [bit] NOT NULL,
	[IsSyncWithBackup] [bit] NOT NULL,
	[ServiceBrokerGuid] [uniqueidentifier] NOT NULL,
	[IsBrokerEnabled] [bit] NOT NULL,
	[LogReuseWait] [tinyint] NULL,
	[LogReuseWaitDesc] [nvarchar](60) NULL,
	[IsDateCorrelationOn] [bit] NOT NULL,
	[IsCdcEnabled] [bit] NOT NULL,
	[IsEncrypted] [bit] NULL,
	[IsHonorBrokerPriorityOn] [bit] NULL,
	[ReplicaId] [uniqueidentifier] NULL,
	[GroupDatabaseId] [uniqueidentifier] NULL,
	[ResourcePoolId] [int] NULL,
	[DefaultLanguageLcId] [smallint] NULL,
	[DefaultLanguageName] [nvarchar](128) NULL,
	[DefaultFulltextLanguageLcId] [int] NULL,
	[DefaultFulltextLanguageName] [nvarchar](128) NULL,
	[IsNestedTriggersOn] [bit] NULL,
	[IsTransformNoiseWordsOn] [bit] NULL,
	[TwoDigitYearCutoff] [smallint] NULL,
	[Containment] [tinyint] NULL,
	[ContainmentDesc] [nvarchar](60) NULL,
	[TargetRecoveryTimeInSeconds] [int] NULL,
	[DelayedDurabilityDesc] [nvarchar](60) NULL,
	[IsMemoryOptimizedElevateToSnapshotOn] [bit] NULL,
	[IsFederationMember] [bit] NULL,
	[IsRemoteDataArchiveEnabled] [bit] NULL,
	[IsMixedPageAllocationOn] [bit] NULL,
	[IsTemporalHistoryRetentionEnabled] [bit] NULL,
	[CatalogCollationTypeDesc] [nvarchar](60) NULL,
	[PhysicalDatabaseName] [nvarchar](128) NULL,
	[IsResultSetCachingOn] [bit] NULL,
	[IsAcceleratedDatabaseRecoveryOn] [bit] NULL,
	[IsTempDbSpillToRemoteStore] [bit] NULL,
	[IsStalePageDetectionOn] [bit] NULL,
	[IsMemoryOptimizedEnabled] [bit] NULL,
	[RecordTimeStamp] [datetime] NOT NULL
) ON [PRIMARY]
"""

# Split the SQL query into lines
lines = sql_query.strip().splitlines()

# Add a single quote at the beginning and ' + at the end of each line
formatted_lines = ["'" + line.strip() + " ' +" for line in lines[:-1]]
formatted_lines.append("'" + lines[-1].strip() + "'") 

# Join the formatted lines into a single string
formatted_sql_query = "\n".join(formatted_lines)

# Save the formatted SQL query to a file
file_path = 'C:\\Users\\leoni\\Desktop\\OGRIT-Uygulama-Projesi\\formatted_sql_query.txt'
with open(file_path, 'w') as file:
    file.write(formatted_sql_query)

print(f"Formatted SQL query saved to {file_path}")
