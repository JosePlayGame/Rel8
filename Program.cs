using System.Text;

class Program
{
    static void Main(string[] args){
        // foreach (var item in args)
        // {
        //     if (item != null)
        //     {
                
        //     }
        // }
        string[]str = {"fichero1.txt","fichero2.txt"};
        System.Console.WriteLine(MostrarFicheros(str));
    }
    /*
        2. Haz un programa que copie el contenido de un fichero en otro. Ambos ficheros se pasan desde la línea 
        de comandos según el siguiente formato:
    */
    static void CopiarFichero(string FicheroOrigen,string FicheroDestino){
        if (!Path.Exists(FicheroOrigen))
        {
            System.Console.WriteLine("El fichero de origen no existe");
        }else
        {
            System.Console.WriteLine(FicheroOrigen);
            System.Console.WriteLine(FicheroDestino);
            File.Copy(FicheroOrigen,FicheroDestino);
        }
    }
    /*
        3. Haz un programa que copie el contenido de un fichero en otro sin incluir un carácter pasado desde la 
        consola. Ambos ficheros y el carácter a excluir se pasan desde la línea de comandos según el siguiente 
        formato: (TERMINADO)
    */
    static void CopiarFicheroSinCaracter(string FicheroOrigen,string FicheroDestino,string caracter){
        string text=string.Empty;
        if (Path.Exists(FicheroOrigen) && Path.Exists(FicheroDestino))
        {
            using StreamReader reader = new(FicheroOrigen);
            text=reader.ReadToEnd().Replace(caracter,"");
            System.Console.WriteLine(text);
            using StreamWriter writer = new(FicheroDestino);
            writer.WriteLine(text);
        }
    }
    //4. Haz un programa que muestre por pantalla en contenido de un fichero de texto pasado por la consola. (TERMINADO)
    public static void LeerFichero(string fichero){
        if (!File.Exists(fichero))
        {
            StreamReader reader = new StreamReader(fichero);
            System.Console.WriteLine(reader.ReadToEnd());
            reader.Close();
        }

    }
    //5. Crea una función que reciba como parámetros dos nombres de ficheros de texto y los concatene
    //dejando el resultado guardado en el primero. (TERMINADO)
    static void ConcatenarFicheros(string fichero1, string fichero2){
        if (Path.Exists(fichero1) && Path.Exists(fichero2))
        {
            string nuevonombre = (Path.GetFileNameWithoutExtension("fichero1.txt")+Path.GetFileNameWithoutExtension("fichero2.txt")+Path.GetExtension(fichero1));
            nuevonombre= Path.ChangeExtension(nuevonombre, Path.GetExtension(fichero1));
            if (Path.Exists(nuevonombre))
            {
                File.Delete(nuevonombre);
            }
            File.Move(fichero1, nuevonombre);
        }
        
    }
    /*
    6. Escribe un programa que contenga dos funciones: CrearFichero(string fi) y ListarFichero(string fi) donde:
    a) La primera función almacena en un fichero de texto (fi) los nombres y apellidos de los alumnos. En nombre 
    del archivo se le pasa a la función al llamarla.
    b) Muestra por pantalla el contenido del fichero (fi) pasado.
    */
    static void CrearFichero(string fichero){
        StreamWriter streamWriter = new StreamWriter(fichero);
        string str = string.Empty;
        System.Console.WriteLine("Introduce nombre y apellidos o pulsa ESC para parar");
        ConsoleKeyInfo tecla;
        do
        {
            tecla=Console.ReadKey(false);
            streamWriter.WriteLine(tecla.ToString());
        } while (tecla.Key!=ConsoleKey.Escape);
        streamWriter.Close();
    }
    static void ListarFichero(string fichero){
        if (Path.Exists(fichero)){
            StreamReader streamReader= new StreamReader(fichero);
            System.Console.WriteLine(streamReader.ReadToEnd());
            streamReader.Close();
        }
    }
    /*
        7. Escribe un programa que tome todos los ficheros dados como argumentos en la línea de comandos y 
        muestre por pantalla su contenido uno tras otro, separando cada contenido por una línea horizontal y el 
        nombre del fichero que se mostrará(TERMINADO)
    */
    static string MostrarFicheros(string[]args){
        string str="LISTADO DE FICHEROS \n\n";
        
        foreach (var item in args)
        {
            if (Path.Exists(item))
            {
                StreamReader streamWriter = new StreamReader(item);
                str+=streamWriter.ReadToEnd();
                str+=" / "+Path.GetFileNameWithoutExtension(item)+"\n";
            }
        }
        return str;
    }
    //8. Haz un programa que muestre por pantalla el contenido de un fichero de texto al revés, desde el final
    //hasta el principio. (TERMINADO)
    static void AccesoAleatorio(string fichero){
        if (Path.Exists(fichero))
        {
            string reverse=string.Empty;
            using StreamReader reader = new(fichero);
            string str=reader.ReadToEnd();
            for (int i = str.Length-1; i >= 0; i--)
            {
                reverse+=str[i];
            }
            System.Console.WriteLine(reverse);
        } 
    }
}
