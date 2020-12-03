--Showing creation--

INSERT INTO [dbo].[Showings] (Price, ShowingTime, HallNumber, MovieID) 
VALUES (100, '2021-01-01 12:00:00', 1, 1);

INSERT INTO [dbo].[Showings] (Price, ShowingTime, HallNumber, MovieID) 
VALUES (100, '2021-01-01 14:00:00', 1, 1);

INSERT INTO [dbo].[Showings] (Price, ShowingTime, HallNumber, MovieID) 
VALUES (100, '2021-01-01 16:00:00', 1, 1);

INSERT INTO [dbo].[Showings] (Price, ShowingTime, HallNumber, MovieID) 
VALUES (100, '2021-01-01 18:00:00', 1, 1);

INSERT INTO [dbo].[Showings] (Price, ShowingTime, HallNumber, MovieID) 
VALUES (150, '2021-01-01 12:00:00', 2, 2);

INSERT INTO [dbo].[Showings] (Price, ShowingTime, HallNumber, MovieID) 
VALUES (150, '2021-01-01 14:00:00', 2, 2);

INSERT INTO [dbo].[Showings] (Price, ShowingTime, HallNumber, MovieID) 
VALUES (150, '2021-01-01 16:00:00', 2, 2);

INSERT INTO [dbo].[Showings] (Price, ShowingTime, HallNumber, MovieID) 
VALUES (150, '2021-01-01 18:00:00', 2, 2);

INSERT INTO [dbo].[Showings] (Price, ShowingTime, HallNumber, MovieID) 
VALUES (200, '2021-01-01 12:00:00', 5, 5);

INSERT INTO [dbo].[Showings] (Price, ShowingTime, HallNumber, MovieID) 
VALUES (200, '2021-01-01 14:00:00', 5, 5);

--User creation--

INSERT INTO [dbo].[Users] (FirstName, LastName, Email, PhoneNumber, [Password], Salt, IsAdmin) 
VALUES ('Hans', 'Hansen', 'hans@123.dk', '87654321','66625144bd86bb4548ba940799e4e13dfc8142ab6b645c167def02f6411df141', '8efd84260c694fc5977f', 0);

INSERT INTO [dbo].[Users] (FirstName, LastName, Email, PhoneNumber, [Password], Salt, IsAdmin) 
VALUES ('Lars', 'Larsen', 'lars@123.dk', '12345678', 'f41843d5f9a31a85b154e0986fea5d46fb6a0ba38c52cb064ecf97cf17702d12', 'c36bd1a6b4e4413a9595', 0);

INSERT INTO [dbo].[Users] (FirstName, LastName, Email, PhoneNumber, [Password], Salt, IsAdmin) 
VALUES ('admin', 'chiefone', 'ad@min.dk', '13371337','f2a1e9442bf138e67ae9c0bfea6e24f7e1c4b3ccf30016e933dcd305716d24c5', 'd8e117d1332644d78a84', 1);

--Order creation--

INSERT INTO [dbo].[Orders] (TotalPrice, UserID) 
VALUES (200, 1);

INSERT INTO [dbo].[Orders] (TotalPrice, UserID) 
VALUES (200, 2);

--Seat creation--

INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID)
VALUES (1, 1, 1, 1);

INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID)
VALUES (2, 2, 1, 1);

INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID)
VALUES (3, 3, 1, 2);

INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID)
VALUES (4, 4, 1, 2);

INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID)
VALUES (6, 6, 2, 1);

INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID)
VALUES (7, 7, 2, 1);

INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID)
VALUES (8, 8, 2, 2);

INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID)
VALUES (9, 9, 2, 2);

