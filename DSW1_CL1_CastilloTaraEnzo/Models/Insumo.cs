using System.ComponentModel.DataAnnotations;
namespace DSW1_CL1_CastilloTaraEnzo.Models
{
    public class Insumo
    {
        [Display(Name ="Código")]
        public int codIns { get; set; }
        [Display(Name ="Descripción")]
        public string desIns { get; set; }
        [Display(Name = "Categoria")]
        public string codCate { get; set; }
        [Display(Name = "Precio Unit")]
        public decimal preciou { get; set; }
        [Display(Name = "Stock")]
        public int stockIns { get; set; }

        public Insumo()
        {
            codIns= 0;
            desIns = string.Empty;
            codCate= string.Empty;
            preciou= 0;
            stockIns= 0;
        }

    }
}
