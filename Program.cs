﻿using System.Text;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args){
        
        
        if(args[0]!=null){
            LeerFichero(args[0]);
            AccesoAleatorio(args[0]);
            GuardadoDatos(args[0]);
            CrearFichero(args[0]);
            ListarFichero(args[0]);
        }
        if(args.Length==2)
        {
            CopiarFichero(args[0],args[1]);
            ConcatenarFicheros(args[0],args[1]);
        }
        else
        {
            CopiarFicheroSinCaracter(args[0],args[1],args[2]);
            MostrarFicheros(args);
        }
        Thread.Sleep(3000);
        Ej10();
    }
    #region Ej1
        static void MostrarFichero(){
            string ruta = "c:/directorio1/directorio2/directorio3/texto.txt";
            if (Path.Exists(ruta))
            {
                string cabecera="INFORMACIÓN DEL FICHERO";
                System.Console.WriteLine(cabecera + "\n"+new string('=',cabecera.Length));
                System.Console.WriteLine("El nombre del directorio es : "+Path.GetDirectoryName(ruta));
                System.Console.WriteLine("El archivo se llama : "+Path.GetFileNameWithoutExtension(ruta));
                System.Console.WriteLine("El archivo tiene como extension : "+Path.GetExtension(ruta));
                System.Console.WriteLine("El archivo esta en : "+Path.GetFullPath(ruta));
                System.Console.WriteLine("El directorio esta rooteado : "+Path.GetPathRoot(ruta));
                System.Console.WriteLine("Texto del fichero : \n");
                LeerFichero(ruta);
            }
        }
    #endregion
    #region Ej2
        
    /*
        2. Haz un programa que copie el contenido de un fichero en otro. Ambos ficheros se pasan desde la línea 
        de comandos según el siguiente formato:
    */
    static void CopiarFichero(string FicheroOrigen,string FicheroDestino){
        if (Path.Exists(FicheroOrigen) &&  Path.Exists(FicheroDestino))
        {
            string str = File.ReadAllText(FicheroOrigen);
            File.WriteAllText(FicheroDestino,str);
        }
        else
            System.Console.WriteLine("No existe alguno de los ficheros");
    }
    #endregion
    #region Ej3
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
    #endregion
    #region Ej4
    //4. Haz un programa que muestre por pantalla en contenido de un fichero de texto pasado por la consola. (TERMINADO)
    public static void LeerFichero(string fichero){
        if (Path.Exists(fichero))
        {
            StreamReader reader = new StreamReader(fichero);
            System.Console.WriteLine(reader.ReadToEnd());
            reader.Close();
        }
    }
    #endregion
    #region Ej5
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
    #endregion
    #region Ej6
    /*
    6. Escribe un programa que contenga dos funciones: CrearFichero(string fi) y ListarFichero(string fi) donde:
    a) La primera función almacena en un fichero de texto (fi) los nombres y apellidos de los alumnos. En nombre 
    del archivo se le pasa a la función al llamarla.
    b) Muestra por pantalla el contenido del fichero (fi) pasado.
    */
    static void CrearFichero(string fi){
        ListaAlumnos listaAlumnos = new(10);
        File.WriteAllText(fi,listaAlumnos.ListarJSON());
    }
    static void ListarFichero(string fi){
        if (Path.Exists(fi)){
            using StreamReader sr = new StreamReader(fi);
            System.Console.WriteLine(sr.ReadToEnd());
        }
    }
    #endregion
    #region Ej7
    /*
        7. Escribe un programa que tome todos los ficheros dados como argumentos en la línea de comandos y 
        muestre por pantalla su contenido uno tras otro, separando cada contenido por una línea horizontal y el 
        nombre del fichero que se mostrará
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
    #endregion
    #region EJ8
    //8. Haz un programa que muestre por pantalla el contenido de un fichero de texto al revés, desde el final
    //hasta el principio. 
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
    #endregion
    #region Ej9
    /*
        9. Haz un programa que gestione un fichero en el que vaya guardando los datos: Nombre usuario, fecha, 
        hora y tiempo de conexión, para cada una de las veces que se ha ejecutado.
    */
    static void GuardadoDatos(string fichero){
        string usuario;
        usuario=Environment.UserName;
        DateTime acceso = DateTime.Now;
        string escritutar = usuario + "\n"+acceso;
        File.WriteAllText(fichero,escritutar);
    }
    #endregion
    #region Ej10
    static void Ej10(){
        PintarFichero pintarFichero= new PintarFichero();
        pintarFichero.Ejecutar();
    }
    #endregion
}
