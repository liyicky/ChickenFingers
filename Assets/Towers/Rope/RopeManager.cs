using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RopeManager : MonoBehaviour
{
    [SerializeField] Rope[] ropes;
    [SerializeField] List<RopeTower> leftRopeTowers, rightRopeTowers;
    public bool leftSet, rightSet = false;

    
    public void InitiateRope(RopeTower ropeTower)
    {   
        if (ropeTower.Tile.isLeft())
        {

            leftRopeTowers.Add(ropeTower); 
            leftSet = true;
        }

        if (ropeTower.Tile.isRight())
        {

            rightRopeTowers.Add(ropeTower);
            rightSet = true;
        }

        if (leftSet && rightSet)
        {

            CheckForConnection();
        }
    }

    private void CheckForConnection()
    {
        string ropeName = leftRopeTowers.Last().Tile.name + "-" + rightRopeTowers.Last().Tile.name;

        foreach (Rope rope in ropes)
        {
            if (rope.name == ropeName)
            {
                rope.Activate();
            }
        }

        leftSet = false;
        rightSet = false;
    }
}
