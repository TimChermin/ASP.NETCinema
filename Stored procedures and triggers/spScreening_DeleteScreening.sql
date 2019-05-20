CREATE PROCEDURE dbo.spScreening_DeleteScreening
@screeningId int
AS
BEGIN 
	SET NOCOUNT ON;

	DELETE Employee_Task WHERE Employee_Task.IdTask IN (SELECT Task.Id FROM Task WHERE Task.IdScreening = @screeningId)

	DELETE Task WHERE Task.IdScreening = @screeningId

	DELETE Users WHERE Users.IdScreening = @screeningId

	DELETE Screening WHERE Screening.Id = @screeningId
END