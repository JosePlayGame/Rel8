using Newtonsoft.Json;

public class Articulo:IEquatable<Articulo>,IComparable<Articulo>
{
    #region CamposPropiedades
    private static int _id = 1;
    public int Id{get;set;}
    private string _nombre;
    public string Nombre { get=>_nombre;set{
        if (_nombre.Length>15){}
        else 
            _nombre=value;

    }}
    public float Precio{get;set;}
    public float Pvp{get=>Precio+(Precio*0.25f);}
    [JsonIgnore]
    private string _comentario;
    public string Comentarios { get=>_comentario;set{
        if (_comentario.Length>60){}
        else 
            Comentarios=value;

    }}
    #endregion
    #region Constructores
    public Articulo(string nom,float precio,string Comen){
        Id=_id++;
        if (_id > 999) 
        {
            _id = 1;
        }
        _nombre= nom;
        Precio = precio;
        _comentario=Comen;
    }
    #endregion
    #region Metodos
    public bool Equals(Articulo? other)
    {
        return other!=null&&Nombre == other.Nombre&&Precio == other.Precio;    
    }
    public override string ToString()
    {
        return $"ID: {Id} NOMBRE: {Nombre} PRECIO: {Precio} PVP: {Pvp}";
    }

    public int CompareTo(Articulo? other)
    {
        if (other!= null)
        {
            if (Id > other.Id)
                return 1;
            else if (Id < other.Id)
                return -1;
            else
                return 0;
        }
        return 0;
    }
    #endregion
}
#region OrdernarNombre
public class OrdenarPorNombre : IComparer<Articulo>
{
    public int Compare(Articulo? x, Articulo? y)
    {
        if (x!=null&&y!=null)
        {
            return string.Compare(x.Nombre, y.Nombre);
        }
        else
            return 0;
    }
}
#endregion