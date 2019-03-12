using Senai_Spmedgroup_API.Domains;
using Senai_Spmedgroup_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Spmedgroup_API.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        public void CadastrarConsulta(Consulta consulta)
        {
            using (SPMEDGROUPContext cadconsulta = new SPMEDGROUPContext())
            {
                cadconsulta.Consulta.Add(consulta);
                cadconsulta.SaveChanges();

            }
        }

        public List<Consulta> ListaConsulta()
        {
            using (SPMEDGROUPContext list = new SPMEDGROUPContext())
            {
                return list.Consulta.ToList();
            }
        }

        public List<Consulta> ListConsultaUsuario(int IdUsuario, int IdTipoUsuario)
        {
            using (SPMEDGROUPContext listConsUsu = new SPMEDGROUPContext())
            {
                if (IdTipoUsuario == 2)
                {
                    Medico medico;
                    medico = listConsUsu.Medico.FirstOrDefault(x => x.IdUsuario == IdUsuario);
                    return listConsUsu.Consulta.Where(x => x.IdMedico == medico.Id).ToList();
                
                }

                if (IdTipoUsuario == 3)
                {
                    Prontuario prontuario;
                    prontuario = listConsUsu.Prontuario.FirstOrDefault(x => x.IdUsuario == IdUsuario);
                    return listConsUsu.Consulta.Where(x => x.IdProntuario == prontuario.Id).ToList();
                }

                return null;
            }
        }
    }
}
