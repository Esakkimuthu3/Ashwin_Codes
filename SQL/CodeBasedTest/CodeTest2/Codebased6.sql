--1.Code1

CREATE DATABASE codebasedtest6;

CREATE TABLE Code_Employees (
    empno int PRIMARY KEY,
    empname varchar(35),
    empsal decimal(10,2) NOT NULL CHECK (empsal > 0),
    emptype char(1) CHECK (emptype IN ('F', 'P'))
);

CREATE PROCEDURE AddEmployees
    @empno int,
    @empname varchar(35),
    @empsal decimal(10,2),
    @emptype char(1)
AS
BEGIN
    INSERT INTO Code_Employees(empno, empname, empsal, emptype)
    VALUES (@empno, @empname, @empsal, @emptype)
END;
--select* from Employee
 
EXEC AddEmployees 7369,'Smith',8000.00,'F'
EXEC AddEmployees 7499,'Allen',5001.00,'P'
EXEC AddEmployees 7521,'Ward',6000.00,'F'
EXEC AddEmployees 7566,'Jones',2975.00,'P'

--select*from Code_Employees

--2.Code2

-- Declare the variables for the cursor
DECLARE @empnum NUMERIC(4);
DECLARE @salary INT;

 

-- Declare the cursor
DECLARE employee_cursors CURSOR FOR
SELECT empno, salary
FROM employee
WHERE deptno = 10;

 

-- Open the cursor
OPEN employee_cursors;

 

-- Fetch the first row
FETCH NEXT FROM employee_cursors INTO @empnum, @salary;

 

-- Loop through the cursor
WHILE @@FETCH_STATUS = 0
BEGIN
    -- Update the salary with a 15% increase
    UPDATE employee
    SET salary = salary * 1.15
    WHERE empno = @empnum;

 

    -- Fetch the next row
    FETCH NEXT FROM employee_cursors INTO @empnum, @salary;
END

 

-- Close and deallocate the cursor
CLOSE employee_cursors;
DEALLOCATE employee_cursors;

--Select the updated value for verification
SELECT * FROM Employee WHERE deptno = 10;




