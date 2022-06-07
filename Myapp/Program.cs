using System;
using System.IO;

public class program
{
   public static void Main(String[] args){
       Console.WriteLine("Ingrese la direccion de la carpeta");
       String? direccion = Console.ReadLine();
       direccion = @""+ direccion;

       string NombreArchivo = direccion + "\\index.csv";

       if(!File.Exists(NombreArchivo)){
           File.Create(NombreArchivo);
       }
       FileStream filestream = new FileStream(NombreArchivo, FileMode.Open);
        StreamWriter streamWriter = new StreamWriter(filestream);  

        List<string> ListadoCarpetas = Directory.GetDirectories(direccion).ToList();
        List<string> ListadoElementos = Directory.GetFiles(direccion).ToList();
        int contador = 1;
        foreach (string Carpeta in ListadoCarpetas)
        {
            Console.WriteLine(Carpeta);
            streamWriter.Write(contador + Carpeta + ", ");
            contador ++;
            foreach (string elemento in Directory.GetFiles(Carpeta))
            {
                Console.WriteLine(elemento);
                streamWriter.WriteLine(""+elemento + ", ");
            }
            foreach (string elementos in ListadoElementos)
            {
                Console.WriteLine(elementos);
                streamWriter.WriteLine(elementos + ", ");
            }
        }

        streamWriter.Close();
        filestream.Close();
        
    }



    }




