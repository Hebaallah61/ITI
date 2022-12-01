
                                         /*Day 4 DB*/
use Company_SD

--1.Display (Using Union Function)

--a.The name and the gender of the dependence that's gender is Female and depending on Female Employee.
select distinct dd.Dependent_name from Dependent dd,Employee e where e.Sex='f' and dd.Sex='f'
union all
select dd.Sex from Dependent dd  where dd.Sex='f'

--b.And the male dependence that depends on Male Employee.
select distinct dd.Dependent_name from Dependent dd,Employee e where e.Sex='m' and dd.Sex='m'
union all
select dd.Sex from Dependent dd  where dd.Sex='m'


--2.For each project, list the project name and the total hours per week (for all employees) spent on that project.
select p.Pname,sum(f.Hours) Total_hourse from Works_for f ,Project p
where p.Pnumber=f.Pno
group by p.Pname


--3.Display the data of the department which has the smallest employee ID over all employees' ID.
select d.* from Departments d inner join Employee on Dno=Dnum where SSN=(select min(SSN) from Employee)---

--4.For each department, retrieve the department name and the maximum, minimum and average salary of its employees.
select d.Dname,max(e.Salary),min(e.Salary),avg(e.Salary) from  Employee e inner join Departments d on Dno=Dnum group by d.Dname---

--5.List the full name of all managers who have no dependents.
select e.Fname+' '+e.Lname as manager_name from Employee e inner join Departments on SSN=MGRSSN and MGRSSN not in (select d.ESSN from Dependent d)---


--6.For each department-- if its average salary is less than the average salary of all employees-- 
--display its number, name and number of its employees.
select  d.Dname, d.Dnum, COUNT(e.SSN) as num_employees from  Employee e inner join Departments d on d.Dnum=e.Dno group by d.Dname,d.Dnum 
having (select avg(e.Salary) from  Employee e )<avg(e.Salary)

--7.Retrieve a list of employees names and the projects names they are working on ordered by department number and within each department,--
--ordered alphabetically by last name, first name.
select Fname,Lname,Pname from Project p,Employee e,Works_for w where ESSN=SSN and w.ESSn=e.SSN and p.Pnumber=w.Pno order by Dnum, Fname,Lname

--8.Try to get the max 2 salaries using subquery
select(select max(Salary) from Employee) maxsalary,
  (select max(Salary) from Employee where Salary not in 
  (select max(Salary) from Employee )) as [2nd_max_salary]

--9.Get the full name of employees that is similar to any dependent name
select e.Fname,e.Lname from Employee e,Employee d where e.Fname like d.Fname and e.Lname like d.Lname

--10.Display the employee number and name if at least one of them have dependents (use exists keyword) self-study.
select SSN,Fname from Employee e where  Exists (select ESSN from Dependent d )

--11.In the department table insert new department called "DEPT IT" , with id 100, employee with SSN = 112233 as a manager for this department. The start date for this manager is '1-11-2006'
insert into Departments values('DEPT IT',100,'112233','1-11-2006')

--12.Do what is required if you know that : Mrs.Noha Mohamed(SSN=968574)
--moved to be the manager of the new department (id = 100), and they give you(your SSN =102672) 
--her position (Dept. 20 manager) 
--a.First try to update her record in the department table
update Departments set MGRSSN=968574 where Dnum=100
--b.Update your record to be department 20 manager.
update Departments set MGRSSN=102672 where Dnum=20
--c.Update the data of employee number=102660 to be in your teamwork
--(he will be supervised by you) (your SSN =102672)
update Employee set Superssn=102672 where SSN=102672


--13.Unfortunately the company ended the contract with Mr. Kamel Mohamed (SSN=223344)
--so try to delete his data from your database in case you know that you will be temporarily in his position.
--Hint: (Check if Mr. Kamel has dependents, works as a department manager,
--supervises any employees or works in any projects and handle these cases).
delete from Dependent where ESSN=223344
select * from Works_for where ESSN=102672 -- ESSN=223344
update Works_for set ESSN=102672 where ESSN=223344 --4rows 
select * from Departments where MGRSSN=223344
update Departments set MGRSSN=102672
select * from Employee where Superssn=223344--2
update Employee set Superssn=102672 where Superssn=223344
delete from Employee where SSN=223344


--14.Try to update all salaries of employees who work in Project ‘Al Rabwah’ by 30%
update Employee set Salary=Salary+0.3*Salary where SSN in (select SSN from Employee inner join Works_for on SSN=ESSN  where Pno=(select Pnumber from Project where Pname='Al Rabwah')  ---