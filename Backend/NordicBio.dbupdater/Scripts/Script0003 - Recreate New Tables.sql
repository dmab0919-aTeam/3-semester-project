CREATE TABLE [dbo].[Orders] (
	[Id] int PRIMARY KEY identity(1,1),
	[TotalPrice] float NOT NULL,
	[UserID] int NOT NULL,
	FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] (Id),
)

CREATE TABLE [dbo].[Seats] (
	[Id] int UNIQUE identity(1,1),
	[Row] int NOT NULL,
	[Number] int NOT NULL,
	[ShowingID] int NOT NULL,
	[OrderID] int NOT NULL,
	PRIMARY KEY([Row], Number, ShowingID),
	FOREIGN KEY (ShowingID) REFERENCES [dbo].[Showings] (Id),
	FOREIGN KEY (OrderID) REFERENCES [dbo].[Orders] (Id)
)
