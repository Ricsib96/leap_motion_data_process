using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using UnityEngine;

public class PipeClient : MonoBehaviour {


    public string File_name { get; set; }
    NamedPipeClientStream client;
    StreamReader reader;
    StreamWriter writer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartClient()
    {
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
}
