using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominio
{
    class reporte
    {
        string nombre;
        string apellido;
        string numCasa;
        float cuotaMantenimeinto;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string NumCasa { get => numCasa; set => numCasa = value; }
        public float CuotaMantenimeinto { get => cuotaMantenimeinto; set => cuotaMantenimeinto = value; }
    }
}
