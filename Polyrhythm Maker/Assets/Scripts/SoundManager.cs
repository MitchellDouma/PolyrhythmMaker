using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip kick;
    public AudioClip snare;
    public AudioClip hat;
    bool isPlaying;

    void Update()
    {
        if (GameManager.instance.play && !isPlaying)
        {
            StartCoroutine(PlayRhythm());
        }
    }

    IEnumerator PlayRhythm()
    {
        isPlaying = true;
        int iterateThroughBeats = 0;
        //play the rhythm
        for (int i = 0; i < GameManager.instance.secondCurrentRhythm; i++)
        {

            for (int j = 0; j < GameManager.instance.firstCurrentRhythm; j++)
            {
                //check if it is the first beat of the second rhythm              
                if (iterateThroughBeats <= GameManager.instance.secondCurrentRhythm)
                {
                    audioSource.PlayOneShot(hat);
                }
                
                if (iterateThroughBeats == 0)
                {
                    audioSource.PlayOneShot(kick);                    
                }

                if (iterateThroughBeats == GameManager.instance.secondCurrentRhythm)
                {
                    iterateThroughBeats = 0;
                }
                else
                {
                    iterateThroughBeats++;
                }
                
                yield return new WaitForSeconds(1);
            }
        }
    }

}
