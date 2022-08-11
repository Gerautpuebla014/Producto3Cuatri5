using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    class Componente
    {
        public int Id_Cont { get; set; }
        public decimal PrecioCompra { get; set; }
        public string NumSerie { get; set; }
        public int Estado { get; set; }
        public bool Descontinuado { get; set; }
        public int F_factura { get; set; }
        public int F_Componente { get; set; }

    }
}
