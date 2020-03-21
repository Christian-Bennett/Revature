use pizzaboxdb;
go

--select
select name
from crust
where price > 0
group by name, price
having price > 1.50
order by name desc;

--order of execution
-- FROM
-- WHERE
-- GROUP BY
-- HAVING
-- SELECT
-- ORDER BY


use AdventureWorks2017;
go

--DML

--select
select *
from Person.Person
where FirstName='john' or LastName='john';

select lastname
from Person.Person
where LastName='johnson'
group by LastName;

select sum(count(lastname)) as [...and counting]
from Person.Person
group by LastName
having count(*) > 1;

select sum(t.counting)
from 
(
  select count(lastname) as [counting]
  from Person.Person
  group by LastName
  having count(*) > 1
) as t;

select pp.lastname
from person.person as pp;