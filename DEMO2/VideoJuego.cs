using System;
using System.Collections.Generic;
using System.Text;

namespace DEMO2
{
    public abstract class VideoJuego
    {
        private static int _ultimoId = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Foto { get; set; }
        public string Descripcion { get; set; }
        public bool DLC { get; set; }

       
        public VideoJuego(string name, decimal precio, string foto, string descripcion, bool dlc)
        {
            Id = _ultimoId++;
            Nombre = name;
            Precio = precio;
            Foto = foto;
            Descripcion = descripcion;
            DLC = dlc;
           
        }

        public VideoJuego()
        {
            
            Id = _ultimoId++;
        }

        
        public abstract decimal CalcularPrecioRealSiLlevaOnoDlc(bool llevaDLC);

    }
}
