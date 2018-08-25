using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
using System.Windows;

namespace sensors
{
    class PipeClient
    {
        public string File_name { get; set; }
        private string state;
        public bool isRecording;
        NamedPipeClientStream client;
        StreamReader reader;
        StreamWriter writer;

        public void StartClient()
        {
            state = "WAIT_FOR_FILE";
            isRecording = false;
            client = new NamedPipeClientStream("Pipe");
            client.Connect();
            
           
            reader = new StreamReader(client);
            writer = new StreamWriter(client);

            string input = reader.ReadLine();
            if (input != null || input.Length > 0)
            {
                File_name = input;
            }

        }
        public void Write(string text)
        {
            writer.WriteLine(text);
            writer.Flush();
            client.Close();
            Environment.Exit(1);
        }
    }
}
