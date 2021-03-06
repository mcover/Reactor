﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private void Awake()
    {
        ToolBox.RegisterAsTool(this);
    }

    private void OnDestroy()
    {
        ToolBox.UnregisterTool(this);
    }

    public string goalType;
    public int goalNum;

    private int goalProgress;

    private bool CheckGoal()
    {
        if(goalType == "targetHit")
        {
            if (goalProgress>= goalNum)
            {
                return true;
            }   
        }
        else if (goalType == "stopWaves")
        {
            if(goalProgress == goalNum)
            {
                return true;
            }
        }
        return false;
    }

    //need to set up action listeners for updating the goal values for both goal types

}
