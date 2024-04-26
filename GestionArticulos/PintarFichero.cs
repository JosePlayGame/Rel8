public class PintarFichero
{
    public static string? ruta;
    public PintarFichero(){
        ruta = "articulos.txt";
    }
    public void Ejecutar(){
        Menu menu= new Menu();
        menu.evtCambioMenu+=EvtCambio;
        menu.Ejecutar();
    }
    public void EvtCambio(object? sender,EventArgs e){
        if (sender!=null)
        {
            File.WriteAllText(ruta!,((GestionAlmacen)sender).ToString());
        }
    }
}