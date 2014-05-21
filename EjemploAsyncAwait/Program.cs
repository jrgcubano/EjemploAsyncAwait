using System;
using EjemploAsyncAwait.Infrastructure;

namespace EjemploAsyncAwait
{
    class Program
    {
        static void Main()
        {
            ControlTiempo.Inicio = DateTime.Now;
            ControlTiempo.MuestraInicio();

            var operaciones = new Operaciones();
            operaciones.EjecutarV2Async();

            Console.WriteLine("Pulse la tecla intro para salir");
            Console.ReadLine();
        }
    }
}
