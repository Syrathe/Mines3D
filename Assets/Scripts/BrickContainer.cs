using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BrickContainer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Brick brick;
    private int x = MainMenu.getDiff();
    [SerializeField]
    private static int mines=0;
    
    public NavMeshSurface  surface;

    void Start()
    {
        for (int h = 0; h < x; h++)
        {
            Debug.Log("h = " + h);
            for (int i = 0; i < x; i++)
            {
                Debug.Log("i = " + i );
                brick = Instantiate(brick, new Vector3(i, 0, h), Quaternion.identity);
                brick.transform.SetParent(this.transform);
                brick.name = "Brick";
            }
        }
        surface.BuildNavMesh();
        Instantiate(player, new Vector3(1,1,1), Quaternion.identity);
    }

    public static void addMine(){
        mines++;
    }

    public static int getMines(){
        return mines;
    }
}