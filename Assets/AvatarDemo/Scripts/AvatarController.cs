using OpenAI;
using Samples.Whisper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarController : MonoBehaviour
{
    public GameObject STT;
    public GameObject avatar;
    public AudioSource audioSource = null;
    private bool started = false;
    public SkinnedMeshRenderer SMR;
    private float SMRInterval;

    private void Start()
    {
        StartCoroutine(AudioManager());
    }
    public void BeginRecording()
    {
        Animator animator = avatar.GetComponent<Animator>();
        if(audioSource != null) { audioSource.Stop(); }
        animator.Update(animator.GetCurrentAnimatorClipInfo(0).Length);
        STT.GetComponent<Whisper>().StartRecording();
    }
    private IEnumerator AudioManager()
    {
        Animator animator = avatar.GetComponent<Animator>();
        yield return new WaitUntil(() => avatar.GetComponent<AudioSource>().clip != null);
        //avatar.GetComponent<Animator>().SetInteger("Animation", UnityEngine.Random.Range(1, clips.Length + 1));
        //avatar.GetComponent<AnimancerComponent>().Play(randomclip);
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        animator.Play(stateInfo.fullPathHash, 0, 1f);
        //animator.Update(animator.GetCurrentAnimatorClipInfo(0).Length);
        avatar.GetComponent<AudioSource>().Play();
        started = true;
        yield return new WaitUntil(() => !avatar.GetComponent<AudioSource>().isPlaying);
        avatar.GetComponent<AudioSource>().clip = null;
        started = false;
        //animator.Update(animator.GetCurrentAnimatorClipInfo(0).Length);
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        animator.Play(stateInfo.fullPathHash, 0, 1f);
        StartCoroutine(AudioManager());
    }
    private void Update()
    {

        if (!audioSource.isPlaying && started)
        {
            avatar.GetComponent<Animator>().SetInteger("Animation", 0); // idle
            started = false;
        }
        else if (audioSource.isPlaying && started)
        {
            float[] samples = new float[1024];
            audioSource.GetOutputData(samples, 0);

            float maxAmplitude = 0f;
            for (int i = 0; i < 1024; i++)
            {
                float amplitude = Mathf.Abs(samples[i]);
                if (amplitude > maxAmplitude)
                {
                    maxAmplitude = amplitude;
                }
            }

            float decibelLevel = 20f * Mathf.Log10(maxAmplitude);
            if (decibelLevel > -100f)
            {

                var blendvalue = SMR.GetBlendShapeWeight(0);
                if (blendvalue >= 26)
                {
                    SMRInterval = -0.8f;
                }
                else if (blendvalue <= 0.8)
                {
                    SMRInterval = 0.8f;
                }
                SMR.SetBlendShapeWeight(0, blendvalue + SMRInterval);
            }
            else
            {
                SMR.SetBlendShapeWeight(0, 0);
            }
        }
    }
}
