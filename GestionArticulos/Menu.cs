public class Menu
{
    GestionAlmacen gestion = new();
    public EventHandler? evtCambioMenu;
    #region Menu
    private void PintarMenu(){
        string cabecera = "MENU PRINCIPAL";
        string[]opciones = {"1. Alta Articulos","2. Baja Articulos","3. Consultar artículo","4. Modificar un artículo","5. Listar artículo ordenados por código","6. Listar artículos ordenados por nombre","7. Generar JSON","8. Crear fichero"};
        string final = "0 - Para salir del programa";
        System.Console.WriteLine(cabecera + "\n" + new string('=',cabecera.Length));
        foreach (var item in opciones)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine("\n" + final);
    }
    public void Ejecutar(){
        ConsoleKeyInfo tecla;
        Console.Clear();
        if (evtCambioMenu != null)
        {
            evtCambioMenu.Invoke(gestion,EventArgs.Empty);
        }
        PintarMenu();
        do
        {
            tecla=Console.ReadKey(true);
            switch (tecla.KeyChar){
                case '1':
                    Console.Clear();
                    gestion.AltaArticulos();
                    Console.WriteLine("Volviendo al menu en 3 segundos");
                    Thread.Sleep(3000);
                    Ejecutar();
                    break;
                case '2':
                    Console.Clear();
                    gestion.BajaArticulos();
                    Console.WriteLine("Volviendo al menu en 3 segundos");
                    Thread.Sleep(3000);
                    Ejecutar();
                    break;
                case '3':
                    Console.Clear();
                    gestion.Consultar();
                    Console.WriteLine("Volviendo al menu en 3 segundos");
                    Thread.Sleep(3000);
                    Ejecutar();
                    break;
                case '4':
                    Console.Clear();
                    gestion.Modificar();
                    Console.WriteLine("Volviendo al menu en 3 segundos");
                    Thread.Sleep(3000);
                    Ejecutar();
                    break;
                case '5':
                    Console.Clear();
                    gestion.OrdenarID();
                    System.Console.WriteLine(gestion);
                    Console.WriteLine("Volviendo al menu en 3 segundos");
                    Thread.Sleep(3000);
                    Ejecutar();
                    break;
                case '6':
                    Console.Clear();
                    gestion.OrdenarNombre();
                    System.Console.WriteLine(gestion);
                    Console.WriteLine("Volviendo al menu en 3 segundos");
                    Thread.Sleep(3000);
                    Ejecutar();
                    break;
                case '7':
                    Console.Clear();
                    gestion.GenerarJSON();
                    Console.WriteLine("Volviendo al menu en 3 segundos");
                    Thread.Sleep(3000);
                    Ejecutar();
                    break;
                case '8':
                    Console.Clear();
                    PintarFichero.ruta=gestion.CrearFichero();
                    Console.WriteLine("Volviendo al menu en 3 segundos");
                    Thread.Sleep(3000);
                    Ejecutar();
                    break;
            }
        } while (tecla.KeyChar!='0');
    }
    #endregion
    
}