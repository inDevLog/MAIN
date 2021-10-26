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
    float acc_normalizer_factor = 0.00025f;
    float gyro_normalizer_factor = 1.0f / 32768.0f;   // 32768 is max value captured during test on imu

    float curr_angle_x = 0;
    float curr_angle_y = 0;
    float curr_angle_z = 0;

    float curr_offset_x = 0;
    float curr_offset_y = 0;
    float curr_offset_z = 0;

    // Increase the speed/influence rotation
    public float factor = 7;


    public bool enableRotation;
    public bool enableTranslation;

    // SELECT YOUR COM PORT AND BAUDRATE
    string port = "COM5";
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

        if (!dataString.Equals("NOT OPEN"))
        {
            // recived string is  like  "accx;accy;accz;gyrox;gyroy;gyroz"
            char splitChar = ';';
            string[] dataRaw = dataString.Split(splitChar);

            // normalized accelerometer values
            float ax = Int32.Parse(dataRaw[0]) * acc_normalizer_factor;
            float ay = Int32.Parse(dataRaw[1]) * acc_normalizer_factor;
            float az = Int32.Parse(dataRaw[2]) * acc_normalizer_factor;

            // normalized gyrocope values
            float gx = Int32.Parse(dataRaw[3]) * gyro_normalizer_factor;
            float gy = Int32.Parse(dataRaw[4]) * gyro_normalizer_factor;
            float gz = Int32.Parse(dataRaw[5]) * gyro_normalizer_factor;

            // prevent 
            if (Mathf.Abs(ax) - 1 < 0) ax = 0;
            if (Mathf.Abs(ay) - 1 < 0) ay = 0;
            if (Mathf.Abs(az) - 1 < 0) az = 0;


            curr_offset_x += ax;
            curr_offset_y += ay;
            curr_offset_z += 0; // The IMU module have value of z axis of 16600 caused by gravity


            // prevent little noise effect
            if (Mathf.Abs(gx) < 0.025f) gx = 0f;
            if (Mathf.Abs(gy) < 0.025f) gy = 0f;
            if (Mathf.Abs(gz) < 0.025f) gz = 0f;

            curr_angle_x += gx;
            curr_angle_y += gy;
            curr_angle_z += gz;

            if (enableTranslation) target.transform.position = new Vector3(curr_offset_x, curr_offset_z, curr_offset_y);
            if (enableRotation) target.transform.rotation = Quaternion.Euler(curr_angle_x * factor, -curr_angle_z * factor, 0);

        }
    }

}