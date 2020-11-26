CREATE TABLE [dbo].[Users] (
	Id int UNIQUE identity(1,1),
	FirstName varchar(20) NOT NULL,
	LastName varchar(20) NOT NULL,
	Email varchar(50) PRIMARY KEY,
	PhoneNumber varchar(20) NOT NULL,
	[Password] varchar(200) NOT NULL,
	Salt varchar(20) NOT NULL,
	IsAdmin bit
) 

CREATE TABLE [dbo].[Sodas] (
	Id int PRIMARY KEY identity(1,1),
	[Name] varchar(20) NOT NULL,
	Flavour varchar(20) NOT NULL,
	Price float NOT NULL,
	ML int NOT NULL
) 

CREATE TABLE [dbo].[Candy] (
	Id int PRIMARY KEY identity(1,1),
	[Name] varchar(20) NOT NULL,
	Price float NOT NULL,
	[Description] varchar(50) NOT NULL,
	[Weight] float NOT NULL
) 

CREATE TABLE [dbo].[FoodOrders] (
	Id int PRIMARY KEY identity(1,1),
	FoodOrderNumber int NOT NULL,
	TotalPrice float NOT NULL,
	CandyID int NULL,
	SodaID int NULL,
	FOREIGN KEY (CandyID) REFERENCES [dbo].[Candies] (Id),
	FOREIGN KEY (SodaID) REFERENCES [dbo].[Sodas] (Id)
) 

CREATE TABLE [dbo].[Orders] (
	Id int PRIMARY KEY identity(1,1),
	OrderNumber int NOT NULL,
	TotalPrice float NOT NULL,
	UserID int NOT NULL,
	FoodOrderID int NULL,
	FOREIGN KEY (UserID) REFERENCES [dbo].[Users] (Id),
	FOREIGN KEY (FoodOrderID) REFERENCES [dbo].[FoodOrders] (Id)
)

CREATE TABLE [dbo].[Movies] (
	Id int PRIMARY KEY identity(1,1),
	Title text NOT NULL,
	ReleaseDate varchar(10) NOT NULL,
	VoteAverage float NOT NULL,
	PosterPath varchar(100) NOT NULL,
	BackdropPath varchar(100) NOT NULL,
	[Description] text NOT NULL,
); 

CREATE TABLE [dbo].[Showings] (
	Id int PRIMARY KEY identity(1,1),
	Price float NOT NULL,
	[ShowingTime] datetime NOT NULL,
	HallNumber int NOT NULL,
	MovieID int NOT NULL,
	FOREIGN KEY (MovieID) REFERENCES [dbo].[Movies] (Id),
)

CREATE TABLE [dbo].[Seats] (
	Id int UNIQUE identity(1,1),
	[Row] int NOT NULL,
	Number int NOT NULL,
	ShowingID int NOT NULL,
	PRIMARY KEY([Row], Number, ShowingID),
	FOREIGN KEY (ShowingID) REFERENCES [dbo].[Showings] (Id),
)

CREATE TABLE [dbo].[Tickets]  (
	Id int PRIMARY KEY identity(1,1),
	SeatID int NOT NULL,
	TicketNumber int NOT NULL,
	ShowingID int NOT NULL,
	OrderID int NOT NULL,
	FOREIGN KEY (SeatID) REFERENCES [dbo].[Seats] (Id),
	FOREIGN KEY (ShowingID) REFERENCES [dbo].[Showings] (Id),
	FOREIGN KEY (OrderID) REFERENCES [dbo].[Orders] (Id),
); 