using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip kick;
    public AudioClip snare;
    public AudioClip hat;
    bool isPlaying;
    public float tempo;

    void Update()
    {
        //make sure we dont grab null
        if(GameManager.instance.tempo.text != "")
        {
            tempo = float.Parse(GameManager.instance.tempo.text) / 60;
        }
        else
        {
            tempo = 120 / 60;
        }
        

        if (GameManager.instance.play && !isPlaying)
        {
            StartCoroutine(PlayRhythm());
        }
    }

    //stop the loop when the tempo changes
    public void StopAfterTempoChange()
    {
        GameManager.instance.play = false;
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

                    //if the play stops, get out
                    if (!GameManager.instance.play)
                    {
                        isPlaying = false;
                        break;                      
                    }

                    yield return new WaitForSeconds(1 / tempo);
                }
            }
        }      
    }

}
