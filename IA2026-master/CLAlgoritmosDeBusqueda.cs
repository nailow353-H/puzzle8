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

        public static List<CLEstado> ProfundidadIterativa(CLEstado Inicial, Action<string> MostrarMensaje)
        {
            List<CLEstado> Solucion = new List<CLEstado>();
            int Profundidad = 0;
            int ProfundidadMaxima = 100;

            while (Profundidad < ProfundidadMaxima)
            {
                MostrarMensaje($"Buscando en el nivel {Profundidad}...");
                
                Solucion = ProfundidadLimitadaConMensaje(Inicial, Profundidad, MostrarMensaje);

                if (Solucion.Count > 0)
                {
                    MostrarMensaje($"¡Encontrado en el nivel {Profundidad}!");
                    return Solucion;
                }

                MostrarMensaje($"No encontrado en el nivel {Profundidad}, continuando...");
                Profundidad++;
            }

            MostrarMensaje("No se encontró solución.");
            return Solucion;
        }

        public static List<CLEstado> BusquedaHeuristicaH1(CLEstado Inicial)
        {
            return BusquedaHeuristica(Inicial, 1);
        }

        public static List<CLEstado> BusquedaHeuristicaH2(CLEstado Inicial)
        {
            return BusquedaHeuristica(Inicial, 2);
        }

        public static List<CLEstado> BusquedaHeuristicaH3(CLEstado Inicial)
        {
            return BusquedaHeuristica(Inicial, 3);
        }

        private static List<CLEstado> ProfundidadLimitadaConMensaje(CLEstado Inicial, int Limite, Action<string> MostrarMensaje)
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

        private static List<CLEstado> BusquedaHeuristica(CLEstado Inicial, int TipoHeuristica)
        {
            List<CLEstado> Solucion = new List<CLEstado>();
            List<CLEstado> Abiertos = new List<CLEstado>();
            List<CLEstado> Cerrados = new List<CLEstado>();
            List<CLEstado> Hijos = new List<CLEstado>();

            CLEstado Actual = new CLEstado();

            Inicial.nivel = 0;
            Inicial.padre = null;

            Abiertos.Add(Inicial);

            while (Abiertos.Count > 0)
            {
                OrdenarPorHeuristica(Abiertos, TipoHeuristica);

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

                foreach (CLEstado h in Hijos)
                {
                    Abiertos.Add(h);
                }
            }

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

        private static void OrdenarPorHeuristica(List<CLEstado> Abiertos,
                                         int TipoHeuristica)
        {
            for (int i = 0; i < Abiertos.Count - 1; i++)
            {
                for (int j = i + 1; j < Abiertos.Count; j++)
                {
                    int ValorI = ObtenerHeuristica(
                        Abiertos[i],
                        TipoHeuristica);

                    int ValorJ = ObtenerHeuristica(
                        Abiertos[j],
                        TipoHeuristica);

                    if (ValorJ < ValorI)
                    {
                        CLEstado Aux = Abiertos[i];
                        Abiertos[i] = Abiertos[j];
                        Abiertos[j] = Aux;
                    }
                }
            }
        }

        private static int ObtenerHeuristica(CLEstado Estado,
                                     int TipoHeuristica)
        {
            switch (TipoHeuristica)
            {
                case 1:
                    return Estado.CalcularH1();

                case 2:
                    return Estado.CalcularH2();

                case 3:
                    return Estado.CalcularH3();

                default:
                    return Estado.CalcularH1();
            }
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

        public static List<CLEstado> BusquedaAlgoritmoA(CLEstado Inicial, int TipoHeuristica)
        {
            List<CLEstado> Solucion = new List<CLEstado>();
            List<CLEstado> Abiertos = new List<CLEstado>();
            List<CLEstado> Cerrados = new List<CLEstado>();
            List<CLEstado> Hijos = new List<CLEstado>();

            CLEstado Actual = new CLEstado();

            Inicial.nivel = 0;
            Inicial.padre = null;

            // Estabiertos.insertar( Estadoinicial )
            Abiertos.Add(Inicial);

            // Mientras no esfinal?(Actual) y no Estabiertos.vacia?()
            while (Abiertos.Count > 0)
            {
                // Evita que la ventana de Windows Forms diga "No responde"
                System.Windows.Forms.Application.DoEvents();

                // Como la lista se mantiene ordenada al insertar, el primero siempre es el menor f(n)
                Actual = Abiertos[0];

                if (Actual.EsFinal())
                    break;

                // Estcerrados.insertar( Actual ) y Estabiertos.borrarprimero()
                Cerrados.Add(Actual);
                Abiertos.RemoveAt(0);

                // hijos = generarsucesores( Actual )
                Hijos = Actual.GenerarHijos();

                foreach (CLEstado h in Hijos)
                {
                    h.padre = Actual;
                    h.nivel = Actual.nivel + 1;
                }

                // hijos = tratarrepetidos( Hijos, Estcerrados, Estabiertos )
                Hijos = TratarRepetidosAlgoritmoA(Hijos, Abiertos, Cerrados, TipoHeuristica);

                // Estabiertos.insertar( Hijos ) -> Los insertamos de forma ordenada eficientemente
                foreach (CLEstado h in Hijos)
                {
                    InsertarOrdenado(Abiertos, h, TipoHeuristica);
                }
            }

            // Reconstrucción de pasos (idéntico a tus otros algoritmos)
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

        // Método eficiente para insertar directamente en su posición correcta sin usar Burbuja
        private static void InsertarOrdenado(List<CLEstado> lista, CLEstado nuevoNodo, int tipoHeuristica)
        {
            int fNuevo = nuevoNodo.nivel + ObtenerHeuristica(nuevoNodo, tipoHeuristica);
            int index = 0;

            while (index < lista.Count)
            {
                int fActual = lista[index].nivel + ObtenerHeuristica(lista[index], tipoHeuristica);
                if (fNuevo < fActual)
                {
                    break;
                }
                index++;
            }
            lista.Insert(index, nuevoNodo);
        }

        // Tratar repetidos exclusivo para el Algoritmo A
        private static List<CLEstado> TratarRepetidosAlgoritmoA(List<CLEstado> hijos, List<CLEstado> abiertos, List<CLEstado> cerrados, int TipoHeuristica)
        {
            List<CLEstado> HijosDepurado = new List<CLEstado>();

            foreach (CLEstado hijo in hijos)
            {
                bool duplicadoInutil = false;
                int fHijo = hijo.nivel + ObtenerHeuristica(hijo, TipoHeuristica);

                // Comparar con abiertos
                foreach (CLEstado a in abiertos)
                {
                    if (hijo.EsIgual(a))
                    {
                        int fAbierto = a.nivel + ObtenerHeuristica(a, TipoHeuristica);
                        if (fHijo >= fAbierto)
                        {
                            duplicadoInutil = true;
                        }
                        break;
                    }
                }

                if (duplicadoInutil) continue;

                // Comparar con cerrados
                foreach (CLEstado c in cerrados)
                {
                    if (hijo.EsIgual(c))
                    {
                        int fCerrado = c.nivel + ObtenerHeuristica(c, TipoHeuristica);
                        if (fHijo >= fCerrado)
                        {
                            duplicadoInutil = true;
                        }
                        break;
                    }
                }

                if (!duplicadoInutil)
                    HijosDepurado.Add(hijo);
            }

            return HijosDepurado;
        }

    }
}