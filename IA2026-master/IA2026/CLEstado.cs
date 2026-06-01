using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA2026
{
    public class CLEstado
    {
        #region Campos
            private int[,] _tablero;
            private int _nivel;
        #endregion

        #region Propiedades
        public int[,] tablero 
        { 
            get => _tablero; 
            set => _tablero = value; 
        }
        public int nivel 
        { 
            get => _nivel; 
            set => _nivel = value; 
        }
        #endregion

        #region Constructor
        public CLEstado()
        {
            this._tablero = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                this._tablero[i, j] = 0;
            this._nivel = 0;
        }
        public CLEstado(int p00, int p01, int p02,
                        int p10, int p11, int p12,
                        int p20, int p21, int p22
                        )
        {
            this._tablero = new int[3, 3];
            this._tablero[0, 0] = p00;
            this._tablero[1, 0] = p10;
            this._tablero[2, 0] = p20;
            this._tablero[0, 1] = p01;
            this._tablero[1, 1] = p11;
            this._tablero[2, 1] = p21;
            this._tablero[0, 2] = p02;
            this._tablero[1, 2] = p12;
            this._tablero[2, 2] = p22;
            this._nivel = 0;
        }
        #endregion

        #region Métodos
        public List<CLEstado> GenerarHijos()
        {
            List<CLEstado> Respuesta = new List<CLEstado>();
            String pos0 = "";
            int[,] aux = new int[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (this._tablero[i, j] == 0)
                    {
                        pos0 = i.ToString() + j.ToString();
                    }
            CLEstado A = new CLEstado();
            switch (pos0)
            {
                case "00":
                    A = new CLEstado(this._tablero[0, 1],
                                             this._tablero[0, 0],
                                             this._tablero[0, 2],
                                             this._tablero[1, 0],
                                             this._tablero[1, 1],
                                             this._tablero[1, 2],
                                             this._tablero[2, 0],
                                             this._tablero[2, 1],
                                             this._tablero[2, 2]);
                    Respuesta.Add(A);
                    A = new CLEstado(this._tablero[1, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[0, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    Respuesta.Add(A);
                    break;
                case "01":
                    A = new CLEstado(this._tablero[0, 1],
                                         this._tablero[0, 0],
                                         this._tablero[0, 2],
                                         this._tablero[1, 0],
                                         this._tablero[1, 1],
                                         this._tablero[1, 2],
                                         this._tablero[2, 0],
                                         this._tablero[2, 1],
                                         this._tablero[2, 2]);
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                         this._tablero[1, 1],
                                         this._tablero[0, 2],
                                         this._tablero[1, 0],
                                         this._tablero[0, 1],
                                         this._tablero[1, 2],
                                         this._tablero[2, 0],
                                         this._tablero[2, 1],
                                         this._tablero[2, 2]);
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                         this._tablero[0, 2],
                                         this._tablero[0, 1],
                                         this._tablero[1, 0],
                                         this._tablero[1, 1],
                                         this._tablero[1, 2],
                                         this._tablero[2, 0],
                                         this._tablero[2, 1],
                                         this._tablero[2, 2]);
                    Respuesta.Add(A);
                    break;
                case "02":
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 2],
                                     this._tablero[0, 1],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    Respuesta.Add(A);
                    break;
                case "10":
                    A = new CLEstado(this._tablero[0, 1],
                                     this._tablero[0, 0],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 1],
                                     this._tablero[1, 0],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[2, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[1, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    Respuesta.Add(A);
                    break;
                case "11":
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 1],
                                     this._tablero[1, 0],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[1, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[0, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 2],
                                     this._tablero[1, 1],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[2, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[1, 1],
                                     this._tablero[2, 2]);
                    Respuesta.Add(A);
                    break;
                case "12":
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[1, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[0, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 2],
                                     this._tablero[1, 1],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[2, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[1, 2]);
                    Respuesta.Add(A);
                    break;
                case "20":
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[2, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[1, 0],
                                     this._tablero[2, 1],
                                     this._tablero[2, 2]);
                    Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 1],
                                     this._tablero[2, 0],
                                     this._tablero[2, 2]);
                    Respuesta.Add(A);
                    break;
                case "21":
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 1],
                                     this._tablero[2, 0],
                                     this._tablero[2, 2]);
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[2, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[1, 1],
                                     this._tablero[2, 2]);
                    Respuesta.Add(A);

                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 2],
                                     this._tablero[2, 1]);
                    Respuesta.Add(A);
                    break;
                case "22":
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[2, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 1],
                                     this._tablero[1, 2]);
                    Respuesta.Add(A);
                    A = new CLEstado(this._tablero[0, 0],
                                     this._tablero[0, 1],
                                     this._tablero[0, 2],
                                     this._tablero[1, 0],
                                     this._tablero[1, 1],
                                     this._tablero[1, 2],
                                     this._tablero[2, 0],
                                     this._tablero[2, 2],
                                     this._tablero[2, 1]);
                    Respuesta.Add(A);
                    break;
            }
            return Respuesta;
        }
        
        //busqueda con esfinal
        public bool EsFinal()
        {
            int[,] final = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 0 }
            };

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (this._tablero[i, j] != final[i, j])
                        return false;

            return true;
        }
public int CalcularH1()
{
    int fichasIncorrectas = 0;
    int[,] objetivo = new int[3, 3]
    {
        { 1, 2, 3 },
        { 4, 5, 6 },
        { 7, 8, 0 }
    };

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (_tablero[i, j] != objetivo[i, j])
            {
                fichasIncorrectas++;
            }
        }
    }

    return fichasIncorrectas;
}

/// <summary>
/// H2: Distancia Manhattan (suma de distancias de cada ficha a su posición correcta)
/// </summary>
public int CalcularH2()
{
    int distanciaTotal = 0;
    int[,] objetivo = new int[3, 3]
    {
        { 1, 2, 3 },
        { 4, 5, 6 },
        { 7, 8, 0 }
    };

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (_tablero[i, j] != 0)
            {
                // Encontrar la posición correcta del número actual
                for (int oi = 0; oi < 3; oi++)
                {
                    for (int oj = 0; oj < 3; oj++)
                    {
                        if (objetivo[oi, oj] == _tablero[i, j])
                        {
                            // Sumar la distancia Manhattan
                            distanciaTotal += Math.Abs(i - oi) + Math.Abs(j - oj);
                        }
                    }
                }
            }
        }
    }

    return distanciaTotal;
}

/// <summary>
/// H3: Distancia Euclideana (raíz cuadrada de la suma de distancias al cuadrado)
/// </summary>
public int CalcularH3()
{
    int distanciaEuclideana = 0;
    int[,] objetivo = new int[3, 3]
    {
        { 1, 2, 3 },
        { 4, 5, 6 },
        { 7, 8, 0 }
    };

    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (_tablero[i, j] != 0)
            {
                // Encontrar la posición correcta del número actual
                for (int oi = 0; oi < 3; oi++)
                {
                    for (int oj = 0; oj < 3; oj++)
                    {
                        if (objetivo[oi, oj] == _tablero[i, j])
                        {
                            // Calcular distancia euclideana
                            int dx = i - oi;
                            int dy = j - oj;
                            distanciaEuclideana += (int)Math.Sqrt(dx * dx + dy * dy);
                        }
                    }
                }
            }
        }
    }

    return distanciaEuclideana;
}

#endregion
 }   
}
