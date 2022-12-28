/*1.Create the following tables with all the required information and load the required data as specified in each table using insert statements[at least two rows]*/
create table Department(
DeptNo int primary key,
DeptName varchar(20),
Location varchar(50)
)
sp_addtype loc,'nchar(2)'
create rule r1 as @x in('NY','DS','KW')
create default def1 as 'NY'
sp_bindefault def1,loc
sp_bindrule r1,loc

insert into dbo.Department values(1,'Research','NY')
insert into dbo.Department values(2,'Accounting','DS')
insert into dbo.Department values(3,'Markiting','KW')

alter table department alter column location loc 


create table Employee(
EmpNo  int primary key,
Fname varchar(20) not null,
Lname varchar(20) not null,
DeptNo int ,
Salary int,
constraint c1 foreign key(DeptNo)references Department(DeptNo),
constraint c2 unique(Salary)
)

insert into dbo.Employee values(25348,'Mathew','Smith','3',2500)
insert into dbo.Employee values(10102,'Ann','Jones','3',6500)

create rule r2 as @x>6000
sp_bindrule r2,'employee.Salary'

alter table employee add TelephoneNumber int
alter table employee drop column TelephoneNumber 

/*2.Create the following schema and transfer the following tables to it 
a.Company Schema 
i.Department table (Programmatically)
ii.Project table (using wizard)
b.Human Resource Schema
i.Employee table (Programmatically)
*/
create schema company 
alter schema company transfer Department
alter schema company transfer project
create schema HR
alter schema hr transfer company.Employee 

/*3.	 Write query to display the constraints for the Employee table.*/
sp_helpconstraint 'hr.Employee '

/*4.Create Synonym for table Employee as Emp and then run the following queries and describe the results
a.Select * from Employee
b.Select * from [Human Resource].Employee
c.Select * from Emp
d.Select * from [Human Resource].Emp
*/
create synonym emp for hr.employee

Select * from Employee /*invalid*/ 
Select * from [HR].Employee/*done*/
Select * from Emp /*done*/
Select * from [HR].emp/*invalid*/

/*5.Increase the budget of the project where the manager number is 10102 by 10%.*/
update company.project set budget +=(budget*0.1) from hr.employee
where EmpNo in(select empno from Works_on where empno=10102)

/*6.Change the name of the department for which the employee named James works.The new department name is Sales.*/
update company.Department set DeptName='Sales' from hr.employee where Fname=(select fname from hr.employee where fname='James') 

/*7.Change the enter date for the projects for those employees who work in project p1 and belong to department ‘Sales’. The new date is 12.12.2007.*/
update works_on set Enter_Date='2007.12.12' where EmpNo in (select EmpNo from hr.employee,company.Department where ProjectNo=1 and  DeptName='sales')

/*8.Delete the information in the works_on table for all employees who work for the department located in KW.*/
delete works_on from works_on inner join company.Department cd on    cd.Location='KW' 

delete from works_on where empno in
(select e.empno from works_on e,hr.employee h, company.department d where e.empno=h.empno and h.deptno=d.deptno and location='kw')