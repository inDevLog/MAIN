using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class button_col : MonoBehaviour
{
    // Start is called before the first frame update
    public Image img_thongso, img_thongso2;
    public Image img_tinhhuong, img_tinhhuong2;
    public TMP_Text txt_thongso, txt_thongso2;
    public TMP_Text txt_tinhhuong, txt_tinhhuong2;
    void Start()
    {
        img_tinhhuong.DOColor(new Color(0.3970096f, 0.7735849f, 0.6761516f), 0.01f);
        img_tinhhuong2.DOColor(new Color(0.3970096f, 0.7735849f, 0.6761516f), 0.01f);
        img_thongso.DOColor(new Color(255, 255, 255), 0.01f);
        img_thongso2.DOColor(new Color(255, 255, 255), 0.01f);
        txt_tinhhuong.DOColor(new Color(255, 255, 25), 0.01f);
        txt_tinhhuong2.DOColor(new Color(255, 255, 255), 0.01f);
        txt_thongso.DOColor(new Color(0.4056604f, 0.2158419f, 0.2158419f), 0.01f);
        txt_thongso2.DOColor(new Color(0.4056604f, 0.2158419f, 0.2158419f), 0.01f);
    }   

    // Update is called once per frame
    void Update()
    {

    }
    public void btn_tinhhuong()
    {
        img_tinhhuong.DOColor(new Color(0.3970096f, 0.7735849f, 0.6761516f), 0.01f);
        img_tinhhuong2.DOColor(new Color(0.3970096f, 0.7735849f, 0.6761516f), 0.01f);
        img_thongso.DOColor(new Color(255, 255, 255), 0.01f);
        img_thongso2.DOColor(new Color(255, 255, 255), 0.01f);
        txt_tinhhuong.DOColor(new Color(255, 255, 25), 0.01f);
        txt_tinhhuong2.DOColor(new Color(255, 255, 255), 0.01f);
        txt_thongso.DOColor(new Color(0.4056604f, 0.2158419f, 0.2158419f), 0.01f);
        txt_thongso2.DOColor(new Color(0.4056604f, 0.2158419f, 0.2158419f), 0.01f);
    }
    public void btn_thongso()
    {
        img_thongso.DOColor(new Color(0.3970096f, 0.7735849f, 0.6761516f), 0.01f);
        img_thongso2.DOColor(new Color(0.6761516f, 0.7735849f, 0.6761516f), 0.01f);
        img_tinhhuong.DOColor(new Color(255, 255, 255), 0.01f);
        img_tinhhuong2.DOColor(new Color(255, 255, 255), 0.01f);
        txt_thongso.DOColor(new Color(255, 255, 25), 0.01f);
        txt_thongso2.DOColor(new Color(255, 255, 255), 0.01f);
        txt_tinhhuong.DOColor(new Color(0.4056604f, 0.2158419f, 0.2158419f), 0.01f);
        txt_tinhhuong2.DOColor(new Color(0.4056604f, 0.2158419f, 0.2158419f), 0.01f);
    }
}
