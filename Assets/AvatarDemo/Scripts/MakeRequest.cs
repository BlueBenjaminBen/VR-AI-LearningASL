using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;
using TMPro;
using System;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

public class MakeRequest : MonoBehaviour
{
    public GameObject speak;
    public GameObject avatar;
    public TextMeshProUGUI input;
    public float temperature = 0.5f;

    private List<ChatMessage> messages = new List<ChatMessage>();

    public void RequestTask()
    {
        StartCoroutine(RequestCoroutine(input.text));
    }

    private IEnumerator RequestCoroutine(string input)
    {
        var task = Request(input);
        while (!task.IsCompleted)
        {
            yield return null;
        }

    }

    public void Start()
    {
        string initialPrompt = "You are a team member in a meeting room for a weekly meeting and you are doing research at the UD HCI Lab " +
            "Your name is Sarah and you are a senior in college" + "You are speaking to another team member whom you are trying to get to know better. " +
            "Make sure to start off with a greeting, such as 'Hello!, nice to meet you! My name is Sarah. How are you?" +
            "You can ask questions such as where they are studying, what project are they working on, and what sports they like. Do not ask these questions " +
            "all in the same message, make sure they answer the previous question first before asking the next and make" +"sure to also answer the question yourself. " +
            "For example when you ask 'Where are you studying?', after " +"they answer, you will state where you are studying." + "Do not mention you are an AI" + "Respond in a friendly, interested, and upbeat tone";
        var systemMessage = new ChatMessage()
        {
            Role = "system",
            Content = initialPrompt
        };
        messages.Add(systemMessage);
    }



    /*
     * Makes the request to chatGPT, grabs ChatGPT's reponse, and plays it (if necessary)
     * 
     * @param: input: The inputted message for ChatGPT
     * 
     * @return: None
     * 
     */
    public async Task Request(string input)
    {
        avatar.GetComponent<AudioSource>().Stop(); //Stops for interrupt
        string output;
        if (input == "")
        {
            output = "Sorry, but I didn't seem to get an input. Please try again";
            speak.GetComponent<UIManager>().SpeechPlayback(output);
        }
        else
        {
            var openai = new OpenAIApi();
            try
            {
                var newMessage = new ChatMessage()
                {
                    Role = "user",
                    Content = input
                };
               
                messages.Add(newMessage);
                var completionResponse = await openai.CreateChatCompletion(new CreateChatCompletionRequest()
                {
                    MaxTokens = 128,
                    Model = "gpt-3.5-turbo",
                    Messages = messages,
                    Temperature = temperature
                });
                if (completionResponse.Choices != null && completionResponse.Choices.Count > 0)
                {
                    var message = completionResponse.Choices[0].Message;
                    message.Content = message.Content.Trim();
                    output = message.Content;
                    messages.Add(message);

                    Debug.Log($"User: {input}");
                    Debug.Log($"ChatGPT: {output}");

                    speak.GetComponent<UIManager>().SpeechPlayback(output);

                }



            }
            catch (Exception ex)
            {
                Debug.LogError("An error occurred during the API request: " + ex.Message);
            }
        }
    }


}
