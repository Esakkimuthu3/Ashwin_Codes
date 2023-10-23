--1.Code1

CREATE DATABASE codebasedtest6;

CREATE TABLE Code_Employees (
    empno int PRIMARY KEY,
    empname varchar(35),
    empsal decimal(10,2) NOT NULL CHECK (empsal > 0),
    emptype char(1) CHECK (emptype IN ('F', 'P'))
);

CREATE PROCEDURE AddEmployeese
    
    @empname varchar(35),
    @empsal decimal(10,2),
    @emptype char(1)
AS
BEGIN
   declare @empno int;
    set @empno = (select isnull(max(empno), 0) + 1 from Code_Employees);
    INSERT INTO Code_Employees(empno, empname, empsal, emptype)
    VALUES (@empno, @empname, @empsal, @emptype)
END;
--select* from Employee
 
EXEC AddEmployeese 'Smith',8000.00,'F'
EXEC AddEmployeese 'Allen',5001.00,'P'
EXEC AddEmployeese 'Ward',6000.00,'F'
EXEC AddEmployeese 'Jones',2975.00,'P'

--select*from Code_Employees



--2.Code2


DECLARE @empnum NUMERIC(4);
DECLARE @salary INT;
DECLARE employee_cursors CURSOR FOR
SELECT empno, salary
FROM employee
WHERE deptno = 10;
OPEN employee_cursors;
FETCH NEXT FROM employee_cursors INTO @empnum, @salary;
WHILE @@FETCH_STATUS = 0
BEGIN
    UPDATE employee
    SET salary = salary * 1.15
    WHERE empno = @empnum;
    FETCH NEXT FROM employee_cursors INTO @empnum, @salary;
END;

CLOSE employee_cursors;
DEALLOCATE employee_cursors;
SELECT * FROM Employee WHERE deptno = 10;




