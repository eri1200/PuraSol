using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BLL;
using DAL;

namespace ProyectoPurasol.Models
{
    public class UsuarioCrear
    {
        [Required]
        public int IdUsuario { get; set; } //se tienen los constructores del IdUsuario
        [Required]
        public string NombreUsuario { get; set; } //se tienen los constructores de NOmbre Usuario
        [Required]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; } //se tienen los constructores de la contraseña

        [Required]
        public bool Activo { get; set; } //se tienen los constructores del Activo
        [Required]
        public string ListaRol { get; set; } //se tienen los constructores del ListaRol
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [Required]
        public string Descripcion { get; set; }
    }
}