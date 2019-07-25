using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition : MonoBehaviour
{
    public bool isCompleted = false;
    public bool isFailed = false;

    private string failureText;
    public string FailureText
    {
        get
        {
            return failureText;
        }
        set
        {
            failureText = value;
        }
    }
    private string completeText;
    
    public string CompleteText
    {
        get
        {
            return completeText;
        }
        set
        {
            completeText = value;
        }
    }
    private string incompleteText;
    public string IncompleteText
    {
        get
        {
            return incompleteText;
        }
        set
        {
            incompleteText = value;
        }
    }

    public int numberDone;
    public int numberTotal;

    public abstract bool checkCompleted();

}
