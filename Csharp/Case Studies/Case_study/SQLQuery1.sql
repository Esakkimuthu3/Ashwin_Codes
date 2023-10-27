create database StudentandCourse; 
--create table NivedKDetails(id int primary key)
--insert into nivedkdetails values(102)
select * from nivedkdetails
create table course (id int primary key, name varchar(50));
create table student(id int primary key, name varchar(100), dob datetime, cid int , Foreign key (cid) references course(id));

select*from course
select * from student