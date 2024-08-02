using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhrasePrompt : MonoBehaviour
{
    [SerializeField]    //This will show the current phrase
    TMP_Text Phrase;

    [SerializeField]    //Tells the user what letter to phrase
    TMP_Text instructions;


    [SerializeField]   //Tells the user the letter that was just detected
    TMP_Text SignedLetter;

    [SerializeField]    //Tells the user if the letter was correct or not and when the phrase is completed or the whole set of phrases is completed.
    TMP_Text feedbackText;

    [SerializeField]    //Spacebar button
    Button Space;

    private List<string> phrases = new List<string> //The list (set) of phrases
    {
        "Hello how are you",
        "My name is jay",
        "Im doing very good",
        "Im currently at ud",
        "I love football go birdz",
        "Do you eat squid"
    };

    private int currentPhraseIndex = 0;
    private int currentLetterIndex = 0;

    private void Start()
    {
        PromptNextLetter();         
        Space.onClick.AddListener(OnSpacePressed);  //Space button listener
    }

    //Prompts the first and the next letter. Colors the current letter yellow and if the correct letter is signed, it will turn green and the next letter will be yellow
    private void PromptNextLetter()
    {
        if (currentPhraseIndex < phrases.Count) //checks that we are still in the index of the phrase list
        {
            string currentPhrase = phrases[currentPhraseIndex];
            Phrase.text = currentPhrase;           //Sets the phrase
            UpdatedColoredPhrase(currentPhrase, currentLetterIndex); //Makes the phrase colored
            if (currentLetterIndex < currentPhrase.Length)
            {
                //Debug.Log(currentPhrase[currentLetterIndex]);
                if (currentPhrase[currentLetterIndex] == ' ') //Whenever the user gets to a space in the phrase, it will prompt the user to press the space button
                {
                    instructions.text = "Press Space";
                }
                else
                {
                    instructions.text = $"Sign the letter: {currentPhrase[currentLetterIndex]}";    //Tells the user what letter to sign

                }
            }
            else
            {   //Executes when phrase is completed, pauses 2 seconds before the next phrase is put up. Resets currentLetterIndex to 0 and increments currentPhraseIndex.
                feedbackText.text = "Congratulations! You completed the phrase";
                currentLetterIndex = 0;
                currentPhraseIndex++;
                Invoke("PromptNextLetter", 2);
            }
        }
        else
        {
            //Executes when all the phrases are completed
            feedbackText.text = "Well done! You have completed all the phrases";
        }
    }
    /*
     * string phrase: The current phrase in the list
     * int currentLetterIndex: The current index of the current phrase
     * 
     * This function changes the colors of the current letter the user is on to yellow to indicate where the user is and when they get the letter correct, it will move on to the next letter and make it yellow. The previous letter will be changed
     * gree.
     * */
    private void UpdatedColoredPhrase( string phrase, int currentLetterIndex)
    {
        string coloredPhrase = "";
        for (int i = 0; i < phrase.Length; i++)
        {
            if(i < currentLetterIndex) //Only way to increment currentLetterIndex is to get the letter correct, therefore all previous letter will be green
            {
                coloredPhrase += $"<color=green>{phrase[i]}</color>";
            }
            else if (i == currentLetterIndex)
            {
                coloredPhrase += $"<color=yellow>{phrase[i]}</color>";  //Makes current letter yellow
            }
            else
            {
                coloredPhrase += phrase[i]; //Makes the rest of the letters after the currentLetterindex normal color (white)
            }
        }
        Phrase.text = "Phrase: " + coloredPhrase;   //Sets the phrase to the colored phrase
    }

    /*
     * GestureCompletionData data: The data the contains the pretrained gestures. The file should be in the StreamingAssets folder and the StreamingAssets folder should be in the Assets folder
     * 
     * This function detects what letter was signed from the data file runs it through the ProcessLetter function. It also tell the user what letter was just detected when gesturing
     */

    public void OnGestureCompleted(GestureCompletionData data)
    {
        int gestureID = data.gestureID;
        string gestureName = data.gestureName;
        char gestureChar = gestureName[0];
        SignedLetter.text = "Signed Letter: " + gestureChar.ToString();
        if (gestureID >= 0)
        {
            ProcessLetter(gestureChar);            
        }
        else
        {
            Debug.LogError("Gesture Not Found!");
        }
    }

    //Adds a space to the user's phrase progress
    public void OnSpacePressed()
    {
        string currentPhrase = phrases[currentPhraseIndex];
        if (currentLetterIndex < currentPhrase.Length)
        {
            ProcessLetter(' ');
        }
    }


    /*
     * char letter: The first character that was detected from the OnGestureCompleted function
     * 
     * This function checks the character that was detected and compares it with the character of the current phrase at the currentLetterIndex. If it matches it will move on to the next letter and tell the user it was correct, else it will
     * tell the user to try again.
     */
    private void ProcessLetter(char letter)
    {
        string currentPhrase = phrases[currentPhraseIndex];
        if (currentLetterIndex == 0) //Makes the first detected character always uppercase
        {
            letter = char.ToUpper(letter);
        }
        if (letter == currentPhrase[currentLetterIndex])
        {
            currentLetterIndex++;
            feedbackText.text = "Correct!";
            PromptNextLetter();
        }
        else
        {
            feedbackText.text = "Try again";
        }
    }
}
