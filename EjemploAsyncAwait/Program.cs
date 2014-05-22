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

            var operaciones = new Operaciones(true);
            operaciones.EjecutarV2Async();


            Console.WriteLine("\r\nPulse la tecla intro para salir...\r\n");
            Console.ReadLine();
        }
    }
}
