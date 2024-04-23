using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using Newtonsoft.Json;


public class ListaAlumnos
{
    List<ALumnos> listaAlumnos;
    public string ruta="./CreadorAlumnos/alumnos.json";
    public ListaAlumnos(int num){
        listaAlumnos = new();
        string[] Nombres = {
        "Juan", "María", "Carlos", "Laura", "Pedro",
        "Ana", "José", "Sofía", "Miguel", "Elena",
        "David", "Lucía", "Pablo", "Isabel", "Manuel",
        "Carmen", "Javier", "Paula", "Daniel", "Raquel"
        };
        string[] apellidos = {
        "García", "Rodríguez", "López", "Martínez", "González",
        "Hernández", "Sánchez", "Pérez", "Martín", "Gómez",
        "Ruiz", "Díaz", "Alvarez", "Fernández", "Vázquez",
        "Torres", "Jiménez", "Moreno", "Ramos", "Romero"
        };
        Random random= new Random();
        for (int i = 0; i <= num; i++)
        {
            listaAlumnos.Add(new ALumnos(Nombres[random.Next(0,Nombres.Length)],apellidos[random.Next(0,apellidos.Length)],apellidos[random.Next(0,apellidos.Length)]));
        }
        SerializarJson();
    }
    public void SerializarJson(){
        string json = JsonConvert.SerializeObject(listaAlumnos, Formatting.Indented);
        File.WriteAllText(ruta,json);
    }
     public string ListarJSON(){
        List<ALumnos> plantilla = new List<ALumnos>();
        string str = string.Empty;
        using(StreamReader sr = File.OpenText(ruta)){
            plantilla = JsonConvert.DeserializeObject<List<ALumnos>>(sr.ReadToEnd())!;
        }
        if (plantilla!= null)
        {
            foreach (var item in plantilla)
            {
                str+=item +"\n";
            }
        }
        return str;
    }
    

}