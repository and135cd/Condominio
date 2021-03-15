using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominio
{
    class propiedad
    {
        string numCasa;
        string Dpi;
        float cuotaMantenimiento;

        public string NumCasa { get => numCasa; set => numCasa = value; }
        public string Dpi1 { get => Dpi; set => Dpi = value; }
        public float CuotaMantenimiento { get => cuotaMantenimiento; set => cuotaMantenimiento = value; }
    }
}
