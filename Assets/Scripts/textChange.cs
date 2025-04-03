using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using Unity.VisualScripting;

public class textChange : MonoBehaviour
{
    
    //references the texts from the scene.
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI screenText;

    //string of path file
    private string filePath = Path.Combine(Application.streamingAssetsPath, "Texts", "example.txt");


    // Start is called before the first frame update
    void Start()
    {

        //change text based on what is returned by textinator()
        screenText.text = textinator();
        
    }

    private string textinator() //function to display the content text
    {
        string failedMsg = "No txt file available";

        //checks if folder stated in file path exists or not
        if(File.Exists(filePath))
        {
            //read all text in txt file
            string readTxt = File.ReadAllText(filePath);
            
            titleText.text = displayText(true); //change display text based on the return data of displayText()
            Debug.Log("Found txt file, contents read as: " + readTxt); //console log message
            return readTxt;
        }
        else 
        {
            Debug.Log("Couldn't find txt file.");
            titleText.text = displayText(false);
            return failedMsg;
        }
    }

    //function that returns a certain string depending on the bool parameter
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
