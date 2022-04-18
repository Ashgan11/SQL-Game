using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputParser : MonoBehaviour
{    
    public TMP_Text outputArea;
    public TMP_InputField inputArea;

    private LinkedList<string> outputText = new LinkedList<string>();
    private int currentOutputLines = 0;
    public int maxOutputLines = 29;

    private Database testDB;

    public void Start(){
        testDB = new Database();
        Debug.Log(testDB.ToString());
    }

    private void appendOutputText(string text){
        //outputArea.text += text + '\n';
        outputText.AddLast(text);

        if (++currentOutputLines > maxOutputLines) outputText.RemoveFirst();

        string newOutput = default;
        foreach (string word in outputText){
            newOutput += word + '\n';
        }

        outputArea.text = newOutput;
    }

    public void Update(){
        //Input query with enter button
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) getInput();

        //Auto-select input area
        if (inputArea.isFocused == false) inputArea.ActivateInputField();
    }

    public void getInput(){
        string input = inputArea.text.ToLower();
        appendOutputText(input);
        inputArea.text = default;
        parseInput(input);
    }

    private void parseInput(string input){
        string[] words = input.Split(' ');

        switch(words[0]){
            case "select":{
                appendOutputText("Type: Select");
                parseSelect(words);
                break;
            }
            default:{
                appendOutputText("Invalid statement!");
                break;
            }
        }
    }

    private void parseSelect(string[] words){
        int currentIndex = 1;
        List<string> colArgs = new List<string>();

        //Get Column Names
        while (words[currentIndex] != "from"){
            colArgs.Add(words[currentIndex]);
            appendOutputText("Argument " + currentIndex + ": " + words[currentIndex]);
            currentIndex++;            
        }

        //Get Table Name
        string targetTable = words[++currentIndex];
        appendOutputText("Target: " + targetTable);
    }
}