using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EjemploAsyncAwait.Infrastructure
{
    class Operaciones
    {
        private readonly bool _mostrarDetalleAsyncEnConsola;

        public Operaciones(bool mostrarDetalleAsyncEnConsola)
        {
            _mostrarDetalleAsyncEnConsola = mostrarDetalleAsyncEnConsola;
        }

        public int Ejecutar()
        {
            int dos = DosSegundos();
            int tres = TresSegundos();
            int suma = dos + tres;

            Console.WriteLine("Resultado de la operación (Ejecutar): " + suma);

            ControlTiempo.Fin = DateTime.Now;
            ControlTiempo.MuestraFin();
            return suma;
        }

        int DosSegundos()
        {
            const int timeout = 2000;
            Thread.Sleep(timeout);
            Console.WriteLine("ThreadId (DosSegundos): {0}", Thread.CurrentThread.ManagedThreadId);

            return timeout / 1000;
        }

        int TresSegundos()
        {
            const int timeout = 3000;
            Thread.Sleep(timeout);
            Console.WriteLine("ThreadId (TresSegundos): {0}", Thread.CurrentThread.ManagedThreadId);

            return timeout / 1000;
        }

        [Obsolete]
        public async void EjecutarAsync()
        {
            int dos = await DosSegundosAsync();
            int tres = await TresSegundosAsync();

            var suma = dos + tres;

            Console.WriteLine("Resultado de la operación (EjecutarAsync): {0}", suma);
            ControlTiempo.Fin = DateTime.Now;
            ControlTiempo.MuestraFin();
        }

        public async void EjecutarV2Async()
        {
            Task<int> dos = DosSegundosAsync();
            Task<int> tres = TresSegundosAsync();

            int[] ints = await Task.WhenAll(dos, tres);

            var suma = ints.Sum();

            Console.WriteLine("Resultado de la operación (EjecutarV2Async): {0}", suma);
            ControlTiempo.Fin = DateTime.Now;
            ControlTiempo.MuestraFin();
        }

        async Task<int> DosSegundosAsync()
        {
            MostrarDetalleAsyncEnConsola("DosSegundosAsync antes de await", Thread.CurrentThread.ManagedThreadId);
            var value = await Task.Run(() => DosSegundos());
            MostrarDetalleAsyncEnConsola("DosSegundosAsync después de await", Thread.CurrentThread.ManagedThreadId);

            return value;
        }

        async Task<int> TresSegundosAsync()
        {
            MostrarDetalleAsyncEnConsola("TresSegundosAsync antes de await", Thread.CurrentThread.ManagedThreadId);
            var value = await Task.Run(() => TresSegundos());
            MostrarDetalleAsyncEnConsola("TresSegundosAsync después de await", Thread.CurrentThread.ManagedThreadId);

            return value;
        }

        private void MostrarDetalleAsyncEnConsola(string text, int? managedThreadId = null)
        {
            var template = "{0}.";

            if (_mostrarDetalleAsyncEnConsola)
            {
                if (managedThreadId.HasValue)
                {
                    template += " ThreadId: {1}";
                }

                Console.WriteLine(template, text, managedThreadId);
            }
        }
    }
}