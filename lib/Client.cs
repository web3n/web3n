using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Web3n
{
  public class Client
  {
    Socket client;

    public Client()
    {
      //      var options = new SocketInformation();
      //options.Options = SocketInformationOptions.NonBlocking;

      IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
      IPEndPoint remoteEP = new IPEndPoint(ipAddress, 8545);

      // Create a TCP/IP  socket.  
      this.client = new Socket(ipAddress.AddressFamily,
          SocketType.Stream, ProtocolType.Tcp);

      try
      {
        this.client.Connect(remoteEP);

      }
      catch (ArgumentNullException ane)
      {
        Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
      }
      catch (SocketException se)
      {
        Console.WriteLine("SocketException : {0}", se.ToString());
      }
      catch (Exception e)
      {
        Console.WriteLine("Unexpected exception : {0}", e.ToString());
      }
    }

    public void Send(string message)
    {
      byte[] msg = Encoding.Unicode.GetBytes(message + "<Client Quit>");
      this.client.Send(msg);
    }
  }
}
