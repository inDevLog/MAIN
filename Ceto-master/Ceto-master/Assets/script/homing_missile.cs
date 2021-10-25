using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homing_missile : MonoBehaviour
{
    public btn_chuyenchedo a;
    // Start is called before the first frame update
    [SerializeField]
    public Transform muctieu;
    Vector3 direction;
    public float speed ;
    float rotationSpeed = 0.3f;
    void Start()
    {
        a = GameObject.FindGameObjectWithTag("TagA").GetComponent<btn_chuyenchedo>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = a.vantoc_mt1;
        if (a.kiemtra == true)
        {
            //transform.position = Vector3.MoveTowards(transform.position,muctieu.position, Time.deltaTime * speed);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            direction = muctieu.position - transform.position;
            direction = direction.normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            //Debug.Log(Vector3.Distance(muctieu.position, transform.position));
            //if (Vector3.Distance(muctieu.position, transform.position) < 1) transform.rotation = Quaternion.Euler(0, 0, Random.Range(0.7f, 1f) * 150); 
        }
    }
}
