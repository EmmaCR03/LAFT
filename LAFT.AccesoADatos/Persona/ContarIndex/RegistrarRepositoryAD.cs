using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LAFT.Abstracciones.AccessoADatos.Interfaces.Persona.CountPersonas;

public class RegistrarRepositoryAD : IRegistrarRepositoryAD
{
    private readonly string _connectionString = "Data Source=(local); Initial Catalog=LAFT;Integrated Security=True";

    public int ObtenerTotalRegistrados()
    {
        int count = 0;

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT COUNT(*) FROM Users"; // Cambia "Users" por tu tabla
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                count = (int)command.ExecuteScalar();
            }
        }

        return count;
    }
}
