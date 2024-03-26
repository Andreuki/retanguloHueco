using System;
/*Crea un programa que vuelque a un fichero de texto llamado "rectángulo.txt" un rectángulo
 * hueco, cuyo borde sean asteriscos y cuya anchura y altura elegirá el usuario.
 */
using System.IO;
namespace rectanguloHueco
{
    class Program
    {
        static void Main(string[] args)
        {
            try {

                StreamWriter fichero = File.CreateText("rectangulo.txt");
              
                int alto = Pedir("Introduce el alto");
                int ancho = Pedir("Introduce el ancho");
                Rectangulo(fichero, ancho, alto);
                fichero.Close();
            }
            catch (PathTooLongException) {
                Console.WriteLine("Ruta demasiado larga ");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("El archivo no existe o no se encuentra "+ e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("Error de E/S "+ e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error general " + e.Message);
            }

        }
        static int Pedir(string texto) {
            Console.WriteLine(texto);
            int respuesta = Convert.ToInt32(Console.ReadLine());
            return respuesta;
        }
        static void Rectangulo(StreamWriter fichero, int ancho, int alto) {
            for (int i =0; i< alto;i++) {
                for (int j = 0; j < ancho;j++) {
                    if (i == 0 || i == alto - 1 || j == 0 || j == ancho - 1)
                    {
                        fichero.Write("*"); // Dibujar asterisco en el borde exterior
                    }
                    else
                    {
                        fichero.Write(" "); // De lo contrario, dibujar un espacio en blanco en el interior
                    }
                }
                fichero.WriteLine();
            }

        }
    }
}
