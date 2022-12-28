--1)Create view named   “v_clerk” that will display employee#,project#, 
--the date of hiring of all the jobs of the type 'Clerk'.
Create view v_clerk
as
	Select empno,projectno,enter_date 
	from Works_on
	where Job='Clerk'


select * from v_clerk

--2)Create view named  “v_without_budget” that will display all the projects data 
--without budget
Create view v_without_budget
as
	Select  [ProjectNo],[ProjectName]
	from company.project
	


select * from v_without_budget

--3)Create view named  “v_count “ that will display the project name and the # of jobs in it
Create view v_count
as
	Select count(job) as njob,p.ProjectName
	from Works_on w,company.Project p 
	where p.ProjectNo=w.ProjectNo
	group by ProjectName
	


select * from v_count
--4)Create view named ” v_project_p2” that will display the emp#  for the project# ‘p2’
--use the previously created view  “v_clerk”
alter view v_project_p2
as
	Select empno
	from v_clerk
	where projectno=2
	

select * from v_project_p2 ---??

--5)modifey the view named  “v_without_budget”  to display all DATA in project p1 and p2 
alter view v_without_budget
as
	Select *
	from company.project
	where ProjectName in('p1' , 'p2' )
	


select * from v_without_budget

--6)Delete the views  “v_ clerk” and “v_count”
drop view v_clerk
drop view v_count

--7)Create view that will display the emp# and emp lastname who works on dept# is ‘d2’
Create view vs
as
	Select EmpNo,lname
	from company.Department d,emp p
	where d.DeptNo=p.DeptNo and d.DeptNo=2
	
	
select * from vs

--8)Display the employee  lastname that contains letter “J”
--Use the previous view created in Q#7

select lname from vs where lname like '%j%'

--9)Create view named “v_dept” that will display the department# and department name.
Create view v_dept
as
	Select d.DeptNo,d.DeptName
	from company.Department d
	
	
	
select * from v_dept
--10)using the previous view try enter new department data where dept#
--is ’d4’ and dept name is ‘Development’
 insert into v_dept values(4,'Development')

--11)Create view name “v_2006_check” that will display employee#,
--the project #where he works and the date of joining the project
--which must be from the first of January and the last of December 2006.
Create view v_2006_check
as
	Select p.EmpNo,cp.ProjectName,Enter_Date
	from company.Project cp,emp p,Works_on w
	where cp.ProjectNo=w.ProjectNo and p.EmpNo=w.EmpNo and Enter_Date between '1-1-2006' and '12-12-2006'
	
		
select * from v_2006_check