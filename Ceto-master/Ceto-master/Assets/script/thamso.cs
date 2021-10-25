using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thamso : MonoBehaviour
{
    // Start is called before the first frame update
    public float docao, culy_nghieng, culy_ngang;
    public float speed = 2f;
    public Transform diem_a, diem_b;
    void Start()
    {

    }

    // Update is called once per frame
    float Khoangcach(Vector3 rayOrigin, Vector3 rayDir, Vector3 point)
    {
        float distance = Vector3.Distance(rayOrigin, point);
        float angle = Vector3.Angle(rayDir, point - rayOrigin);
        //return (distance * Mathf.Sin(angle * Mathf.Deg2Rad));
        return angle;
    }
    void Update()
    {
        Vector3 forward = diem_b.transform.TransformDirection(Vector3.forward) * 100;
        Vector3 line = diem_b.position - diem_a.position;
        Debug.DrawRay(diem_b.position, line, Color.green);
        //diem_b.transform.Translate(Vector3.forward * Time.deltaTime);
        //docao = diem_a.transform.position.y - diem_b.transform.position.y;
        //culy_nghieng = Vector3.Distance(diem_a.position, diem_b.position);
        //culy_ngang = Vector3.Distance(diem_a.position, new Vector3(diem_b.position.x, diem_a.position.y, diem_b.position.z));
        //float giatri_thamso = Khoangcach(diem_b.position, forward, diem_a.position);
        //Debug.Log(giatri_thamso);
        //Debug.Log(" Toa do hinh chieu " + diem_b.position.x + " " +  diem_a.position.y + " " + diem_b.position.z);
    }
}
