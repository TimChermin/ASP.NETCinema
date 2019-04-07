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

        public IEnumerable<ITask> GetTasks()
        {
            var tasks = new List<ITask>();
            _connection.SqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT Id, IdScreening, TaskType FROM Task", _connection.SqlConnection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var task = new TaskDto
                    {
                        Id = (int)reader["Id"],
                        IdScreening = (int)reader["IdScreening"],
                        TaskType = (int)reader["TaskType"]
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
                        TaskType = (int)reader["TaskType"]
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
