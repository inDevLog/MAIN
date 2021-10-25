using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckAnsL1 : MonoBehaviour
{
  
    void Update()
    {
        transform.Translate(0, 20f * Time.deltaTime, 0);
    }
}