using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ArbolFilogenetico
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Seleccione un item:");
            Console.WriteLine("[1] Ingresar Nodo ID");
            Console.WriteLine("[2] Salir");
            Console.WriteLine();

            //Obtiene la tecla presionada
            int item = 0;
            ConsoleKeyInfo keyinfo = Console.ReadKey();
            if (char.IsDigit(keyinfo.KeyChar)) item = int.Parse(keyinfo.KeyChar.ToString());

            //verifica él item seleccionado
            if (item == 1) Operacion();
            else if (item == 2) Environment.Exit(1);
            else
            {
                Console.WriteLine();
                Console.WriteLine("Item seleccionado no es valido" + Environment.NewLine);
                Main();
            }
        }

        static void Operacion()
        {
            Console.WriteLine();
            Console.WriteLine("****************************************" +
                Environment.NewLine + "Escriba 'exit' y presione Enter para salir" +
                Environment.NewLine + "****************************************");
            Console.WriteLine();
            Console.WriteLine("Ingrese Nodo ID y presione Enter: ");
            string nodoInput = Console.ReadLine();

            if (nodoInput == "exit")
            {
                Environment.Exit(1);
            }
            else
            {
                string line;
                List<string> nodos = new List<string>();
                StringBuilder resultado = new StringBuilder(Environment.NewLine);

                string sangria = "";
                int sizeSangria = 0;

                // Lee el texto de cada fila del archivo inputArbol.txt
                string pathArbol = Path.Combine(Environment.CurrentDirectory, "inputArbol.txt");
                StreamReader file = new StreamReader(pathArbol);
                while ((line = file.ReadLine()) != null)
                {
                    // Si la fila comienza con el nodo ingresado, agrega la linea a una lista de Nodos
                    if (line.StartsWith(nodoInput)) nodos.Add(line.Split(',')[1]);
                }
                file.Close();

                // Si la lista de Nodos tiene información, la recorre y la escribe en consola
                if (nodos.Count > 0)
                {
                    int cantCarac = 0;
                    nodos = nodos.OrderBy(n => n).ToList();
                    foreach (var nodo in nodos)
                    {
                        if (cantCarac == 0 || nodo.Length == cantCarac)
                            resultado.AppendLine(sangria.PadLeft(sizeSangria) + nodo);
                        else
                        {
                            sizeSangria += 5;
                            resultado.AppendLine(sangria.PadLeft(sizeSangria) + nodo);
                        }

                        cantCarac = nodo.Length;
                    }

                    Console.WriteLine(resultado.ToString());
                }
                else Console.WriteLine(Environment.NewLine + "No existe información para el nodo ingresado");

                Operacion();
            }
        }
    }
}
