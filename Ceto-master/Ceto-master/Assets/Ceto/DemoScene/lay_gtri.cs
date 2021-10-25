using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lay_gtri : MonoBehaviour
{
    public static int giatri = 0;
    public AudioSource amthanh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void dangnhap()
    {
        giatri = 1;
        amthanh.Play();
    }
}
