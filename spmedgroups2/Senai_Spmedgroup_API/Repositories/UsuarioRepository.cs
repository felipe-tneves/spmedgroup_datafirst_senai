using Microsoft.EntityFrameworkCore;
using Senai_Spmedgroup_API.Domains;
using Senai_Spmedgroup_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Spmedgroup_API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //busca por email 
        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            using (SPMEDGROUPContext login = new SPMEDGROUPContext())
            {
                Usuario usuarioPesquisa = login.Usuario.Include(x => x.IdTipoUsuarioNavigation).Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
                return usuarioPesquisa;

            }
        }

        //cadastra um novo usuario
        public void CadastrarUsuario(Usuario usuario)
        {
            using (SPMEDGROUPContext cadastra = new SPMEDGROUPContext())
            {
                cadastra.Usuario.Add(usuario);
                cadastra.SaveChanges();
            }
        }

        //listar usuarios 
        public List<Usuario> Listar()
        {
            using (SPMEDGROUPContext list = new SPMEDGROUPContext())
            {
                return list.Usuario.ToList();
            }
        }
    }
}
