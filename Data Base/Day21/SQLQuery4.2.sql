
                                                /*Day 5 DB*/
use ITI

--1.Retrieve number of students who have a value in their age. 
select COUNT(st_id) from student where st_age is not null 

--2.Get all instructors Names without repetition
select Distinct ins_name from Instructor 

--3.Display student with the following Format (use isNull function)
--Student ID	Student Full Name	Department name
select isNull(st_id,1) ,concat(isnull(st_fname,' '),' ',isnull(st_lname,' ')) as full_name,isnull( Dept_name,'n') from Student s,Department d where d.Dept_Id=s.Dept_Id 

--4.Display instructor Name and Department Name ====
--Note: display all the instructors if they are attached to a department or not
select ins_name,d.dept_name from Instructor i left outer join Department d  on i.Dept_Id=d.Dept_Id 

--5.Display student full name and the name of the course he is taking
--For only courses which have a grade  
select st_fname+' '+st_lname as full_name,crs_name from Student s,Course c,Stud_Course sc where c.Crs_Id=sc.Crs_Id and sc.Grade is not null   

--6.Display number of courses for each topic name
select COUNT(crs_id) as count_number,top_name from Course,Topic group by top_name

--7.Display max and min salary for instructors
select max(salary),min(salary) from Instructor
select salary from Instructor

--8.Display instructors who have salaries less than the average salary of all instructors.
select Ins_Name from instructor where ( select avg(salary) from Instructor ) >(salary) 

--9.Display the Department name that contains the instructor who receives the minimum salary.
select Dept_Name from Department d, Instructor i where d.dept_id=i.Dept_Id and(select MIN(Salary) from instructor)=i.Salary

--10.Select max two salaries in instructor table.
select top(2)salary from Instructor order by salary desc

--11.Select instructor name and his salary but if there is no salary display instructor bonus keyword. “use coalesce Function”
SELECT i.ins_name ,COALESCE(salary,'0')   FROM Instructor i

--12.Select Average Salary for instructors 
select avg(salary) from Instructor

--13.Select Student first name and the data of his supervisor===
select s.St_Fname+' '+s.St_Lname as name_st,m.* from Student s inner join student m on s.St_Id=m.St_super

--14.Write a query to select the highest two salaries in Each Department for instructors who have salaries. “using one of Ranking Functions”
select * from(select * ,row_number() over (partition by dept_id order by salary desc)as DR from Instructor)as newt where DR<=1

--15.Write a query to select a random  student from each department. “using one of Ranking Functions”===
select st_fname,d.dept_name from (select st_fname,Dept_Id,row_number() over (partition by Dept_id
order by newid() desc ) as random from Student )as new
inner join Department d on new.dept_id=d.Dept_Id
where random=1
-------------------------------------------------------------------------------------