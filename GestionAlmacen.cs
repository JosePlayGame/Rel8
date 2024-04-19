public class GestionAlmacen
{
    public GestionAlmacen(){

    }
    private void PintarMenu(){
        string cabecera = "MENU PRINCIPAL";
        string[]opciones = {"1. Alta de artículos.","2. Baja de artículos.","3. Consultar un artículo.","4. Modificar un artículo. ","5. Listar artículos ordenados por código.","6. Listar artículos ordenados por nombre.","7. Generar un JSON"};
        System.Console.WriteLine(cabecera);
        System.Console.WriteLine(new string('=',cabecera.Length));
        foreach (var item in opciones){
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine("0. Salir");
        System.Console.WriteLine("Pulse una tecla : ");
    }
    public void Ejecutar(){
        ConsoleKeyInfo tecla;
        PintarMenu();
        do{
            tecla = Console.ReadKey(true);
        }while(tecla.Key!=ConsoleKey.Escape);
    }
}