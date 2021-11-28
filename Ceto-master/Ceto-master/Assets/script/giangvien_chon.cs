using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using Newtonsoft.Json.Linq;
using System.IO.Ports;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class giangvien_chon : MonoBehaviour
{
    public Texture2D cursoArrow;
    public TMP_Text chon_tudong;
    public Image bgr_chon_tudong, bgr_chon_bangtay,bgr_chon_bandon,bgr_chon_banduoi;

    WebSocket ws;
    dynamic data;
    // Start is called before the first frame update
    void Start()
    {
        ws = new WebSocket("ws://dia chi IP cua sever:8080/Server_java/endpoint");

        ws.OnMessage += (sender, e) =>
        {
            this.data = JObject.Parse(e.Data);
        };
        ws.OnOpen += (sender, e) =>
        {
            JObject o = new JObject();
            o["role"] = 1; //receiver
            ws.Send(o.ToString());
        };
        ws.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.SetCursor(cursoArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
    public void chedoban_tudong()
    {
        //Cursor.SetCursor(cursoArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
    public void chedoban_tudong_clicked()
    {
        Debug.Log("Da chon che do ban tu dong");
        bgr_chon_tudong.DOColor(new Color(0, 1, 0), 0.01f);
        bgr_chon_bangtay.DOColor(new Color(1, 1, 1), 0.01f);
    }
    public void chedoban_bangtay()
    {
        //Cursor.SetCursor(cursoArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
    public void chedoban_bangtay_clicked()
    {
        Debug.Log("Da chon che do ban bang tay");
        bgr_chon_bangtay.DOColor(new Color(0, 1, 0), 0.01f);
        bgr_chon_tudong.DOColor(new Color(1, 1, 1), 0.01f);
    }
    public void phuongphapban_bandon()
    {
        //Cursor.SetCursor(cursoArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
    public void phuongphapban_bandon_clicked()
    {
        Debug.Log("Da chon phuong phap ban - ban don");
        bgr_chon_banduoi.DOColor(new Color(1, 1, 1), 0.01f);
        bgr_chon_bandon.DOColor(new Color(0, 1, 0), 0.01f);
    }
    public void phuongphapban_banduoi()
    {
        //Cursor.SetCursor(cursoArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
    public void phuongphapban_banduoi_clicked()
    {
        Debug.Log("Da chon phuong phap ban - ban duoi");
        bgr_chon_banduoi.DOColor(new Color(0, 1, 0), 0.01f);
        bgr_chon_bandon.DOColor(new Color(1, 1, 1), 0.01f);
    }
    public void doesnotchoose()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }
}
