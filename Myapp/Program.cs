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
            
            foreach (string elemento in Directory.GetFiles(Carpeta))
            {
                Console.WriteLine(elemento);
                
                
                string[] nombre = nombreYextencion(elemento); 
                streamWriter.WriteLine(contador +", "+ nombre[0] + ", "+nombre[1]+", ");
                contador ++;
            }
            foreach (string elementos in ListadoElementos)
            {
                Console.WriteLine(elementos);
                
                string[] nombre = nombreYextencion(elementos); 
                streamWriter.WriteLine(contador +", "+ nombre[0] + ", "+nombre[1]+", ");
                contador ++;
                
            }
        }

        streamWriter.Close();
        filestream.Close();
        
    }


    public static string[] nombreYextencion(string ruta){
        string[] subs = ruta.Split(@"\");
        int total = subs.Count();
        string[] nombre = subs[total-1].Split('.'); 
        return nombre;
    }


    }




