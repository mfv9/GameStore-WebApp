using System;
using System.Collections.Generic;
using System.Text;

namespace DEMO2
{
    public class Fisico : VideoJuego
    {
        public int Stock { get; set; }
        public string Formato { get; set; }

        public Fisico(int stock, string formato, string name, decimal precio, string foto, string descripcion) : base(name,precio,foto,descripcion)
        {
            Stock = stock;
            Formato = formato;
        }
        public Fisico()
        {

        }
       


        public override decimal CalcularPrecioRealSiLlevaOnoDlc(bool llevaDLC)
        {
            return 0;
        }
    }
}
