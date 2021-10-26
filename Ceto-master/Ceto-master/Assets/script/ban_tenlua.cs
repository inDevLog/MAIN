using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ban_tenlua : MonoBehaviour
{
    // Start is called before the first frame update
    public btn_chuyenchedo ban_duoi;
    public chedo_bandon laydulieu_chedo;
    public GameObject dan_nhieu;
    public Transform vitri_tha;
    public GameObject clone_dannhieu;
    public Transform muctieu;
    Vector3 direction;
    public float speed = 250f;
    public float rotationSpeed = 5f;
    public ParticleSystem khoi;
    public AudioSource tieng_tenlua,tieng_trungdan;
    public GameObject ong_phong;
    public Transform posCurrent;
    public bool ketqua_ban = false;
    public ParticleSystem maybay_chay, maybay_no;
    void Start()    
    {
        ban_duoi = GameObject.FindGameObjectWithTag("TagA").GetComponent<btn_chuyenchedo>();
        laydulieu_chedo = GameObject.FindGameObjectWithTag("bandon").GetComponent<chedo_bandon>();
        if (maybay_chay.isPlaying) maybay_chay.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (laydulieu_chedo.chedo_don == true && laydulieu_chedo.chedo_duoi == false)
        {
            laydulieu_chedo.pointBandon.transform.parent = null;
            muctieu.transform.position = laydulieu_chedo.pointBandon.transform.position;
        }
        else if (laydulieu_chedo.chedo_don == false && laydulieu_chedo.chedo_duoi == true) muctieu.transform.position = ban_duoi.muctieu1_that.transform.position;
        Debug.Log(muctieu.transform.position.x);
        if (khoi.isPlaying) khoi.Stop();
        //if (maybay_no.isPlaying) maybay_no.Stop();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dan_nhieu.SetActive(true);
            clone_dannhieu = Instantiate(dan_nhieu, vitri_tha.position, Quaternion.identity);
            posCurrent.position = clone_dannhieu.transform.position;
            clone_dannhieu.transform.parent = ong_phong.transform;
            clone_dannhieu.transform.localEulerAngles = new Vector3(-90, 0, 0);
            speed = 50;
            if (!tieng_tenlua.isPlaying) tieng_tenlua.Stop();
            tieng_tenlua.Play();
        }
        if (Vector3.Distance(muctieu.position, clone_dannhieu.transform.position) < 50)
        {
            ketqua_ban = true;
            Debug.Log("TRUNG !!");
            speed = 0;
            Destroy(clone_dannhieu);
            maybay_chay.Play();
            if (!maybay_no.isPlaying) maybay_no.Stop();
            maybay_no.Play();
            if (tieng_trungdan.isPlaying) tieng_trungdan.Stop();
            tieng_trungdan.Play();
        }
        if(ketqua_ban == false)
        {
            if (maybay_no.isPlaying) maybay_no.Stop();
            if (maybay_chay.isPlaying) maybay_chay.Stop();
        }
        clone_dannhieu.transform.Translate(Vector3.forward * 500f * Time.deltaTime);
        if (clone_dannhieu.transform.position != posCurrent.position) clone_dannhieu.transform.parent = null;
        direction = muctieu.position - clone_dannhieu.transform.position;
        direction = direction.normalized;
        clone_dannhieu.transform.rotation = Quaternion.Slerp(clone_dannhieu.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

    }
   
}
