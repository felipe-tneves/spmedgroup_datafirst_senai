using Senai_Spmedgroup_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Spmedgroup_API
{
   public interface IMedicoRepository
   {
        List<Medico> ListaMed();

        
   }
}
