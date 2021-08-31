using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Text _mapSize;
    private static int difficulty = 10; 

    public void LoadGame(){
        SceneManager.LoadScene(0);
    }

    void Start(){}
    void Update(){}

    public void incDiff(){
        if(difficulty<=99){
            difficulty++;
            /* Debug.Log($"Map Size is now {difficulty}"); */
            _mapSize.text = difficulty.ToString();
            /* Debug.Log($"Text is now {_mapSize.text}"); */
        }
    }
    public void decDiff(){
        if(difficulty>=6){
            difficulty--;
            /* Debug.Log($"Map Size is now {difficulty}"); */
            _mapSize.text = difficulty.ToString();
        }
    }
    public static int getDiff(){
        return difficulty;
    }
}
