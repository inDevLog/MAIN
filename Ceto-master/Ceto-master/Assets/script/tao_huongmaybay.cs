using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tao_huongmaybay : MonoBehaviour
{
    public Transform[] vitri;
    public int i = 0;
    public GameObject[] waypoints;
    public GameObject maybay_ref;
    public int current = 0;
    public float speed;
    float WPradius = 1;
    // Start is called before the first frame update
    void Start()
    {
        // vitri.position = transform.position;
        StartCoroutine("thoigian");
        vitri[0].position = new Vector3(-1,2,-3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(waypoints[current].transform.position, maybay_ref.transform.position) < WPradius)
        {
            current += 1;
            Debug.Log(current);
                
            if (current >= waypoints.Length)
            {
                Debug.Log(current);
                //Destroy(transform);
            }
        }
        maybay_ref.transform.position = Vector3.MoveTowards(maybay_ref.transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }
    public IEnumerator thoigian()
    {
        i = 1;
        while (i <= 4)
        {
            yield return new WaitForSeconds(0.1f);
            creatRandom();
            i++;
        }
    }
    public void creatRandom()
    {
        vitri[i].position = new Vector3(Random.Range(vitri[i-1].position.x - 20, vitri[i - 1].position.x + 20), Random.Range(vitri[i - 1].position.y - 20, vitri[i - 1].position.y + 20), Random.Range(vitri[i - 1].position.z + 50, vitri[i - 1].position.z + 100));
        //Debug.Log(transform.position);
        waypoints[i].transform.position = vitri[i].position;
        //vitri.position = transform.position;
        //vitri[i].transform.position = transform.position;
    }
    public void nhap()
    {
        StartCoroutine("thoigian");
        current = 0;
    }
}
