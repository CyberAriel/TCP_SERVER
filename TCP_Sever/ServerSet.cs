﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MyTcpListener
{
    public string data
    {
        get;
        set;
    }
    public static MyTcpListener Instance = new MyTcpListener();

    public void Show(ref string Data)
    {
        Data = data;
    }
    public void Start()
    {
        
        Task.Run(() =>
        {

        
         
        TcpListener server = null;
        try
        {
            
            // Set the TcpListener on port 13000.
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            // TcpListener server = new TcpListener(port);
            server = new TcpListener(localAddr, port);

            // Start listening for client requests.
            server.Start();
           
            // Buffer for reading data
            Byte[] bytes = new Byte[256];
            

            // Enter the listening loop.
         
            while (true)
            {
                    data = "Waiting for a connection... ";
 
                 Console.Write("Waiting for a connection... ");
                
                // Perform a blocking call to accept requests.
                // You could also use server.AcceptSocket() here.
                TcpClient client = server.AcceptTcpClient();
                    data = "Waiting for a connection...Connected! ";
                    Console.WriteLine("Connected!");

                data = null;

                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                int i;

                // Loop to receive all the data sent by the client.
                
               while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
               {
                    
                   // Translate data bytes to a ASCII string.
                   data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                   Console.WriteLine("Received: {0}", data);

                   // Process the data sent by the client.
                   data = data.ToUpper();

                   byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                   // Send back a response.
                   stream.Write(msg, 0, msg.Length);
                   Console.WriteLine("Sent: {0}", data);
                    
               }

               // Shutdown and end connection
               client.Close();
          
            }

        }
        catch (SocketException e)
        {
                data = "SocketException: { 0}";
               
            Console.WriteLine("SocketException: {0}", e);
        }
        finally
        {
            // Stop listening for new clients.
            server.Stop();
                Console.WriteLine("Disconnected");
        }
            data = "Hit enter to continue...";
        Console.WriteLine("\nHit enter to continue...");
            //Console.Read();
        });
    }
}