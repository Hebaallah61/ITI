--1.Create a cursor for Employee table that increases Employee salary by 10% if
--Salary <3000 and increases it by 20% if Salary >=3000. Use company DB
declare c1 cursor
for select Salary from Employee
for update

declare @sal int
open c1
fetch c1 into @sal    --counter=0
while @@FETCH_STATUS=0
	begin
		if (@sal<3000)
			update Employee
				set Salary = @sal*1.1
				where current of c1
		else if (@sal<3000)
			update Employee
				set Salary =@sal*1.2
				where current of c1
		fetch c1 into @sal
	end
close c1
deallocate c1

--2.Display Department name with its manager name using cursor. Use ITI DB
declare c1 cursor
for select Dept_Name , Ins_Name
from Department d inner join Instructor i on i.Ins_Id = d.Dept_Manager
for read only

declare @Dept_name nvarchar(20), @mgr_name nvarchar(20)
open c1
fetch c1 into @Dept_name, @mgr_name
while @@FETCH_STATUS = 0
	begin
		select @Dept_name as Depart, @mgr_name as maneger
		fetch c1 into @Dept_name, @mgr_name
	end
close c1
deallocate c1
--3.Try to display all students first name in one cell separated by comma. Using Cursor 
declare c1 cursor 
for select St_Fname from Student where St_Fname is not null
for read only

declare @name nvarchar(20), @all_names nvarchar(200)=''
open c1
fetch c1 into @all_names
while @@FETCH_STATUS=0
	begin
		fetch c1 into @name
		set @all_names = CONCAT(@all_names, ', ', @name)
	end
	select @all_names
close c1
deallocate c1
--4.Create full, differential Backup for SD DB.
/*DB->tasks-> backup->ful or defferential or transactional*/

--5.Use import export wizard to display students data (ITI DB) in excel sheet
/*excel file---Data->from other sources->sql server */

--6.Try to generate script from DB ITI that describes all tables and views in this DB
/*DB-> tasks-> generate scripts*/

--7.Create a sequence object that allow values from 1 to 10 without cycling in a specific column and test it.
create SEQUENCE mys10  
    START WITH 1  
    INCREMENT BY 1 
	MinValue 1
	MaxValue 10
	NO CYCLE
GO  

create table testsq(col int)
create table testsq1(col int)
insert into testsq values (NEXT VALUE FOR mys10)
insert into testsq1 values (NEXT VALUE FOR mys10)