SELECT 
	wait_type,
	waiting_tasks_count,
	wait_time_ms,
	max_wait_time_ms,
	signal_wait_time_ms
	
	FROM sys.dm_os_wait_stats
	ORDER By wait_type;