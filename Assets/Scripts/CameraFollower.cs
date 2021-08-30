using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private GameObject character;
    public float smoothSpeed = 5f;
    private Vector3 mDistance = new Vector3(-5,-4,-3);
    private bool assigned = false;

    void LateUpdate()
    {
        if (assigned==false)
        {
            assigned=true;
            character = GameObject.FindGameObjectWithTag("Player");
        }
        Vector3 nextPos = character.transform.position - mDistance;
        transform.position = Vector3.Lerp(transform.position, nextPos, smoothSpeed * Time.deltaTime);
    }
}