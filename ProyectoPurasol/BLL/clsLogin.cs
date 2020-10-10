using API_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsLogin
    {
        public string ValidarInicio(string User, string contraseña)
        {
            clsUsuario Objusuario = new clsUsuario();
            var usuario = Objusuario.ConsultarUsuario(User, contraseña);


            if (usuario.Count() > 0)
            {
                var token = TokenGenerator.GenerateTokenJwt(User);
                return (token);
            }
            else
            {
                return null;
            }
        }
    }
}
