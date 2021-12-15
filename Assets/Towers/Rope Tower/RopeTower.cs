using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTower : MonoBehaviour
{

    [SerializeField] RopeManager ropeManager;

    void Awake()
    {
        ropeManager = FindObjectOfType<RopeManager>();
    }
    
    
    private Tile tile;
    public Tile Tile { get {return GetComponent<Tower>().Tile;} }
    
    void Start()
    {
        ropeManager.InitiateRope(this);
    }
}
