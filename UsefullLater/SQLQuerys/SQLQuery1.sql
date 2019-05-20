CREATE PROCEDURE dbo.spScreening_DeleteScreening
@screeningId int
AS
BEGIN 
	DELETE Employee_Task WHERE Employee_Task.IdTask = (SELECT Task.Id FROM Task WHERE Task.IdScreening = @screeningId)

	DELETE Task WHERE Task.IdScreening = @screeningId

	DELETE Users WHERE Users.IdScreening = @screeningId

	DELETE Screening WHERE Screening.Id = @screeningId
END