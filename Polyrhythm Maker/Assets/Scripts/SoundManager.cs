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
        while (GameManager.instance.play)
        {
            for (int i = 0; i < GameManager.instance.secondCurrentRhythm; i++)
            {
                for (int j = 0; j < GameManager.instance.firstCurrentRhythm; j++)
                {
                    //check if it is the first beat of the second rhythm    
                    if (iterateThroughBeats == GameManager.instance.secondCurrentRhythm)
                    {
                        iterateThroughBeats = 0;
                    }
                    if (iterateThroughBeats < GameManager.instance.secondCurrentRhythm)
                    {
                        audioSource.PlayOneShot(hat);
                    }
                    if(iterateThroughBeats == 0 && j != 0)
                    {
                        audioSource.PlayOneShot(snare);
                    }
                    if (j == 0)
                    {
                        audioSource.PlayOneShot(kick);
                    }

                 
                    iterateThroughBeats++;
                    

                    yield return new WaitForSeconds(0.5f);
                }
            }
        }
        isPlaying = false;
    }

}
