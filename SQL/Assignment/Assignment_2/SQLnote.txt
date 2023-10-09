create Database Assignment_2;



create table Employee(
empno int primary key,
ename varchAR(40),
job varchar(40) NOt Null,
mgr_id int Not Null,
hiredate Date,
salary int check(salary >0),
comm int,
Deptno int,
Foreign Key (Deptno) references  Department(Deptno));

create table Department(
Deptno int primary key,
dname varchar(40),
Loc varchar(40));

select * from Department;
Select * from Employee;

Alter table Employee
Alter column  mgr_id int;

INSERT INTO Employee VALUES
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10);


INSERT INTO Department VALUES
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');

-- List the name whose name starts with A

select ename from Employee where ename like 'a%';

-- Select all those employees who don't have a manager

select ename from Employee where mgr_id is null;

-- List employee name, number and salary for those employees who earn in the range 1200 to 1400.

select ename, empno , salary from Employee where salary between 1200 and 1400;

-- Give all the employees in the RESEARCH department a 10% pay rise. Verify that this has been done by listing all their details before and after the rise.

select ename , salary as Before_rise from Employee as e, Department as d where d.dname = 'RESEARCH' and e.Deptno = d.Deptno  

Update Employee 
set salary = salary*1.10 where salary = (select salary from Employee as e , Department as d where d.dname = 'RESEARCH'and e.Deptno = d.Deptno )
select salary as After_rise from Employee as e , Department as d where d.dname = 'RESEARCH' ;


-- Find the number of CLERKS employed. Give it a descriptive heading.

select COUNT(job) as CountOfClerk from Employee where job = 'CLERK';

-- Find the average salary for each job type and the number of people employed in each job.

select job, AVG(salary) as AverageSalary , count(job) as CountOfEmployee
from Employee 
group by job;

-- List the employees with the lowest and highest salary. 

select ename, salary from Employee where salary in ( 
select min(salary)  from Employee 
union 
select max(salary) from Employee);

-- List full details of departments that don't have any employees.

select d.deptno,d.dname, d.Loc from Employee e right join Department d on e.Deptno = d.Deptno
group by 
    d.Deptno, d.dname, d.Loc
having 
    count(e.empno) = 0;

-- Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name.

select ename, salary from Employee where job = 'ANALYST' and salary > 1200
order by ename;

-- For each department, list its name and number together with the total salary paid to employees in that department. 

select d.Deptno, d.dname, sum(e.salary) as TotalSalary from Department d, Employee e where d.Deptno = e.Deptno group by d.Deptno, d.dname;

-- Find out salary of both MILLER and SMITH.

select ename, salary from Employee where ename = 'MILLER'
union
select ename, salary from Employee where ename = 'SMITH';

-- Find out the names of the employees whose name begin with ‘A’ or ‘M’.

select ename from Employee where ename like 'A%'
union
select ename from Employee where ename like 'M%';

--Compute yearly salary of SMITH. 

select ename as EmployeeName , salary * 12 as YearlySalary from Employee where ename = 'SMITH';

-- List the name and salary for all employees whose salary is not in the range of 1500 and 2850.

select ename as EmployeeName , salary from Employee where salary not between 1500 and 2850;

-- Find all managers who have more than 2 employees reporting to them

select mgr_id ,COUNT(empno) as CountOfEmployee from Employee 
group by mgr_id 
having COUNT(empno) > 2;