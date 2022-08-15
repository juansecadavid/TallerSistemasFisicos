using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Hola Mundo!");
Thread server = new Thread(new ThreadStart(StartServer));
server.Start();
while (server.IsAlive)
{
    Thread.Sleep(5000);
    Console.WriteLine("5 segundos..");
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
        string data = null;
        byte[] bytes = null;

        while (true)
        {
            bytes = new byte[1024];
            int bytesRec = handler.Receive(bytes);

            data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            Console.WriteLine($"Text received : {data}");

            if (data.Length == 0)
            {
                break;
            }
            data = Analizar(data);
            if (data.Length == 0 || data.Contains("XXX"))
            {
                break;
            }
            byte[] msg = Encoding.ASCII.GetBytes(data);
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
static string Analizar(string data)
{
    string msg = "Comando desconocido";
    if (data.Contains("Abrir"))
    {
        msg = "Puerta Abierta";

    }
    if (data.Contains("Cerrar"))
    {
        msg = "Puerta Cerrada";
    }
    if (data.Contains("Adios"))
    {
        msg = "Adiós";
    }
    if (data.Contains("Abrir ventana"))
    {
        msg = "Ventana Abierta";
    }
    if (data.Contains("Cerrar ventana"))
    {
        msg = "Ventana Cerrada";
    }
    if (data.Contains("Ganar juego"))
    {
        msg = "Te pasaste el juego";
    }
    if (data.Contains("Open web"))
    {
        Process p = new Process();
        p.StartInfo.FileName = @"explorer";
        p.StartInfo.Arguments = "\"http://upb.edu.co\"";
        p.Start();
        p.WaitForExit();
    }
    return msg;
}

