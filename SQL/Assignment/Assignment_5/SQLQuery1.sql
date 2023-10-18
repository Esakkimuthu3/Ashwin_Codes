CREATE PROCEDURE GeneratePayslips

AS
BEGIN
    DECLARE @EmpId int
	DECLARE @Salary DECIMAL(10,2)
    DECLARE @HRA DECIMAL(10, 2)
    DECLARE @DA DECIMAL(10, 2)
	DECLARE @PF DECIMAL(10, 2)
    DECLARE @IT DECIMAL(10, 2)
    DECLARE @Deductions DECIMAL(10, 2)
    DECLARE @GrossSalary DECIMAL(10, 2)
    DECLARE @NetSalary DECIMAL(10, 2)
	--Retrieve the values of Employee and salary 
	select @EmpID = empno , @Salary = salary from Employee
    -- Calculate HRA, DA, PF, and IT
    SET @HRA = 0.10 * @Salary
    SET @DA = 0.20 * @Salary
    SET @PF = 0.08 * @Salary
    SET @IT = 0.05 * @Salary
    -- Calculate Deductions
    SET @Deductions = @PF + @IT
    -- Calculate Gross Salary
    SET @GrossSalary = @Salary + @HRA + @DA
    -- Calculate Net Salary
    SET @NetSalary = @GrossSalary - @Deductions
    -- Print the payslip
    PRINT 'Employee Payslip for EmployeeID: ' + CAST(@EmpID AS VARCHAR(10))
    PRINT '-------------------------------'
    PRINT 'Basic Salary: ' + CAST(@Salary AS VARCHAR(10))
    PRINT 'HRA: ' + CAST(@HRA AS VARCHAR(10))
    PRINT 'DA: ' + CAST(@DA AS VARCHAR(10))
    PRINT 'PF: ' + CAST(@PF AS VARCHAR(10))
    PRINT 'IT: ' + CAST(@IT AS VARCHAR(10))
    PRINT 'Deductions: ' + CAST(@Deductions AS VARCHAR(10))
    PRINT 'Gross Salary: ' + CAST(@GrossSalary AS VARCHAR(10))
    PRINT 'Net Salary: ' + CAST(@NetSalary AS VARCHAR(10))
    PRINT '-------------------------------'
END

 

EXEC GeneratePayslips 