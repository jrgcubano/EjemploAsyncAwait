using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EjemploAsyncAwait.Infrastructure
{
    class Operaciones
    {
        public int Ejecutar()
        {
            var dosSegundos = DosSegundos();
            var tresSegundos = TresSegundos();
            var suma = dosSegundos + tresSegundos;

            Console.WriteLine("Resultado de la operación (Ejecutar): " + suma);

            ControlTiempo.Fin = DateTime.Now;
            ControlTiempo.MuestraFin();
            return suma;
        }

        int DosSegundos()
        {
            const int millisecondsTimeout = 2000;
            Thread.Sleep(millisecondsTimeout);
            Console.WriteLine("ThreadId (DosSegundos): " + Thread.CurrentThread.ManagedThreadId);

            return millisecondsTimeout / 1000;
        }

        int TresSegundos()
        {
            const int millisecondsTimeout = 3000;
            Thread.Sleep(millisecondsTimeout);
            Console.WriteLine("ThreadId (TresSegundos): " + Thread.CurrentThread.ManagedThreadId);

            return millisecondsTimeout / 1000;
        }

        public async void EjecutarV2Async()
        {
            var dosSegundosAsync = DosSegundosAsync();
            var tresSegundosAsync = TresSegundosAsync();

            var ints = await Task.WhenAll(dosSegundosAsync, tresSegundosAsync);

            var suma = ints.Sum();

            Console.WriteLine("Resultado de la operación (EjecutarV2Async): " + suma);
            ControlTiempo.Fin = DateTime.Now;
            ControlTiempo.MuestraFin();
        }

        [Obsolete]
        public async void EjecutarAsync()
        {
            var dosSegundosAsync = await DosSegundosAsync();
            var tresSegundosAsync = await TresSegundosAsync();

            var suma = dosSegundosAsync + tresSegundosAsync;

            Console.WriteLine("Resultado de la operación (EjecutarAsync): " + suma);
            ControlTiempo.Fin = DateTime.Now;
            ControlTiempo.MuestraFin();
        }

        async Task<int> DosSegundosAsync()
        {
            Console.WriteLine("DosSegundosAsync antes de await: " + Thread.CurrentThread.ManagedThreadId);
            var value = await Task.Run(() => DosSegundos());
            Console.WriteLine("DosSegundosAsync después de await: " + Thread.CurrentThread.ManagedThreadId);

            return value;
        }

        async Task<int> TresSegundosAsync()
        {
            Console.WriteLine("TresSegundosAsync antes de await: " + Thread.CurrentThread.ManagedThreadId);
            var value = await Task.Run(() => TresSegundos());
            Console.WriteLine("TresSegundosAsync después de await: " + Thread.CurrentThread.ManagedThreadId);

            return value;
        }
    }
}