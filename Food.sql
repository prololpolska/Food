create database Food;
use Food;

create table Accounts
(
	id int not null primary key,
    fullName varchar(32),
    userName varchar(16) not null,
    paswd varchar(128) not null,
    email varchar(32) not null,
    dietEnd dateTime not null
);

create table Days
(
	id tinyint not null primary key,
    nameDay varchar(16) not null,
    dateDay dateTime not null
);

create table Meals
(
	id tinyint not null primary key,
    items text not null
);

create table MealDayConnector
(
	id smallint not null primary key,
    dayId tinyint not null,
    mealId tinyint not null
);

alter table Accounts add constraint c_uEmail unique(email);
alter table Accounts add constraint c_uUserName unique(userName);
alter table MealDayConnector add constraint c_fkDay foreign key c_fkDay(dayId) references Days(id) on update restrict on delete restrict;
alter table MealDayConnector add constraint c_fkMeal foreign key c_fkDay(mealId) references Meals(id) on update restrict on delete restrict;

select * from accounts;