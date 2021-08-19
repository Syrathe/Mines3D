using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BrickContainer : MonoBehaviour
{
    private int x = 5;
    [SerializeField]
    private Brick brick;
    public NavMeshSurface [] surfaces;

    void Start()
    {
        for (int h = 0; h < x; h++)
        {
            for (int i = 0; i < x; i++)
            {
                Instantiate(brick, new Vector3(i, 0, h), Quaternion.identity);
                surfaces[i].BuildNavMesh();
            }
        }

        for (int i = 0; i < surfaces.Length; i++) 
        {
            surfaces [i].BuildNavMesh ();    
        } 
    }
}