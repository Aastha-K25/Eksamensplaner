using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Eksamensplaner.Core.Models;

namespace Eksamensplaner.Infrastructure.Repositories;

public class RegistreretEksamenRepository
{
    private readonly string _connectionString;

    public RegistreretEksamenRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Add(RegistreretEksamen e)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            string sql =
                "INSERT INTO Eksamener" +
                "(HoldId, Navn, ProeveNavn, Form, EksamensType, Rolle, Dato, StartTid, SlutTid, Tidspunkt, AntalStuderende, HarTilsyn, MaalGruppe)" +
                "VALUES " +
                "(@HoldId, @Navn, @ProeveNavn, @Form, @EksamensType, @Rolle, @Dato, @StartTid, @SlutTid, @Tidspunkt, @AntalStuderende, @HarTilsyn, @MaalGruppe)";

            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                AddString(cmd, "@HoldId", e.HoldId);
                AddString(cmd, "@Navn", e.Navn);
                AddString(cmd, "@ProeveNavn", e.ProeveNavn);
                AddString(cmd, "@Form", e.Form);
                AddString(cmd, "@EksamensType", e.EksamensType);
                AddString(cmd, "@Rolle", e.Rolle);

                cmd.Parameters.AddWithValue("@Dato", e.Dato);

                AddTime(cmd, "@StartTid", e.StartTid);
                AddTime(cmd, "@SlutTid", e.SlutTid);
                AddTime(cmd, "@Tidspunkt", e.Tidspunkt);

                AddInt(cmd, "@AntalStuderende", e.AntalStuderende);

                cmd.Parameters.AddWithValue("@HarTilsyn", e.HarTilsyn);

                AddString(cmd, "@MaalGruppe", e.MaalGruppe);

                cmd.ExecuteNonQuery();
            }
        }
    }

    public List<RegistreretEksamen> GetForStuderende(string holdId)
    {
        return GetByHoldAndMaalgruppe(holdId, "Studerende");
    }

    public List<RegistreretEksamen> GetForLaerer(string holdId)
    {
        return GetByHoldAndMaalgruppe(holdId, "Lærer");
    }

    private List<RegistreretEksamen> GetByHoldAndMaalgruppe(string holdId, string maalgruppe)
    {
        List<RegistreretEksamen> result = new List<RegistreretEksamen>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            string sql =
                "SELECT HoldId, Navn, ProeveNavn, Form, EksamensType, Rolle, Dato, StartTid, SlutTid, Tidspunkt, AntalStuderende, HarTilsyn, MaalGruppe " +
                "FROM Eksamener " +
                "WHERE HoldId = @HoldId AND MaalGruppe = @MaalGruppe " +
                "ORDER BY Dato";

            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@HoldId", holdId);
                cmd.Parameters.AddWithValue("@MaalGruppe", maalgruppe);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RegistreretEksamen e = new RegistreretEksamen();

                        e.HoldId = reader["HoldId"].ToString();
                        e.Navn = reader["Navn"].ToString();
                        e.ProeveNavn = reader["ProeveNavn"].ToString();
                        e.Form = reader["Form"].ToString();
                        e.EksamensType = reader["EksamensType"].ToString();
                        e.Rolle = reader["Rolle"].ToString();

                        e.Dato = (DateTime)reader["Dato"];

                        e.StartTid = ReadTime(reader, "StartTid");
                        e.SlutTid = ReadTime(reader, "SlutTid");
                        e.Tidspunkt = ReadTime(reader, "Tidspunkt");

                        e.AntalStuderende = ReadInt(reader, "AntalStuderende");

                        e.HarTilsyn = (bool)reader["HarTilsyn"];
                        e.MaalGruppe = reader["MaalGruppe"].ToString();

                        result.Add(e);
                    }
                }
            }
        }

        return result;
    }

    private TimeSpan? ReadTime(SqlDataReader reader, string column)
    {
        if (reader[column] == DBNull.Value)
        {
            return null;
        }

        return (TimeSpan)reader[column];
    }

    private int? ReadInt(SqlDataReader reader, string column)
    {
        if (reader[column] == DBNull.Value)
        {
            return null;
        }

        return (int)reader[column];
    }

    private void AddString(SqlCommand cmd, string name, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            cmd.Parameters.AddWithValue(name, DBNull.Value);
        }
        else
        {
            cmd.Parameters.AddWithValue(name, value);
        }
    }

    private void AddInt(SqlCommand cmd, string name, int? value)
    {
        if (value.HasValue)
        {
            cmd.Parameters.AddWithValue(name, value.Value);
        }
        else
        {
            cmd.Parameters.AddWithValue(name, DBNull.Value);
        }
    }

    private void AddTime(SqlCommand cmd, string name, TimeSpan? value)
    {
        if (value.HasValue)
        {
            cmd.Parameters.AddWithValue(name, value.Value);
        }
        else
        {
            cmd.Parameters.AddWithValue(name, DBNull.Value);
        }
    }
}