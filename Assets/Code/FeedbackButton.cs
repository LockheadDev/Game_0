using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void OpenURL()
    {
        Application.OpenURL("https://forms.gle/SvezdxnR6h7RUXTa6");
        Debug.Log("Opening feedback link...");
    }
}
