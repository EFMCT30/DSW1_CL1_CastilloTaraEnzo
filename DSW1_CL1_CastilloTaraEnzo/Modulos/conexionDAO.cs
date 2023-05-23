using Microsoft.Data.SqlClient;
namespace DSW1_CL1_CastilloTaraEnzo.Modulos
{
    public class conexionDAO
    {
        private SqlConnection cn = new SqlConnection(@"server=DESKTOP-HHJH2A8\SQLEXPRESS;Database=Negocios2023;Trusted_Connection=true;MultipleActiveResultSets=True;TrustServerCertificate=false;Encrypt=false;");

        public SqlConnection getcn { get { return cn; } }
    }
}
