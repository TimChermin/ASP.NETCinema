using ASPNETCinema;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTests.Task.MockContext;
using Xunit;

namespace TaskTests
{
    public class TaskBasicsTests
    {
        TaskLogic taskLogic;
        IMapper _mapper;

        public TaskBasicsTests()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
            taskLogic = new TaskLogic(new TaskContextMock(), _mapper);
        }

        [Fact]
        public void Should_AddATask_WhenAddingATask()
        {
            //Arrange

            //Act
            taskLogic.AddTask(new TaskModel { Id = 5, TaskType = "AddTest" });

            //Assert
            Assert.True(taskLogic.GetTaskById(5).TaskType == "AddTest");
        }

        [Fact]
        public void Should_EditATask_WhenEditingAnTask()
        {
            //Arrange
            TaskModel task = new TaskModel { Id = 1, TaskType = "EditTest" };

            //Act
            taskLogic.EditTask(task);

            //Assert
            Assert.True(taskLogic.GetTasks()[0].TaskType == "EditTest");
        }


        [Fact]
        public void Should_ReturnATask_WhenGettingATaskById()
        {
            //Arrange
            taskLogic.AddTask(new TaskModel { Id = 5, TaskType = "GetByIdTest" });

            //Act
            TaskModel task = taskLogic.GetTaskById(5);

            //Assert
            Assert.True(task.Id == 5 && task.TaskType == "GetByIdTest");
        }

        [Fact]
        public void Should_DeleteAnTask_WhenDeleteingAnTask()
        {
            //Arrange
            List<TaskModel> tasks = new List<TaskModel>();
            tasks = taskLogic.GetTasks();
            string screenType = tasks[0].TaskType;

            //Act
            taskLogic.DeleteTask(tasks[0].Id);

            //Assert
            Assert.False(tasks[0].TaskType != screenType);
        }

        [Fact]
        public void Should_GetTasksFromTheList_WhenGettingTasks()
        {
            //Arrange
            var taskLogic = new TaskLogic(new TaskContextMock(), _mapper);
            TaskModel task = new TaskModel { Id = 10, TaskType = "GetTest" };
            taskLogic.AddTask(task);
            bool found = false;

            //Act
            if (taskLogic.GetTasks()[4].Id == 10 && taskLogic.GetTasks()[4].TaskType == "GetTest")
            {
                found = true;
            }

            //Assert
            Assert.True(found);
        }
    }
}
