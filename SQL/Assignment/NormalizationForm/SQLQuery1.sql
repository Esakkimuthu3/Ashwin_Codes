create database NormalizationForm


-- For 1st NF
create table FirstNF ( ClientNo varchar(10),
cName varchar(20), 
propertyNo varchar(10),
pAddress varchar (30),
rentStart date,
resntFinish date,
rent int,
ownerNo varchar(10),
oName varchar(30));

insert into FirstNF values
('CR76', 'John Kay', 'PG4', '6 lawrence st, Glasgow', '2000-07-01', '2001-10-31', 350, 'C040', 'Tina Murphy') ,
('CR76', 'John Kay', 'PG16', '5 Novar Dr, Glasgow', '2002-09-01', '2002-09-01', 450, 'C093', 'Tony Shaw'),
('CR56', 'Aline Stewars', 'PG4', '6 lawrence st, Glasgow', '1999-09-01', '2000-06-10', 350, 'C040', 'Tina Murphy'),
('CR56', 'Aline Stewars', 'PG36', '2 Manor Rd, Glasgow', '2000-10-10', '2001-12-01', 370, 'C093', 'Tony Shaw'),
('CR56', 'Aline Stewars', 'PG16', '5 Novar Dr, Glasgow', '2002-11-01', '2003-08-01', 450, 'C093', 'Tony Shaw');

select * from FirstNF

--For 2nd and 3rd NF

create table Client (
ClientNO varchar(10) primary key,
cName varchar(20));

insert into Client values
('CR76','John kay'),
('CR56','Aline Stewars');

select * from Client;


create table Owners (
ownerNo varchar(10) primary key,
oName varchar(30));

insert into Owners values
('C040', 'Tina Murphy'),
('C093', 'Tony Shaw');

select * from Owners;


create table property (
propertyNo varchar(10) primary key,
pAddress varchar (30),
ownerNo varchar(10) foreign key references Owners(ownerNo));

insert into property values 
('PG4', '6 lawrence st, Glasgow', 'C040'),
('PG16', '5 Novar Dr, Glasgow', 'C093'),
('PG36','2 Manor Rd, Glasgow','C093');

select * from property;


create table rent (
ClientNo varchar(10)  foreign key references  Client (ClientNo),
propertyNo varchar(10) foreign key references Property (propertyNo),
rentStart date,
rentFinish date,
rent int,
primary key (ClientNo, propertyNo));

insert into rent values 
('CR76', 'PG4', '2000-07-01', '2001-10-31', 350),
('CR76', 'PG16', '2002-09-01', '2002-09-01', 450),
('CR56', 'PG4', '1999-09-01', '2000-06-10', 350),
('CR56', 'PG36', '2000-10-10', '2001-12-01', 370),
('CR56', 'PG16', '2002-11-01', '2003-08-01', 450);

select * from rent;