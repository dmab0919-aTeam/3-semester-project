DROP TABLE [dbo].[movies];

CREATE TABLE [dbo].[movies] 
(
	Id int PRIMARY KEY identity(1,1),
	Title varchar(50),
	ReleaseDate varchar(10),
	VoteAverage float,
	PosterPath varchar(50)
); 