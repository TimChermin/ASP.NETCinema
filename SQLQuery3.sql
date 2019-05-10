CREATE PROCEDURE dbo.spMovie_DeleteMovie
@movieId int
AS
BEGIN 
	DELETE Employee_Task WHERE IdTask = (SELECT Task.Id From Task WHERE Task.IdScreening = (SELECT Screening.Id FROM Screening WHERE Screening.IdMovie = @movieId))

	DELETE Task WHERE Task.IdScreening = (SELECT Screening.Id FROM Screening WHERE Screening.IdMovie = @movieId)

	DELETE Users WHERE Users.IdScreening = (SELECT Screening.Id FROM Screening WHERE Screening.IdMovie = @movieId)

	DELETE Screening WHERE Screening.IdMovie = @movieId

	DELETE Movie WHERE Movie.Id = @movieId
END