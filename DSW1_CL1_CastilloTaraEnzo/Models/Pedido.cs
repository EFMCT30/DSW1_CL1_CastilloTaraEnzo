using System.ComponentModel.DataAnnotations;
namespace DSW1_CL1_CastilloTaraEnzo.Models
{
    public class Pedido
    {
        [Display (Name ="Id Pedido")]
        public int idPedido { get; set; }

        [Display(Name = "Fecha Pedido")]
        public DateTime fecha{ get; set; }

        [Display(Name = "Cliente")]
        public string cliente { get; set; }

        [Display(Name = "Dirección")]
        public string direc { get; set; }

        public Pedido()
        {
            idPedido = 0;
            fecha= DateTime.Now;
            cliente = "";
            direc= "";
        }
    }
}
