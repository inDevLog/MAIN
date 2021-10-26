using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class btn_chuyenchedo: MonoBehaviour
{
    public TMP_Text hientai_culy, hientai_vantoc, hientai_docao, hientai_culyTL_MT, hientai_thamso;
    public TMP_Text ogs_culy, ogs_vantoc, ogs_docao, ogs_tl_mt, ogs_thamso;
    public TMP_Text phong_culy, phong_vantoc, phong_docao, phong_tl_mt, phong_thamso;
    public TMP_Text trung_culy, trung_vantoc, trung_docao, trung_tl_mt, trung_thamso;
    public AudioSource audioData;
    public Transform to, diem_batdau;
    public float culy_old = 0, culy_hientai, culy_updated;
    //DOTWEEN
    public Text thongso1, tinhhuong1, thongso2, tinhhuong2;
    //
    public Dropdown somuctieu;
    public InputField huong_mt1_input, vantoc_mt1_input, gocman_mt1_input, docao_mt1_input, culy_mt1_input;
    public InputField huong_mt2_input, vantoc_mt2_input, gocman_mt2_input, docao_mt2_input, culy_mt2_input;
    public InputField huong_mt3_input, vantoc_mt3_input, gocman_mt3_input, docao_mt3_input, culy_mt3_input;
    public InputField huong_mt4_input, vantoc_mt4_input, gocman_mt4_input, docao_mt4_input, culy_mt4_input;
    ///
    /// 
    public string huong_mt1_str, vantoc_mt1_str, gocman_mt1_str, docao_mt1_str, culy_mt1_str,duongbay_mt1_str;
    public string huong_mt2_str, vantoc_mt2_str, gocman_mt2_str, docao_mt2_str, culy_mt2_str,duongbay_mt2_str;
    public string huong_mt3_str, vantoc_mt3_str, gocman_mt3_str, docao_mt3_str, culy_mt3_str,duongbay_mt3_str;
    public string huong_mt4_str, vantoc_mt4_str, gocman_mt4_str, docao_mt4_str, culy_mt4_str,duongbay_mt4_str;
    /// <summary>
    /// 
    /// </summary>
    public GameObject muctieu1_tren, muctieu1_duoi;
    public GameObject muctieu2_tren, muctieu2_duoi;
    public GameObject muctieu3_tren, muctieu3_duoi;
    public GameObject muctieu4_tren, muctieu4_duoi;
    public GameObject muctieu1_that;
    /// <summary>
    /// 
    /// </summary>
    public GameObject goc_tren, goc_duoi;
    /// <summary>
    /// 
    /// </summary>
    public int huong_mt1, vantoc_mt1, gocman_mt1, docao_mt1, culy_mt1;
    public int huong_mt2, vantoc_mt2, gocman_mt2, docao_mt2, culy_mt2;
    public int huong_mt3, vantoc_mt3, gocman_mt3, docao_mt3, culy_mt3;
    public int huong_mt4, vantoc_mt4, gocman_mt4, docao_mt4, culy_mt4;
    /// <summary>
    /// 
    /// </summary>
    public Dropdown kieuloai_mt1, kieuloai_mt2, kieuloai_mt3, kieuloai_mt4;
    public Dropdown duongbay_mt1, duongbay_mt2, duongbay_mt3, duongbay_mt4;
    // Start is called before the first frame update
    public GameObject canvas_ratinhhuong, canvas_thongso;
    public GameObject canvas_mt1, canvas_mt2, canvas_mt3, canvas_mt4;
    public int culygia_radar = 45;
    public GameObject tauta;
    public Camera cam;
    public LayerMask layer1, layer2;
    public bool kiemtra = false;
    public Transform hinhchieu_mt1_that;
    public Vector3 dir_hinhchieu_mt1_that;
    public homing_missile code_thaydoi;
    public heat_flares mode_phongnhieu;
    public ban_tenlua banTenlua;
    public float thoigian_phongnhieu = 0;
    public Vector3 forward;
    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        code_thaydoi = GameObject.FindGameObjectWithTag("Muctieu").GetComponent<homing_missile>();
        mode_phongnhieu = GameObject.FindGameObjectWithTag("phongnhieu").GetComponent<heat_flares>();
        banTenlua = GameObject.FindGameObjectWithTag("banTL").GetComponent<ban_tenlua>();
    }
    public void ratinhhuong()
    {
        canvas_ratinhhuong.SetActive(true);
        canvas_thongso.SetActive(false);
        //cam.cullingMask = layer1;
        thongso1.DOColor(new Color(0.7f, 0.7f, 0.7f), 0.1f);
        tinhhuong1.DOColor(new Color(0, 0.8f, 0), 0.1f);
        
    }
    public void thoat()
    {
        Application.Quit();
    }
    public void thongso()
    {
        canvas_ratinhhuong.SetActive(false);
        canvas_thongso.SetActive(true);
        //cam.cullingMask = layer2;
        tinhhuong2.DOColor(new Color(0.7f, 0.7f, 0.7f), 0.1f);
        thongso2.DOColor(new Color(0, 0.8f, 0), 0.1f);
    }
    public void laydulieu()
    {
        /// NEN DUA VAO HAM CON ??
        /// 
        ///
        // ---------------------MUC TIEU 1---------------
        huong_mt1_str = huong_mt1_input.text.ToString();
        vantoc_mt1_str = vantoc_mt1_input.text.ToString();
        gocman_mt1_str = gocman_mt1_input.text.ToString();
        docao_mt1_str = docao_mt1_input.text.ToString();
        culy_mt1_str = culy_mt1_input.text.ToString();
        duongbay_mt1_str = duongbay_mt1.options[duongbay_mt1.value].text;
        //--------------//
        huong_mt1 = int.Parse(huong_mt1_str);
        vantoc_mt1 = int.Parse(vantoc_mt1_str);
        gocman_mt1 = int.Parse(gocman_mt1_str);
        docao_mt1 = int.Parse(docao_mt1_str);
        culy_mt1 = int.Parse(culy_mt1_str);
        //------------//
        //// muctieu tren
        if (gocman_mt1 < 0 || gocman_mt1 > 180) muctieu1_tren.transform.localPosition = goc_tren.transform.localPosition + new Vector3(-culy_mt1 * culygia_radar / 1000, docao_mt1 * culygia_radar / 1000, 0);
        else muctieu1_tren.transform.localPosition = goc_tren.transform.localPosition + new Vector3(culy_mt1 * culygia_radar / 1000, docao_mt1 * culygia_radar / 1000, 0);
        //muctieu1_tren.transform.Rotate(0,0,huong);

        // muctieu duoi
        float muctieu1_x = culy_mt1 * Mathf.Cos(gocman_mt1 * Mathf.Deg2Rad) * culygia_radar / 1000;
        //Debug.Log(muctieu1_x);
        float muctieu1_y = culy_mt1 * Mathf.Sin(gocman_mt1 * Mathf.Deg2Rad) * culygia_radar / 1000;
        //Debug.Log(muctieu1_y);
        muctieu1_duoi.transform.localPosition = goc_duoi.transform.localPosition + new Vector3(muctieu1_y, muctieu1_x, 0);
        //muctieu1_duoi.transform.localPosition = goc_duoi.transform.localPosition ;

        // huong bay muc tieu
        muctieu1_duoi.transform.rotation = Quaternion.Euler(0, 0, -huong_mt1);
        kiemtra = false;
        taomuctieu();
        muctieu1_that.transform.rotation = Quaternion.Euler(0, huong_mt1, 0);
        culy_old = Vector3.Distance(goc_duoi.transform.position, muctieu1_duoi.transform.position) * 1000 / culygia_radar;
        to.transform.localPosition = muctieu1_tren.transform.localPosition;
        muctieu1_duoi.SetActive(true);
        ////----------------------------------------------
        ///
        //if (duongbay_mt1.options[duongbay_mt1.value].text == "MB BAY BẰNG")
        //muctieu1_tren.transform.rotation = Quaternion.Euler(0, 0, 90);
        {
            if (gocman_mt1 < 180 && huong_mt1 < 180) muctieu1_tren.transform.rotation = Quaternion.Euler(0, 0, -90);
            else if (gocman_mt1 > 180 && huong_mt1 > 180) muctieu1_tren.transform.rotation = Quaternion.Euler(0, 0, 90);
            else if (gocman_mt1 < 180 && huong_mt1 > 180) muctieu1_tren.transform.rotation = Quaternion.Euler(0, 0, 90);
            else if (gocman_mt1 > 180 && huong_mt1 < 180) muctieu1_tren.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        hinhchieu_mt1_that.transform.position = new Vector3(muctieu1_that.transform.position.x, 0, muctieu1_that.transform.position.z);
        hinhchieu_mt1_that.transform.rotation = Quaternion.Euler(0, muctieu1_that.transform.rotation.eulerAngles.y, 0);
        thoigian_phongnhieu = 0;
        banTenlua.ketqua_ban = false;
    }
    public void batdautap()
    {
        kiemtra = true;
        audioData.Play();
        float volumeAmthanh = 1 + (0 - 1) * (Vector3.Distance(goc_duoi.transform.position, muctieu1_duoi.transform.position) / 7000);
        audioData.DOFade(volumeAmthanh, 0.5f);
    }
    void Update()
    {
        hinhchieu_mt1_that.transform.position = new Vector3(muctieu1_that.transform.position.x, 0, muctieu1_that.transform.position.z); 
        forward = hinhchieu_mt1_that.TransformDirection(Vector3.forward) * 100;
        hinhchieu_mt1_that.transform.rotation = Quaternion.Euler(0, muctieu1_that.transform.rotation.eulerAngles.y, 0);
        Debug.DrawRay(hinhchieu_mt1_that.transform.position, forward, Color.green);
        //Debug.Log("Tham so !!!" + thamso(hinhchieu_mt1_that.transform.position, forward, tauta.transform.position));
        //float hientai_culy_float = Vector3.Distance(goc_duoi.transform.localPosition, muctieu1_duoi.transform.localPosition);
        //if (Vector3.Distance(goc_duoi.transform.localPosition, muctieu1_duoi.transform.localPosition) > 315.0f) muctieu1_duoi.SetActive(false); 
        if (somuctieu.options[somuctieu.value].text == "1")
        {

            //float culy_updated = Vector3.Distance(goc_duoi.transform.localPosition, muctieu1_duoi.transform.localPosition) * 1000 / 45 - culy_old;
            //if(culy_updated < 0 )   
            canvas_mt1.SetActive(true);
            canvas_mt2.SetActive(false);
            canvas_mt3.SetActive(false);
            canvas_mt4.SetActive(false);
            //move_mt1();
            if (kiemtra == true)
            {
               
                culy_hientai = Vector3.Distance(goc_duoi.transform.position, muctieu1_duoi.transform.position) * 1000 / culygia_radar;
                culy_updated = culy_hientai - culy_old;
               
                float vantoc_canthiet = (culy_mt1 * culygia_radar / 1000) / (culy_mt1 / vantoc_mt1);
                muctieu1_duoi.transform.Translate(0, vantoc_canthiet * Time.deltaTime, 0, Space.Self);
                if (Vector3.Distance(goc_duoi.transform.localPosition, muctieu1_duoi.transform.localPosition) > 315.0f) muctieu1_duoi.SetActive(false);
                //Debug.Log(Vector3.Distance(goc_duoi.transform.position, muctieu1_duoi.transform.position) * 1000/culygia_radar + " thoi gian " + Time.time);

                // LUU Ý !!!!
                //muctieu1_tren.transform.localPosition = goc_tren.transform.localPosition + new Vector3((Vector3.Distance(muctieu1_duoi.transform.position, goc_duoi.transform.position)), docao_mt1 * 45 / 1000, 0);
                if(muctieu1_tren.transform.localPosition.x < goc_tren.transform.localPosition.x)
                {
                    muctieu1_tren.transform.localPosition = goc_tren.transform.localPosition + new Vector3(-(Vector3.Distance(muctieu1_duoi.transform.position, goc_duoi.transform.position)), muctieu1_that.transform.position.y * 45 / 1000, 0);
                }
                else
                    muctieu1_tren.transform.localPosition = goc_tren.transform.localPosition + new Vector3((Vector3.Distance(muctieu1_duoi.transform.position, goc_duoi.transform.position)), muctieu1_that.transform.position.y * 45 / 1000, 0);
                if (duongbay_mt1_str == "MB BAY BẰNG")
                {   
                    if (culy_updated <= 0 && gocman_mt1 < 180) muctieu1_tren.transform.rotation = Quaternion.Euler(0, 0, 90);
                    else if (culy_updated <= 0 && gocman_mt1 > 180) muctieu1_tren.transform.rotation = Quaternion.Euler(0, 0, -90);
                    else if (culy_updated > 0 && gocman_mt1 < 180) muctieu1_tren.transform.rotation = Quaternion.Euler(0, 0, -90);
                    else if (culy_updated > 0 && gocman_mt1 > 180) muctieu1_tren.transform.rotation = Quaternion.Euler(0, 0, 90);


                    else muctieu1_tren.transform.rotation = Quaternion.Euler(0, 0, -90);
                    if(banTenlua.ketqua_ban == false)   muctieu1_that.transform.Translate(0, 0, vantoc_mt1 * Time.deltaTime, Space.Self);
                    else if(banTenlua.ketqua_ban == true)
                    {
                        muctieu1_that.transform.Translate(0, 0, 0, Space.Self);
                        muctieu1_that.transform.rotation = Quaternion.Slerp(muctieu1_that.transform.rotation, Quaternion.EulerAngles(45,0,0), 2f * Time.deltaTime);
                        muctieu1_that.transform.Translate(Vector3.forward * 50f * Time.deltaTime);
                        if (muctieu1_that.transform.position.y == 0) Destroy(muctieu1_that);
                    }
                    code_thaydoi.enabled = false;
                    mode_phongnhieu.enabled = false;
                    //Debug.Log(Vector3.Distance(new Vector3(muctieu1_that.transform.position.x,0,muctieu1_that.transform.position.z), tauta.transform.position) + "   " + Vector3.Distance(goc_duoi.transform.position, muctieu1_duoi.transform.position) * 1000 / culygia_radar);

                }
                else if(duongbay_mt1_str == "THAM SỐ THAY ĐỔI")
                {
                    mode_phongnhieu.enabled = false;
                    code_thaydoi.enabled = true;
                    muctieu1_duoi.transform.rotation = Quaternion.Euler(0, 0, -code_thaydoi.transform.rotation.eulerAngles.y);
                    if (culy_updated <= 0 && gocman_mt1 > 180) muctieu1_tren.transform.rotation = Quaternion.Euler(0, 0, -(90 + code_thaydoi.transform.rotation.eulerAngles.x));
                    else if(culy_updated > 0 && gocman_mt1 > 180) muctieu1_tren.transform.rotation = Quaternion.Euler(0, 0, (90 + code_thaydoi.transform.rotation.eulerAngles.x));
                    else if(culy_updated <=0 && gocman_mt1 < 180) muctieu1_tren.transform.rotation = Quaternion.Euler(0, 0, (90 + code_thaydoi.transform.rotation.eulerAngles.x));
                    else if(culy_updated > 0 && gocman_mt1 < 180) muctieu1_tren.transform.rotation = Quaternion.Euler(0, 0, -(90 + code_thaydoi.transform.rotation.eulerAngles.x));
                    //muctieu1_tren.transform.rotation = Quaternion.Euler(0, 0, 90 + code_thaydoi.transform.rotation.eulerAngles.x);
                    //else muctieu1_tren.transform.rotation = Quaternion.Euler(0, 0, -(90 + code_thaydoi.transform.rotation.eulerAngles.x));
                    //Debug.Log(Vector3.Distance(new Vector3(muctieu1_that.transform.position.x,0,muctieu1_that.transform.position.z), tauta.transform.position) + "   " + Vector3.Distance(goc_duoi.transform.position, muctieu1_duoi.transform.position) * 1000 / culygia_radar);
                }
                else if(duongbay_mt1_str == "MB MANG NHIỄU")
                {
                    thoigian_phongnhieu += Time.deltaTime;
                    mode_phongnhieu.enabled = true;
                    code_thaydoi.enabled = false;
                    if (banTenlua.ketqua_ban == false) muctieu1_that.transform.Translate(0, 0, vantoc_mt1 * Time.deltaTime, Space.Self);
                    else if (banTenlua.ketqua_ban == true)
                    {
                        muctieu1_that.transform.Translate(0, 0, 0, Space.Self);
                        muctieu1_that.transform.rotation = Quaternion.Slerp(muctieu1_that.transform.rotation, Quaternion.EulerAngles(45, 0, 0), 2f * Time.deltaTime);
                        muctieu1_that.transform.Translate(Vector3.forward * 50f * Time.deltaTime);
                        if (muctieu1_that.transform.position.y == 0) Destroy(muctieu1_that);
                    }
                }
                hientai_culy.text = (Vector3.Distance(goc_duoi.transform.localPosition, muctieu1_duoi.transform.localPosition) * 1000 / 45).ToString();
                hientai_vantoc.text = vantoc_mt1_str;
                hientai_docao.text = (muctieu1_that.transform.position.y).ToString();
                hientai_culyTL_MT.text = (Vector3.Distance(goc_duoi.transform.localPosition, muctieu1_duoi.transform.localPosition) * 1000 / 45).ToString();
                hientai_thamso.text = thamso(hinhchieu_mt1_that.transform.position, forward, tauta.transform.position).ToString();
            }
            culy_old = culy_hientai; // DUA RA NGOAI !!!!!!
        }
        if (somuctieu.options[somuctieu.value].text == "2")
        {
            canvas_mt1.SetActive(true);
            canvas_mt2.SetActive(true);
            canvas_mt3.SetActive(false);
            canvas_mt4.SetActive(false);
        }
        if (somuctieu.options[somuctieu.value].text == "3")
        {
            canvas_mt1.SetActive(true);
            canvas_mt2.SetActive(true);
            canvas_mt3.SetActive(true);
            canvas_mt4.SetActive(false);
        }
        if (somuctieu.options[somuctieu.value].text == "4")
        {
            canvas_mt1.SetActive(true);
            canvas_mt2.SetActive(true);
            canvas_mt3.SetActive(true);
            canvas_mt4.SetActive(true);
        }
    }

    public void taomuctieu()
    {
        float muctieu1_that_x = culy_mt1 * Mathf.Cos(gocman_mt1 * Mathf.Deg2Rad);
        //Debug.Log(muctieu1_that_x);
        float muctieu1_that_y = culy_mt1 * Mathf.Sin(gocman_mt1 * Mathf.Deg2Rad);
        //Debug.Log(muctieu1_that_y);
        muctieu1_that.transform.position = new Vector3(muctieu1_that_y, docao_mt1 , muctieu1_that_x);
        //Debug.Log(Vector3.Distance(new Vector3(0,0,0), muctieu1_that.transform.position));

    }

    public void move_mt1()
    {
        float vantoc_giaduoi = (culy_mt1 * culygia_radar / 1000) / (culy_mt1 / vantoc_mt1);
        float vantoc_giatren = (Vector3.Distance(muctieu1_duoi.transform.position, goc_duoi.transform.position)) * 45 / 1000;
        muctieu1_duoi.transform.Translate(0,vantoc_giaduoi * Time.deltaTime, 0, Space.Self);
        
    }
    public void bam_huongnguoclai()
    {
        Vector3 dir = to.position - diem_batdau.position;
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(diem_batdau.rotation, targetRotation, Time.deltaTime * 10f);
    }
    public float thamso(Vector3 rayOrigin, Vector3 rayDir, Vector3 point)
    {
        float distance = Vector3.Distance(rayOrigin, point);
        float angle = Vector3.Angle(rayDir, point - rayOrigin);
        return (distance * Mathf.Sin(angle * Mathf.Deg2Rad));
        //return angle;
    }
}
