using Senai_Spmedgroup_API.Domains;
using Senai_Spmedgroup_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Spmedgroup_API.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        public void Cadastrar(Clinica clinica)
        {
            using (SPMEDGROUPContext cadclinica = new SPMEDGROUPContext())
            {
                cadclinica.Clinica.Add(clinica);
                cadclinica.SaveChanges();

            }
        }
    }
}
