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
            Debug.Log("Setting left tower");
            leftRopeTowers.Add(ropeTower); 
            leftSet = true;
        }

        if (ropeTower.Tile.isRight())
        {
            Debug.Log("Setting right tower");
            rightRopeTowers.Add(ropeTower);
            rightSet = true;
        }
        Debug.Log(leftSet + " " + rightSet);
        if (leftSet && rightSet)
        {
            Debug.Log("LEFT AND RIGHT SET");
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
