/*creating database*/

drop database if exists Food;
create database Food;
use Food;

/*creating users*/

CREATE USER 'FoodAdmin'@'localhost' IDENTIFIED BY  '1234';
GRANT ALL PRIVILEGES ON Food.* TO 'FoodAdmin'@'localhost';

CREATE USER 'FoodUser'@'%' IDENTIFIED BY  '1234';
GRANT SELECT, INSERT, UPDATE, DELETE ON Food.* TO 'FoodUser'@'%';

/*creating Tables*/

create table Accounts
(
	id int not null primary key,
    fullName varchar(32),
    userName varchar(16) not null,
    paswd varchar(256) not null,
    email varchar(32) not null,
    salt varchar(64) not null,
    role varchar(16) not null,
    dietEnd dateTime not null
);

create table Days
(
	id integer not null primary key,
    dateDay dateTime not null
);

create table Meals
(
	id smallint not null primary key,
    items text not null
);

create table MealDayConnector
(
	id bigint not null primary key,
    dayId integer not null,
    mealId smallint not null
);

/*creating constraints*/

alter table Accounts add constraint c_uEmail unique(email);
alter table Accounts add constraint c_uUserName unique(userName);
alter table MealDayConnector add constraint c_fkDay foreign key c_fkDay(dayId) references Days(id) on update restrict on delete restrict;
alter table MealDayConnector add constraint c_fkMeal foreign key c_fkDay(mealId) references Meals(id) on update restrict on delete restrict;

select * from accounts;
insert into Accounts values (1, "Tomasz Wojtkowski", "Admin", "PxdgfbCtshXNKnefhpL0cY+0/M2bgF5uOw+1iHX5B+qdjdAP5B5z3A==", "admin@email.com", "i0jN+tYevuD/SFpiwBoQJT91PpJi2u/dtJZICO+C1AywWVZGnrd9/w==", "Admin", '2100-12-30 00:00:00');