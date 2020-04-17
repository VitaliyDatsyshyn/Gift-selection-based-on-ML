create table Persons
	(ID int primary key,
	FirstName varchar(50),
	LastName varchar(50),
	Age int not null,
	Sex varchar(20) not null, --male, female, other -- dropdown
	Relation varchar(50) not null, -- dropdown
	Occasion varchar(100) not null, -- dropdown
	Hobby varchar(150) not null, -- dropdown
	Interests varchar(255) not null, --seperated by comma -- dropdown
	PriceCategory varchar(50) not null, --High, medium, low -- dropdown
	PsycoType varchar(255) --introvert, extravert -- dropdown
	)