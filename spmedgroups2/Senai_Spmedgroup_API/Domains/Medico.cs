using System;
using System.Collections.Generic;

namespace Senai_Spmedgroup_API.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public long Crm { get; set; }
        public string Agenda { get; set; }
        public string Telefone { get; set; }
        public int IdUsuario { get; set; }
        public int IdEspecialidade { get; set; }
        public int IdClinica { get; set; }

        public Clinica IdClinicaNavigation { get; set; }
        public Especialidade IdEspecialidadeNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
    }
}
