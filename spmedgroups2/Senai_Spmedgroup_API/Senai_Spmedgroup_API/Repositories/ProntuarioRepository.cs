using Senai_Spmedgroup_API.Domains;
using Senai_Spmedgroup_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Spmedgroup_API.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        public List<Prontuario> ListProntuario()
        {
            using (SPMEDGROUPContext list = new SPMEDGROUPContext())
            {
                return list.Prontuario.ToList();
            }
        }
    }
}
