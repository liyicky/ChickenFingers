using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    TowerMenu towerMenu;
    TileManager tileManager;
    private bool locked = false;
    public bool Locked { get {return locked;} set {locked = value;} }

    void Awake()
    {
        towerMenu = FindObjectOfType<TowerMenu>();
        tileManager = FindObjectOfType<TileManager>();
    }


    public bool isLeft()
    {
        return tileManager.isLeft(this);
    }

    public bool isRight()
    {
        // If it's not left, it's right ~ Bernie Sanders
        return !tileManager.isLeft(this);
    }
    

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(name + " Clicked");
            towerMenu.ToggleMenu(this);
        }
    }
}
