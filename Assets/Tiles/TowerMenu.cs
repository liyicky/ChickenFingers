using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{

    TileManager tileManager;
    bool isActive = false;
    GameObject selectedTower;
    Tile selectedTile;
    

    void Awake()
    {
        gameObject.SetActive(isActive); 
        tileManager = FindObjectOfType<TileManager>();
    }

    public void SetSelectedTower(GameObject tower)
    {
        selectedTower = tower;
        Debug.Log("Selected " + selectedTower.name);
    }

    public void ConfirmButtonPressed()
    {
        
        Vector3 newPos = new Vector3
        (
            selectedTile.transform.position.x, 
            selectedTile.transform.position.y,
            0f
        );

        Instantiate(selectedTower, newPos, Quaternion.identity).GetComponent<Tower>().Tile = selectedTile;
        selectedTile.Locked = true;
    }

    public void ToggleMenu(Tile tile)
    {
        if (!tile.Locked)
        {
            isActive = !isActive;
            selectedTile = tile;
            transform.position = new Vector3(0.5f, tile.transform.position.y);
            gameObject.SetActive(isActive);
            Debug.Log("Menu Toggled to " + isActive);
        }
    }
}
