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

INSERT INTO [dbo].[Users] (FirstName, LastName, Email, PhoneNumber, [Password], Salt, UserRole) 
VALUES ('william', 'baviansen', 'william@123.dk', '12345678','8184ba394ea55ba84487138c068476d5924cd24f6cd013ee4751599b20069d39', 'dc2050e6840f46f893de', 'User');

INSERT INTO [dbo].[Users] (FirstName, LastName, Email, PhoneNumber, [Password], Salt, UserRole) 
VALUES ('bavian', 'baviansen', 'bavian@123.dk', '12345678', '427016a43fe2b8bc060404dc352fbf09651cc77a5d4b26c6886aae80637744f5', '5007ac9eec714d67b5e4', 'User');

INSERT INTO [dbo].[Users] (FirstName, LastName, Email, PhoneNumber, [Password], Salt, UserRole) 
VALUES ('admin3', 'chiefone', 'admin@1234.dk', '13371337','38b4ef976f74053506d1a6e6eead654483fd39f37dead607f34d0be030a30472', '4110535b2ba8411c9300', 'Admin');

--Order creation--

INSERT INTO [dbo].[Orders] (TotalPrice, UserID) 
VALUES (200, 1);

INSERT INTO [dbo].[Orders] (TotalPrice, UserID) 
VALUES (200, 2);

--Seat creation--

INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID, [State], [UserID], ReserveTime)
VALUES (1, 1, 1, 1, 'Bought', 1, '2020-12-8 11:24:20');

INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID, [State], [UserID], ReserveTime)
VALUES (2, 2, 1, 1, 'Bought', 1, '2020-12-8 11:24:20');

INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID, [State], [UserID], ReserveTime)
VALUES (3, 3, 1, 2, 'Bought', 1, '2020-12-8 11:24:20');

INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID, [State], [UserID], ReserveTime)
VALUES (4, 4, 1, 2, 'Bought', 1, '2020-12-8 11:24:20');

INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID, [State], [UserID], ReserveTime)
VALUES (6, 6, 2, 1, 'Bought', 2, '2020-12-8 11:24:20');

INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID, [State], [UserID], ReserveTime)
VALUES (7, 7, 2, 1, 'Bought', 2, '2020-12-8 11:24:20');

INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID, [State], [UserID], ReserveTime)
VALUES (8, 8, 2, 2, 'Bought', 2, '2020-12-8 11:24:20');

INSERT INTO [dbo].[Seats] (Row, Number, ShowingID, OrderID, [State], [UserID], ReserveTime)
VALUES (9, 9, 2, 2, 'Bought', 2, '2020-12-8 11:24:20');

