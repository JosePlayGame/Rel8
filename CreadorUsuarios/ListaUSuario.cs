using System.Net.Http.Json;
using Newtonsoft.Json;

public class ListaUSuario
{
    List<Usuario> _usuarios;
    public string ruta = "./CreadorUsuarios/usuarios.json";
    public ListaUSuario(){
        _usuarios = new();
    }
    public void GenerarUsuario(int num){
        string[] nombresUsuarios = {
            "Juan", "María", "Carlos", "Laura", "Pedro",
            "Ana", "José", "Sofía", "Miguel", "Elena",
            "David", "Lucía", "Pablo", "Isabel", "Manuel",
            "Carmen", "Javier", "Paula", "Daniel", "Raquel"
            };
        Random random= new Random();
        for (int i = 0; i <= num; i++)
        {
            _usuarios.Add(new Usuario(nombresUsuarios[random.Next(0,nombresUsuarios.Length)]));
        }
        SerializarJson();
    }
    public void SerializarJson(){
        string json = JsonConvert.SerializeObject(_usuarios, Formatting.Indented);
        File.WriteAllText(ruta, json);
    }
}