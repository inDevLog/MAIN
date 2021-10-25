using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrip1 : MonoBehaviour
{
    // Start is called before the first frame update
    public btn_chuyenchedo a;

    void Start()
    {
        a = GameObject.FindGameObjectWithTag("TagA").GetComponent<btn_chuyenchedo>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log((Vector3.Distance(a.goc_duoi.transform.localPosition, a.muctieu1_duoi.transform.localPosition) * 1000 / 45));

    }

}
