using Senai_Spmedgroup_API.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Spmedgroup_API.Interfaces
{
    public interface IConsultaRepository
    {
         void CadastrarConsulta(Consulta consulta);
        List<Consulta> ListaConsulta();

        List<Consulta> ListConsultaUsuario(int IdUsuario, int IdTipoUsuario);
    }
}
