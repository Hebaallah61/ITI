--1.Create a view that displays student full name, course name if the student has a grade more than 50. 
Create view viewstud
as
	Select St_Fname+' '+St_Lname as fullname,crs_name
	from student s,Course c,Stud_Course sc 
	where s.St_Id=sc.St_Id and sc.Crs_Id=c.Crs_Id and Grade>50


select * from viewstud
--2.Create an Encrypted view that displays manager names and the topics they teach. 
create view viewmang 
with encryption
as
	select i.Ins_Name,t.Top_Name  
	from Instructor i,Topic t,Course c ,Ins_Course ic,Department d
	where c.Top_Id=t.Top_Id and i.Ins_Id=ic.Ins_Id and ic.Crs_Id=c.Crs_Id and d.Dept_Manager=i.Ins_Id


select * from viewmang
--3.Create a view that will display Instructor Name, Department Name for the ‘SD’ or ‘Java’ Department 
create view viewinstruct
as
	select i.Ins_Name,d.dept_name from Instructor i,Department d
	where i.Dept_Id=d.Dept_Id and d.Dept_Name in('SD' , 'Java')


select * from viewinstruct


--4.Create a view “V1” that displays student data for student who lives in Alex or Cairo. 
--Note: Prevent the users to run the following query 
--Update V1 set st_address=’tanta’
--Where st_address=’alex’;
create view v1 (sid,sfnam,slnam,sadd,sage,depi,ssup)
as
	select * from Student s
	where s.St_Address in('alex','cairo')

with check option

select * from v1


--5.Create a view that will display the project name and the number of employees work on it.
--“Use SD database”
create view v2 
as
	select p.projectname,count(w.empno) from Company.project p,works_on w
	where p.projectno=w.projectno group by projectname

select * from v2

--6.Create index on column (Hiredate) that allow u to cluster the data in table Department.
--What will happen?
create clustered index i1
on department([Manager_hiredate])/*Cannot create more than one clustered index on table 'department'*/

--7.Create index that allow u to enter unique ages in student table. What will happen? 
create unique index i2
on student([St_Age]) /*The CREATE UNIQUE INDEX statement terminated because a duplicate key*/

--8.Using Merge statement between the following two tables [User ID, Transaction Amount]
create table dailyt
(
userid int primary key,
tamont int,
)

create table lastt(
userid int primary key,
tamont int
)

merge into lastt as l 
using dailyt as d 
on l.userid=d.userid
when Matched then
update 
set l.tamont=d.tamont
when not matched then
insert
values(d.userid,d.tamont);
--(3 rows affected)
select * from lastt
select * from dailyt