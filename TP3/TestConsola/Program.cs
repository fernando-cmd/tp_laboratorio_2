using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Sol a1 = new Sol(false, 10, EArmazon.Acero, ELente.Plastico, false, true, EColor.Blanco, EColor.Blanco);
            Sol a2 = new Sol(false, 10, EArmazon.Aluminio, ELente.Vidrio, false, true, EColor.Blanco, EColor.Blanco);
            Sol a3 = new Sol(false, 100, EArmazon.Plastico, ELente.Metal, false, true, EColor.Blanco, EColor.Blanco);
            Clasico a4 = new Clasico(false, 3, EArmazon.Plastico, ELente.Plastico, false, false);

            Fabrica f = new Fabrica("ASD");
            f.Agregar(a1);
            f.Agregar(a2);
            f.Agregar(a3);
            f.Agregar(a4);
            Console.WriteLine((string)f);

            Console.ReadKey();


        }
    }
}
