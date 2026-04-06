USE Performance

DECLARE @max AS INT, @rc AS INT;
SET @max = 1000000;
SET @rc = 1;

INSERT INTO dbo.Nums(n) VALUES(1);
WHILE @rc * 2 <= @max
BEGIN
	INSERT INTO dbo.Nums(n) SELECT n+@rc FROM dbo.Nums;
	SET @rc = @rc * 2;
END

INSERT INTO dbo.Nums(n) 
	SELECT n+@rc FROM dbo.Nums WHERE n +@rc <= @max;

GO

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
	
INSERT INTO dbo.Customers(custid,custname)
	SELECT 
		'C' +RIGHT('000000000' + CAST(n as varchar(10)), 10) AS custid,
		N'Cust_'+ CAST(n AS varchar(10)) AS custname
		FROM dbo.Nums 
		WHERE n <= @numcusts;


ALTER TABLE dbo.Customers ADD
	CONSTRAINT PK_Customers PRIMARY KEY(custid);



INSERT INTO dbo.Employees(empid, firstname, lastname)
	SELECT n As empid,
		N'Fname_'+CAST(n as NVarchar(10)) AS firstname,
		N'LName_'+CAST(n as nvarchar(10)) As lastname
		FROM dbo.Nums
		WHERE n <= @numemps;

ALTER TABLE dbo.Employees ADD
	CONSTRAINT PK_Employees PRIMARY KEY(empid);


INSERT INTO dbo.Shippers(shipperid, shippername)
	SELECT shipperid ,N'Shipper_' + shipperid AS shippername
		FROM (SELECT CHAR(ASCII('A') - 2+ 2 * n) as shipperid FROM dbo.Nums WHERE n <= @numshippers) AS D;

ALTER TABLE dbo.Shippers ADD
	CONSTRAINT PK_Shippers PRIMARY KEY(shipperid);

INSERT INTO dbo.Orders(orderid, custid, empid, shipperid, orderdate)
	SELECT n as Orderid,
		'C' + RIGHT('000000000' + CAST( 1 + ABS(CHECKSUM(NEWID())) % @numcusts
				AS VARCHAR(10)), 10) As custid,
			1 + ABS(CHECKSUM(NEWID())) % @numcusts AS empid,
			CHAR(ASCII('A') - 2 + 2  * (1 + ABS(CHECKSUM(NEWID())) % @numshippers)) AS Shipperid,
			DATEADD(day, n / (@numorders / (@numyears * 365.25)), @startdate) -  
						CASE WHEN n % 10 = 0 
							THEN 1 + ABS(CHECKSUM(NEWID())) % 30
							ELSE 0
							END AS OrderDate

						FROM dbo.Nums
						WHERE n <= @numorders
						ORDER BY CHECKSUM(NEWID());


CREATE CLUSTERED INDEX idx_c1_od ON dbo.Orders(orderdate);
CREATE NONCLUSTERED INDEX idx_nc_sid_od_i_cid ON
		dbo.Orders(shipperid, orderdate)
		INCLUDE (custid);

CREATE UNIQUE INDEX idx_unc_od_oid_i_cid_eid ON
		dbo.Orders(orderdate, orderid)
		INCLUDE (custid, empid);

ALTER TABLE dbo.Orders ADD
	--CONSTRAINT PK_Orders PRIMARY KEY NONCLUSTERED(orderid),
	CONSTRAINT FK_Orders_Customers 
		FOREIGN KEY (custid) REFERENCES dbo.Customers(custid),
	CONSTRAINT  FK_Orders_Employees
		FOREIGN KEY (empid) REFERENCES dbo.Employees(empid),
	CONSTRAINT FK_Orders_Shippers
		FOREIGN KEY (shipperid) REFERENCES dbo.Shippers(shipperid);

GO







