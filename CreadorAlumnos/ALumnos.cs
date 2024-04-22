using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class ALumnos
{
    public string Nombre { get; set; }
    public string Apellido1{ get; set; }
    public string Apellido2{ get; set; }
    public ALumnos(string nombre, string Apellido1, string Apellido2){
        this.Nombre = nombre;
        this.Apellido1 = Apellido1;
        this.Apellido2 = Apellido2;
    }
}