using ASPNETCinema.Models;
using DAL;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.DAL
{
    public class DatabaseTask : ITaskContext
    {
        private readonly DatabaseConnection _connection;

        public DatabaseTask(DatabaseConnection connection)
        {
            _connection = connection;
        }
        
        
        public List<TaskDto> GetTasksAssigned()
        {
            var tasks = new List<TaskDto>();
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand(@"SELECT Task.Id, Employee.Id, Employee.Name, Task.TaskType, Screening.DateOfScreening, Screening.TimeOfScreening, Screening.IdHall 
            FROM Employee 
            INNER JOIN Employee_Task ON Employee.Id = Employee_Task.IdEmployee 
            INNER JOIN Task ON Employee_Task.IdTask = Task.Id 
            INNER JOIN Screening ON Screening.Id = Task.IdScreening", _connection.SqlConnection);
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var task = new TaskDto
                {
                    Id = (int)reader["Id"],
                    EmployeeId = (int)reader["Id"],
                    EmployeeName = reader["Name"].ToString(),
                    TaskType = reader["TaskType"].ToString(),
                    DateOfScreening = (DateTime)reader["DateOfScreening"],
                    TimeOfScreening = (TimeSpan)reader["TimeOfScreening"],
                    HallId = (int)reader["IdHall"]
            };
                tasks.Add(task);
            }
        }
        _connection.SqlConnection.Close();
        return (tasks);
        }

        public List<TaskDto> GetTasksNotAssigned()
        {
            var tasks = new List<TaskDto>();
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand(@"SELECT Task.Id, Task.TaskType, Screening.DateOfScreening, Screening.TimeOfScreening, Screening.IdHall 
            FROM Task 
            INNER JOIN Screening ON Screening.Id = Task.IdScreening", _connection.SqlConnection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var task = new TaskDto
                    {
                        Id = (int)reader["Id"],
                        TaskType = reader["TaskType"].ToString(),
                        DateOfScreening = (DateTime)reader["DateOfScreening"],
                        TimeOfScreening = (TimeSpan)reader["TimeOfScreening"],
                        HallId = (int)reader["IdHall"]
                    };
                    tasks.Add(task);
                }
            }
            _connection.SqlConnection.Close();
            return (tasks);
        }

        public List<TaskDto> GetTasks()
        {
            var tasks = new List<TaskDto>();
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand(@"SELECT Task.Id AS IdTask, Employee.Id AS IdEmployee, Employee.Name, Task.TaskType, Screening.DateOfScreening, Screening.TimeOfScreening, Screening.IdHall 
            FROM Employee 
            FULL OUTER JOIN Employee_Task ON Employee.Id = Employee_Task.IdEmployee 
            FULL OUTER JOIN Task ON Employee_Task.IdTask = Task.Id 
            FULL OUTER JOIN Screening ON Screening.Id = Task.IdScreening", _connection.SqlConnection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var task = new TaskDto
                    {
                        Id = (reader["IdTask"] as int?) ?? 0,
                        EmployeeId = (reader["IdEmployee"] as int?) ?? 0,
                        EmployeeName = reader["Name"].ToString(),
                        TaskType = reader["TaskType"].ToString(),
                        DateOfScreening = (reader["DateOfScreening"] as DateTime?) ?? DateTime.Now.AddYears(-500),
                        TimeOfScreening = (reader["TimeOfScreening"] as TimeSpan?) ?? DateTime.Now.TimeOfDay,
                        HallId = (reader["IdHall"] as int?) ?? 0
                    };

                    tasks.Add(task);
                }
            }
            _connection.SqlConnection.Close();
            return (tasks);
        }


        public void AddTask(TaskModel task)
        {
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO Task VALUES (@IdScreening, @TaskType)", _connection.SqlConnection);
            command.Parameters.AddWithValue("@IdScreening", task.IdScreening);
            command.Parameters.AddWithValue("@TaskType", task.TaskType);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public TaskDto GetTaskById(int id)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("SELECT Id, IdScreening, TaskType FROM Task WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Id", id);
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var task = new TaskDto
                {
                    Id = (int)reader["Id"],
                    IdScreening = (int)reader["IdScreening"],
                    TaskType = reader["TaskType"].ToString()
                };
                _connection.SqlConnection.Close();
                return task;
            }
        }
        _connection.SqlConnection.Close();
        return null;
        }

        public void EditTask(TaskModel task)
        {
            _connection.SqlConnection.Open();

            SqlCommand command = new SqlCommand("UPDATE Task SET IdScreening = @IdScreening, TaskType = @TaskType WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@IdScreening", task.IdScreening);
            command.Parameters.AddWithValue("@TaskType", task.TaskType);
            command.Parameters.AddWithValue("@Id", task.Id);

            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public void DeleteTask(int id)
        {
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand("EXEC dbo.spTask_DeleteTask @taskId", _connection.SqlConnection);
            command.Parameters.AddWithValue("@taskId", id);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        
    }
}
