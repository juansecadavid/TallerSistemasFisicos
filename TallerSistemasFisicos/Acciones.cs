using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerSistemasFisicos
{
    public class Acciones
    {
        public string accion;
        public static int situacion2=0;
        public static string[] situaciones = new string[7];
        //static List<string> opciones = new List<string>();
        public static int vidas = 3;
        public Acciones(string accion)
        {
            this.accion = accion;
            situaciones[0] = "";
            situaciones[1] = $"Estás en el ático, te zafas de las manos de la bruja.\nAcciones:\n1)Lanzarme (por la ventana).\t2)Bajar (las escaleras al 2do piso).";
            situaciones[2] = $"Estás en el segundo piso de la casa abandonada, no hay ventanas y la única forma de bajar es por una puerta con llave.\nAcciones:\n1)Gritar (por ayuda).\t2)Investigar (el piso).";
            situaciones[3] = $"Luego de un rápido vistazo por el lugar sigues en panico y tu busqueda es fallida..., de repente escuchas a la bruja bajando las escaleras.\nAcciones:\n1)Enfrentarme (a la bruja).\t2)Esconderme.";
            situaciones[4] = $"La bruja está a punto de atacarte.\nAcciones:\n1)Rodearme de sal.\t2)Clavarle un cuchillo.";
            situaciones[5] = $"Tu única oportunidad de salir de allí está en frente de ti.\nAcciones:\n1)Romper la ventana (y salir).\t2)Forcejear la puerta (principal).";
            situaciones[6] = "Terminaste el juego!";
        }
        public static string Situaciones(string data)
        {
            string msg = "Comando desconocido: Vuelve a intentar!";
            if (data.Contains("INICIO"))
            {
                msg = $"Apresurate!";
            }
            if (data.Contains("Lanzarme"))
            {
                vidas--;
                msg = $"Resbalaste mientras ibas hacia la ventana y caiste herido en el segundo piso, mala eleccion! \nTe quedan {vidas} vidas";
            }
            if (data.Contains("Bajar las escaleras"))
            {
                msg = $"Bajaste al segundo piso, buena eleccion!\nTe quedan {vidas} vidas";
            }
            if (data.Contains("Gritar"))
            {
                vidas--;
                msg = $"Tus gritos no sirvieron y tuviste que investigar, gastanto energias valiosas..., mala eleccion\nTe quedan {vidas} vidas";
            }
            if (data.Contains("Investigar"))
            {
                msg = $"Siempre es mejor investigar en el lugar que te encuentras, buena eleccion!\nTe quedan {vidas} vidas";
            }
            if (data.Contains("Enfrentarme"))
            {
                vidas--;
                msg = $"No te quedan muchas energias y te mareaste, quiza pelear sea una mala eleccion...\nTe quedan {vidas} vidas";
            }
            if (data.Contains("Esconderme"))
            {
                msg = $"Siempre es mejor buscar un lugar seguro, buena eleccion!\nTe quedan {vidas} vidas";
            }
            if (data.Contains("Rodearme de sal"))
            {
                msg = $"Protegerse siempre sera una buena eleccion!\nTe quedan {vidas} vidas";
            }
            if (data.Contains("Clavarle un cuchillo"))
            {
                vidas--;
                msg = $"Te acercaste a la bruja y ella logró herirte con el cuchillo. Muy mala eleccion!\nTe quedan {vidas} vidas";
            }
            if (data.Contains("Romper la ventana"))
            {
                msg = $"Efectivamente, elegiste salvar tu via. Felicidades, has completado el juego y has sobrevivido!";
            }
            if (data.Contains("Forcejear la puerta"))
            {
                vidas--;
                msg = $"Perdiste mucho esfuerzo dañando la puerta, sin embargo, lograste salir a cambio de una vida menos... Felicidades, has completado el juego y has sobrevivido!";
            }
            if (data.Contains("Ganar Juego"))
            {
                msg = $"Felicidades, completaste el juego con el truco secreto! (Por favor no compartas este truco con nadie :v)";
            }
            return msg;
        }
    }
}
