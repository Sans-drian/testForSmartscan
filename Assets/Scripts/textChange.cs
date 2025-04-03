using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using Unity.VisualScripting;

public class textChange : MonoBehaviour
{

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI screenText;

    private string filePath = Path.Combine(Application.streamingAssetsPath, "Texts", "example.txt");


    // Start is called before the first frame update
    void Start()
    {

        screenText.text = textinator();
        
    }

    private string textinator() //function to display the content text
    {
        string failedMsg = "No txt file available";

        if(File.Exists(filePath))
        {
            string readTxt = File.ReadAllText(filePath);

            Debug.Log("Found txt file, contents read as: " + readTxt);
            titleText.text = displayText(true);
            return readTxt;
        }
        else 
        {
            Debug.Log("Couldn't find txt file.");
            titleText.text = displayText(false);
            return failedMsg;
        }
    }

    private string displayText(bool isTrue)
    {
        if (isTrue)
        {
            return "Wow found a file:";
        }
        else
        {
            return "Womp no file found.";
        }
    }
}
