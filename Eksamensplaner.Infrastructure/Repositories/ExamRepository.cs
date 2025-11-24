using System.Collections.Generic;
using System.Data.SqlClient;
using Eksamensplaner.Core.Models;
using Microsoft.Extensions.Configuration;
namespace Eksamensplaner.Infrastructure.Repositories;

public class ExamRepository
{
    private readonly string _connectionString;

    public ExamRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    
}