using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
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
            towerMenu.ConfirmButtonPressed();
        }
    }
}
