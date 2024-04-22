public class Producto
{
    private string nombre_art;
    public float precio;
    public float pvp => precio+precio*0.25f;
    public List<string> comentarios;
    public string NombreArticulo{get=>nombre_art;set{
        if (nombre_art.Length>15)
            value="";
        else
            nombre_art=value;
    }} 
    public Producto(string nombre_art,float precio){
        this.nombre_art=nombre_art;
        this.precio=precio;
        comentarios=new();
    }
    public override string ToString()
    {
        return $"Nombre : {NombreArticulo} Precio Coste : {precio} PVP : {pvp}";
    }
    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }
}