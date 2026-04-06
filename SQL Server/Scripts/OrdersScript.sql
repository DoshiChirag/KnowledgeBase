USE Performance
GO

TRUNCATE TABLE dbo.Orders

DECLARE 
	@numorders AS INT,
	@numcusts AS INT,
	@numemps AS INT,
	@numshippers AS INT,
	@numyears AS INT,
	@startdate AS DATETIME;

SELECT 
	@numorders = 1000000,
	@numcusts = 20000,
	@numemps = 500,
	@numshippers = 5,
	@numyears = 4,
	@startdate = '20050101';

INSERT INTO dbo.Orders(orderid, custid, empid, shipperid, orderdate)
	SELECT n as Orderid,
		'C' + RIGHT('000000000' + CAST( 1 + ABS(CHECKSUM(NEWID())) % @numcusts
				AS VARCHAR(10)), 10) As custid,
			1 + ABS(CHECKSUM(NEWID())) % @numemps AS empid,
			CHAR(ASCII('A') - 2 + 2  * (1 + ABS(CHECKSUM(NEWID())) % @numshippers)) AS Shipperid,
			DATEADD(day, n / (@numorders / (@numyears * 365.25)), @startdate) -
			
			
						CASE WHEN n % 10 = 0 
							THEN 1 + ABS(CHECKSUM(NEWID())) % 30
							ELSE 0
							END  AS OrderDate

						FROM dbo.Nums
						WHERE n <= @numorders
						ORDER BY CHECKSUM(NEWID());


GO

