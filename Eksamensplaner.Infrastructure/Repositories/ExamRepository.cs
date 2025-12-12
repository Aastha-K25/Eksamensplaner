using System.Collections.Generic;
using System.Data.SqlClient;
using Eksamensplaner.Core.Models;
using Microsoft.Data.SqlClient;

namespace Eksamensplaner.Infrastructure.Repositories
{
    public class ExamRepository
    {
        private readonly string _connectionString;

        public ExamRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Eksamen> GetBySemester (int semester)
        {
            List<Eksamen> list = new List<Eksamen>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql =
                    "SELECT Id, Uddannelse, Aktivitet, Semester, Type " +
                    "FROM Exams " +
                    "WHERE (@semester = 0 OR Semester = @semester)";


                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@semester", semester);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Eksamen e = new Eksamen();
                            e.Id = (int)reader["Id"];
                            e.Uddannelse = reader["Uddannelse"].ToString();
                            e.Aktivitet = reader["Aktivitet"].ToString();
                            e.Semester = (int)reader["Semester"];
                            e.Type = reader["Type"].ToString();

                            list.Add(e);
                        }
                    }
                }
            }
            return list;
        }
    }
}
