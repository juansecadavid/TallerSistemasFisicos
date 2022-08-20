using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TallerSistemasFisicos;
int tiempo = 0;
Console.WriteLine("Bienvenido a Save your life!");
string aviso = "5 segundos..";
Thread server = new Thread(new ThreadStart(StartServer));
server.Start();
while (server.IsAlive)
{
    Thread.Sleep(5000);
    Console.WriteLine(aviso);
    tiempo++;
    //Thread.Sleep(2000);
    //aviso = aviso.Remove(0, 9);
    /*if (tiempo==36)
    {
        Console.WriteLine("Se acabó el juego");
        Console.WriteLine("Presiona cualquier tecla para volver a iniciar");
        Console.ReadKey();
        //handler.Shutdown(SocketShutdown.Both);
        //handler.Close();
        //falta algo para reiniciar
    }*/

}
//StartServer();
Console.WriteLine("\n Presione una tecla para continuar...");
Console.ReadKey();
void StartServer()
{

    IPHostEntry host = Dns.GetHostEntry("localhost");
    IPAddress ipAddress = host.AddressList[1];
    ipAddress = IPAddress.Parse("127.0.0.1");
    IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 50000);
    Acciones accion = new Acciones($"Hola");
    int situacion = 0;
    try
    {
        int primeravez = 0;
        Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        listener.Bind(localEndPoint);
        listener.Listen(10);

        Console.WriteLine("Waiting for a connection...");
        Socket handler = listener.Accept();

        // Incoming data from the client.
        string mensaje = null;
        string data = null;
        byte[] bytes = null;
        string perdiste = "Has perdido todas las vidas!, la bruja gana...";

        while (true)
        {;
            Console.Clear();
            if (primeravez==0)
            {
                Console.WriteLine("Hola! lamentamos tener que ser tan directos, pero estás en una situación demasiado ¡PELIGROSA!");
                Console.WriteLine("\nEs una noche tenue y fría, estás en el ático de una casa abandonada en medio del bosque y luego de ver cómo una bruja asesina a tus amigos, tendrás que intentar irte a toda prisa para salvar tu vida.");
                Console.WriteLine("Pero no creas que será fácil salir...");
                Console.WriteLine("\nInstrucciones:\nPara cada situacion tendrás que elgir entre dos opciones, y para elegirla deberás escribir tal cual el comando como se muestra en cada opcion, pero sin poner lo que haya entre paréntesis.");
                Console.WriteLine("Ejemplo:\n1) jugar arriba (texto adicional)\t2)saltar al lado(texto adicional)\n En este ejemplo para elegir la opcion 1 deberás escribir: jugar arriba ");
                Console.WriteLine("\nTambién tendrás 3 vidas, y las perderás si eliges la opción incorrecta en cada situción. Si pierdes las 3 vidas se acabará el juego!, sin embargo, aunque elijas mal pasarás a la siguiente situacion mientras tengas vidas disponibles");
                Console.WriteLine("\nEscribe INICIO para comenzar");
            }
            Console.WriteLine($"{Acciones.situaciones[situacion]}");          
            
            bytes = new byte[1024];
            int bytesRec = handler.Receive(bytes);
            data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            if(data=="INICIO")
            {
                primeravez++;
            }
            accion.accion=$"{data}";
            Console.WriteLine($"Acción recibida: {accion.accion}");

            if (data.Length == 0)
            {
                break;
            }
            mensaje=Acciones.Situaciones(accion.accion);
            if (mensaje == "Comando desconocido: Vuelve a intentar!")
            {
                if (primeravez == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Hola! lamentamos tener que ser tan directos, pero estás en una situación demasiado ¡PELIGROSA!");
                    Console.WriteLine("Es una noche tenue y fría, estás en el ático de una casa abandonada en medio del bosque y luego de ver cómo una bruja asesina a tus amigos, tendrás que intentar irte a toda prisa para salvar tu vida.");
                    Console.WriteLine("Pero no creas que será fácil salir...");
                    Console.WriteLine("Escribe INICIO para comenzar");
                }
            }
            else
            {
                situacion++;
            }
            if (data.Length == 0 || data.Contains("XXX"))
            {
                break;
            }
            byte[] msg = Encoding.ASCII.GetBytes(mensaje);
            byte[] ret = Encoding.ASCII.GetBytes(perdiste);
            handler.Send(msg);
            if(Acciones.vidas==0)
            {
                handler.Send(ret);
                Environment.Exit(0);
            }
        }

        handler.Shutdown(SocketShutdown.Both);
        handler.Close();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.ToString());
    }
}


