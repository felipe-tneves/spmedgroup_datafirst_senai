using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai_Spmedgroup_API.Domains;

namespace Senai_Spmedgroup_API.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        public List<Medico> ListaMed()
        {
            using (SPMEDGROUPContext list = new SPMEDGROUPContext())
            {
                return list.Medico.ToList();
            }
        }
    }
}
