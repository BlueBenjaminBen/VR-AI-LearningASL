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
        var systemMessage = new ChatMessage()
        {
            Role = "system",
            Content = " You are a professional team member in a business meeting room. The company you work at is the UD HCI Lab. " +
            "You are speaking to another team member who is deaf and will conversate with you in ASL sentence structure. When asked about deadlines, make sure to state that the project is on track; ask for any extra suggestions and ideas" +
            "If asked about the deadlines, get the current date and state the deadline is a month from the current day. Make sure to give the month and day." +
            "If you are asked about when you are going on break, state any time from 11AM to 2PM" + 
            "Respond to questions and contribute to discussions in a professional and frienldy manner."
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
