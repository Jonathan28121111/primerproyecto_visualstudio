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
                    
        public Task AgregarJuego(Juego juego)
        {
            juegos.Add(juego);
            return Task.CompletedTask;
        }
    }
}
    