using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace primerproyecto.Components.Data
{
    public class ServicioJuegos
    {
        private List<Juego> juegos = new List<Juego>
        {
            new Juego { Identificador = 1, Nombre = "Fortnite", Jugado = true },
            new Juego { Identificador = 2, Nombre = "GTA 6", Jugado = false },
        };

        public Task<List<Juego>> ObtenerJuegos() => Task.FromResult(juegos);

        public Task<List<Juego>> ActualizarDatosDesdeServidor()
        {
            return Task.FromResult(new List<Juego>(juegos));
        }

        public Task AgregarJuego(Juego juego)
        {
            juegos.Add(juego);
            return Task.CompletedTask;
        }

        public Task CambiarEstadoJuego(int identificador)
        {
            var juego = juegos.FirstOrDefault(j => j.Identificador == identificador);
            if (juego != null)
            {
                juego.Jugado = !juego.Jugado;
            }
            return Task.CompletedTask;
        }

        public Task CambiarEstadoTodos(bool nuevoEstado)
        {
            foreach (var juego in juegos)
            {
                juego.Jugado = nuevoEstado;
            }
            return Task.CompletedTask;
        }

        public Task EliminarJuego(int identificador)
        {
            var juego = juegos.FirstOrDefault(j => j.Identificador == identificador);
            if (juego != null)
            {
                juegos.Remove(juego);
            }
            return Task.CompletedTask;
        }
    }
}
