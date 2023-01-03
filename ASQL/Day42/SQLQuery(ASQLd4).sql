--1.Create a stored procedure without parameters to show the number of students per department name
--.[use ITI DB] 
create proc show
as
select count(s.St_Id),d.Dept_Name from Student s,Department d where s.Dept_Id=d.Dept_Id group by d.Dept_Name

show
--2.Create a stored procedure that will check for the # of employees in the project p1 if they are
--more than 3 print message to the user “'The number of employees in the project p1 is 3 or more'” 
--if they are less display a message to the user “'The following employees work for the project p1'” 
--in addition to the first name and last name of each one. [Company DB] 
create proc checkf
as
if (select count(e.EmpNo) from hr.Employee e,company.Project p,Works_on w 
where w.EmpNo=e.EmpNo and p.ProjectNo=w.ProjectNo and p.ProjectNo=1)>3 
begin
select 'The number of employees in the project p1 is 3 or more'
end
else
begin
select 'The following employees work for the project p1'
select e.Fname,e.Lname from hr.Employee e ,company.Project p,Works_on w 
where w.EmpNo=e.EmpNo and p.ProjectNo=w.ProjectNo and p.ProjectNo=1
end

checkf

--3.Create a stored procedure that will be used in case there is an old employee has left 
--the project and a new one become instead of him. The procedure should take 3 parameters 
--(old Emp. number, new Emp. number and the project number) and it will be used 
--to update works_on table. [Company DB]
create proc useiff @oldEmp int, @newEmp int , @theproject int
as
begin try
update Works_on  set EmpNo=@newEmp where EmpNo=@oldEmp and ProjectNo=@theproject
end try
begin catch
select 'error '
end catch

drop proc useiff

useiff 1,25348,3

--4.add column budget in project table and insert any draft values in it then 
--then Create an Audit table with the following structure 
create table Audits
(
ProjectNo int,
UserName varchar(100),
ModifiedDate date,
Budget_Old int,
Budget_New int
)
--drop table Audits
create trigger t1
on company.project 
instead of update
as
	if update(budget)
		begin
			declare @no int, @old int,@new int
			select @old=Budget from deleted
			select @new=Budget from inserted
			select @no=Projectno from inserted
			insert into Audits
			values(@no,suser_name(),getdate(),@old,@new)
		end



update company.Project set Budget=5051*2 where ProjectNo=1

--5.Create a trigger to prevent anyone from inserting a new record in the Department table [ITI DB]
--“Print a message for user to tell him that he can’t insert a new record in that table”
create trigger t3
on department
instead of insert
as
	select  'can’t insert a new record in that table'

insert into Department values(4,'m','j','',1,'')

--6.Create a trigger that prevents the insertion Process for Employee table in March [Company DB].
create trigger t2
on hr.employee 
instead of insert
as
if format(getdate(),'MMMM')='March'
		begin
			select 'not allowed'
		end
	else
		insert into hr.employee
		select * from inserted

--7.Create a trigger on student table after insert to add Row in Student Audit table 
--(Server User Name , Date, Note) where note will be 
--“[username] Insert New Row with Key=[Key Value] in table [table name]”
create table Auditstu
(
ServerUserName varchar(100),
Dates date,
Note varchar(100)
)

create trigger t1
on student
after insert
as
	declare @note varchar(300),@id int
	select @id=st_id from inserted
	select @note=convert(varchar(100),convert(varchar(100),suser_name())+'Insert New Row with Key='+convert(varchar(100),@id)+'in table student') 
	insert into Auditstu
	values(suser_name(),getdate(),@note)
drop trigger t1
insert into student (st_id,st_fname) values(9900,'ahmed')

--8.Create a trigger on student table instead of delete to add Row in Student Audit table
--(Server User Name, Date, Note) where note will be“ try to delete Row with Key=[Key Value]”
create trigger t2
on student
instead of delete
as
	declare @note varchar(100)
	select @note=suser_name()+'try to delete Row with Key='+convert(varchar(100),St_Id)+'in table student' from deleted
	insert into Auditstu
	values(suser_name(),getdate(),@note)

	drop trigger t2

--9.Display all the data from the Employee table (HumanResources Schema) 
--As an XML document “Use XML Raw”. “Use Adventure works DB” 
--A)Elements
--B)Attributes
select *
from HumanResources.employee
for xml raw('emp'),elements

