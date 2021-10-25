using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heat_flares : MonoBehaviour
{
    public GameObject[] clone_phongnhieu;
    public GameObject[] orig_clone;
    public GameObject dan_nhieu, clone_dannhieu;
    public GameObject tonghop_dannhieu;
    public Transform vitri_tha;
    public ParticleSystem khoi;
    public int i = 0;
    public Transform quay_dannhieu;
    public float speed;
    float rotationSpeed = 6f;
    Vector3 direction;
    public int dem =0;
    public btn_chuyenchedo chedo_phongnhieu;
    public bool thoigian_batdauphong;
    // Start is called before the first frame update
    void Start()
    {
        thoigian_batdauphong = false;
        dem = 0;
        if (khoi.isPlaying) khoi.Stop();
        chedo_phongnhieu = GameObject.FindGameObjectWithTag("TagA").GetComponent<btn_chuyenchedo>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform con in chedo_phongnhieu.muctieu1_that.transform)
        {
            foreach (Transform grandchild in con)
            {
                if (grandchild.transform.childCount > 0)
                {
                    if (con.transform.localPosition.x < 0) ham_quay(con);
                    else if (con.transform.localPosition.x > 0) ham_quay2(con);
                }
            }
        }
        if ((int)chedo_phongnhieu.thoigian_phongnhieu % 8 == 0 && chedo_phongnhieu.thoigian_phongnhieu > 0)
        {
            foreach (Transform child in chedo_phongnhieu.muctieu1_that.transform)
            {
                //Debug.Log(dem);
                foreach (Transform grandchild in child)
                {
                    Destroy(grandchild.gameObject);
                    dem++;
                }
            }
            thoigian_batdauphong = true;
        }

        ////////
        if (thoigian_batdauphong == true)
        {
            thoigian_batdauphong = false;
            //thoigian_batdauphong = true;
            //dem = 0;
            //tonghop_dannhieu.transform.localPosition = new Vector3(0f, 0f, 0f);

            StartCoroutine("phongnhieu");
        }
        
        //  clone_dannhieu.transform.Translate(0, 0, -5f * Time.deltaTime);
        //if (i > 0)

        ////tonghop_dannhieu.transform.Translate(-Vector3.up * speed * Time.deltaTime);
        //clone_phongnhieu[i].transform.Translate(-Vector3.up  * speed * Time.deltaTime, Space.Self);
        //direction = quay_dannhieu.position - tonghop_dannhieu.transform.position;
        //direction = direction.normalized;
        //tonghop_dannhieu.transform.rotation = Quaternion.Slerp(tonghop_dannhieu.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
    }
    public IEnumerator phongnhieu()
    {
        i = 0;
        while(i < 15)
        {
            yield return new WaitForSeconds(0f);
            clone_dannhieu = Instantiate(dan_nhieu,clone_phongnhieu[i].transform.localPosition, clone_phongnhieu[i].transform.localRotation);
            clone_phongnhieu[i].transform.localPosition = orig_clone[i].transform.position;
            clone_dannhieu.transform.parent = clone_phongnhieu[i].transform;
            clone_dannhieu.transform.localPosition = new Vector3(0, 0, 0);
            //clone_phongnhieu[i].transform.parent = tonghop_dannhieu.transform;
            //clone_phongnhieu[i].transform.Translate(0,speed * Time.deltaTime,0);
            i++;
        }
    }
    //public void phongnhieu(int i)
    //{
    //    for (i = 0; i < 10; i++)
    //    {
    //        clone_dannhieu = Instantiate(dan_nhieu, new Vector3(transform.localPosition.x, transform.localPosition.y, 10 * (i + 1)), vitri_tha.rotation);
    //        clone_dannhieu.transform.Translate(0, 0, -5f * Time.deltaTime);
    //    }
        
    //}
    public void ham_quay(Transform a)
    {
        a.Translate(Random.Range(-200f,200f) * Time.deltaTime,0, 0);
        //Vector3 dir = quay_dannhieu.position - a.position;
        //dir = dir.normalized;
        //a.rotation = Quaternion.Slerp(a.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
    }
    public void ham_quay2(Transform a)
    {
        a.Translate(Random.Range(-200f,200f) * Time.deltaTime,0,0);
        //Vector3 dir = quay_dannhieu.localPosition - a.localPosition;
        //dir = dir.normalized;
        //a.localRotation = Quaternion.Slerp(a.localRotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
    }
}
