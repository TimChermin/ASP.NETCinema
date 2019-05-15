CREATE PROCEDURE dbo.spEmployee_DeleteEmployee
@employeeId int
AS
BEGIN 
	SET NOCOUNT ON;

	DELETE Employee_Task WHERE IdEmployee = @employeeId

	DELETE Employee WHERE Employee.Id = @employeeId
END