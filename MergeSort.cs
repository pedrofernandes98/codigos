﻿using System;
using System.Collections;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Aleatorio = new int[4];

            int[] Ordenado = new int[4];

            Random random = new Random();

            Console.WriteLine("Elementos orginal da lista");
            for (int i = 0; i < Aleatorio.Length; i++)
            {
                Aleatorio[i] = random.Next(0, 100);
                Console.Write(Aleatorio[i] + " ");
            }

            Console.WriteLine();

            Ordenado = MergeSort(Aleatorio);

            Console.WriteLine("Elementos ordenados");
            foreach (int x in Ordenado)
            {
                Console.Write(x + " ");
            }

            Console.Write("\n");

            Console.ReadKey();
        }

        public static int[] MergeSort(int[] Aleatorio)
        {
            if (Aleatorio.Length <= 1)
                return Aleatorio;


            int[] ordenado = new int[Aleatorio.Length];
            int[] esquerdo;
            int[] direito;

            int meio = Aleatorio.Length / 2;

            esquerdo = new int[meio];


            if (Aleatorio.Length % 2 == 0)
                direito = new int[meio];

            else
                direito = new int[meio + 1];


            for (int i = 0; i < meio; i++)
            {
                esquerdo[i] = Aleatorio[i];
            }

            int j = 0;

            for (int i = meio; i < Aleatorio.Length; i++)
            {
                direito[j] = Aleatorio[i];
                j++;
            }

            esquerdo = MergeSort(esquerdo);
            direito = MergeSort(direito);
            ordenado = Merge(esquerdo, direito);
            return ordenado;
        }

        public static int[] Merge(int[] esquerdo, int[] direito)
        {
            int resultjuncao = esquerdo.Length + direito.Length;

            int[] resultfinal = new int[resultjuncao];

            int auxesquerdo = 0, auxdireito = 0, auxResult = 0;

            while (auxesquerdo < esquerdo.Length || auxdireito < direito.Length)
            {
                if (auxesquerdo < esquerdo.Length && auxdireito < direito.Length)
                {
                    if (esquerdo[auxesquerdo] <= direito[auxdireito])
                    {
                        resultfinal[auxResult] = esquerdo[auxesquerdo];
                        auxesquerdo++;
                        auxResult++;

                    }

                    else
                    {
                        resultfinal[auxResult] = direito[auxdireito];
                        auxdireito++;
                        auxResult++;
                    }
                }

                else if (auxesquerdo < esquerdo.Length)
                {

                    resultfinal[auxResult] = esquerdo[auxesquerdo];
                    auxesquerdo++;
                    auxResult++;

                }

                else if (auxdireito < direito.Length)
                {
                    resultfinal[auxResult] = direito[auxdireito];
                    auxdireito++;
                    auxResult++;
                }


            }

            return resultfinal;
        }
    }
}
