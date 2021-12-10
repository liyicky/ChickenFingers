using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileManager : MonoBehaviour
{
    [SerializeField] GameObject[] leftWallTiles, rightWallTiles;

    void Awake()
    {
        leftWallTiles = GameObject.FindGameObjectsWithTag("Left Tile");
        rightWallTiles = GameObject.FindGameObjectsWithTag("Right Tile");
     }

    public bool isLeft(Tile tile)
    {
        if (tile == null) { Debug.Log("tile is null"); }
        if (leftWallTiles == null) { Debug.Log("leftWallTiles is null"); }
        foreach (GameObject t in leftWallTiles)
        {
            if (t == null) { Debug.Log("t is null"); }
            if (t.GetComponent<Tile>() == tile) { return true; }
        }
        return false;
    }

    public bool CanMakeRopeConnection(Tile leftTile, Tile rightTile)
    {
        
        return false;
    }

    Tile[] AllTiles()
    {
        Tile[] combined = new Tile[leftWallTiles.Length + rightWallTiles.Length];
        combined.CopyTo(leftWallTiles, leftWallTiles.Length);
        combined.CopyTo(rightWallTiles, rightWallTiles.Length);
        return combined;
    }
    
    
}
