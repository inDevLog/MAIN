using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giatri_thamso : MonoBehaviour
{
    public float docao, culy_nghieng, culy_ngang;
    public float speed = 2f;
    public Transform diem_a, diem_b,diem_c;
    void Start()
    {

    }

    // Update is called once per frame
    float thamso(Vector3 rayOrigin, Vector3 rayDir, Vector3 point)
    {
        float distance = Vector3.Distance(rayOrigin, point);
        float angle = Vector3.Angle(rayDir, point - rayOrigin);
        return (distance * Mathf.Sin(angle * Mathf.Deg2Rad));
    }
    void Update()
    {
        diem_c.transform.position = new Vector3(diem_b.transform.position.x, 0, diem_b.transform.position.z);
        Vector3 forward = diem_c.transform.TransformDirection(Vector3.forward) * 100;
        Debug.Log(forward);
        Debug.DrawRay(new Vector3(diem_b.position.x, diem_a.position.y, diem_b.position.z), forward, Color.green);
        //Debug.Log(thamso(diem_c.transform.position, forward, diem_a.position));
    }
}
