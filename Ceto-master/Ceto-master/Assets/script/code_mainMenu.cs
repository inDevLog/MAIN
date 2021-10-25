using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class code_mainMenu : MonoBehaviour
{
    public GameObject loading;
    public Slider slider;
    public IEnumerator coroutine;
    public Image background;
    public RectTransform tieude;
    public RectTransform kltn;
    public Image login;
    public Text username, password;
    public RectTransform nhapsai,nhapdung, txt_tacgia;
    public bool kiemtra = false;
    // Start is called before the first frame update
    void Start()
    {
        //background.DOColor(new Color(0, 0, 102), 1f);
        background.DOFade(0.4f, 3f);
        tieude.DOAnchorPos(new Vector2(-100, 472), 2f);
        kltn.DOAnchorPos(new Vector2(-281, 300), 2f);
        login.DOFade(0.0f, 0f);
        coroutine = wait(0.2f);
        StartCoroutine(coroutine);
        txt_tacgia.DOAnchorPos(new Vector2(986, -323), 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (kiemtra == true)
        {
            StartCoroutine(chay_slider(1f));
            loading.SetActive(true);
        }
        if (slider.value == slider.maxValue) SceneManager.LoadScene("DemoScene");
    }
    public IEnumerator wait(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            login.DOFade(0.8f, 2f);
        }
    }
    public IEnumerator chay_slider(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            slider.value += 0.5f;
        }
    }
    public IEnumerator doi_sai(float waitTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            nhapsai.DOScale(new Vector3(0, 0, 0), 0.2f);
        }
    }
    public IEnumerator doi_dung(float waitTime)
    {
        {
            yield return new WaitForSeconds(waitTime);
            nhapdung.DOScale(new Vector3(0, 0, 0), 0.2f);
        }
    }
   
    public void dangnhap()
    {

        if (username.text == "ok" && password.text == "ok")
        {
            Debug.Log("dung");
            nhapdung.DOScale(new Vector3(1, 1, 1), 0.2f);
            StartCoroutine(doi_dung(2f));
           
            kiemtra = true;

        }
        else
        {
            nhapsai.DOScale(new Vector3(1, 1, 1), 0.2f);
            StartCoroutine(doi_sai(2f));
         
            kiemtra = false;
        }
    }
}
