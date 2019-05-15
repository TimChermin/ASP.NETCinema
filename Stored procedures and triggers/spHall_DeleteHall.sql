CREATE PROCEDURE dbo.spHall_DeleteHall
@hallId int
AS
BEGIN 
	SET NOCOUNT ON;

	DELETE Users WHERE Users.IdScreening = (SELECT Screening.Id FROM Screening WHERE Screening.IdHall = @hallId)

	DELETE Employee_Task WHERE Employee_Task.IdTask = (SELECT Task.Id From Task WHERE Task.IdScreening = (SELECT Screening.Id FROM Screening WHERE Screening.IdHall = @hallId))

	DELETE Task WHERE Task.IdScreening = (SELECT Screening.Id FROM Screening WHERE Screening.IdHall = @hallId)
	
	DELETE Screening WHERE Screening.IdHall = @hallId

	DELETE Hall WHERE Hall.Id = @hallId
END