using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class link_code : MonoBehaviour
{
    // Start is called before the first frame update
    public btn_chuyenchedo a;
    public Transform[] vitri;
    public int i = 0;
    public GameObject[] waypoints;
    public GameObject maybay_ref;
    public int current = 1;
    public float speed;
    float WPradius = 0.01f;
    public Transform max;
    void Start()
    {
        a = GameObject.FindGameObjectWithTag("TagA").GetComponent<btn_chuyenchedo>();
        current = 1;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(waypoints[current].transform.localPosition);
        speed = a.vantoc_mt1 * 1.05f;
        if (a.kiemtra == false) current = 1;  
        if (a.kiemtra == true) 
        {
            //vitri[i].rotation = Quaternion.Euler(0,0, Random.Range(1f, 2f) * 90);
            if (Vector3.Distance(waypoints[current].transform.localPosition, maybay_ref.transform.localPosition) < WPradius && current < waypoints.Length)
            {
                //vitri[i].rotation = Quaternion.Euler(0, 0, Random.Range(0f, 1f) * 150);
                //Debug.Log("Da den vi tri " + current);
                current += 1;
                if (current >= waypoints.Length)
                {
                    //Debug.Log(current);
                    //Destroy(transform);
                    maybay_ref.transform.localPosition = new Vector3(waypoints[waypoints.Length - 1].transform.localPosition.x, waypoints[waypoints.Length-1].transform.localPosition.y,10000000);
                }
            }
            maybay_ref.transform.localPosition = Vector3.MoveTowards(maybay_ref.transform.localPosition, waypoints[current].transform.localPosition, Time.deltaTime * speed);
            //if (current >= waypoints.Length)
            //    waypoints[waypoints.Length - 1].transform.position = vitri[vitri.Length - 1].localPosition + new Vector3(0, 0, 10000);
        }
    }
    public IEnumerator thoigian()
    {
        i = 1;
        while (i <= 20)
        {
            float vitri_x = Random.Range(-0.5f, 1f) * 300f;
            //float vitri_y = vitri[i].localPosition.y;
            float vitri_y = Random.Range(0.1f, 0.8f) * 300f;
            float vitri_z = vitri[i].localPosition.z;
            vitri[i].localPosition = new Vector3(vitri_x, vitri_y, vitri_z);
            //vitri[i].position = vitri[i-1] + Random.Range(0, 1) * (max - vitri[i-1].position);
            //vitri[i].rotation = Quaternion.Euler(Random.Range(vitri[i - 1].rotation.x + 50, vitri[i - 1].rotation.x - 50),Random.Range(a.huong_mt1+2,a.huong_mt1-2), Random.Range(vitri[i - 1].rotation.z + 50, vitri[i - 1].rotation.z - 50));
            //vitri[i].Translate(0, 0, 90000 * Time.deltaTime, Space.Self);
            //vitri[i].position = new Vector3(vitri[i].position.x + Random.Range(-1000, -2000), Random.Range(90, 900), vitri[i].position.z);
            yield return new WaitForSeconds(0.01f);
            creatRandom();
            i++;
        }
    }
    public void creatRandom()
    {

        //vitri[i].position = new Vector3(Random.Range(vitri[i - 1].position.x - 1000, vitri[i - 1].position.x + 1000), Random.Range(vitri[i - 1].position.y - 1000, vitri[i - 1].position.y + 1000), Random.Range(vitri[i - 1].position.z + 500, vitri[i - 1].position.z + 1000));
        //Debug.Log(transform.position);
        waypoints[i].transform.localPosition = vitri[i].localPosition;
        //vitri.position = transform.position;
        //vitri[i].transform.position = transform.position;
    }
    public void nhap()
    {
        vitri[0].position = new Vector3(a.culy_mt1 * Mathf.Sin(a.gocman_mt1 * Mathf.Deg2Rad), a.docao_mt1, a.culy_mt1 * Mathf.Cos(a.gocman_mt1 * Mathf.Deg2Rad));
        vitri[0].rotation = Quaternion.Euler(0, a.huong_mt1, 0);
        waypoints[0].transform.rotation = Quaternion.Euler(0, a.huong_mt1, 0);
        StartCoroutine("thoigian");
        maybay_ref.transform.localPosition = max.transform.localPosition;
        waypoints[0].transform.position = vitri[0].transform.position;
    }
    
}

