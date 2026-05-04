
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IA2026
{

       public static class CLlgoritmoDeBusqueda 
        {
        public static List<CLEstado> AnchuraPrioritaria(CLEstado Inicial)
        {
            //definicion de variables 
            List<CLEstado> Solucion = new List<CLEstado>();
            List<CLEstado> Abierto = new List<CLEstado>();
            List<CLEstado> Cerrado = new List<CLEstado>();
            List<CLEstado> Hijo = new List<CLEstado>();
            CLEstado Actual = new CLEstado();
            //algoritmos
            Abierto.Add(Inicial);
            Actual = Abierto[0];
            while (!Actual.EsFinal()&&Abierto.Count > 0)
            {
                Cerrado.Add(Actual);
                Abierto.RemoveAt(0);
                Hijo=Actual.GenerarHijos();
                Hijo = TratarRepetidos(Hijo, Abierto, Cerrado);
                foreach (CLEstado a in Hijo)
                    Abierto.Add(a);
                Actual = Abierto[0];
            }
            return Solucion;
        }

        private static List<CLEstado> TratarRepetidos(List<CLEstado> hijos, List<CLEstado> abiertos, List<CLEstado> cerrados)
        {
            List<CLEstado> HijosDepurado = new List<CLEstado>();
            bool encontrado = false;

            foreach (CLEstado hijo in hijos)
            {
                encontrado = false;

                // Comparar con Abiertos
                foreach (CLEstado a in abiertos)
                {
                    bool igual = true;
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                            if (hijo.tablero[i, j] != a.tablero[i, j])
                                igual = false;
                    if (igual) encontrado = true;
                }

                // Comparar con Cerrados
                if (!encontrado)
                {
                    foreach (CLEstado c in cerrados)
                    {
                        bool igual = true;
                        for (int i = 0; i < 3; i++)
                            for (int j = 0; j < 3; j++)
                                if (hijo.tablero[i, j] != c.tablero[i, j])
                                    igual = false;
                        if (igual) encontrado = true;
                    }
                }

                if (!encontrado)
                    HijosDepurado.Add(hijo);
            }

            return HijosDepurado;
        }
    }
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FRMOchoPuzzle());
        }
    }
}
