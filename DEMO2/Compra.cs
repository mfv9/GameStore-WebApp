using System;
using System.Collections.Generic;
using System.Text;

namespace DEMO2
{
    public class Compra
    {
        private static int _ultimoId = 1;
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public Cliente Cliente { get; set; }

        public decimal Total { get; set; }

        public List<CarritoCompra> Juegos { get; set; } = new();
        public decimal PrecioFinalPagado { get; set; } = 0;

        public Compra(Cliente c, List<CarritoCompra> games, decimal total)
        {
            Id = _ultimoId++;
            Juegos = games;
            Fecha = DateTime.Now;
            Cliente = c;
            Total = total;

        }

        public Compra()
        {
            Id = _ultimoId++;
            Fecha = DateTime.Now;

        }

        public void CalcularYFijarPrecio()
        {
            if (PrecioFinalPagado.Equals(0))
            {
                decimal precioFinal = 0;

                foreach (CarritoCompra cc in Juegos)
                {
                    precioFinal += cc.CalcularPrecioVideoJuego();
                }
                PrecioFinalPagado = precioFinal;
            }
        }
    }
}

