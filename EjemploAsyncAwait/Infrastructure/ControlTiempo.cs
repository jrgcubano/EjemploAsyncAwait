using System;
using System.Threading;

namespace EjemploAsyncAwait.Infrastructure
{
    public static class ControlTiempo
    {
        public static DateTime Inicio { get; set; }
        public static DateTime Fin { get; set; }

        public static string VerInicio()
        {
            return string.Format("{0}. Thread inicial: {1}\r\n", Inicio, Thread.CurrentThread.ManagedThreadId);
        }

        public static string VerFin()
        {
            var diferencia = Fin - Inicio;
            return String.Format("\r\n{0}. Thread final: {1}. Duración: {2}", ControlTiempo.Fin, Thread.CurrentThread.ManagedThreadId, (int)diferencia.TotalSeconds);
        }
    }
}