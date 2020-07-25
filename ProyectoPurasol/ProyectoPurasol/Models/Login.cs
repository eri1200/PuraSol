using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoPurasol.Models
{
    public class LoginViewModel  //Creacion de la clase login
    {
        
            [Required] //Se requiere
            [Display(Name = "Usuario")] //Usuario, regular de expresion para evitar que se ingresen correos incorrectos
            [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", 
            ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
            [StringLength(100, ErrorMessage = "Longitud máxima 100")] //Mensaje de error si no se pone la logitud y la expresión correcta.
            [DataType(DataType.EmailAddress)]
            public string Usuario { get; set; } //Constructor del Usuario.
        
   

            [Required] //Espacios Requeridos
     
            [Display(Name = "Contraseña")] //Se requiere la contraseña
            [StringLength(15, ErrorMessage = "Longitud entre 6 y 15 caracteres.",
                      MinimumLength = 6)] //Se define la longitud, de la contraseña.
            [DataType(DataType.Password)] //Tipo de password.
            public string Password { get; set; } //Constructor de la contraseña.
       

            [Display(Name = "Recordar?")]  //Display para recordar a la persona.
            public bool RememberMe { get; set; } //Constructor de RememberMe.
        
    }
}