using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    public Condition[] conditionList;

    public Text startText;
    public Text[] MissionTexts;

    // Vertical Text Offset
    public float textLeading;

    [Header("Mission Text Colours")]
    [SerializeField]
    private Color c_completed;
    [SerializeField]
    private Color c_inComplete;
    [SerializeField]
    private Color c_failed;

    private void Start()
    {
        RectTransform rt = startText.GetComponent<RectTransform>();
        Font f = startText.font;
        FontStyle fs = startText.fontStyle;
        int count = 0;
        MissionTexts = new Text[conditionList.Length];
        foreach(Condition condition in conditionList)
        {
            // TODO add Label Movement ( I just can't figure this out right now im sorry)
            MissionTexts[count] = Instantiate(startText, rt);
            count++;
        }
        //Destroy(startText);
    }
    // TODO: Calling this every frame isn't the best, possibly think about making run on the condition changes
    private void Update()
    {
        int count = 0;
        foreach(Condition condition in conditionList)
        {
            Text currentText = MissionTexts[count];
            if (condition.isFailed)
            {
                currentText.color = c_failed;
                currentText.text = "> " + condition.FailureText;
            }
            else
            {

                if (condition.isCompleted)
                {
                    currentText.color = c_completed;
                    currentText.text = "> " + condition.CompleteText + condition.numberDone.ToString() + "/" + condition.numberTotal.ToString();
                }
                else
                // Mission is incomplete so far
                {
                    currentText.color = c_inComplete;
                    currentText.text = "> " + condition.IncompleteText + condition.numberDone.ToString() + "/" + condition.numberTotal.ToString();
                }
            }

            count++;
        }
    }

}