using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flighttest : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField] float flightSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * flightSpeed * Time.deltaTime, Space.Self);
    }
}
