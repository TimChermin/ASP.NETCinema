create trigger TRG_AddTasksAfterAddingScreening 
ON Screening
AFTER INSERT AS
BEGIN
INSERT INTO Task (IdScreening, TaskType)
VALUES (Screening.Id, "Cleaning")

INSERT INTO Task (IdScreening, TaskType)
VALUES (Screening.Id, "Projectionist")

INSERT INTO Task (IdScreening, TaskType)
VALUES (Screening.Id, "TicketChecking")
END