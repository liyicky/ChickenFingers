using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItem : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    TowerMenu towerMenu;
    // Start is called before the first frame update
    void Start()
    {
        towerMenu = GetComponentInParent<TowerMenu>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            towerMenu.SetSelectedTower(towerPrefab);
        }
    }
}
