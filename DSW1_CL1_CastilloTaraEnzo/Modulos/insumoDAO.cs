using Microsoft.Data.SqlClient;
using System.Data;
using DSW1_CL1_CastilloTaraEnzo.Models;
namespace DSW1_CL1_CastilloTaraEnzo.Modulos
{
    public class insumoDAO
    {
        private conexionDAO cn=new conexionDAO();

        public IEnumerable<Insumo> listado()
        {
            List<Insumo> temporal = new List<Insumo>();
            try
            {
                cn.getcn.Open();
                SqlCommand cmd = new SqlCommand("usp_insumos", cn.getcn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    temporal.Add(new Insumo()
                    {
                        codIns=rd.GetInt32(0),
                        desIns=rd.GetString(1),
                        codCate=rd.GetString(2),
                        preciou=rd.GetDecimal(3),
                        stockIns=rd.GetInt32(4)
                    });
                }
                rd.Close();
            }
            catch (SqlException ex) { temporal = new List<Insumo>(); }
            finally { cn.getcn.Close(); }
            return temporal;
        }
        public string agregar(Insumo reg)
        {
            string mensaje = "";
            try
            {
                cn.getcn.Open();
                SqlCommand cmd = new SqlCommand("usp_insertarInsumos", cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cod", reg.codIns);
                cmd.Parameters.AddWithValue("@des", reg.desIns);
                cmd.Parameters.AddWithValue("@idCate", reg.codCate);
                cmd.Parameters.AddWithValue("@precio", reg.preciou);
                cmd.Parameters.AddWithValue("@stock", reg.stockIns);
                int c = cmd.ExecuteNonQuery();
                mensaje = $"Se ha agregado {c} insumo(s)";
            }
            catch (SqlException ex) { mensaje = ex.Message; }
            finally { cn.getcn.Close(); }
            return mensaje;
        }
    }
}
