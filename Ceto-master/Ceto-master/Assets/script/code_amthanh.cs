using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class code_amthanh : MonoBehaviour
{
    public AudioSource tieng_maybay;
    public Camera camera;
    private string nameObject;
    private bool hitObject;
    public float thoigian;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hitObject);
      //if(hitObject == false && thoigian > 1f ) tieng_maybay.Play();
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        hitObject = false;
        if (Physics.Raycast(ray, out hit))
        {
            hitObject = false;
            Transform objectHit = hit.transform;
            nameObject = hit.transform.gameObject.name;
            Debug.Log(nameObject);
            thoigian += Time.deltaTime;
            Debug.Log(thoigian);
            if (nameObject == "Cube")
            {
                if (!tieng_maybay.isPlaying) tieng_maybay.Play();
            }

        }
        else
        {
            if (tieng_maybay.isPlaying) tieng_maybay.Stop();
            Debug.Log("MOVE OUT !");
            thoigian = 0;
        }
        if (thoigian >= 5) Debug.Log("BAM SAT !");
        else Debug.Log("CHUA BAM SAT !");
    }
 
}
