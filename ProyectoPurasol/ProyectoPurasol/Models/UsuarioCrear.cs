using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using DAL;

namespace ProyectoPurasol.Models
{
    public class UsuarioCrear
    {
        public int IdUsuario { get; set; } //se tienen los constructores del IdUsuario

        public string NombreUsuario { get; set; } //se tienen los constructores de NOmbre Usuario

        public string Contrasena { get; set; } //se tienen los constructores de la contraseña

        public bool Activo { get; set; } //se tienen los constructores del Activo
        public string ListaRol { get; set; } //se tienen los constructores del ListaRol
        public string Correo { get; set; }
        public string Descripcion { get; set; }
    }
}