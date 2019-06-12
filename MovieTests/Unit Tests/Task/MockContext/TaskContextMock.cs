using ASPNETCinema.Models;
using DAL;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Task.MockContext
{
    class TaskContextMock : ITaskContext
    {
        List<TaskDto> tasks = new List<TaskDto>();
        List<TaskDto> tasksTemp = new List<TaskDto>();
        List<TaskDto> tasksTempDeleted = new List<TaskDto>();
        int delete = 0;
        int edit = 0;
        string editName = "";

        public List<TaskDto> GetTasks()
        {
            tasks.Clear();
            SetTasks();
            AddedTasks();
            return tasks;
        }

        public void SetTasks()
        {
            tasks.Add(new TaskDto
            {
                Id = 1,
                IdScreening = 1,
                TaskType = "Cleaning",
                DateOfScreening = DateTime.Today,
                TimeOfScreening = new TimeSpan(20, 0, 0, 0),
                TaskLenght = new TimeSpan(2, 0, 0, 0),
                HallId = 1
            });

            tasks.Add(new TaskDto
            {
                Id = 2,
                IdScreening = 1,
                TaskType = "Projecting",
                DateOfScreening = DateTime.Today,
                TimeOfScreening = new TimeSpan(20, 0, 0, 0),
                TaskLenght = new TimeSpan(2, 0, 0, 0),
                HallId = 1
            });

            tasks.Add(new TaskDto
            {
                Id = 3,
                IdScreening = 2,
                TaskType = "Cleaning",
                DateOfScreening = DateTime.Today,
                TimeOfScreening = new TimeSpan(10, 0, 0, 0),
                TaskLenght = new TimeSpan(2, 30, 0, 0),
                HallId = 2
            });

            tasks.Add(new TaskDto
            {
                Id = 4,
                IdScreening = 2,
                TaskType = "Projecting",
                DateOfScreening = DateTime.Today,
                TimeOfScreening = new TimeSpan(10, 0, 0, 0),
                TaskLenght = new TimeSpan(2, 30, 0, 0),
                HallId = 2
            });

            WasSomethingDeleted();
            WasSomethingEdited();
        }

        public void WasSomethingDeleted()
        {
            if (delete != 0)
            {
                foreach (var task in tasks)
                {
                    if (task.Id == delete)
                    {
                        tasks.Remove(task);
                        break;
                    }
                }
            }
        }

        public void WasSomethingEdited()
        {
            if (edit != 0)
            {
                foreach (var task in tasks)
                {
                    if (task.Id == edit && editName != "")
                    {
                        tasks[0].TaskType = editName;
                        break;
                    }
                }
            }
        }

        public void AddTask(TaskModel task)
        {
            tasksTemp.Add(new TaskDto
            {
                Id = task.Id,
                IdScreening = task.IdScreening,
                TaskType = task.TaskType,
                DateOfScreening = task.DateOfScreening,
                TimeOfScreening = task.TimeOfScreening,
                TaskLenght = task.TaskLenght,
                HallId = task.HallId
            });
        }

        private void AddedTasks()
        {
            foreach (var task in tasksTemp)
            {
                tasks.Add(task);
            }
        }

        public void EditTask(TaskModel task)
        {
            edit = task.Id;
            editName = task.TaskType;
        }

        public void DeleteTask(int id)
        {
            delete = id;
        }

        public TaskDto GetTaskById(int id)
        {
            foreach (var task in tasks)
            {
                if (task.Id == id)
                {
                    return task;
                }
            }
            foreach (var task in tasksTemp)
            {
                if (task.Id == id)
                {
                    return task;
                }
            }
            return null;
        }

        public List<TaskDto> GetTasksAssigned()
        {
            return null;
        }

        public List<TaskDto> GetTasksNotAssigned()
        {
            return null;
        }
    }
}
