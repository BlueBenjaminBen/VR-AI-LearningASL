using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhrasePrompt : MonoBehaviour
{
    [SerializeField]
    TMP_Text Phrase;

    [SerializeField]
    TMP_Text instructions;


    [SerializeField]
    TMP_Text SignedLetter;

    [SerializeField]
    TMP_Text feedbackText;

    [SerializeField]
    Button Space;

    private List<string> phrases = new List<string>
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
        Space.onClick.AddListener(OnSpacePressed);
    }

    private void PromptNextLetter()
    {
        if (currentPhraseIndex < phrases.Count)
        {
            string currentPhrase = phrases[currentPhraseIndex];
            Phrase.text = currentPhrase;
            UpdatedColoredPhrase(currentPhrase, currentLetterIndex);
            if (currentLetterIndex < currentPhrase.Length)
            {
                Debug.Log(currentPhrase[currentLetterIndex]);
                if (currentPhrase[currentLetterIndex] == ' ')
                {
                    instructions.text = "Press Space";
                }
                else
                {
                    instructions.text = $"Sign the letter: {currentPhrase[currentLetterIndex]}";

                }
            }
            else
            {
                feedbackText.text = "Congratulations! You completed the phrase";
                currentLetterIndex = 0;
                currentPhraseIndex++;
                Invoke("PromptNextLetter", 2);
            }
        }
        else
        {
            feedbackText.text = "Well done! You have completed all the phrases";
        }
    }

    private void UpdatedColoredPhrase( string phrase, int currentLetterIndex)
    {
        string coloredPhrase = "";
        for (int i = 0; i < phrase.Length; i++)
        {
            if(i < currentLetterIndex)
            {
                coloredPhrase += $"<color=green>{phrase[i]}</color>";
            }
            else if (i == currentLetterIndex)
            {
                coloredPhrase += $"<color=yellow>{phrase[i]}</color>";
            }
            else
            {
                coloredPhrase += phrase[i];
            }
        }
        Phrase.text = "Phrase: " + coloredPhrase;
    }

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


    public void OnSpacePressed()
    {
        string currentPhrase = phrases[currentPhraseIndex];
        if (currentLetterIndex < currentPhrase.Length)
        {
            ProcessLetter(' ');
        }
    }

    //Takes in the gestured letter and compares it to the current indexed letter of the phrase. 
    private void ProcessLetter(char letter)
    {
        string currentPhrase = phrases[currentPhraseIndex];
        if (currentLetterIndex == 0)
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
