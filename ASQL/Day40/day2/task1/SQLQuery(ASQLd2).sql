--1.Create a scalar function that takes date and returns Month name of that date.

alter function monthsname(@mdate date)
returns varchar(20)

begin
declare @mname varchar(20)
select @mname=format(@mdate,'MMMM')
return @mname
end

select dbo.monthsname('12-26-2020')

--2.Create a multi-statements table-valued function that takes 2 integers and returns the values between them.
alter function rangebetween(@x int, @y int)
returns @t table(rang int)
as
begin
if(@x<@y)
	while @x<@y
	begin
       insert into @t 
	   values(@x)
	   set @x=@x+1
	   end
return 
end

select* from dbo.rangebetween(10,20)


--3.Create inline function that takes Student No and returns Department Name with Student full name.
alter function dapname(@st_id int) 
returns table
as 
return(
select d.dept_name,St_Fname+' '+St_Lname as fullname from student e,Department d where d.Dept_Id=e.Dept_Id and @st_id=st_id 
)

select* from dbo.dapname(1)
--4.Create a scalar function that takes Student ID and returns a message to user 
--a.If first name and Last name are null then display 'First name & last name are null'
--b.If First name is null then display 'first name is null'
--c.If Last name is null then display 'last name is null'
--d.Else display 'First name & last name are not null'
alter function messageuser(@st_id int)
returns varchar(50)

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
return @m1
end

select dbo.messageuser(2)


--5.Create inline function that takes integer which represents manager ID and displays department name, Manager Name and hiring date 
alter function display(@m_id int) returns table
as 
return (
select d.dept_name,i.[Ins_Name],d.manager_hiredate  from Instructor i,Department d 
where  i.Ins_Id=d.Dept_Manager and  d.Dept_Manager=@m_id
--i.Dept_Id=d.Dept_Manager and @m_id=i.Ins_Id
)

select *from dbo.display(1)

--6.Create multi-statements table-valued function that takes a string
--If string='first name' returns student first name
--If string='last name' returns student last name 
--If string='full name' returns Full Name from student table 
--Note: Use “ISNULL” function

create function messagestring(@m varchar(50))
returns @t table (names varchar(20))

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
return
end

select * from messagestring('full name')

--7.Write a query that returns the Student No and Student first name without the last char
select st_id, substring(st_fname,1,len(st_fname)-1)from student

--8.Wirte query to delete all grades for the students Located in SD Department 

delete s from stud_course s inner join student st on st.st_id=s.st_id inner join Department d
on d.dept_id=st.dept_id and d.dept_name='sd'

--Bonus:
--1.Give an example for hierarchyid Data type
create table shapes(
node hierarchyid not null,
[shape Name] nvarchar(20) not null,
[shape Type] nvarchar(20) 
)
insert shapes values ('/1/1/','circle','shape'),('/1/2/','eclips','shape'),('/2/1/','triangle','shape'),('/2/2/','square','shape'),
('/1/','first','shape1'),('/2/','second','shape2'),('/3/','three','shape3'),('/1/1/1/','cirve','symbol'),('/1/2/1/','line','symbol'),
('/1/3/1/','strline','symbol'),('/2/1/1/','4line','symbol'),('/2/2/1/','4line','symbol'),('/','geshape','lines')

select node,node.ToString() as nodetext,node.GetLevel() nodelevel,[shape Name],[shape Type] from shapes
order by nodelevel




--2.Create a batch that inserts 3000 rows in the student table(ITI database). 
--The values of the st_id column should be unique and between 3000 and 6000.
--All values of the columns st_fname, st_lname, should be set to 'Jane', ' Smith' respectively.

declare @x int=3000
while @x<6000
begin
insert into student (st_id,St_Fname,St_Lname)
values(@x,'jane','smith')
set @x=@x+1
end


