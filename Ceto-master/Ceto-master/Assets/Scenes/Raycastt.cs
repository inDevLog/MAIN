using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycastt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10000000;
        Debug.DrawRay(transform.position, forward, Color.green);
        Ray ngam = new Ray(transform.position, forward);
        RaycastHit hit;
        if (Physics.Raycast(ngam, out hit)) Debug.Log(" BÁM SÁT !!!");
        else Debug.Log("CHƯA BÁM SÁT !!");


    }
}
