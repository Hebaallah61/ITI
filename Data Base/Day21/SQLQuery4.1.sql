
                                             /*Day 5 DB*/
use AdventureWorks2012


--1.Display the SalesOrderID, ShipDate of the SalesOrderHeader table (Sales schema) to show SalesOrders that occurred within the period ‘7/28/2002’ and ‘7/29/2014’
select SalesOrderID ,s.shipDate from sales.SalesOrderHeader s where s.OrderDate between '7/28/2002' and '7/29/2014'

--2.Display only Products(Production schema) with a StandardCost below $110.00 (show ProductID, Name only)
select p.ProductID, p.Name from Production.Product p where  StandardCost<110.00

--3.Display ProductID, Name if its weight is unknown
select p.ProductID, p.Name from Production.Product p where p.Weight is null

--4.Display all Products with a Silver, Black, or Red Color
select p.ProductID, p.Name  from Production.Product p where Color in ('silver','black','red')

--5.Display any Product with a Name starting with the letter B
select p.ProductID, p.Name  from Production.Product p where Name like 'b%'

--6.Run the following Query
--UPDATE Production.ProductDescription
--SET Description = 'Chromoly steel_High of defects'
--WHERE ProductDescriptionID = 3
--Then write a query that displays any Product description with underscore value in its description.
update  Production.ProductDescription
set Description = 'Chromoly steel_High of defects' WHERE ProductDescriptionID = 3

select * from Production.ProductDescription where Description like '%[_]%'

--7.Calculate sum of TotalDue for each OrderDate in Sales.SalesOrderHeader table for the period between  '7/1/2001' and '7/31/2014'
select sum(TotalDue), OrderDate from  Sales.SalesOrderHeader where OrderDate between '7/1/2001' and '7/31/2014'  group by OrderDate 

--8.Display the Employees HireDate (note no repeated values are allowed)
select distinct hiredate from HumanResources.Employee

--9.Calculate the average of the unique ListPrices in the Product table
select avg(ListPrice) from(select distinct  ListPrice from Production.Product ) as t 

--10.Display the Product Name and its ListPrice within the values of 100 and 120 the list should has the following format
--"The [product name] is only! --[List price]" (the list will be sorted according to its ListPrice value)
select concat ('the ',p.Name,' ','is only',convert(nvarchar(30),p.ListPrice)) List from Production.Product p 
where p.ListPrice between 100 and 120 order by p.ListPrice

--11.	

--a)Transfer the rowguid ,Name, SalesPersonID, Demographics from Sales.Store table  in a newly 
--created table named [store_Archive]
select s.rowguid, s.Name, s.SalesPersonID,s.Demographics into Sales.[store_archive] from sales.Store s
select * from Sales.store_archive

--Note: Check your database to see the new table and how many rows in it?//701
--b)Try the previous query but without transferring the data? 
select s.rowguid, s.Name, s.SalesPersonID,s.Demographics into Sales.[store_AArchive] from sales.Store s where 1=2
select * from Sales.store_AArchive 
--12.Using union statement, retrieve the today’s date in different styles using convert or format funtion.
select CONVERT(nchar(20),GETDATE()) datesty union select CONCAT(year(getdate()),'/',month(getdate()),'/',day(getdate()))
union select format(getdate(),'d','sa-us') 
