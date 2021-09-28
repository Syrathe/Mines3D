using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void showText(){
        this.gameObject.SetActive(true);
    }
}
