create trigger TRG_AddTasksAfterAddingScreening 
ON Screening
AFTER INSERT AS
BEGIN
INSERT INTO Task (IdScreening, TaskType)
VALUES ((SELECT Id FROM Inserted), 'Cleaning')

INSERT INTO Task (IdScreening, TaskType)
VALUES ((SELECT Id FROM Inserted), 'Projectionist')

INSERT INTO Task (IdScreening, TaskType)
VALUES ((SELECT Id FROM Inserted), 'TicketChecking')
END