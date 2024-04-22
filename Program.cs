using System.Text;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args){
        CopiarFichero(args[0],args[1]);
    }
    #region menu
    static void Menu(){
        string cabecera="MENU PRINCIPAL";
        string final="PULSA [ESC] PARA SALIR";
        string[]opciones ={"[1] Clase PATH"
        ,"[2] Copiar Fichero"
        ,"[3] Copiar contenido sin caracter"
        ,"[4] Mostrar Fichero"
        ,"[5] Concatenar Ficheros"
        ,"[6] Funciones Ficheros"
        ,"[7] Mostrar ficheros concatenados"
        ,"[8] Mostrar Fichero al reves"
        ,"[9] Guardar datos"
        ,"[F10] Manipulación almacen"
        };
        System.Console.WriteLine(cabecera + "\n" + new string('=',cabecera.Length));
        foreach (var item in opciones)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine(new string('=',final.Length)+"\n"+final);
    }
    static void EjecutarMenu(string[]args){
        ConsoleKeyInfo tecla;
        do
        {
            Menu();
            tecla= Console.ReadKey();
        } while (tecla.KeyChar!='1'&&tecla.KeyChar!='2'&&tecla.KeyChar!='3'&&tecla.KeyChar!='4'&&tecla.KeyChar!='5'&&tecla.KeyChar!='6'&&tecla.KeyChar!='7'&&
        tecla.KeyChar!='8'&&tecla.KeyChar!='9'&&tecla.Key!=ConsoleKey.F10&&tecla.Key!=ConsoleKey.Escape
        );
        switch(tecla.KeyChar){
            
            case '1':
                break;
            case '2':
                CopiarFichero(args[0],args[1]);
                break;
            case '3':
                CopiarFicheroSinCaracter(args[0],args[1],args[2]);
                break;
            case '4':
                LeerFichero(args[0]);
                break;
            case '5':
                ConcatenarFicheros(args[0],args[1]);
                break;
            case '6':

                break;
            case '7':
                MostrarFicheros(args);
                break;
            case '8':
                AccesoAleatorio(args[0]);
                break;
            case '9':
            case (Char)ConsoleKey.F10:
                break;
            case (Char)ConsoleKey.Escape:
                return;
        }
    }
    #endregion
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
        if (File.Exists(fichero))
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
    /*
    6. Escribe un programa que contenga dos funciones: CrearFichero(string fi) y ListarFichero(string fi) donde:
    a) La primera función almacena en un fichero de texto (fi) los nombres y apellidos de los alumnos. En nombre 
    del archivo se le pasa a la función al llamarla.
    b) Muestra por pantalla el contenido del fichero (fi) pasado.
    */
    static void CrearFichero(string fi){
        ListaAlumnos listaAlumnos = new(20);
        File.WriteAllText("../../../alumnos.txt",File.ReadAllText(fi));
    }
    static void ListarFichero(string fichero){
        if (Path.Exists(fichero)){
            StreamReader streamReader= new StreamReader(fichero);
            System.Console.WriteLine(streamReader.ReadToEnd());
            streamReader.Close();
        }
    }
    #region Ej6 v2.0
        static void CrearFichero2(){
        ListaAlumnos listaAlumnos = new(20);
        File.WriteAllText("alumnos.txt",File.ReadAllText(Path.GetFullPath(listaAlumnos.ruta)));
    }
    #endregion
    #region Ej7
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
    #endregion
    #region EJ8
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
    #endregion
    #region Ej9
    /*
        9. Haz un programa que gestione un fichero en el que vaya guardando los datos: Nombre usuario, fecha, 
        hora y tiempo de conexión, para cada una de las veces que se ha ejecutado.
    */
    static void GuardadoDatos(){
        ListaUSuario listaUSuario= new ListaUSuario();
        listaUSuario.GenerarUsuario(20);
        File.AppendAllText("usuarios.txt",File.ReadAllText(Path.GetFullPath(listaUSuario.ruta)));
    }
    #endregion
    
}
