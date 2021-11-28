using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{

    bool isActive = false;
    GameObject selectedTower;
    GameObject selectedTile;
    

    void Awake()
    {

        gameObject.SetActive(isActive);
        
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelectedTower(GameObject tower)
    {
        selectedTower = tower;
        Debug.Log("Selected " + selectedTower.name);
    }

    public void ConfirmButtonPressed()
    {
        Vector3 newPos = new Vector3(
            selectedTile.transform.position.x, 
            selectedTile.transform.position.y,
            0f);
        Instantiate(selectedTower, newPos, Quaternion.identity);
    }

    public void ToggleMenu(GameObject tile)
    {
        isActive = !isActive;
        selectedTile = tile;
        transform.position = new Vector3(0.5f, tile.transform.position.y);
        gameObject.SetActive(isActive);
        Debug.Log("Menu Toggled to " + isActive);
    }
}
