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
        public static string[] situaciones = new string[5];
        static List<string> opciones = new List<string>();
        static int vidas = 0;
        public Acciones(string accion)
        {
            this.accion = accion;
            opciones.Add("Puerta");
            situaciones[0] = "";
            situaciones[1] = "Situacion1";
            situaciones[2] = "situacion2";
        }
        public static string Situaciones(string data)
        {
            string msg = "Comando desconocido";
            if (data.Contains("INICIO"))
            {

                msg = $"Apresurte!";
            }

            if (data.Contains("Hola"))
            {
                opciones.Remove("hola");
                msg = $"El código en la nota es el siguiente: 2-9-7-6-8\nTe quedan {vidas} vidas ";

            }
            if (data.Contains("Ver código"))
            {
                msg = "El código en la nota es el siguiente: 2-9-7-6-8\nSin Embargo, está en el orden incorrecto... ";

            }
            if (data.Contains("Ganar Juego"))
            {
                msg = "Felicidades, completaste el juego! (Por favor no compartas este truco con nadie :v)";

            }
            return msg;
        }
    }
}
