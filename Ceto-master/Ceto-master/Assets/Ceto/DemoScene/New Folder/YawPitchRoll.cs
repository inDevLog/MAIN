using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YawPitchRoll : MonoBehaviour
{
    // pitch -> x
    // yaw -> y
    // roll -> z
    [Range(-1f, 1f)]
    [SerializeField] float pitch = 0;
    [Range(-1f, 1f)]
    [SerializeField] float yaw = 0;
    [Range(-1f, 1f)]
    [SerializeField] float roll = 0;

    [Range(0f, 30f)]
    [SerializeField] float rotationSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        applyRotation();
    }

    private void applyRotation()
    {

        // roll 
        transform.Rotate(0f, 0f, roll * rotationSpeed * Time.deltaTime, Space.Self);

        // pitch
        transform.Rotate(pitch * rotationSpeed * Time.deltaTime, 0f, 0f, Space.Self);

        // yaw
        transform.Rotate(0f, yaw * rotationSpeed * Time.deltaTime, 0f, Space.Self);

    }

    public float PITCH { set => pitch = value; }
    public float YAW { set => yaw = value; }
    public float ROLL { set => roll = value; }

    private void SetAxis(Vector3 value)
    {
        pitch = value.x;
        yaw = value.y;
        roll = value.z;
    }

    public Vector3 Direction { set => SetAxis(value); }
}
