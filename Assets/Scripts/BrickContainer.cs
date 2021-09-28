using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BrickContainer : MonoBehaviour
{
    private static BrickContainer _instance;

    [SerializeField]
    private GameObject gameOverText;
    [SerializeField]
    private GameObject player;
    private GameObject playerChar;
    [SerializeField]
    private Brick brick;
    [SerializeField]
    public List<Brick> mineArray;
    public List<Brick> noMineArray;
    private int x = MainMenu.getDiff();
    private bool _gameOver =false;    
    
    public NavMeshSurface  surface;

    public static BrickContainer Instance{
        get
        {
            if(_instance != null)
            {
                return _instance;
            } else {
                Debug.LogError("Brick Container is null");
                return null;
            }
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        for (int h = 0; h < x; h++)
        {
            for (int i = 0; i < x; i++)
            {
                bool hasMine;
                if (h != 1 && i != 1)
                {
                    hasMine = Random.value < 0.17;
                } else {
                    hasMine = false;
                }
                brick = Instantiate(brick, new Vector3(i, 0, h), Quaternion.identity);
                brick.transform.SetParent(this.transform);
                brick.mine = hasMine;
                if (hasMine)
                {
                    _instance.mineArray.Add(brick);
                } else {
                    _instance.noMineArray.Add(brick);
                }
                brick.name = "Brick";
            }
        }
        surface.BuildNavMesh();
        playerChar = Instantiate(player, new Vector3(1,1,1), Quaternion.identity);
    }

    void Update(){
        if (_gameOver){
            if (Input.GetKeyDown("x"))
            {
                Application.Quit();
            }
            if (Input.GetKeyDown("r"))
            {
                 SceneManager.LoadScene("MainMenu");
            }
        }
    }

    public bool checkGameOver(){
        Debug.Log("Will check for game over");
        if( ( bricksAreUnchecked() ) && ( minesAreChecked() ) )
        {
            Debug.Log("Game IS over");/* 
            var playingChar = GameObject.FindGameObjectWithTag("Player"); */
            gameOverText.GetComponent<GameOverText>().showText();
            playerChar.GetComponent<CharControl>().DisablePlayer();
            _gameOver = true;
            return true;
        } 
        else
        {
            Debug.Log("Game Ongoing");
            return false;
        }
    }

    private bool minesAreChecked(){//refine
        foreach (var brick in mineArray)
        {
            if (brick.tile.sprite.name == "TileFlag" || brick.tile.sprite.name == "TileMine")
            {
            }else{
                return false;
            }
        } 
        return true;
    }

    private bool bricksAreUnchecked(){
        foreach (var brick in noMineArray)
        {
            if (brick.tile.sprite.name == "TileFlag")
            {
                return false;
            }else{
                Debug.Log("this brick is unmarked");
            }
        } 
        Debug.Log("All bricks are unmarked");
        return true;
    }
}