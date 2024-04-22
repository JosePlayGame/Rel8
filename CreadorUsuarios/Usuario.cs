public class Usuario
{
    public string NombreUsuario;
    public DateTime fecha;
    public Usuario(string NombreUsuario){
        this.NombreUsuario=NombreUsuario;
        fecha=DateTime.Now;
    }
    public override string ToString()
    {
        return $"{NombreUsuario} {fecha}";
    }
}