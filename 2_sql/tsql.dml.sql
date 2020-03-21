use AdventureWorks2017;
go

--select
select firstname, lastname
from Person.Person;

select firstname, lastname
from person.person
where LastName='adams';

select firstname, lastname, MiddleName
from person.person
where LastName='adams' and MiddleName is null;

select firstname, lastname, MiddleName
from person.person
where LastName='adams' and MiddleName like '[a-z]_%';
-- % = wildcard, _ = exactly, [] = within

--join
select pp.FirstName, pp.LastName, pa.addressline1, pa.city
from Person.Address as pa
inner join Person.BusinessEntityAddress as pbea on pbea.AddressID = pa.AddressID
left join Person.Person as pp on pp.BusinessEntityID = pbea.BusinessEntityID
where pp.LastName='adams';

--subquery
select pp.FirstName, pp.LastName, pa.addressline1, pa.city
from Person.Address as pa
inner join Person.BusinessEntityAddress as pbea on pbea.AddressID = pa.AddressID
left join
(
  select businessentityid, firstname, lastname
  from Person.Person
  where LastName='adams'
) as pp on pp.BusinessEntityID = pbea.BusinessEntityID

--cte
with persons as
(
  select businessentityid, firstname, lastname
  from Person.Person
  where LastName='adams'
)

select persons.FirstName, persons.LastName, pa.addressline1, pa.city
from Person.Address as pa
inner join Person.BusinessEntityAddress as pbea on pbea.AddressID = pa.AddressID
left join persons on persons.BusinessEntityID = pbea.BusinessEntityID;
