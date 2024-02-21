using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=(local);Initial Catalog=examen_software;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();


            string insertCliente = "INSERT INTO tclientes (Nombre, Genero) VALUES (@Nombre, @Genero)";
            using (SqlCommand command = new SqlCommand(insertCliente, connection))
            {
                command.Parameters.AddWithValue("@Nombre", "kevin");
                command.Parameters.AddWithValue("@Genero", "Masculino");

                command.ExecuteNonQuery();
            }


            string registrarVenta = "INSERT INTO tventas (ClienteID, LibroID, Cantidad, ImportBruto, Descuento) VALUES (@ClienteID, @LibroID, @Cantidad, @ImportBruto, @Descuento)";
            using (SqlCommand command = new SqlCommand(registrarVenta, connection))
            {
                int ClienteID = 1;
                int LibroID = 1;
                int Cantidad = 3;

                string getPrecio = "SELECT Precio FROM tlibros WHERE ID = @LibroID";
                SqlCommand getPrecioCommand = new SqlCommand(getPrecio, connection);
                getPrecioCommand.Parameters.AddWithValue("@LibroID", LibroID);
                decimal Precio = (decimal)getPrecioCommand.ExecuteScalar();


                decimal ImportBruto = Cantidad * Precio;

                //DESCUENTO
                decimal Descuento = 0;
                if (Cantidad >= 3 && Cantidad <= 6)
                {
                    Descuento = ImportBruto * 0.06m; 
                }
                else if (Cantidad > 6)
                {
                    Descuento = ImportBruto * 0.08m; 
                }

                command.Parameters.AddWithValue("@ClienteID", ClienteID);
                command.Parameters.AddWithValue("@LibroID", LibroID);
                command.Parameters.AddWithValue("@Cantidad", Cantidad);
                command.Parameters.AddWithValue("@ImporteBruto", ImporteBruto);
                command.Parameters.AddWithValue("@Descuento", Descuento);

                command.ExecuteNonQuery();
            }
        }
    }
}