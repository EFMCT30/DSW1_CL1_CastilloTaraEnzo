using Microsoft.Data.SqlClient;
using System.Data;
using DSW1_CL1_CastilloTaraEnzo.Models;

namespace DSW1_CL1_CastilloTaraEnzo.Modulos
{
    public class categoriaDAO
    {
        private conexionDAO cn = new conexionDAO();

        public IEnumerable<Categoria> listado()
        {
            List<Categoria> temporal = new List<Categoria>();
            try
            {
                cn.getcn.Open();
                SqlCommand cmd = new SqlCommand("usp_categorias", cn.getcn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    temporal.Add(new Categoria()
                    {
                        codiCate = rd.GetInt32(0),
                        nombreCate = rd.GetString(1)
                    });
                }
                rd.Close();
            }
            catch (SqlException ex) { temporal = new List<Categoria>(); }
            finally { cn.getcn.Close(); }
            return temporal;
        }
    }
}
