using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Facturas
    {
        public int Id_Factura { get; set; }
        public string Folio { get; set; }
        public DateTime Fecha { get; set; }
        public int F_Proveedor { get; set; }
        public string AnotacionExtra { get; set; }
    }
}
