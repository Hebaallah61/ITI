                          /*Day 2 DB*/

use Company_SD

/*1.Display the Department id, name and id and the name of its manager.done*/
select d.Dname,d.Dnum , e.SSN, e.Fname+' '+e.Lname as fullname from Departments d,Employee e where d.MGRSSN=e.SSN
select Dname,Dnum , SSN, Fname+' '+Lname as fullname from Departments ,Employee  where MGRSSN=SSN


/*2.Display the name of the departments and the name of the projects under its control. done*/ 
select Dname, Pname from Departments,Project where Departments.Dnum=Project.Dnum
select Dname, Pname from Departments inner join Project on Departments.Dnum=Project.Dnum


/*3.Display the full data about all the dependence associated with the name of the employee they depend on him/her. done*/
select  d.*,Fname+' '+Lname as fullname from Dependent d,Employee where SSN=ESSN


/*4.Display the Id, name and location of the projects in Cairo or Alex city. done*/
select Pnumber,Pname,Plocation from Project where City in('Cairo','Alex')
select Pnumber,Pname,Plocation from Project where City='Cairo' or City= 'Alex'


/*5.Display the Projects full data of the projects with a name starts with "a" letter.done*/
select * from Project where Pname like 'A%'


/*6.display all the employees in department 30 whose salary from 1000 to 2000 LE monthlydone*/
select Fname+' '+Lname as fullname from Employee where Dno=30 and Salary between 1000 and 2000
select Fname+' '+Lname as fullname,Salary from Employee where Dno=30 and Salary between 1000 and 2000


/*7.Retrieve the names of all employees in department 10 who works more than or equal10 hours per week on "AL Rabwah" project. done*/
select Distinct Fname+' '+Lname as fullname from Employee inner join Works_for  on Dno=10  and Hours>=10 inner join Project on Pname='AL Rabwah'
select Distinct Fname+' '+Lname as fullname from Employee , Works_for, Project  where Dno=10  and Hours>=10 and Pname='AL Rabwah'


/*8.Find the names of the employees who directly supervised with Kamel Mohamed. */
select  e.Fname+' '+e.Lname as Employee_fullname from Employee e,Employee m  where e.Superssn=m.SSN and m.Fname='Kamel' and m.Lname='Mohamed' 


/*9.Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name. done*/
select Fname+' '+Lname as employee,Pname from Employee,Project, Works_for where SSN=ESSn order by Pname


/*10.For each project located in Cairo City , find the project number, the controlling department name ,the department manager last name ,address and birthdate. ??*/
select d.Dnum,e.Lname,p.Pnumber,e.Address,e.Bdate from Departments d,Project p,Employee e where p.City='Cairo' and d.Dnum=p.Pnumber and e.SSN=d.MGRSSN 
select Dname,Lname,Pnumber,Address,Bdate from Departments ,Project ,Employee  where City='Cairo' and Departments.Dnum=Pnumber and SSN=MGRSSN


/*11.Display All Data of the managers done*/
select d.* from Departments d inner join Employee e on e.SSN=d.MGRSSN
select m.* from Departments, Employee m where m.SSN=MGRSSN 

/*12.Display All Employees data and the data of their dependents even if they have no dependents done*/
select e.*,d.* from Employee e left outer join Dependent d on e.SSN=d.ESSN


/*13.Insert your personal data to the employee table as a new employee in department number 30, SSN = 102672, Superssn = 112233, salary=3000. ??*/
insert into Employee values ('hebaallah','ahmed',102672,2000-1-15,'Cairo','f',3000,112233,30)


/*14.Insert another employee with personal data your friend as new employee in department number 30, SSN = 102660, but don’t enter any value for salary or supervisor number to him. ??*/
insert into Employee  (Fname,Lname,ssn,address,sex,Dno) values('nora','ana',102660,'alex','f',30);
/*testing*/
select * from Employee where ssn=102660

/*15.Upgrade your salary by 20 % of its last value. ??*/
update Employee set Salary=Salary+Salary*0.2 where SSN=102660
/*testing*/
select * from Employee 
---------------------------------------------------------------------------------------
