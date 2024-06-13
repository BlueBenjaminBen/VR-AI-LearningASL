using OpenAI;
using UnityEngine;
using UnityEngine.UI;

namespace Samples.Whisper
{
    public class Whisper : MonoBehaviour
    {
        public MakeRequest makereq;
        public string output;


        public GameObject Avatar;
        public int microphone;

        private readonly string fileName = "output.wav";
        private readonly int duration = 5;

        private AudioClip clip;
        private bool isRecording;
        private float time;
        private OpenAIApi openai = new OpenAIApi();




        /*
         * Starts Recording and listening for user voice input
         * 
         * @param: None
         * 
         * @return: None
         *
         */
        public void StartRecording()
        {
            Avatar.GetComponent<AudioSource>().Stop(); //Stops for interrupt
            isRecording = true;


#if !UNITY_WEBGL

            clip = Microphone.Start(Microphone.devices[microphone], false, duration, 44100);
#endif
        }

        /*
         * Ends recording and begins GPT translation
         * 
         * @param: None
         * 
         * @return: None
         * 
         */
        private async void EndRecording()
        {
#if !UNITY_WEBGL
            Microphone.End(null);
#endif

            byte[] data = SaveWav.Save(fileName, clip);

            var req = new CreateAudioTranscriptionsRequest
            {
                FileData = new FileData() { Data = data, Name = "audio.wav" },
                Model = "whisper-1", //OpenAI STT
                Language = "en"
            };
            var res = await openai.CreateAudioTranscription(req);
            await makereq.Request(res.Text);
        }

        private void Update()
        {

            if (isRecording)
            {
                time += Time.deltaTime;

                if (time >= duration)
                {
                    time = 0;
                    isRecording = false;
                    EndRecording();
                }
            }
        }
    }
}
