using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



public class n : MonoBehaviour
{
    static int rec;
    int[] movmnt;
    int[] rot;
    char[][] a;
    String dataString;
    float speed;
    float rotspeed = 1f;
    string returnData;
    public Rigidbody rg;
    Thread m_Thread;
    UdpClient m_Client;
    String[] strlist;
    float[] dataList;
    public float gx, gy, gz;
    public float az;

    public float angles;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rec = 0;

        print("Starting Thread");
        m_Thread = new Thread(new ThreadStart(ReceiveData));
        m_Thread.IsBackground = true;
        m_Thread.Start();
        udpSend();
    }


    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            rg.velocity = new Vector3(0, 0, 0);
            //print("BUTTON");

        }
        else
        {
            rg.velocity = new Vector3(-az, 0, 0);
        }

        angles = (float)Math.Asin(gy) * Mathf.Rad2Deg;
        // print(angles);
        // angles += Time.deltaTime * rotspeed;
        transform.eulerAngles = new Vector3(0, 0, -angles);
    }

    void ReceiveData()
    {

        try
        {

            m_Client = new UdpClient(8888);
            // m_Client.EnableBroadcast = true;

            print("Start recieving...");
            IPEndPoint hostIP = new IPEndPoint(IPAddress.Any, 0);
            print(hostIP);
            //returnData = "Random";
            while (true)
            {
                print("In While loop");
                try
                {
                    print("Test1");
                    byte[] data = m_Client.Receive(ref hostIP);
                    print("Test3");
                    returnData = Encoding.UTF8.GetString(data);
                    
                    print("Received: " + returnData);
                    print("Test2");
                    dataList = Array.ConvertAll(returnData.Trim().Split(','), float.Parse);
                    // strlist = dataString.Split(',');
                   /* gx = (float)Math.Round(dataList[0], 1);
                    gy = dataList[1];

                    if (gy < -1) gy = -1;
                    else if (gy > 1) gy = 1;*/

                    gz = (float)Math.Round(dataList[0], 1) / 2;
                    // ax = (float)Math.Round(dataList[3], 1);
                    // ay = (float)Math.Round(dataList[4], 1);
                    az = (float)Math.Round(dataList[1], 1) / 10;
                }
                catch(Exception a)
                {
                    print(a);
                }
                // string returnData = Encoding.ASCII.GetString(data);
               


            }

        }
        catch (Exception e)
        {
            print(e);
            udpSend();
            // OnApplicationQuit();
        }
    }

    public float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }

    private void OnApplicationQuit()
    {
        if (m_Thread != null)
        {
            m_Thread.Abort();
        }

        if (m_Client != null)
        {
            m_Client.Close();
        }
    }

    void udpSend()
    {
        var IP = IPAddress.Parse("192.168.43.78");

        int port = 8888;
        print("Sending UDP");

        var udpClient1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        var sendEndPoint = new IPEndPoint(IP, port);


        try
        {
            //Sends a message to the host to which you have connected.
            byte[] sendBytes = Encoding.ASCII.GetBytes("send");
            udpClient1.SendTo(sendBytes, sendEndPoint);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }
}
