using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
public class ArduinoTest : MonoBehaviour
{
    public SerialPort stream;
    // Start is called before the first frame update
    void Start()
    {
        stream = new SerialPort("COM4", 115200);
        stream.ReadTimeout = 50;
        stream.Open();
        WriteToArduino("PING");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WriteToArduino(string message)
    {
        stream.WriteLine(message);
        stream.BaseStream.Flush();
    }
}
