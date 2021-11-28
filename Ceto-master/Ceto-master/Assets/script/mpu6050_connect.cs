using UnityEngine;
using System.Collections;
using System;
using System.IO.Ports;
public class mpu6050_connect : MonoBehaviour
{
    public GameObject den_tinhieu;
    public float timer_bamsat =0 ;
    SerialPort stream;
    public Renderer tinhieu_mausac;
    public AudioSource tieng_beep;
    public GameObject target; // is the gameobject to 
    public Transform duong_ngam;
    // Increase the speed/influence rotation
    public float factor = 7;
    // SELECT YOUR COM PORT AND BAUDRATE
    string port = "COM6";
    int baudrate = 9600;
    int readTimeout = 25;

    void Start()
    {
        tinhieu_mausac = den_tinhieu.GetComponent<Renderer>();
        tinhieu_mausac.material.SetColor("_Color", Color.black);
        if (tieng_beep.isPlaying) tieng_beep.Stop();
        // open port. Be shure in unity edit > project settings > player is NET2.0 and not NET2.0Subset
        stream = new SerialPort("\\\\.\\" + port, baudrate);

        try
        {
            stream.ReadTimeout = readTimeout;
        }
        catch (System.IO.IOException ioe)
        {
            Debug.Log("IOException: " + ioe.Message);
        }

        stream.Open();
    }

    void Update()
    {

        // DUONG NGAM
        Vector3 forward = duong_ngam.transform.transform.up * 10000000;
        Debug.DrawRay(duong_ngam.transform.position, forward, Color.green);
        Ray ngam = new Ray(transform.position,forward);
        RaycastHit hit;
        if (Physics.Raycast(ngam, out hit))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.name == "F 15 C")
            {
                timer_bamsat += Time.deltaTime;
                if (!tieng_beep.isPlaying) tieng_beep.Play();
                tinhieu_mausac.material.SetColor("_Color", Color.green);
            }
        }
        else
        {
            timer_bamsat = 0;
            if (tieng_beep.isPlaying) tieng_beep.Stop();
            tinhieu_mausac.material.SetColor("_Color", Color.black);

        }

        ////////
        ///


        string dataString = "null received";

        if (stream.IsOpen)
        {
            try
            {
                dataString = stream.ReadLine();
                Debug.Log("RCV_ : " + dataString);
            }
            catch (System.IO.IOException ioe)
            {
                Debug.Log("IOException: " + ioe.Message);
            }

        }
        else
            dataString = "NOT OPEN";
        Debug.Log("RCV_ : " + dataString);   
    }
}