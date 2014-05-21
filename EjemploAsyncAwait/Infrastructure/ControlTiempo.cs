using System;
using System.Threading;

namespace EjemploAsyncAwait.Infrastructure
{
    public static class ControlTiempo
    {
        public static DateTime Inicio { get; set; }
        public static DateTime Fin { get; set; }

        public static void MuestraInicio()
        {
            Console.WriteLine("{0}. Thread inicial: {1}\r\n", Inicio, Thread.CurrentThread.ManagedThreadId);
        }

        public static void MuestraFin()
        {
            var diferencia = Fin - Inicio;
            Console.WriteLine("\r\n{0}. Thread final: {1}. Duración: {2}", ControlTiempo.Fin, Thread.CurrentThread.ManagedThreadId, (int)diferencia.TotalSeconds);
        }
    }
}