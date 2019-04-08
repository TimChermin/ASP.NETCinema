using DAL;
using DAL.Dtos;
using Interfaces;
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

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

            /// <summary>
            /// tasks with employees asigned.
            /// </summary>
            /// <returns></returns>
        public IEnumerable<ITask> GetTasksAssigned()
        {
            var tasks = new List<ITask>();
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT Task.Id, Employee.Id, Employee.Name, Task.TaskType, Screening.DateOfScreening, Screening.TimeOfScreening, Screening.IdHall " +
            "FROM Employee " +
            "INNER JOIN Employee_Task ON Employee.Id = Employee_Task.IdEmployee " +
            "INNER JOIN Task ON Employee_Task.IdTask = Task.Id " +
            "INNER JOIN Screening ON Screening.Id = Task.IdScreening", _connection.SqlConnection);
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

        public IEnumerable<ITask> GetTasksNotAssigned()
        {
            var tasks = new List<ITask>();
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT Task.Id, Task.TaskType, Screening.DateOfScreening, Screening.TimeOfScreening, Screening.IdHall " +
            "FROM Task " +
            "INNER JOIN Screening ON Screening.Id = Task.IdScreening", _connection.SqlConnection);
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

        public IEnumerable<ITask> GetTasks()
        {
            var tasks = new List<ITask>();
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT Task.Id, Employee.Id, Employee.Name, Task.TaskType, Screening.DateOfScreening, Screening.TimeOfScreening, Screening.IdHall " +
            "FROM Employee " +
            "INNER JOIN Employee_Task ON Employee.Id = Employee_Task.IdEmployee " +
            "INNER JOIN Task ON Employee_Task.IdTask = Task.Id " +
            "INNER JOIN Screening ON Screening.Id = Task.IdScreening", _connection.SqlConnection);
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


        public void AddTask(ITask task)
        {
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO Task OUTPUT Inserted.Id VALUES (@IdScreening, @TaskType)", _connection.SqlConnection);
            command.Parameters.AddWithValue("@IdScreening", task.IdScreening);
            command.Parameters.AddWithValue("@TaskType", task.TaskType);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        public ITask GetTaskById(int id)
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

        public void EditTask(ITask task)
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

            SqlCommand command = new SqlCommand("DELETE FROM Task WHERE Id = @Id", _connection.SqlConnection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
            _connection.SqlConnection.Close();
        }

        
    }
}
