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

        //cadastra qualquer tipo de usuario 
        void CadastrarUsuario(Usuario usuario);

        //lista de usuarios 
        List<Usuario> Listar();


    }
}
