Use Performance;
WITH Waits AS
(
SELECT 
	wait_type,
	wait_time_ms / 1000 as wait_time_s,
	100 * wait_time_ms / SUM(wait_time_ms) OVER() AS pct,
	ROW_NUMBER() OVER(ORDER BY wait_time_ms DESC) AS rn,
	100 * signal_wait_time_ms / wait_time_ms as signal_pct

	FROM sys.dm_os_wait_stats
	WHERE wait_time_ms > 0
		AND wait_type NOT LIKE N'%SLEEPS%' 
		AND wait_type NOT LIKE N'%IDLE'
		AND wait_type NOT LIKE N'%QUEUE%'
		AND wait_type NOT IN(N'CLR_AUTO_EVENT',
							 N'REQUEST_FOR_DEADLOCK_SEARCH',
							 N'SQLTRACE_BUFFER_FLUSH'
							 /* filter out additional relevant waits */ )
)
SELECT
	W1.wait_type,
	CAST(W1.wait_time_s As Numeric(12,2)) As wait_time_s,
	CAST(W1.pct AS NUMERIC(5,2)) As pct,
	CAST(SUM(W2.pct) AS NUMERIC(5,2)) AS running_pct,
	CAST(W1.signal_pct AS NUMERIC(5,2)) AS signal_pct
	FROM Waits As W1 
		JOIN Waits As W2 
			ON W2.rn <= W1.rn
	GROUP BY W1.rn, W1.wait_type, W1.wait_time_s,W1.pct,W1.signal_pct 
	HAVING SUM(W2.pct) - W1.pct < 80 --percentage threshold
		OR W1.rn <= 5
		ORDER BY W1.rn;
GO
-- Function script
use Performance;
GO

CREATE FUNCTION dbo.IntervalWaits 
	(@fromdt AS DATETIME, @todt AS DATETIME)

RETURNS TABLE 
AS 

RETURN 
	WITH Waits As 
	(
		SELECT dt, wait_type, wait_time_ms,
			ROW_NUMBER() OVER(PARTITION BY wait_type ORDER BY dt) as rn
			FROM dbo.WaitStats
	)
	SELECT Prv.wait_type,Prv.dt as start_time,
			CAST((Cur.wait_time_ms - Prv.wait_time_ms) / 1000 AS NUMERIC(12, 2)) As interval_wait_s
		FROM Waits As Cur
				JOIN Waits AS Prv 
					ON Cur.wait_type = Prv.wait_type
						AND Cur.rn = Prv.rn+1
						AND Prv.dt >= @fromdt
						AND Prv.dt < DATEADD(day, 1, @todt)

GO



SELECT wait_type, start_time, interval_wait_s
FROM dbo.IntervalWaits('20090212', '20090213') AS F
ORDER BY SUM(interval_wait_s) OVER(PARTITION BY wait_type) DESC,
        wait_type, start_time;

GO
