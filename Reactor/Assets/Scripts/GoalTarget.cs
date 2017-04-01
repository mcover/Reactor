using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTarget : MonoBehaviour, IHitMe {
    public GameController gameController; //should grab reference to this instead of dragging in
    public GameObject goalCheck;

    private void Start()
    {
        goalCheck.SetActive(false);
        Debug.Log("script active");
    } 

    public virtual void HitMe(GameObject hitter)
    {
        //tell Game Controller that the goal has been hit (game controller needs listener)
        //animate success for this object
        goalCheck.SetActive(true);
        Debug.LogFormat("Objects {0} hit by object", name);
    }

}
