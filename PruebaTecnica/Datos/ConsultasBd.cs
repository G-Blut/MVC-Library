using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PruebaTecnica.Models;
using System.Data;
using System.Data.SqlClient;

namespace PruebaTecnica.Datos
{
    public class ConsultasBd
    {
        ConexionBd cn = new ConexionBd();

        public List<EstudianteModel> LectorEstudiante()
        {
            var oLEstudiante = new List <EstudianteModel>();
            var cn = new ConexionBd();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Leer", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLEstudiante.Add(new EstudianteModel()
                        {
                            IdRows = Convert.ToInt32(dr["IdRows"]),
                            StrNombre = dr["StrNombre"].ToString(),
                            IntDocumento = Convert.ToInt32(dr["IntDocumento"]),
                            StrPrograma = dr["StrPrograma"].ToString()

                        }) ;
                    }
                }
            }return oLEstudiante;
        }

        public EstudianteModel ObtenerEstudiante(int IdRows)
        {
            var oEstudiante = new EstudianteModel();
            var cn = new ConexionBd();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("@IdRows", IdRows);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oEstudiante.IdRows = Convert.ToInt32(dr["IdRows"]);
                        oEstudiante.StrNombre = dr["StrNombre"].ToString();
                        oEstudiante.IntDocumento = Convert.ToInt32(dr["IntDocumento"]);
                        oEstudiante.StrPrograma = dr["StrPrograma"].ToString();
                    }
                }
            }
            return oEstudiante;
        }

        public bool Guardar(EstudianteModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new ConexionBd();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("StrNombre", ocontacto.StrNombre);
                    cmd.Parameters.AddWithValue("IntDocumento", ocontacto.IntDocumento);
                    cmd.Parameters.AddWithValue("StrPrograma", ocontacto.StrPrograma);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Editar(EstudianteModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new ConexionBd();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("@IdRows", ocontacto.IdRows);
                    cmd.Parameters.AddWithValue("@IntDocumento", ocontacto.IntDocumento);
                    cmd.Parameters.AddWithValue("@Nombre", ocontacto.StrNombre);
                    cmd.Parameters.AddWithValue("@Programa", ocontacto.StrPrograma);
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        

        [HttpPost]
        public bool EliminarEstudiante(int IdRows)
        {
            bool rpta;
            try
            {
                var cn = new ConexionBd();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("@IdRows", IdRows);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
 ////////////////////////////////////Inicio de zona de control del area Libro///////////////////////////////////////
        
        [HttpGet]
        public List<LibroModel> LeerLibro()
        {
            var cn = new ConexionBd();
            var oLibro = new List<LibroModel>();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_LeerLibro", conexion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr=cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLibro.Add(new LibroModel()
                        {
                            IdRows = Convert.ToInt32(dr["IdRows"]),
                            StrNombreLibro = dr["StrNombreLibro"].ToString(),
                            StrNomAutor = dr["StrNomAutor"].ToString(),
                            StrLuNacimiento = dr["StrLuNacimiento"].ToString(),
                            DtmNacimiento = Convert.ToDateTime(dr["DtmNacimiento"].ToString()),
                            DtmPublicacion = Convert.ToDateTime(dr["DtmPublicacion"].ToString())
                        });
                    }
                }
            }return oLibro;
        }

        public bool GuardarLibro(LibroModel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new ConexionBd();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarLibro", conexion);
                    cmd.Parameters.AddWithValue("StrNombreLibro", ocontacto.StrNombreLibro);
                    cmd.Parameters.AddWithValue("StrNomAutor", ocontacto.StrNomAutor);
                    cmd.Parameters.AddWithValue("StrLuNacimiento", ocontacto.StrLuNacimiento);
                    cmd.Parameters.AddWithValue("DtmNacimiento", ocontacto.DtmNacimiento);
                    cmd.Parameters.AddWithValue("DtmPublicacion", ocontacto.DtmPublicacion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }


        public bool EditarLibro(LibroModel oLibro)
        {
            bool rpta;

            try
            {
                var cn = new ConexionBd();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarLibro", conexion);
                    cmd.Parameters.AddWithValue("@IdRows", oLibro.IdRows);
                    cmd.Parameters.AddWithValue("@StrNombreLibro", oLibro.StrNombreLibro);
                    cmd.Parameters.AddWithValue("@StrNomAutor", oLibro.StrNomAutor);
                    cmd.Parameters.AddWithValue("@StrLuNacimiento", oLibro.StrLuNacimiento);
                    cmd.Parameters.AddWithValue("@DtmNacimiento", oLibro.DtmNacimiento);
                    cmd.Parameters.AddWithValue("@DtmPublicacion", oLibro.DtmPublicacion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public LibroModel ObtenerLibro(int IdRows)
        {
            var oLibro = new LibroModel();
            var cn = new ConexionBd();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerLibro", conexion);
                cmd.Parameters.AddWithValue("IdRows", IdRows);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLibro.IdRows = Convert.ToInt32(dr["IdRows"]);
                        oLibro.StrNombreLibro = dr["StrNombreLibro"].ToString();
                        oLibro.StrNomAutor = dr["StrNomAutor"].ToString();
                        oLibro.StrLuNacimiento = dr["StrLuNacimiento"].ToString();
                        oLibro.DtmNacimiento = Convert.ToDateTime(dr["DtmNacimiento"].ToString());
                        oLibro.DtmPublicacion = Convert.ToDateTime(dr["DtmPublicacion"].ToString());
                    }
                }
            }
            return oLibro;
        }

        [HttpPost]
        public bool EliminarLibro(int IdRows)
        {
            bool rpta;
            try
            {
                var cn = new ConexionBd();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarLibros", conexion);
                    cmd.Parameters.AddWithValue("@IdRows", IdRows);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        ////////////////////////////////////Inicio de zona de control del area prestamo///////////////////////////////////////
        [HttpGet]
        public List<PrestamoModel> LeerPrestamo()
        {
            var cn = new ConexionBd();
            var oPrestamo = new List<PrestamoModel>();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_LeerPrestamo", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oPrestamo.Add(new PrestamoModel()
                        {
                            IdRows = Convert.ToInt32(dr["IdRows"]),
                            StrNombreLibro = dr["StrNombreLibro"].ToString(),
                            StrNombre = dr["StrNombre"].ToString(),
                            DtmFechaPrestamo = Convert.ToDateTime(dr["DtmFechaPrestamo"].ToString()),
                            DtmFechaRegreso = Convert.ToDateTime(dr["DtmFechaRegreso"].ToString())
                        });
                    }
                }
            }
            return oPrestamo;
        }

        public bool GuardarPrestamo(PrestamoModel oPrestamo)
        {
            bool rpta;

            try
            {
                var cn = new ConexionBd();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarPrestamo", conexion);
                    cmd.Parameters.AddWithValue("StrNombreLibro",  oPrestamo.StrNombreLibro);
                    cmd.Parameters.AddWithValue("StrNombre",       oPrestamo.StrNombre);
                    cmd.Parameters.AddWithValue("DtmFechaRegreso", oPrestamo.DtmFechaRegreso);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }


    } 
}
