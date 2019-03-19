using System;
using System.Collections.Generic;

namespace Senai_Spmedgroup_API.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medico = new HashSet<Medico>();
            Prontuario = new HashSet<Prontuario>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdTipoUsuario { get; set; }

        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public ICollection<Medico> Medico { get; set; }
        public ICollection<Prontuario> Prontuario { get; set; }
    }
}