select *
from HumanResources.employee
for xml raw('emp')


--10.Display Each Department Name with its instructors. “Use ITI DB”
--A)Use XML Auto
--B)Use XML Path
select d.Dept_Name, i.Ins_Name
from Department d,Instructor i 
where i.Dept_Id=d.Dept_Id
for xml auto

select d.Dept_Name, i.Ins_Name
from Department d,Instructor i 
where i.Dept_Id=d.Dept_Id
for xml path

--11.Use the following variable to create a new table “customers” inside the company DB.
--Use OpenXML

declare @docs xml ='<customers>
              <customer FirstName="Bob" Zipcode="91126">
                     <order ID="12221">Laptop</order>
              </customer>
              <customer FirstName="Judy" Zipcode="23235">
                     <order ID="12221">Workstation</order>
              </customer>
              <customer FirstName="Howard" Zipcode="20009">
                     <order ID="3331122">Laptop</order>
              </customer>
              <customer FirstName="Mary" Zipcode="12345">
                     <order ID="555555">Server</order>
              </customer>
       </customers>'

declare @hdocs int
Exec sp_xml_preparedocument @hdocs output, @docs
select *
from openxml (@hdocs,'//customer')

with (firstname varchar(50) '@FirstName', zipcode int '@Zipcode', orders varchar(50) 'order', ID int 'order/@ID')

exec sp_xml_removedocument @hdocs

--/4

--Bonus :
/*1.Transform all functions in lab2 to be stored procedures*/
--1.Create a scalar function that takes date and returns Month name of that date.

create proc monthsnamep @mdate date
as
begin
declare @mname varchar(20)
select @mname=format(@mdate,'MMMM')
return @mname
end



--2.Create a multi-statements table-valued function that takes 2 integers and returns the values between them.
create proc rangebetweenp @x int, @y int
as
begin
if(@x<@y)
	while @x<@y
	begin
	   declare @t table(rang int)
       insert into @t 
	   values(@x)
	   set @x=@x+1
	   end
	  select * from @t
end

rangebetweenp 20,30

--3.Create inline function that takes Student No and returns Department Name with Student full name.
create proc dapnamep @st_id int 
as 
select d.dept_name,St_Fname+' '+St_Lname as fullname
from student e,Department d where d.Dept_Id=e.Dept_Id and @st_id=st_id 

dapnamep 1


--4.Create a scalar function that takes Student ID and returns a message to user 
--a.If first name and Last name are null then display 'First name & last name are null'
--b.If First name is null then display 'first name is null'
--c.If Last name is null then display 'last name is null'
--d.Else display 'First name & last name are not null'
create proc messageuserp @st_id int
as
begin
declare @m1 varchar(100)
if (select st_fname from student where @st_id=st_id) is NULL
  begin if (select St_Lname from student where @st_id=st_id) is NULL
		set @m1 ='First name & last name are null'

end
else if (select st_fname from student where @st_id=st_id) is NULL
	    set @m1='first name is null'
else if(select St_Lname from student where @st_id=st_id) is NUll
	    set @m1='last name is null'
else
        set @m1='First name & last name are not null'
select @m1
end

messageuserp 2


--5.Create inline function that takes integer which represents manager ID and displays department name, Manager Name and hiring date 
create proc displayp @m_id int  
as 

select d.dept_name,i.[Ins_Name],d.manager_hiredate  from Instructor i,Department d 
where  i.Ins_Id=d.Dept_Manager and  d.Dept_Manager=@m_id



displayp 1

--6.Create multi-statements table-valued function that takes a string
--If string='first name' returns student first name
--If string='last name' returns student last name 
--If string='full name' returns Full Name from student table 
--Note: Use “ISNULL” function

create proc messagestringp @m varchar(50)
as
declare @t table (names varchar(20))
begin
if @m='first name'
begin
  insert into @t 
  select isnull(st_fname,'') from student
  end
else if @m='last name'
begin
  insert into @t
  select isnull(st_lname,'') from student
  end
else if @m='full name'
begin
 insert into @t
 select isnull(st_fname,'')+' '+isnull(st_lname,'') from Student
 end
select * from @t
end

messagestringp 'full name'


/*2.Create a trigger that prevents users from altering any table in Company DB.*/
create trigger denay 
on database
for Alter_table
as  
begin
print 'No tables will be altered today'  
rollback  
end  

create table test(
che int,

)
alter table test add  xcv int
 





