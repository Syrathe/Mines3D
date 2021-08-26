using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BrickContainer : MonoBehaviour
{
    private int x = 10;
    [SerializeField]
    private Brick brick;
    public NavMeshSurface  surface;

    void Start()
    {
        for (int h = 0; h < x; h++)
        {
            Debug.Log("h ");
            for (int i = 0; i < x; i++)
            {
                Debug.Log("i ");
                brick = Instantiate(brick, new Vector3(i, 0, h), Quaternion.identity);
                brick.transform.SetParent(this.transform);
            }
        }

        surface.BuildNavMesh();

        //surface = GameObject.FindGameObjectsWithTag("Brick");

        /* for (int i = 0; i < surfaces.Length; i++) 
        {
            //Debug.Log(surfaces[i]);
            /* surfaces[i].BuildNavMesh();   */  
        //}  */
    }
}