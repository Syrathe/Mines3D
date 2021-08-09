using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject character;

    public float smoothSpeed = 5f;

    private Vector3 mDistance;

    // Start is called before the first frame update
    void Start()
    {
        mDistance = character.transform.position - transform.position;
    }

    void LateUpdate()
    {
        Vector3 nextPos = character.transform.position - mDistance;
        transform.position = Vector3.Lerp(transform.position, nextPos, smoothSpeed * Time.deltaTime);
    }
}