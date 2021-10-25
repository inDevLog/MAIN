using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class docgiatri : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject a,b,c,goc_tren,goc_duoi;
    void Start()
    {
        //----------------- Set vị trí mục tiêu trên Radar_tren

        // 
        b.transform.localPosition = goc_tren.transform.localPosition + new Vector3(a.transform.position.x * 45 / 1000, 0, 0);

        //----------------- Set vị trí mục tiêu trên radar_duoi

        //
        //c.transform.localPosition = goc_duoi.transform.localPosition + new Vector3(a.transform.position.x * 45 / 1000, a.transform.position.y * 45 / 1000, 0);
    }

    // Update is called once per frame
    void Update()
    {

       
        // góc quay của mục tiêu
        //b.transform.localRotation = a.transform.rotation;


        int goc_sin_cos = 60;
        float giatri_y = a.transform.position.x * 45 / 1000 * Mathf.Sin(goc_sin_cos*Mathf.Deg2Rad);
        //float giatri_y = a.transform.position.x * 45 / 1000;
        float giatri_x = a.transform.position.x * 45 / 1000 * Mathf.Cos(goc_sin_cos*Mathf.Deg2Rad);
        Debug.Log(giatri_y + "   " +giatri_x );
        Vector3 toado_goc = goc_duoi.transform.localPosition +  new Vector3(giatri_x, giatri_y,0);
        c.transform.localPosition = toado_goc;
        //Debug.Log(toado_goc);
    }



    float Khoangcach(Vector3 rayOrigin, Vector3 rayDir, Vector3 point)
    {
        float distance = Vector3.Distance(rayOrigin, point);
        float angle = Vector3.Angle(rayDir, point - rayOrigin);
        return (distance * Mathf.Sin(angle * Mathf.Deg2Rad));
        //return angle;
    }
}
