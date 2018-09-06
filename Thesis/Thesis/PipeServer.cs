using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;
using System.Threading;

namespace Thesis
{
    class PipeServer
    {


        public void StartServer(string file_name)
        {
            try
            {

                var server = new NamedPipeServerStream("Pipe");
                Task.Factory.StartNew(() =>
                {
                   
                        server.WaitForConnection();
                        StreamReader reader = new StreamReader(server);
                        StreamWriter writer = new StreamWriter(server);

                        writer.WriteLine(file_name);
                        writer.Flush();
                    
                        server.Disconnect();
                        server.Dispose();

                });

                //Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public string StartServerAndGetString(string file_name)
        {
            try
            {
                var server = new NamedPipeServerStream("Pipe");
                Task.Factory.StartNew(() =>
                {
                    
                    server.WaitForConnection();
                    StreamReader reader = new StreamReader(server);
                    StreamWriter writer = new StreamWriter(server);

                    writer.WriteLine(file_name);
                    writer.Flush();

                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line != null)
                        {
                            Trace.WriteLine(line);
                            server.Disconnect();
                            server.Dispose();
                            return line;
                        }
                    }
                    
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return "NOPE";
        }
    }

}
