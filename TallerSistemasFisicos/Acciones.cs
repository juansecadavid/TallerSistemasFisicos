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

        public Acciones(string accion)
        {
            this.accion = accion;
        }

        public static string Situaciones(string data)
        {
            string msg = "Comando desconocido";
            if (data.Contains(""))
            {
                msg = "El código en la nota es el siguiente: 2-9-7-6-8\nSin Embargo, quizá ";

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
