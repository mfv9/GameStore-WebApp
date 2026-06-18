using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DEMO2
{
    public class Sistema
    {
        private static Sistema instancia = null;

        private List<Cliente> _clientes = new List<Cliente>();
        private List<VideoJuego> _juegos = new List<VideoJuego>();
        private List<Compra> _compras = new List<Compra>();
        public Compra CarritoActual { get; set; } = new Compra();



        private Sistema()
        {
            Precarga();
        }

        public static Sistema getInstance()
        {
            if (instancia == null)
            {
                instancia = new Sistema();
            }
            return instancia;
        }
        public void AltaCliente(Cliente c)
        {
            c.Validar();
            if (!_clientes.Contains(c))
            {
                _clientes.Add(c);
            }
            else
            {
                throw new Exception("Ya existe el mail");
            }
        }

        public void AltaJuego(VideoJuego v)
        {
            _juegos.Add(v);
        }
        public void AltaCompra(Compra  c)
        {
            _compras.Add(c);
        }


        public Cliente FindClientById(int id)
        {
            foreach (Cliente c in _clientes)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            return null;
        }

        public void ActualizarUsuario(Cliente c)
        {
            Cliente buscado = FindClientById(c.Id);

            if (buscado != null)
            {
                buscado.Nombre = c.Nombre;
                buscado.Apellido = c.Apellido;
                buscado.Password = c.Password;
                buscado.Email = c.Email;
                buscado.FechNac = c.FechNac;
            }
        }

        public void DesactivarUsuario(Cliente c)
        {
            Cliente buscado = FindClientById(c.Id);

            if (buscado != null)
            {
                buscado.EsActivo = false;
            }
        }

        public void ActivarUsuario(Cliente c)
        {
            Cliente buscado = FindClientById(c.Id);

            if (buscado.EsActivo == true)
            {
                throw new Exception("No se puede activar a alguien ya activado JA");
            }
            if (buscado != null && buscado.EsActivo == false)
            {
                buscado.EsActivo = true;
            }


        }
        public List<Cliente> GetClientes()
        {
            return _clientes;
        }
        public List<VideoJuego> GetJuegos()
        {
            return _juegos;
        }

        public List<Compra> GetCompras()
        {
            return _compras;
        }


        public Cliente VerificarExistencia(string email, string pass)
        {
            foreach (Cliente c in _clientes)
            {
                if (c.Email.Equals(email) && c.Password.Equals(pass))
                {
                    return c;
                }
            }
            return null;
        }

        public List<VideoJuego> BuscarJuego(string buscador)
        {
            if (string.IsNullOrWhiteSpace(buscador))
            {
                return new List<VideoJuego>();
            }

            List<VideoJuego> ret = new List<VideoJuego>();

            foreach (VideoJuego juego in _juegos)
            {
                if (juego.Nombre.ToLower().Contains(buscador.ToLower()) || juego.Descripcion.ToLower().Contains(buscador.ToLower()))
                {
                    ret.Add(juego);
                }

            }
            return ret;
        }

        public VideoJuego FindJuegoPor(int id)
        {
            foreach(VideoJuego vj in _juegos)
            {
                if(vj.Id == id)
                {
                    return vj;
                }
            }
            return null;
        }

        public void AgregarAlCarrito(int id, bool dlc)
        {
            VideoJuego juego = FindJuegoPor(id);
            if(juego!=null)
            {
                CarritoCompra item = new CarritoCompra
                {
                    VideoJuego = juego,
                    TieneDLC = dlc
                };
                CarritoActual.Juegos.Add(item);
            }
        }
        private void Precarga()
        {

            Fisico j1 = new Fisico();
            j1.Nombre = "Apex Legends";
            j1.Precio = 40;
            j1.Formato = "Bluray";
            j1.Foto = "apex.jpg";
            j1.Stock = 30;
            j1.Descripcion = "Apex Legends es un videojuego de disparos en primera persona del género battle royale. Los jugadores forman escuadrones y compiten en un mapa donde deben sobrevivir eliminando rivales y aprovechando las habilidades únicas de cada personaje.";

            Fisico j2 = new Fisico();
            j2.Nombre = "Call of Duty: Modern Warfare II";
            j2.Precio = 70;
            j2.Formato = "Bluray";
            j2.Foto = "callofduty.jpg";
            j2.Stock = 50;
            j2.Descripcion = "Call of Duty: Modern Warfare II es un shooter en primera persona que continúa la historia de la Fuerza Operativa 141. Incluye una campaña cinematográfica, modos multijugador competitivos y experiencias cooperativas.";

            Fisico j3 = new Fisico();
            j3.Nombre = "Counter-Strike 2";
            j3.Precio = 30;
            j3.Formato = "Bluray";
            j3.Foto = "cs2.jpg";
            j3.Stock = 20;
            j3.Descripcion = "Counter-Strike 2 es un juego de disparos táctico por equipos donde terroristas y antiterroristas se enfrentan en rondas basadas en objetivos como desactivar bombas o rescatar rehenes.";

            Fisico j4 = new Fisico();
            j4.Nombre = "EA Sports FC 25";
            j4.Precio = 60;
            j4.Formato = "Bluray";
            j4.Foto = "FC25.jpg";
            j4.Stock = 40;
            j4.Descripcion = "EA Sports FC 25 es un simulador de fútbol que permite disputar partidos, gestionar equipos y competir en distintos modos de juego con licencias oficiales de clubes, ligas y futbolistas.";

            AltaJuego(j1);
            AltaJuego(j2);
            AltaJuego(j3);
            AltaJuego(j4);

            Virtual j5 = new Virtual();
            j5.Nombre = "Fortnite";
            j5.Precio = 0;
            j5.Foto = "fortnite.jpg";
            j5.Plataforma = "PC";
            j5.TamañoGB = 50;
            j5.Descripcion = "Fortnite es un videojuego multijugador de acción y supervivencia conocido por su modo battle royale, donde cien jugadores compiten para ser el último en pie mientras construyen estructuras y exploran el mapa.";

            Virtual j6 = new Virtual();
            j6.Nombre = "Genshin Impact";
            j6.Precio = 0;
            j6.Foto = "GenshinImpact.jpg";
            j6.Plataforma = "PC";
            j6.TamañoGB = 100;
            j6.Descripcion = "Genshin Impact es un RPG de acción de mundo abierto ambientado en el continente de Teyvat. Los jugadores exploran, completan misiones y forman equipos de personajes con habilidades elementales.";

            Virtual j7 = new Virtual();
            j7.Nombre = "Minecraft";
            j7.Precio = 30;
            j7.Foto = "minecraft.jpg";
            j7.Plataforma = "PC";
            j7.TamañoGB = 2;
            j7.Descripcion = "Minecraft es un juego de construcción y aventura en un mundo generado de forma procedimental. Permite recolectar recursos, fabricar objetos, construir estructuras y sobrevivir frente a criaturas.";

            Virtual j8 = new Virtual();
            j8.Nombre = "Roblox";
            j8.Precio = 0;
            j8.Foto = "roblox.jpg";
            j8.Plataforma = "PC";
            j8.TamañoGB = 1;
            j8.Descripcion = "Roblox es una plataforma de videojuegos en línea donde los usuarios pueden crear, compartir y jugar experiencias desarrolladas por la comunidad en una gran variedad de géneros.";

            AltaJuego(j5);
            AltaJuego(j6);
            AltaJuego(j7);
            AltaJuego(j8);

            Cliente c2 = new Cliente();
            c2.Id = 1;
            c2.Nombre = "Juan";
            c2.Apellido = "Pérez";
            c2.Email = "admin@gmail";
            c2.Password = "11";
            c2.FechNac = new DateTime(1990, 5, 12);
            c2.FechaAlta = DateTime.Now.AddMonths(-12);
            c2.EsActivo = true;
            c2.Rol = "Administrador";

            AltaCliente(c2);

            Cliente c1 = new Cliente("Mateo", "Fernandez", "pepe@gmail.com", "11", DateTime.Now.AddYears(-12));
            AltaCliente(c1);



        }
    }
}
