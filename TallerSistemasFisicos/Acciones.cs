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
        public static string[] situaciones = new string[6];
        //static List<string> opciones = new List<string>();
        public static int vidas = 3;
        public Acciones(string accion)
        {
            this.accion = accion;
            situaciones[0] = "";
            situaciones[1] = "Estás en el ático, te zafas de las manos de la bruja.\nAcciones:\n1)Lanzarme por la ventana.\t2)Bajar las escaleras (al 2do piso).";
            situaciones[2] = "Estás en el segundo piso de la casa abandonada, no hay ventanas y la única forma de bajar es por una puerta con llave.\nAcciones:\n1)Subir y atacar (a la bruja).\t2)Investigar (el piso).";
            situaciones[3] = "Luego de un rápido vistazo por el lugar sigues en panico y tu busqueda es fallida..., de repente escuchas a la bruja bajando las escaleras.\nAcciones:\n1)Enfrentar (a la bruja).\t2)Esconderte.";
            situaciones[4] = "La bruja está a punto de atacarte.\nAcciones:\n1)Rodearte de sal.\t2)Clavarle el cuchillo.";
            situaciones[5] = "Tu única oportunidad de salir de allí está en frente de ti.\nAcciones:\n1)Romper la ventana (y salir).\t2)Forcejear la puerta (principal).";
        }
        public static string Situaciones(string data)
        {
            string msg = "Comando desconocido: Vuelve a intentar!";
            if (data.Contains("INICIO"))
            {
                msg = $"Apresurte!";
            }
            if (data.Contains("Lanzarme por la ventana"))
            {
                vidas--;
                msg = $"Te lanzaste por la ventana y te fracturaste asi que pierdes 1 vida \nTe quedan {vidas} vidas";
            }
            if (data.Contains("Bajar las escaleras"))
            {
                msg = $"El código en la nota es el siguiente: 2-9-7-6-8\nTe quedan {vidas} vidas";
            }
            if (data.Contains("Subir y atacar"))
            {
                vidas--;
                msg = $"El código en la nota es el siguiente: 2-9-7-6-8\nTe quedan {vidas} vidas";
            }
            if (data.Contains("Investigar"))
            {
                msg = $"El código en la nota es el siguiente: 2-9-7-6-8\nTe quedan {vidas} vidas";
            }
            if (data.Contains("Enfrentar"))
            {
                vidas--;
                msg = $"El código en la nota es el siguiente: 2-9-7-6-8\nTe quedan {vidas} vidas";
            }
            if (data.Contains("Esconderte"))
            {
                msg = $"El código en la nota es el siguiente: 2-9-7-6-8\nTe quedan {vidas} vidas";
            }
            if (data.Contains("Rodearte de sal"))
            {
                msg = $"El código en la nota es el siguiente: 2-9-7-6-8\nTe quedan {vidas} vidas";
            }
            if (data.Contains("Clavarle el cuchillo"))
            {
                vidas--;
                msg = $"El código en la nota es el siguiente: 2-9-7-6-8\nTe quedan {vidas} vidas";
            }
            if (data.Contains("Romper la ventana"))
            {
                msg = $"El código en la nota es el siguiente: 2-9-7-6-8\nTe quedan {vidas} vidas";
            }
            if (data.Contains("Forcejear la puerta"))
            {
                vidas--;
                msg = $"El código en la nota es el siguiente: 2-9-7-6-8\nTe quedan {vidas} vidas";
            }
            if (data.Contains("Ganar Juego"))
            {
                msg = $"Felicidades, completaste el juego! (Por favor no compartas este truco con nadie :v)";
            }
            return msg;
        }
    }
}
