using primerproyecto.Components.Data;

namespace primerproyecto.Components.Servicio
{
    public class ServicioControlador
    {
        private readonly ServicioJuegos _servicioJuegos;

        public ServicioControlador(ServicioJuegos servicioJuegos)

        {
            _servicioJuegos = servicioJuegos;
        }

        public async Task<List<Juego>> ObtenerJuegos()
        {
            return await _servicioJuegos.ObtenerJuegos();
        }

        public async Task<List<Juego>> ActualizarDatosDesdeServidor()
        {
            return await _servicioJuegos.ActualizarDatosDesdeServidor();
        }

        public async Task AgregarJuego(Juego juego)
        {
            juego.Identificador = await GenerarNuevoID();
            await _servicioJuegos.AgregarJuego(juego);
        }

        public async Task CambiarEstadoJuego(int identificador)
        {
            await _servicioJuegos.CambiarEstadoJuego(identificador);
        }

        public async Task CambiarEstadoTodos(bool nuevoEstado)
        {
            await _servicioJuegos.CambiarEstadoTodos(nuevoEstado);
        }

        private async Task<int> GenerarNuevoID()
        {
            var juegos = await _servicioJuegos.ObtenerJuegos();
            return juegos.Any() ? juegos.Max(j => j.Identificador) + 1 : 1;
        }
    }
}