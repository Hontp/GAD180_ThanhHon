using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllTargetsDestroyedCondition : Condition
{
    public Target[] targets;

    public string completeString = "All Targets Destroyed: ";
    public string inCompleteString = "Targets To Destroy Left: ";
    public string failureString = "Failed to Destroy All the targets.";

    private void Start()
    {
        IncompleteText = inCompleteString;
        CompleteText = completeString;
        FailureText = failureString;

        numberDone = 0;
        numberTotal = targets.Length;
    }

    void Update()
    {
        if(!isCompleted)
        {
            checkCompleted();
        }
    }


    public override bool checkCompleted()
    {
        int numTargets = targets.Length;
        bool returnval = true;
        numberDone = 0;
        foreach (Target target in targets)
        {
            if (target != null)
            {
                returnval = false;
            }
            else
            {
                numberDone += 1;
            }
        }
        if(returnval)
        {
            Debug.Log("MissionComplete!!");
            isCompleted = true;
        }
        return returnval;
    }

}
