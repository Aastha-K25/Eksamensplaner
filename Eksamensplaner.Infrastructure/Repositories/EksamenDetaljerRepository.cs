using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Eksamensplaner.Core;
using Eksamensplaner.Core.ViewModels;
using Microsoft.Data.SqlClient;

public class EksamenDetaljerRepository
{
    private readonly string _connectionString;

    public EksamenDetaljerRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<EksamenElevViewModel> GetEksamenData(int eksamenId)
    {
        List<EksamenElevViewModel> result = new List<EksamenElevViewModel>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            string sql = @"
            SELECT s.StuderendeId,
                   s.Navn, 
                   s.SkoleEmail,
                   es.EksamenTidspunkt,
                   es.HarAfleveret, 
                   es.AfleveretDato
            FROM EksamenStuderende es
            JOIN Studerende s ON s.StuderendeId = es.StuderendeId
            WHERE es.EksamenId = @EksamenId
            ORDER BY s.Navn";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@EksamenId", eksamenId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EksamenElevViewModel elev = new EksamenElevViewModel
                        {
                            StuderendeId = (int)reader["StuderendeId"],
                            Navn = (string)reader["Navn"],
                            SkoleMail = (string)reader["SkoleEmail"],
                            EksamenTidspunkt = (DateTime)reader["EksamenTidspunkt"],
                            HarAfleveret = (bool)reader["HarAfleveret"],
                            AfleveretDato = reader["AfleveretDato"] == DBNull.Value
                                ? (DateTime?)null
                                : (DateTime)reader["AfleveretDato"],
                        };
                        result.Add(elev);
                    }
                }
            }
        }

        return result;
    }
    public List<AfleveringElevViewModel> GetAfleveringForHold(int eksamenId)
    {
        List<AfleveringElevViewModel> result = new List<AfleveringElevViewModel>();

        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = @"
            SELECT s.Navn,
                   s.SkoleEmail,
                   es.HarAfleveret,
                   es.AfleveretDato
            FROM EksamenStuderende es
            INNER JOIN Studerende s ON s.StuderendeId = es.StuderendeId
            WHERE es.EksamenId = @EksamenId
            ORDER BY s.Navn;
        ";

            cmd.Parameters.AddWithValue("@EksamenId", eksamenId);

            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    AfleveringElevViewModel elev = new AfleveringElevViewModel()
                    {
                        Navn          = (string)reader["Navn"],
                        SkoleEmail    = (string)reader["SkoleEmail"],
                        HarAfleveret  =  (bool)reader["HarAfleveret"],
                        AfleveretDato =  reader["AfleveretDato"] == DBNull.Value
                            ? (DateTime?)null
                            : (DateTime)reader["AfleveretDato"],
                    };

                    result.Add(elev);
                }
            }
        }

        return result;
    }
}