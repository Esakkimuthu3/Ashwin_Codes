
--1. Write a T-SQL Program to find the factorial of a given number.


DECLARE @n INT, @fact BIGINT; 
SET @fact = 1; 
SET @n = 5; 
WHILE @n > 1
BEGIN     
SET @fact = @fact * @n;     
SET @n = @n - 1; 
END  
SELECT @fact AS Factorial;

--2. Create a stored procedure to generate multiplication tables up to a given number.

CREATE PROCEDURE GenerateMultiplicationTables    
@n INT 
AS 
BEGIN     
-- Declare variables     
DECLARE @i INT, @result INT;     
-- Initialize variables     
SET @i = 1;    
-- Generate multiplication tables     
WHILE @i <= 10     
BEGIN         
SET @result = @n * @i;         
PRINT CONCAT(@n, ' * ', @i, ' = ', @result);         
SET @i = @i + 1;     
END
END

EXEC GenerateMultiplicationTables @n = 65;

--3.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc.


create table Holidaysof
(holiday_date Date Primary Key, Holiday_name nvarchar(max));


INSERT INTO HOLIDAYsof values('2023-01-01','NewYear'),('2023-08-15','Independence Day'),('2023-10-27','Diwali'),('2023-12-25','Christmas');
INSERT INTO Holidaysof values('2023-10-14','Homieday');

--drop table HOLIDAY

CREATE TRIGGER RestrictDataManiOH
ON Employee 
FOR INSERT, UPDATE, DELETE 
AS 
BEGIN     
DECLARE @Holiday_name VARCHAR(50), @holiday_date DATE
SET @holiday_date = CONVERT(DATE, GETDATE())
SELECT @Holiday_name = Holiday_name     
FROM Holidaysof     
WHERE holiday_date = @holiday_date 
IF @holiday_name IS NOT NULL     
BEGIN         
ROLLBACK TRANSACTION        
RAISERROR('Due to %s, you cannot manipulate data', 16, 1, @holiday_name)     
END 
END 

insert into Employee values(7888,'ashwin','analyst',6767,'2013-07-09',6000,1000,10);

update Employee
set salary = salary*1.10;


