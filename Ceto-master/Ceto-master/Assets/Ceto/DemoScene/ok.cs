using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ok : MonoBehaviour
{
    public Camera camera;
    private string nameObject;
    private bool hitObject;
    public float thoigian;
    public Material hinhanh;
    public AudioSource tieng_beep;
    // Update is called once per frame
    private void Start()
    {
    }
    void Update()
    {
        if (hitObject == false && thoigian > 0.2f)
        {
            hinhanh.DOColor(new Color(255, 255, 255), 0.01f);
            tieng_beep.Play();
            tieng_beep.DOFade(1f, 0.1f);
        }

        else
        {
            hinhanh.DOColor(new Color(1, 1, 1, 1), 0.01f);
            tieng_beep.Stop();
        }
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        hitObject = false;
        if (Physics.Raycast(ray, out hit))
        {
            hitObject = true;
            Transform objectHit = hit.transform;
            nameObject = hit.transform.gameObject.name;
            Debug.Log(nameObject);
            thoigian += Time.deltaTime;
            Debug.Log(thoigian);
            
        }
        else
        {
            Debug.Log("MOVE OUT !");
            thoigian = 0;
        }
        if (thoigian >= 5) Debug.Log("BAM SAT !");
        else Debug.Log("CHUA BAM SAT !");
    }
    public void at()
    {
        tieng_beep.Play();

    }
}