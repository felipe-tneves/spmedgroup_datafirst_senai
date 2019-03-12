using Senai_Spmedgroup_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Spmedgroup_API.Interfaces
{
    public interface IUsuarioRepository
    {
        //buscando por email
        Usuario BuscarPorEmailSenha(string email, string senha);


    }
}
