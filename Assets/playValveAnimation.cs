using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playValveAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI tmpElem = null;
    [SerializeField]
    public CountdownEvent beatingScript;

    static private string PausedText = "Click to Resume the Valve Animation!";
    static private string RunningText = "Click to Pause the Valve Animation!";

    void Start()
    {
        if (tmpElem == null) {
            TextMeshProUGUI tmpElem = GetComponent<TextMeshProUGUI>();
        }
        if (beatingScript.isPause) {
            tmpElem.text = PausedText;
        } else {
            tmpElem.text = RunningText;
        }
    }

    public void Click()
    {
        if (beatingScript.isPause) {
            beatingScript.resume();
            tmpElem.text = RunningText;
        } else {
            beatingScript.pause();
            tmpElem.text = PausedText;
        }
    }
}
