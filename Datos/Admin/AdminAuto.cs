using Datos.Servidor;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Admin
{
    public static class AdminAuto
    {
        //lista Modelo Conectado
        public static List<Auto> Listar()
        {
            string consutlaSQL = "SELECT Id,Marca,Modelo,Matricula,Precio FROM dbo.Auto";
            SqlCommand comando = new SqlCommand(consutlaSQL,
            AdminDB.ConectarBase());
            SqlDataReader reader;
            reader = comando.ExecuteReader();
            List<Auto> lista = new List<Auto>();
            while (reader.Read())
            {
                lista.Add(new Auto()
                {
                    Id = (int)reader["Id"],
                    Marca = reader["Marca"].ToString(),
                    Modelo = reader["Modelo"].ToString(),
                    Matricula = reader["Matricula"].ToString(),
                    Precio = Convert.ToDecimal(reader["Precio"]),
                }
                );
            }
            AdminDB.ConectarBase().Close();
            reader.Close();
            return lista;
        }
        // lista modo desconectado para llenar combos
        public static DataTable ListarMarcas()
        {
            string consultaSQL = "SELECT DISTINCT Marca FROM dbo.Auto";
            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL,
            AdminDB.ConectarBase());
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Marca");
            return ds.Tables["Marca"];
        }
        //lista Modelo Desconectado
        public static DataTable Listar(string marca)
        {
            string consultaSQL = "SELECT Id,Marca,Modelo,Matricula,Precio FROM dbo.Auto WHERE Marca = @Marca";
        SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL,
        AdminDB.ConectarBase());
            adapter.SelectCommand.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value
            = marca;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Marca");
            return ds.Tables["Marca"];
        }
        //Insertar
        public static int Insertar(Auto auto)
        {
            string insertSQL = "INSERT dbo.Auto (Marca, Modelo, Matricula, Precio) VALUES(@Marca, @Modelo, @Matricula, @Precio)";
        SqlCommand command = new SqlCommand(insertSQL, AdminDB.ConectarBase());
            command.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = auto.Marca;
            command.Parameters.Add("@Modelo", SqlDbType.VarChar, 50).Value =
            auto.Modelo;
            command.Parameters.Add("@Matricula", SqlDbType.Char, 6).Value =
            auto.Matricula;
            command.Parameters.Add("@Precio", SqlDbType.Decimal).Value = auto.Precio;
            int filasAfectadas = command.ExecuteNonQuery();
            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }
        //Eliminar
        public static int Eliminar(int id)
        {
            string insertSQL = "DELETE FROM dbo.Auto WHERE Id=@Id";
            SqlCommand command = new SqlCommand(insertSQL, AdminDB.ConectarBase());
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            int filasAfectadas = command.ExecuteNonQuery();
            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }
        // Modificar
        public static int Modificar(Auto auto)
        {
            string insertSQL = "UPDATE dbo.Auto SET Marca=@Marca, Modelo=@Modelo, Matricula=@Matricula, Precio=@Precio WHERE Id=@Id";
        SqlCommand command = new SqlCommand(insertSQL, AdminDB.ConectarBase());
            command.Parameters.Add("@Id", SqlDbType.Int).Value = auto.Id;
            command.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = auto.Marca;
            command.Parameters.Add("@Modelo", SqlDbType.VarChar, 50).Value =
            auto.Modelo;
            command.Parameters.Add("@Matricula", SqlDbType.Char, 6).Value =
            auto.Matricula;
            command.Parameters.Add("@Precio", SqlDbType.Decimal).Value = auto.Precio;
            int filasAfectadas = command.ExecuteNonQuery();
            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }
    }
}

