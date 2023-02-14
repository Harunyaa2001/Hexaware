--Assignment 1
create database shopping
create table customer_master(
CUSTOMER_NUMBER varchar(100) not null,
FIRSTNAME varchar(100) not null,
MIDDLENAME varchar(100),
LASTNAME varchar(70)not null,
CUSTOMER_CITY varchar(100)not null,
CUSTOMER_CONTACT_NO varchar(100)not null,
OOCUPATION varchar(10)not null,
CUSTOMER_DATE_OF_BIRTH DATE not null,
constraint customer_custid_pk primary key(CUSTOMER_NUMBER)
)
insert into customer_master values
('C00001','RAMESH','CHANDRA','SHARMA','DELHI',9876543211,'SERVICE','1976-12-06'),
('C00002','AVINASH','SUNDAR','MINHA','DELHI',9988776655,'SERVICE','1974-10-16'),
('C00003','RAHUL','NULL','RASTOGI','DELHI',8976543210,'STUDENT','1981-09-26'),
('C00004','PARUL','NULL','GANDHI','MUMBAI',7654891234,'HOUSEWIFE','1976-11-03'),
('C00005','NAVEEN','CHANDRA','AEDEKAR','KOLKATA',9098765644,'SERVICE','1976-09-19'),
('C00006','CHITRESH','NULL','BARWE','MUMBAI',7654123455,'STUDENT','1992-11-06'),
('C00007','AMIT','KUMAR','BORKAR','KOLKATA',8966731290,'STUDENT','1981-09-06'),
('C00008','NISHA','NULL','DAMLE','CHENNAI',8895647321,'SERVICE','1975-12-03'),
('C00009','ABHISHEK','NULL','NAIR','CHENNAI',8765438900,'HOUSEWIFE','1973-05-12')
select * from customer_master

--city names without duplicate
select distinct CUSTOMER_CITY 
from customer_master

--middle name null
select * from customer_master
where MIDDLENAME='NULL'

--asc order on firstname
select * from customer_master
order by FIRSTNAME

--desc order date, asc order firstname on occupation
select * from customer_master
order by CUSTOMER_DATE_OF_BIRTH desc

--no of customers from each city
select CUSTOMER_CITY,count(CUSTOMER_NUMBER) as from customer_master
group by CUSTOMER_CITY

--no of customers diff occupation
select OOCUPATION, count(CUSTOMER_NUMBER) as CUSTOMERS from customer_master
group by OOCUPATION

--Assignment 2
-- customer_master table from assign 1
create branch_master(
branch_id varchar(50) identity primary key,
branch_name varchar(50),
branch_city varchar(50)
)

create table loan_details(
loan_amount dec(10,2),
branch_id varchar(50),
constraint fk_customer_number foreign key(customer_number) references customer_master(CUSTOMER_NUMBER)
)

create table account_master(
account_number bigint identity primary key,
constraint fk_customer_number foreign key(customer_number) references customer_master(CUSTOMER_NUMBER

--Assignment 3
/* declare the variable to capture the total product count from production.products table 
and assign the count of products from the same table and display the product count*/

set nocount off --to avoid row affected msg in the result 
declare @productcount int
set @productcount=(select count(*) from production.products)
select @productcount
print @productcount

--stored procedure to take gender and deptid as input and display employee name,gender,salary
create table tblemployee(
id int identity primary key,
name varchar(20),
gender varchar(20),
salary decimal(10,2),
departmentid varchar(30))
insert into tblemployee values
('Mark','Male',8000,1),
('John','Male',5000,1),
('Pam','Male',7000,2),
('Ben','Male',8500,2),
('Jenila','Female',10000,3),
('Vanathi','Female',8000,4),
('Anita','Female',4000,3)
create proc emptab(@gender varchar(20),@departmentid varchar(30))
as
select name,gender,salary from tblemployee
where gender=@gender and departmentid=@departmentid
drop proc emptab
exec emptab 'Male',2
drop proc emptab

--total employee count by gender 
create proc emptab
as
select gender,count(id) as Totalempcount from tblemployee
group by gender
exec emptab
drop proc emptab

--stored procedure to take gender and deptid as input,totalempcount as output and display employee name,gender,salary and total emp based on gender and departmentid
create proc emptab(@gender varchar(20),@departmentid varchar(30),@totalempcount int output)
as
BEGIN
select name,gender,salary from tblemployee
where gender=@gender and departmentid=@departmentid
group by gender,departmentid
select @totalempcount=@@rowcount
END
declare @count int;                       ------------error 
exec emptab 'Male',2,@totalempcount=@count output 
select @count as 'totalempcount'
drop proc emptab

--user defined stored procedure to display “welcome to SQL Server” as message
declare @message varchar(100);
set @message='WELCOME TO SQL SERVER';
print @message

--stored procedure two add thee number and display the sum of three numberas output. If 
--user does not pass values for input params give default value sum as output
declare @no1 int 
declare @no2 int
declare @no3 int 
declare @res int 
set @no1=5;
set @no2=10;
set @no3=15;
set @res=@no1+@no2+@no3;
select @res
print @res

--Assign 4 function to display student info by branchid
---         ''            ''     ''     ''     gender 
create table newstu(
id int identity primary key,
name varchar(50),
gender varchar(10),
branchid varchar(30))
insert into newstu values
('madhu','female','IT001'),
('anu','female','CS002'),
('aakash','male','ECE003'),
('anirudh','male','IT001'),
('mathi','female','CSE002')
-- function to display student information by branchid and gender 
create function newstufun(@branch varchar(30))
 returns table 
 as 
 return (
 select name,gender,branchid from newstu
 where branchid=@branch)
 select * from dbo.newstufun('IT001')

 alter function newstufun(@gender varchar(10))
 returns table 
 as
 return(
 select * from newstu
 where gender=@gender)
 select * from dbo.newstufun('female')

 --create a function to calculate net sales amount from all order_id.
 use BikeStores
 create function sales()
 returns table 
 as 
 return(
 select order_id,sum(list_price) as netsales from sales.order_items
 group by order_id
 )
 select * from dbo.sales()

--Assignment on subquery 
-- list out the product details which is not at all sold.
select * from tblproducts
select * from tblproductslaes
select id,name,description from tblproducts where id in(select productid from tblproductslaes
where quantitysold=0)