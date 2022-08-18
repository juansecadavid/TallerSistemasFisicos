using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TallerSistemasFisicos;
int tiempo = 0;
Console.WriteLine("Bienvenido a Save your life!");
Thread server = new Thread(new ThreadStart(StartServer));
server.Start();
while (server.IsAlive)
{
    Thread.Sleep(5000);
    Console.WriteLine("5 segundos..");
    tiempo++;
    if (tiempo==36)
    {
        Console.WriteLine("Se acabó el juego");
        Console.WriteLine("Presiona cualquier tecla para volver a iniciar");
        Console.ReadKey();
        //handler.Shutdown(SocketShutdown.Both);
        //handler.Close();
        //falta algo para reiniciar
    }

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

        while (true)
        {
            Console.Clear();
            if (primeravez==0)
            {
                Console.WriteLine("Hola! lamentamos tener que ser tan directos, pero estás en una situación demasiado ¡PELIGROSA!");
                Console.WriteLine("Es una noche tenue y fría, estás en el ático de una casa abandonada en medio del bosque y luego de ver cómo una bruja asesina a tus amigos, tendrás que intentar irte a toda prisa para salvar tu vida.");
                Console.WriteLine("Pero no creas que será fácil salir...");
                Console.WriteLine("Escribe INICIO para comenzar");
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
            Console.WriteLine($"Text received: {accion.accion}");

            if (data.Length == 0)
            {
                break;
            }
            mensaje=Acciones.Situaciones(accion.accion);
            if(mensaje == "Comando desconocido")
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
            handler.Send(msg);
        }

        handler.Shutdown(SocketShutdown.Both);
        handler.Close();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.ToString());
    }
}


