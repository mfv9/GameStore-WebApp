using System;
using System.Collections.Generic;
using System.Text;

namespace DEMO2
{
    public class Virtual : VideoJuego
    {
        public string Plataforma { get; set; }
        public double TamañoGB { get; set; }

        public Virtual(string plat, double size, string name, decimal precio, string foto, string descripcion, bool dlc) : base(name, precio, foto, descripcion,dlc)
        {
            Plataforma = plat;
            TamañoGB = size;
        }

        public Virtual()
        {

        }

        public override decimal CalcularPrecioRealSiLlevaOnoDlc(bool llevaDLC)
        {
            if (llevaDLC) {
                return Precio + 150;
            }
            return Precio;
        }

    }
}
    
