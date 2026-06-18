using System;
using System.Collections.Generic;
using System.Text;

namespace DEMO2
{
    public class CarritoCompra
    {
        public VideoJuego VideoJuego { get; set; }
        public bool TieneDLC { get; set; }

        public decimal CalcularPrecioVideoJuego()
        {
            return VideoJuego.CalcularPrecioRealSiLlevaOnoDlc(TieneDLC);
        }
    }
}
