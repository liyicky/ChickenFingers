using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    TowerMenu towerMenu;
    
    // Start is called before the first frame update
    void Awake()
    {
        towerMenu = FindObjectOfType<TowerMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(name + " Clicked");
            towerMenu.ToggleMenu(gameObject);
        }
    }
}
