using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;

namespace Thesis
{
    class PipeServer
    {


        public void StartServer(string file_name)
        {
            Task.Factory.StartNew(() =>
            {
                bool isWaiting;

                var server = new NamedPipeServerStream("Pipe");
                server.WaitForConnection();
                StreamReader reader = new StreamReader(server);
                StreamWriter writer = new StreamWriter(server);

                writer.WriteLine(file_name);
                writer.Flush();

                isWaiting = true;

                while(isWaiting)
                {
                    string line = reader.ReadLine();
                    if (line != null || line.Length > 0)
                    {
                        Trace.WriteLine(line);
                        isWaiting = false;
                    }
                }

                //server.Close();
                
            });
        }

    }

}
