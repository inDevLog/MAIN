using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ketqua : MonoBehaviour
{
    public btn_chuyenchedo hien_ketqua;
    public mpu6050_connect ngamban;
    void Start()
    {
    hien_ketqua = GameObject.FindGameObjectWithTag("TagA").GetComponent<btn_chuyenchedo>();
    ngamban = GameObject.FindGameObjectWithTag("mpu").GetComponent<mpu6050_connect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ngamban.timer_bamsat > 0.1f)
        {
            hien_ketqua.ogs_culy.text = (Vector3.Distance(hien_ketqua.goc_duoi.transform.localPosition, hien_ketqua.muctieu1_duoi.transform.localPosition) * 1000 / 45).ToString();
            hien_ketqua.ogs_vantoc.text = hien_ketqua.vantoc_mt1_str;
            hien_ketqua.ogs_docao.text = (hien_ketqua.muctieu1_that.transform.position.y).ToString();
            hien_ketqua.ogs_tl_mt.text = (Vector3.Distance(hien_ketqua.goc_duoi.transform.localPosition, hien_ketqua.muctieu1_duoi.transform.localPosition) * 1000 / 45).ToString();
            hien_ketqua.ogs_thamso.text = hien_ketqua.thamso(hien_ketqua.hinhchieu_mt1_that.transform.position, hien_ketqua.forward, hien_ketqua.tauta.transform.position).ToString();

            
        }
    }
}
