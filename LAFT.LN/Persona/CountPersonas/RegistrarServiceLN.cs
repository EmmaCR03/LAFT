using LAFT.Abstracciones.AccessoADatos.Interfaces.Persona.CountPersonas;
using LAFT.Abstracciones.LN.Interfaces.Persona.CountPersonas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAFT.LN.Persona.CountPersonas
{
    public class RegistrarServiceLN : IRegistrarServiceLN
    {
        IRegistrarRepositoryAD _repository;

        public RegistrarServiceLN()
        {
            _repository = new RegistrarRepositoryAD();
        }

        public int ObtenerTotalRegistrados()
        {
            return _repository.ObtenerTotalRegistrados();
        }
    }
}