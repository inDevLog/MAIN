using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider_loading : MonoBehaviour
{
    // Start is called before the first frame update
    public IEnumerator coroutine;
    public Slider slider;
    void Start()
    {
        //coroutine = wait(1f);
        //StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(chay_slider(1f));
    }
    public IEnumerator chay_slider(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            slider.value += 0.1f;
        }
    }
}
