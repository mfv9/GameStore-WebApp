using System;
using System.Collections.Generic;
using System.Text;

namespace DEMO2
{
    public class Fisico : VideoJuego
    {
        public int Stock { get; set; }
        public string Formato { get; set; }

        public Fisico(int stock, string formato, string name, decimal precio, string foto, string descripcion,bool dlc ) : base(name,precio,foto,descripcion, dlc)
        {
            Stock = stock;
            Formato = formato;
            DLC = dlc;
        }
        public Fisico()
        {

        }
       


        public override decimal CalcularPrecioRealSiLlevaOnoDlc(bool llevaDLC)
        {
            if (llevaDLC)
            {
               return Precio + 250;
            }
            return Precio;
        }
    }
}
