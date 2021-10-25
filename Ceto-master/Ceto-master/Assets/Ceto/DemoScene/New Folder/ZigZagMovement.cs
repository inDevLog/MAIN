using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(YawPitchRoll))]
public class ZigZagMovement : MonoBehaviour
{
    [SerializeField]
    Vector3 dir = new Vector3();

    [SerializeField]
    float timeToOtherDirection = 2f;

    YawPitchRoll yawPitchRoll;

    private IEnumerator coroutine;

    private void Start()
    {
        yawPitchRoll = gameObject.GetComponent<YawPitchRoll>();
        yawPitchRoll.Direction = dir;

        coroutine = ChangeToOppositeDirection();
        StartCoroutine(coroutine);
    }

    private IEnumerator ChangeToOppositeDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToOtherDirection);
            dir *= -1;
            yawPitchRoll.Direction = dir;
        }
    }

    public Vector3 DirectionZipZag
    {
        set => dir = value;
    }

    public float TimeToOtherDirection
    {
        set => timeToOtherDirection = value;
    }
}
