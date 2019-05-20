CREATE PROCEDURE dbo.spTask_DeleteTask
@taskId int
AS
BEGIN 
	SET NOCOUNT ON;

	DELETE Employee_Task WHERE Employee_Task.IdTask = @taskId

	DELETE Task WHERE Task.Id = @taskId
END