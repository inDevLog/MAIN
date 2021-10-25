using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn_color : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    public void Clicked()
    {
        anim.Play("btn_rath");
    }
    public void Clicked2()
    {
        anim.Play("2");
    }
}
