using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA2026
{
    public static class CLAlgoritmosDeBusqueda
    {
        // Comparamos dos tableros celda a celda
        private static bool SonIguales(CLEstado a, CLEstado b)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (a.tablero[i, j] != b.tablero[i, j])
                        return false;
            return true;
        }

        // Filtra hijos que ya están en Abiertos o Cerrados
        private static List<CLEstado> TratarRepetidos(List<CLEstado> hijos,
                                                       List<CLEstado> abiertos,
                                                       List<CLEstado> cerrados)
        {
            List<CLEstado> HijosDepurado = new List<CLEstado>();
            bool encontrado = false;

            foreach (CLEstado a in hijos)
            {
                encontrado = false;

                foreach (CLEstado b in abiertos)
                {
                    if (SonIguales(a, b)) { encontrado = true; break; }
                }

                if (!encontrado)
                {
                    foreach (CLEstado b in cerrados)
                    {
                        if (SonIguales(a, b)) { encontrado = true; break; }
                    }
                }

                if (!encontrado)
                    HijosDepurado.Add(a);
            }

            return HijosDepurado;
        }

        public static List<CLEstado> AnchuraPrioritaria(CLEstado Inicial)
        {
            List<CLEstado> Solucion = new List<CLEstado>();
            List<CLEstado> Abiertos = new List<CLEstado>();
            List<CLEstado> Cerrados = new List<CLEstado>();
            List<CLEstado> Hijos    = new List<CLEstado>();

            Dictionary<CLEstado, CLEstado> Padre = new Dictionary<CLEstado, CLEstado>();

            Abiertos.Add(Inicial);
            Padre[Inicial] = null;

            // el while verifica Abiertos.Count > 0
            // pasos que debo seguir
            //   Verificar que haya nodos por explorar
            //    Tomar el primero
            //    Si es final es correcto  salir
            //   Si no debe expandir y continuar
            while (Abiertos.Count > 0)
            {
                CLEstado Actual = Abiertos[0]; // tomamos el primero de abiertos
                Abiertos.RemoveAt(0);          // lo scaamos de Abiertos
                Cerrados.Add(Actual);          // lo pasamos a  Cerrados

                // Si es el estado final es true reconstruir camino y salir
                if (Actual.EsFinal())
                {
                    CLEstado nodo = Actual;
                    while (nodo != null)
                    {
                        Solucion.Insert(0, nodo);
                        Padre.TryGetValue(nodo, out nodo);
                    }
                    return Solucion; // retornar inmediatamente
                }

                // Si es final es falso,  generar hijos y agregarlos a Abiertos
                Hijos = Actual.GenerarHijos();
                Hijos = TratarRepetidos(Hijos, Abiertos, Cerrados);

                foreach (CLEstado a in Hijos)
                {
                    Abiertos.Add(a);
                    Padre[a] = Actual;
                }
            }

            // Si salimos del while sin encontrar solución la Solucion queda vacío
            return Solucion;
        }
    }
}
