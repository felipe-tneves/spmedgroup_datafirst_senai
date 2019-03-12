using Senai_Spmedgroup_API.Domains;
using Senai_Spmedgroup_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Spmedgroup_API.Repositories
{
    public class UsarioRepository : IUsuarioRepository
    {
        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            using (SPMEDGROUPContext login = new SPMEDGROUPContext())
            {
                Usuario usuarioPesquisa = login.Usuario.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
                return usuarioPesquisa;

            }
        }
    }
}
