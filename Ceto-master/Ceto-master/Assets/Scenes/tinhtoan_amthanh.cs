using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tinhtoan_amthanh : MonoBehaviour
{
   
    void Start()
    {
        //GetRandomVector3Between(a.position,b.position);
        // c.position = GetRandomVector3Between(a.position, b.position);
        //z = GetRandomHealth();

    }

    // Update is called once per fram
   

    void Update()
    {
        transform.Translate(0, 0, 5f * Time.deltaTime);
    }
}
