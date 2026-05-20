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
            List<CLEstado> Solucion = new List<CLEstado>();
            List<CLEstado> Abiertos = new List<CLEstado>();
            List<CLEstado> Cerrados = new List<CLEstado>();
            List<CLEstado> Hijos = new List<CLEstado>();
            CLEstado Actual = new CLEstado();

            //Algoritmo
            Inicial.nivel = 0;
            Inicial.padre = null;

            Abiertos.Add(Inicial);

            while (Abiertos.Count > 0)
            {
                Actual = Abiertos[0];

                if (Actual.EsFinal())
                    break;

                Cerrados.Add(Actual);
                Abiertos.RemoveAt(0);

                Hijos = Actual.GenerarHijos();

                foreach (CLEstado h in Hijos)
                {
                    h.padre = Actual;
                    h.nivel = Actual.nivel + 1;
                }

                Hijos = TratarRepetidos(Hijos, Abiertos, Cerrados);

                foreach (CLEstado a in Hijos)
                    Abiertos.Add(a);
            }

            //Reconstrucción de la solución
            if (Actual.EsFinal())
            {
                Solucion.Add(Actual);

                while (Actual.padre != null)
                {
                    Solucion.Add(Actual.padre);
                    Actual = Actual.padre;
                }

                Solucion.Reverse();
            }

            return Solucion;
        }

        public static List<CLEstado> ProfundidadLimitada(CLEstado Inicial, int Limite)
        {
            //Definición de variables
            List<CLEstado> Solucion = new List<CLEstado>();
            List<CLEstado> Abiertos = new List<CLEstado>();
            List<CLEstado> Cerrados = new List<CLEstado>();
            List<CLEstado> Hijos = new List<CLEstado>();
            CLEstado Actual = new CLEstado();

            //Algoritmo
            Inicial.nivel = 0;
            Inicial.padre = null;

            Abiertos.Add(Inicial);

            while (Abiertos.Count > 0)
            {
                Actual = Abiertos[Abiertos.Count - 1];

                if (Actual.EsFinal())
                    break;

                Cerrados.Add(Actual);
                Abiertos.RemoveAt(Abiertos.Count - 1);

                //Control del límite
                if (Actual.nivel < Limite)
                {
                    Hijos = Actual.GenerarHijos();

                    foreach (CLEstado h in Hijos)
                    {
                        h.padre = Actual;
                        h.nivel = Actual.nivel + 1;
                    }

                    Hijos = TratarRepetidosProfundidad(Hijos, Abiertos, Cerrados);

                    foreach (CLEstado a in Hijos)
                        Abiertos.Add(a);
                }
            }

            //Reconstrucción de la solución
            if (Actual.EsFinal())
            {
                Solucion.Add(Actual);

                while (Actual.padre != null)
                {
                    Solucion.Add(Actual.padre);
                    Actual = Actual.padre;
                }

                Solucion.Reverse();
            }

            return Solucion;
        }

        private static List<CLEstado> TratarRepetidos(List<CLEstado> hijos,
                                                      List<CLEstado> abiertos,
                                                      List<CLEstado> cerrados)
        {
            List<CLEstado> HijosDepurado = new List<CLEstado>();
            bool encontrado = false;

            foreach (CLEstado hijo in hijos)
            {
                encontrado = false;

                //Comparar con abiertos
                foreach (CLEstado a in abiertos)
                {
                    if (hijo.EsIgual(a))
                    {
                        encontrado = true;
                        break;
                    }
                }

                if (encontrado)
                    continue;

                //Comparar con cerrados
                foreach (CLEstado c in cerrados)
                {
                    if (hijo.EsIgual(c))
                    {
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                    HijosDepurado.Add(hijo);
            }

            return HijosDepurado;
        }

        private static List<CLEstado> TratarRepetidosProfundidad(List<CLEstado> hijos,
                                                                 List<CLEstado> abiertos,
                                                                 List<CLEstado> cerrados)
        {
            List<CLEstado> HijosDepurado = new List<CLEstado>();
            bool encontrado = false;

            foreach (CLEstado hijo in hijos)
            {
                encontrado = false;

                //Comparar con abiertos
                foreach (CLEstado a in abiertos)
                {
                    if (hijo.EsIgual(a))
                    {
                        encontrado = true;
                        break;
                    }
                }

                if (encontrado)
                    continue;

                //Comparar con cerrados
                foreach (CLEstado c in cerrados)
                {
                    if (hijo.EsIgual(c))
                    {
                        if (hijo.nivel >= c.nivel)
                        {
                            encontrado = true;
                            break;
                        }
                    }
                }

                if (!encontrado)
                    HijosDepurado.Add(hijo);
            }

            return HijosDepurado;
        }
    }
}
