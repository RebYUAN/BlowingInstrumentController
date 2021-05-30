using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Text;
using UnityEngine.UI;

public class SocketClient : MonoBehaviour
{
    private Socket tcpClient;
    private string serverIP = "192.168.4.1";//这个ip用自己电脑ip
    private int serverPort = 23;
    public Text text;
    public static float pressure;
    private string cur="";
    //public static float p;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("开始运行");
        text.text = "开始运行";
        //1.创建一个Socket
        tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //2.建立连接请求
        IPAddress ipaddress = IPAddress.Parse(serverIP);
        EndPoint endPoint = new IPEndPoint(ipaddress, serverPort);

        tcpClient.Connect(endPoint);
        Debug.Log("连接成功");
        text.text = "连接成功";


        ////发送消息
        //string message2 = "Client Say To Server Hello";
        //tcpClient.Send(Encoding.UTF8.GetBytes(message2));
        //Debug.Log("客户端向服务器发送消息" + message2);

    }

    // Update is called once per frame
    void Update()
    {
        //3.接受/发送消息
        byte[] data = new byte[1024*6];
        int length = tcpClient.Receive(data);
        if (length != 0)
        {
            //Debug.Log(length);
            var message = Encoding.UTF8.GetString(data, 0, length);
            //Debug.Log(message);
            for(int i = 0; i < message.Length; i++)
            {
                if (message[i] != '\n')
                {
                    cur += message[i];
                }
                else
                {
                    //Debug.Log(cur);
                    text.text = cur;
                    pressure = float.Parse(cur)-99750;
                    cur = "";
                }
            }
            
            //pressure.Enqueue(message);
            //Debug.Log('\r');
            //Debug.Log(pressure.Dequeue());
        }
        
        //p = 0.00087336014 * message; - 0.006780956;
        //if (p > 1) p = 1;
        //if (p < 0) p = 0;
        //if(message != "\r")
        //{
        //    Debug.Log(message);
        //    
        //    //p = float.Parse(message);
        //}

    }



}
