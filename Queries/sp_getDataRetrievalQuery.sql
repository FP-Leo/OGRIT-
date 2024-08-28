CREATE PROCEDURE sp_getDataRetrievalQuery
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX);

    -- Construct the full SQL statement as a string
    SET @sql = 'SELECT ' +
						'@@SERVERNAME as ServerName ' +
						',d.name ' +
						',ownername = l.name ' +
						',d.create_date ' +
						',d.compatibility_level ' +
						',d.collation_name ' +
						',d.user_access_desc ' +
						',d.is_read_only ' +
						',d.is_auto_close_on ' +
						',d.is_auto_shrink_on ' +
						',d.state_desc ' +
						',d.is_in_standby ' +
						',d.is_cleanly_shutdown ' +
						',d.is_supplemental_logging_enabled ' +
						',d.snapshot_isolation_state_desc ' +
						',d.is_read_committed_snapshot_on ' +
						',d.recovery_model_desc ' +
						',d.page_verify_option_desc ' +
						',d.is_auto_create_stats_on ' +
						',d.is_auto_create_stats_incremental_on ' +
						',d.is_auto_update_stats_on ' +
						',d.is_auto_update_stats_async_on ' +
						',d.is_ansi_null_default_on ' +
						',d.is_ansi_nulls_on ' +
						',d.is_ansi_padding_on ' +
						',d.is_ansi_warnings_on ' +
						',d.is_arithabort_on ' +
						',d.is_concat_null_yields_null_on ' +
						',d.is_numeric_roundabort_on ' +
						',d.is_quoted_identifier_on ' +
						',d.is_recursive_triggers_on ' +
						',d.is_cursor_close_on_commit_on ' +
						',d.is_local_cursor_default ' +
						',d.is_fulltext_enabled ' +
						',d.is_trustworthy_on ' +
						',d.is_db_chaining_on ' +
						',d.is_parameterization_forced ' +
						',d.is_master_key_encrypted_by_server ' +
						',d.is_query_store_on ' +
						',d.is_published ' +
						',d.is_subscribed ' +
						',d.is_merge_published ' +
						',d.is_distributor ' +
						',d.is_sync_with_backup ' +
						',d.service_broker_guid ' +
						',d.is_broker_enabled ' +
						',d.log_reuse_wait ' +
						',d.log_reuse_wait_desc ' +
						',d.is_date_correlation_on ' +
						',d.is_cdc_enabled ' +
						',d.is_encrypted ' +
						',d.is_honor_broker_priority_on ' +
						',d.replica_id ' +
						',d.group_database_id ' +
						',d.resource_pool_id ' +
						',d.default_language_lcid ' +
						',d.default_language_name ' +
						',d.default_fulltext_language_lcid ' +
						',d.default_fulltext_language_name ' +
						',d.is_nested_triggers_on ' +
						',d.is_transform_noise_words_on ' +
						',d.two_digit_year_cutoff ' +
						',d.containment ' +
						',d.containment_desc ' +
						',d.target_recovery_time_in_seconds ' +
						',d.delayed_durability_desc ' +
						',d.is_memory_optimized_elevate_to_snapshot_on ' +
						',RecordTimeStamp = GETDATE() ' +
						'FROM sys.databases AS d ' +
						'LEFT JOIN ' +
						'sys.sql_logins AS l ON d.owner_sid = l.sid';

    -- Return the full SQL query
    SELECT @sql AS QueryToExecute;
END
GO

