using Microsoft.Data.SqlClient;
using StoreAPI.Conexion;
using StoreAPI.Modelo;
using System.Data;

namespace StoreAPI.Datos

{
    public class DatosProductos
    {
        readonly ConexionDB bd = new ConexionDB();
        public async Task<List<ModelProducts>> VerProducto()
        {var lista = new List<ModelProducts>();
            using (var sql = new SqlConnection(bd.CadenaSQL()))
            {
                await sql.OpenAsync();
                using (var cmd = new SqlCommand("VerProducto", sql))
                {
        
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproducts = new ModelProducts();
                            mproducts.description = (string)item["description"];
                            mproducts.image = (string)item["image"];
                            mproducts.category = (string)item["category"];
                            mproducts.star = (Boolean)item["star"];
                            mproducts.price = (decimal)item["price"];
                            mproducts.id = (int)item["id"];
                            lista.Add(mproducts);
                        }
                    }
                }   
            }
            return lista; 
        }
        public async Task insertarProducto(ModelProducts parametros)
        {
            using (var sql = new SqlConnection(bd.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@description", parametros.description);
                    cmd.Parameters.AddWithValue("@price", parametros.price);
                    cmd.Parameters.AddWithValue("@category", parametros.category);
                    cmd.Parameters.AddWithValue("@image", parametros.image);
                    cmd.Parameters.AddWithValue("@star", parametros.star);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }    
        }
       
        public async Task EditarProducto(ModelProducts parametros)
        {
            using (var sql = new SqlConnection(bd.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("EditarProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.id);
                    cmd.Parameters.AddWithValue("@description", parametros.description);
                    cmd.Parameters.AddWithValue("@price", parametros.price);
                    cmd.Parameters.AddWithValue("@category", parametros.category);
                    cmd.Parameters.AddWithValue("@image", parametros.image);
                    cmd.Parameters.AddWithValue("@star", parametros.star);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task eliminarProducto(ModelProducts parametros)
        {
            using (var sql = new SqlConnection(bd.CadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
