using System.Data.SqlClient;

namespace PruebaTecnica.Datos
{
    public class ConexionBd
    {
        private string conexion= string.Empty;

        public ConexionBd()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            
            conexion = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSQL()
        {
            return conexion;
        }
    }
}
