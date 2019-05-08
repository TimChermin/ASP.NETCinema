

--(BEFORE | AFTER)_Movie_(INSERT| UPDATE | DELETE)


 

CREATE TRIGGER before_movie_delete
ON dbo.Movie
INSTEAD OF delete
AS
BEGIN
   DELETE FROM Screening WHERE 1002 = Screening.IdMovie;
   
   DELETE FROM Movie WHERE Movie.Id = 1002
END

