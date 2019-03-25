using System;
using System.Collections.Generic;

namespace Senai_Spmedgroup_API.Domains
{
    public partial class Consulta
    {
        public int Id { get; set; }
        public string Situacao { get; set; }
        public string Anamnesia { get; set; }
        public DateTime DataCons { get; set; }
        public int? IdMedico { get; set; }
        public int? IdProntuario { get; set; }

        public Medico IdMedicoNavigation { get; set; }
        public Prontuario IdProntuarioNavigation { get; set; }
    }
}
