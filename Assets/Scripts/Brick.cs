using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Brick : MonoBehaviour
{    
    private static Dictionary<string, Sprite> mTileImages;
    private bool mShowed = false;
    public bool mine = false;
    public float radius = 1.42f;
    public SpriteRenderer tile = null;
    public List<Brick> mNeighbors;
    public bool blocked = false;
    public bool question = false;
    
    public static void BuildSpritesMap()
    {
        if (mTileImages == null) {
            Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/MinesweeperSpritesheet");
            mTileImages = new Dictionary<string, Sprite>();
            for (int i = 0; i < sprites.Length; i++) {
                mTileImages.Add(sprites[i].name, (Sprite) sprites[i]);
            }
        }
    }

    void Start()
    {
        BuildSpritesMap();
        mine = Random.value < 0.17;
        if (mine) 
            BrickContainer.addMine();
        Invoke("FindNeighbors", 0.1f);
    }

    private void FindNeighbors()
    {
        var allBricks = GameObject.FindGameObjectsWithTag("Brick");

        mNeighbors = new List<Brick>();

        for (int i = 0; i < allBricks.Length; i++) {
            var brick = allBricks[i];
            var distance = Vector3.Distance(transform.position, brick.transform.position);
            if (0 < distance && distance <= radius) {
                mNeighbors.Add(brick.GetComponent<Brick>());
            }
        }
    }

    public void ShowSecret()
    {
        if (mShowed) return;
        if (blocked) return;

        mShowed = true;

        string name;

        if (mine) {
            name = "TileMine";
        } else {
            int num = 0;
            mNeighbors.ForEach(brick => {
                if (brick.mine) num += 1;
            });
            name = $"Tile{num}";
        }
        Sprite sprite;
        if (mTileImages.TryGetValue(name, out sprite))
            tile.sprite = sprite;
    }

    public void Blocked(){
        if(mShowed)return;

        string name = "TileFlag";
        Sprite sprite;
        if (mTileImages.TryGetValue(name, out sprite) && (blocked==false) && (question==false)){
            blocked = true;
            tile.sprite = sprite;
            return;
        }

        name = "TileQuestion"; 
        if (mTileImages.TryGetValue(name, out sprite) && (blocked==true)){
            blocked=false;
            question=true;
            tile.sprite=sprite;
            return;
        }

        name = "TileUnknown";
        if(mTileImages.TryGetValue(name, out sprite)){
            question=false;
            tile.sprite=sprite;
            return;
        }
    }
}