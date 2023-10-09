create database Code_Test1;

--Creation of table books

CREATE TABLE books (
 id INT PRIMARY KEY,
 title VARCHAR(25),
 author VARCHAR(25),
 isbn VARCHAR(25),
 published_date DATETIME
);

INSERT INTO books (id, title, author, isbn, published_date)
VALUES (1, 'My first SQL book', 'Mary Parker', '981483029127', '2012-02-22 12:08:17'),
      (2, 'My Second SQL book', 'John Mayer', '857300923713', '1972-07-03 09:22:45'),
      (3, 'My Third SQL book', 'Cary Flint', '523120967812', '2015-10-18 14:05:44');
	  
--Creation of table reviews

CREATE TABLE reviews (
 id INT PRIMARY KEY,
 book_id INT,
 content VARCHAR(255),
 rating INT,
 reviewer_name VARCHAR(255),
 published_date DATETIME,
 FOREIGN KEY (book_id) REFERENCES books(id)
);

INSERT INTO reviews (id,book_id, content, rating, reviewer_name, published_date)
VALUES (1,1, 'My first review', 4, 'John Smith', '2017-12-10 05:50:10'),
      (2,2, 'My second review', 5, 'John Smith', '2017-10-13 15:05:12'),
      (3,3, 'Another review', 1, 'Alice Walker', '2017-10-22 23:47:10');

--Write a query to fetch the details of the books written by author whose name ends with er.

SELECT author as AUTHOR FROM books where author like '%er';

--Display the Title ,Author and ReviewerName for all the books from the above table .

SELECT b.title, b.author , r.reviewer_name FROM books b, reviews r where b.id = r.book_id;

--Display the  reviewer name who reviewed more than one book.

SELECT reviewer_name FROM reviews group by reviewer_name having count(book_id) > 1;

--Creation of table Customers

CREATE TABLE customers (
 id INT PRIMARY KEY,
 name VARCHAR(25),
 age INT,
 address VARCHAR(25),
 salary DECIMAL(10, 2)
);

INSERT INTO customers (id, name, age, address, salary)
VALUES (1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
      (2, 'Khilan', 25, 'Delhi', 1500.00),
      (3, 'Kaushik', 23, 'Kota', 2000.00),
      (4, 'Chaitali', 25, 'Mumbai',6500.00),
      (5, 'Hardik', 27, 'Bhopal', 8500.00),
      (6, 'Komal', 22, 'Mp', 4500.00),
      (7, 'Muffy', 24, 'Indore', 100000.00);

-- Display the Name for the customer from above customer table  who live in same address which has character o anywhere in address

select name from customers where address like '%o%';

-- Creation of table orders

CREATE TABLE orders (
 Oid INT PRIMARY KEY,
 Date DATETIME,
 cust_id INT,
 amount INT,
 FOREIGN KEY (cust_id) references customers(id)
);

INSERT INTO orders (Oid, Date, cust_id, amount)
VALUES (102,'2009-10-08 00:00:00', 3,3000),
       (100,'2009-10-08 00:00:00', 3,1500),
	   (101,'2009-11-20 00:00:00', 2,1560),
	   (103,'2008-05-20 00:00:00', 4,2060);

--Write a query to display the   Date,Total no of customer  placed order on same Date

SELECT o.Date, count(c.id) AS NumofOrders FROM orders o, customers c where o.cust_id = c.id GROUP BY o.Date HAVING count(c.id)>1;
--

--Creation of table Employee

CREATE TABLE Employee (
 id INT PRIMARY KEY,
 name VARCHAR(25),
 age INT,
 address VARCHAR(25),
 salary DECIMAL(10, 2)
);

INSERT INTO Employee(id, name, age, address, salary)
VALUES (1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
      (2, 'Khilan', 25, 'Delhi', 1500.00),
      (3, 'Kaushik', 23, 'Kota', 2000.00),
      (4, 'Chaitali', 25, 'Mumbai',6500.00),
      (5, 'Hardik', 27, 'Bhopal', 8500.00),
      (6, 'Komal', 22, 'Mp', NULL),
      (7, 'Muffy', 24, 'Indore', NULL);

--Display the Names of the Employee in lower case, whose salary is null 

SELECT Lower(name) as LowerCaseName from Employee where salary  IS NULL;

--creation of table Student details

CREATE TABLE students (
 RegisterNo int,
 Name varchar(25),
 Age int,
 Qualification varchar(25),
 MobileNo varchar(25),
 Mail_id varchar(25),
 Location varchar(25),
 Gender varchar(25)
);

drop table students;


INSERT INTO students (RegisterNo, Name, Age, Qualification, MobileNo, Mail_id, Location,Gender) 
VALUES (2, 'Sai', 22, 'BE', '9952836777', 'Sai@gmai.com', 'Chennai','M'),
       (3, 'Kumar', 20, 'BSC', '7890125648', 'Kumar@gmail.com', 'Madurai','M'),
       (4, 'Selvi', 22, 'B. Tech', '8904567342', 'selvi@gnai.com', 'Salem','F'),
       (5, 'Nisha', 25, 'M.E', '7834672310', 'nisha@gmail.com', 'Theni','F'),
       (6, 'SaiSaran', 21, 'B.A', '7890345678', 'saran@gmai.com', 'Madurai','M'),
       (7, 'Tom', 23, 'BCA', '8901234675', 'Tom@gmail.com', 'Pune','M');


--Write a sql server query to display the Gender,Total no of male and female from the above relation.

SELECT ISNULL(Gender,'Not Assigned') AS Gender, COUNT(RegisterNo) AS 'Total Employee' FROM students
GROUP BY Gender;
                   


