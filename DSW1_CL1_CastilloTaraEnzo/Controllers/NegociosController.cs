using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using DSW1_CL1_CastilloTaraEnzo.Models;

namespace DSW1_CL1_CastilloTaraEnzo.Controllers
{
    public class NegociosController : Controller
    {
        //CNX
        string cadena = @"server=DESKTOP-HHJH2A8\SQLEXPRESS;Database=Negocios2023;Trusted_Connection=true;MultipleActiveResultSets=True;TrustServerCertificate=false;Encrypt=false;";
        
        //LISTA PEDIDOS
        IEnumerable<Pedido> pedido()
        {
            List<Pedido> temporal = new List<Pedido>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_listapedidos", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Pedido()
                    {
                        idPedido = dr.GetInt32(0),
                        fecha = dr.GetDateTime(1),
                        cliente = dr.GetString(2),
                        direc = dr.GetString(3),
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public async Task<IActionResult> ListaPedidos()
        {
            return View(await Task.Run(() => pedido()));
        }

        //LISTA PEDIDOS X AÑO
        IEnumerable<Pedido> pedidoYear(int y)
        {
            List<Pedido> temporal = new List<Pedido>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("usp_listapedidos_year", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@y", y);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Pedido()
                    {
                        idPedido = dr.GetInt32(0),
                        fecha = dr.GetDateTime(1),
                        cliente = dr.GetString(2),
                        direc = dr.GetString(3),
                    });
                }
                dr.Close();
            }
            return temporal;

        }

        public async Task<IActionResult> ListaPedidosYear(int? y = null)
        { 
            return View(await Task.Run(() => pedidoYear(y == null ? 0 : y.Value)));

        }

        //PAGINACION x AÑO
        public async Task<IActionResult> PaginacionPedidosXYear(int p = 0, int ? y = null)
        {
            IEnumerable<Pedido> temporal = pedidoYear(y == null ? 0 : y.Value);
            int c = temporal.Count();
            int f = 10;
            int pags = c % f == 0 ? c / f : c / f + 1;

            ViewBag.p = p;
            ViewBag.pags = pags;
            ViewBag.y = (y == null ? 0 : y.Value) ;

            return View(await Task.Run(() => temporal.Skip(p * f).Take(f)));
        }
    }
}
