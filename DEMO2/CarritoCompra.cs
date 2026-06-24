using System;
using System.Collections.Generic;
using System.Text;

namespace DEMO2
{
    public class CarritoCompra
    {
        public VideoJuego VideoJuego { get; set; }
        public bool CompraDLC { get; set; }

        public CarritoCompra(VideoJuego vj)
        {
            VideoJuego = vj;

        }

        public CarritoCompra()
        {

        }
        public decimal CalcularPrecioVideoJuego()
        {
            return VideoJuego.CalcularPrecioRealSiLlevaOnoDlc(CompraDLC);
        }
    }
}
