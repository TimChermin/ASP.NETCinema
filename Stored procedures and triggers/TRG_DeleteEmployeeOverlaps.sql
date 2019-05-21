create trigger TRG_DeleteEmployeeOverlaps
ON Employee
INSTEAD OF DELETE 
AS
BEGIN
	DECLARE @EmployeeId INT
    SELECT @EmployeeId = deleted.Id FROM deleted 

	DELETE Employee_Task WHERE Employee_Task.IdEmployee = @EmployeeId

	DELETE Employee WHERE Employee.Id = @EmployeeId
END
