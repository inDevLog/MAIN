using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(YawPitchRoll))]
public class RandomMovement : MonoBehaviour
{
    Vector3 dir = new Vector3();

    float timeToOtherDirection = 2f;
    [Range(0f, 50f)]
    [SerializeField]
    float miniTimeToOtherDirection = 1f;
    [Range(0f, 50f)]
    [SerializeField]
    float maxTimeToOtherDirection = 5f;

    [SerializeField]
    bool pitchRandom = true;
    [SerializeField]
    bool yawRandom = true;
    [SerializeField]
    bool rollRandom = true;

    YawPitchRoll yawPitchRoll;

    private IEnumerator coroutine;

    private void Start()
    {
        yawPitchRoll = gameObject.GetComponent<YawPitchRoll>();

        coroutine = ChangeToOppositeDirection();
        StartCoroutine(coroutine);
    }

    private IEnumerator ChangeToOppositeDirection()
    {
        while (true)
        {
            setNewRandom();
            yield return new WaitForSeconds(timeToOtherDirection);
        }
    }

    private void setNewRandom()
    {
        timeToOtherDirection = Random.Range(miniTimeToOtherDirection, maxTimeToOtherDirection);
        dir = new Vector3(pitchRandom ? Random.Range(-0.5f, 0.5f) : 0f,
                          yawRandom ? Random.Range(-0.5f, 0.5f) : 0f,
                          rollRandom ? Random.Range(-0.5f, 0.5f) : 0f);
        yawPitchRoll.Direction = dir;
        print(dir);
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
