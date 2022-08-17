using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TallerSistemasFisicos;
int primeravez = 0;
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

    try
    {

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
            if (primeravez==0)
            {
                Console.WriteLine("Tu nombre es ");
                primeravez++;
            }         
            bytes = new byte[1024];
            int bytesRec = handler.Receive(bytes);
            data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            Acciones accion = new Acciones($"{data}");
            Console.WriteLine($"Text received: {accion.accion}");

            if (data.Length == 0)
            {
                break;
            }
            mensaje=Acciones.Situaciones(accion.accion);
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


