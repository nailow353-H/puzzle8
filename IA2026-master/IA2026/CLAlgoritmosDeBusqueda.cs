using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA2026
{
    public static class CLAlgoritmosDeBusqueda
    {
        public static List<CLEstado> AnchuraPrioritaria(CLEstado Inicial)
        { 
            //Definición de variables
            List<CLEstado> Solucion= new List<CLEstado>();
            List<CLEstado> Abiertos = new List<CLEstado>();
            List<CLEstado> Cerrados = new List<CLEstado>();
            List<CLEstado> Hijos = new List<CLEstado>();
            CLEstado Actual= new CLEstado();
            //Algoritmo
            Abiertos.Add(Inicial);
            Actual = Abiertos[0];
            while (!Actual.EsFinal()&&Abiertos.Count>0) 
            { 
                Cerrados.Add(Actual);
                Abiertos.RemoveAt(0);
                Hijos = Actual.GenerarHijos();
                Hijos = TratarRepetidos(Hijos, Abiertos, Cerrados);
                foreach (CLEstado a in Hijos)
                    Abiertos.Add(a);
                Actual = Abiertos[0];
            }

            return Solucion;
        }

        private static List<CLEstado> TratarRepetidos(List<CLEstado> hijos, List<CLEstado> abiertos, List<CLEstado> cerrados)
        {
            List<CLEstado> HijosDepurado = new List<CLEstado>();
            bool encontrado=false;
            foreach (CLEstado a in hijos)
            {
                encontrado = false;
                //Comparar con abiertos
                foreach (CLEstado b in abiertos) { 
                    bool iguales = true;
                    for (int i = 0; i < 3; i++) 
                    {
                        for (int j = 0; j < 3; j++) 
                        {
                            if (a.tablero[i, j] != b.tablero[i, j]) 
                            {
                                iguales = false;
                            }
                            if(iguales)
                            {
                                encontrado = true;
                            }
                        }
                    }
                }
                //COmparo con cerrados
                if (!encontrado)
                {
                    foreach (CLEstado b in cerrados)
                    {
                        bool iguales = true;
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (a.tablero[i, j] != b.tablero[i, j])
                                {
                                    iguales = false;
                                }
                                if (iguales)
                                {
                                    encontrado = true;
                                }
                            }
                        }
                    }
                }

                if (!encontrado)
                {
                    HijosDepurado.Add(a);
                }
            }

            return HijosDepurado;
        }
    }
}
