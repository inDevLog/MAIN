using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chedo_bandon : MonoBehaviour
{
    public btn_chuyenchedo ban_don;
    public ban_tenlua tenlua_banduoi;
    public Transform huongbay_mt1;
    public Transform pointBandon;
    public bool chedo_duoi = false,chedo_don = false;

    // Start is called before the first frame update
    void Start()
    {
    ban_don = GameObject.FindGameObjectWithTag("TagA").GetComponent<btn_chuyenchedo>();
    tenlua_banduoi = GameObject.FindGameObjectWithTag("banTL").GetComponent<ban_tenlua>();
    }
    // Update is called once per frame
    void Update()
    {
        if(ban_don.kiemtra == false)
        {

            pointBandon.transform.parent = huongbay_mt1.transform;
            pointBandon.transform.localPosition = new Vector3(0, 0, 1500);
            tenlua_banduoi.muctieu.transform.position = ban_don.muctieu1_that.transform.position;
            chedo_don = false;
            chedo_duoi = false;
        }
        huongbay_mt1.transform.position = ban_don.muctieu1_that.transform.position;
        Vector3 forward = huongbay_mt1.TransformDirection(Vector3.forward) * 10000000;
        huongbay_mt1.transform.rotation = Quaternion.Euler(0, ban_don.muctieu1_that.transform.rotation.eulerAngles.y, 0);
        Debug.DrawRay(huongbay_mt1.transform.position, forward, Color.green);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            chedo_don = true;
            chedo_duoi = false;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            chedo_don = false;
            chedo_duoi = true;
        }
    }
}
