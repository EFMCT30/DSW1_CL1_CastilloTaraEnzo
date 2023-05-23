using System.ComponentModel.DataAnnotations;
namespace DSW1_CL1_CastilloTaraEnzo.Models
{
    public class Categoria
    {
        [Display(Name = "Código")]
        public int codiCate { get; set; }
        [Display(Name = "NombreCategoria")]
        public string nombreCate { get; set; }
        

        public Categoria()
        {
            codiCate = 0;
            nombreCate = string.Empty;
        }
    }
}
