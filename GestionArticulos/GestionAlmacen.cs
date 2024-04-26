using Newtonsoft.Json;

public class GestionAlmacen{
    private List<Articulo> Articulos { get; set; }
    public int Existencias{get; set;}
    public GestionAlmacen (){
        Articulos = new();
    }
    #region Alta
    public void AltaArticulos(){
        
        
        System.Console.WriteLine("Escriba el nombre del articulo que quieres dar de alta");
        string? str = Console.ReadLine();
        float precio;
        System.Console.WriteLine("Ponle precio a tu articulo");
        float.TryParse(Console.ReadLine(), out precio);
        System.Console.WriteLine("Escribe un comentario para tu articulo");
        string comentario = Console.ReadLine()!;
        if (str!=null &&  str.Length!=0)
        {
            var art = new Articulo(str, precio, comentario);
            if (Articulos.Contains(art))
            {
                System.Console.WriteLine("ERROR: articulo existente");
            }
            else{
                Articulos.Add(art);
                System.Console.WriteLine("Articulo añadido con exito");
            }
        }
    }
    #endregion
    #region Baja
    public void BajaArticulos(){
    
        
        ConsoleKeyInfo tecla;
        System.Console.WriteLine("Escriba el ID del articulo que quieres borrar");
        string? str = Console.ReadLine();
        bool existe=false;
        if (str!=null)
        {
            foreach (var item in Articulos)
            {
                if (item.Id==int.Parse(str))
                {
                    existe=true;
                }
            }
            if (existe)
            {
                do
                {
                    System.Console.WriteLine($"¿Quieres borrar el Articulo con ID: {str}? [1] Confirmar [2] Cancelar");
                    tecla = Console.ReadKey(true);
                } while (tecla.KeyChar != '1' && tecla.KeyChar != '2');
                if (tecla.KeyChar == '1')
                {
                    Articulos.Remove(Articulos.Find(x => x.Id == int.Parse(str))!);
                    System.Console.WriteLine("Articulo dado de baja");
                }
            }
            else{
                System.Console.WriteLine("El articulo no existe");
            }
        }
        
    }
    #endregion
    #region Modificar
    public void Modificar(){
        int id;
        System.Console.WriteLine("Escribe un ID para modificarlo");
        int.TryParse(Console.ReadLine(), out id);
        foreach (var item in Articulos)
        {
            if (item.Id==id)
            {
                System.Console.WriteLine("Escriba el nombre del articulo");
                string? str = Console.ReadLine()!;
                float precio;
                System.Console.WriteLine("Ponle precio a tu articulo");
                float.TryParse(Console.ReadLine(), out precio);
                item.Precio = precio;
                item.Nombre=str;
            }
        }
    }
    #endregion
    #region Consultar
    public void Consultar(){
        if (Articulos.Count>0)
        {
            System.Console.WriteLine("Escriba el ID del articulo que quieres consultar");
            string? str = Console.ReadLine();
            if (str!=null &&  str.Length!=0)
            {
                foreach (var item in Articulos)
                {
                    if (item.Id==int.Parse(str))
                    {
                        System.Console.WriteLine(item+"\n"+item.Comentarios);
                    }
                }
            }
        }
        else
            System.Console.WriteLine("Todavia no hay articulos");
    }
    #endregion
    #region OrdenarID
    public void OrdenarID(){
        if (Articulos.Count!=0)
        {
            Articulos.Sort();
        }
    }
    #endregion
    #region OrdenarNombre
    public void OrdenarNombre(){
        if (Articulos.Count!=0)
        {
            Articulos.Sort(new OrdenarPorNombre());
        }
    }
    #endregion
    #region GenerarJSON 
    public void GenerarJSON(){
        string ruta;
        System.Console.WriteLine("Dame un nombre para el JSON");
        ruta = Console.ReadLine()!;
        ruta = Path.GetFileNameWithoutExtension(ruta)+".txt";
        string json = JsonConvert.SerializeObject(Articulos, Formatting.Indented);
        File.WriteAllText("json.json", json);
        System.Console.WriteLine("JSON creado con exito");
    }
    #endregion
    #region CrearFichero
    public string CrearFichero(){
        string ruta = "";
        System.Console.WriteLine("Escriba un nombre para el archivo");
        ruta = Console.ReadLine()!;
        ruta = Path.GetFileNameWithoutExtension(ruta)+".txt";
        if (Path.Exists(ruta))
        {
            ConsoleKeyInfo tecla;
            do
            {
                System.Console.WriteLine($"¿Quieres borrar los datos del fichero? [1] Confirmar [2] Cancelar");
                tecla = Console.ReadKey(true);
            } while (tecla.KeyChar != '1' && tecla.KeyChar != '2');
            if (tecla.KeyChar=='1')
            {
                File.Delete(ruta);
                using FileStream fl = File.Create(ruta);
            }
        }
        else
        {
            using FileStream fl = File.Create(ruta);
        }
        return ruta;
    }
    #endregion
    #region ToString
    public override string ToString()
    {
        string str = "";
        int count=0;
        foreach (var item in Articulos){
            if (count!=Articulos.Count)
            {
                str += "Cuentas con "+Existencias+" productos en tu lista \n";
                str += item + "\n";
            }
            else
                str += item;
        }
        return str;
    }
    #endregion
}