using System.Data;

namespace DEMO2
{
    public class Cliente
    {
        private static int UltimoId { get; set; } = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechNac { get; set; }
        public string Rol { get; set; }
        public bool EsActivo { get; set; }

        public List<VideoJuego> MisCompras { get; set; } = new();

        public Cliente()
        {
            Id = UltimoId++;
            Rol = "Cliente";
            FechaAlta = DateTime.Now;
            EsActivo = true;
            
        }

        public Cliente(string nombre, string apellido, string email, string pass, DateTime fecha)
        {
            Id = UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = pass;
            FechNac = fecha;
            EsActivo = true;
            MisCompras = new List<VideoJuego>();
            Rol = "Cliente";
        }
         
        public void Validar()
        {

            if (String.IsNullOrEmpty(Nombre))
            {
                throw new Exception("Nombre vacio");
            }
            if (String.IsNullOrEmpty(Apellido))
            {
                throw new Exception("Apellido vacio");

            }
            if (String.IsNullOrEmpty(Email))
            {
                throw new Exception("Apellido vacio");

            }
          
            if (!ValidarEmail(Email))
            {
                throw new Exception("Mail arroba mal");

            }
            if (String.IsNullOrEmpty(Password))
            {
                throw new Exception("Apellido vacio");

            }
            if(FechNac > DateTime.Now)
            {
                throw new Exception("Verificra fecha de nacimiento");
            }
        }
        public bool ValidarEmail(string email)
        {
            int posArroba = email.IndexOf("@");

            if(posArroba != -1 && posArroba != 0 && posArroba != email.Length-1)
            {
                return true;
            }
            return false;
        }
        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   Email == cliente.Email;
        }
    }
}
