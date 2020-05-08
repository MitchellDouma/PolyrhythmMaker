using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //Declaration
    public static GameManager instance = null;

    public InputField firstPolyInput;
    public InputField secondPolyInput;
    public Text errorMessages;
    public Text polyGrid;

    bool gridExists = false;
    public int firstCurrentRhythm;
    public int secondCurrentRhythm;
    public bool play;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            DestroyObject(gameObject);
        }
        
    }

    public void GenerateGrid()
    {
        //look for exceptions before doing anything
        //try catch doesn't do anything for some reason
        if (firstPolyInput.text == "" || secondPolyInput.text == "")
        {
            errorMessages.text = "Input field is empty";
        }
        else
        {
            //for the benefit of playing
            gridExists = true;
            //clear everything
            errorMessages.text = "";
            polyGrid.text = "";

            //make 2d array based on input 
            firstCurrentRhythm = int.Parse(firstPolyInput.text);
            secondCurrentRhythm = int.Parse(secondPolyInput.text);
            string[,] polyRhythm = new string[firstCurrentRhythm, secondCurrentRhythm];
            int iterateThroughBeats = 0;
            
            //create the grid
            for(int i = 0; i < secondCurrentRhythm; i++)
            {         
                for (int j = 0; j < firstCurrentRhythm; j++)
                {
                    //check if it is the first beat of the second rhythm              
                    if(iterateThroughBeats < secondCurrentRhythm && iterateThroughBeats != 0)
                    {
                        polyGrid.text += "| " + (j + 1) + " |";
                        iterateThroughBeats++;
                        
                    }
                    else
                    {
                        iterateThroughBeats = 0;
                    }
                    if (iterateThroughBeats == 0)
                    {
                        polyGrid.text += "( " + (j + 1) + " )";
                        iterateThroughBeats++;
                    }

                }
                //make a new line
                polyGrid.text += "\n";
            }
        }          
    }
    public void PlayPolyRhythm()
    {
        //so we dont try to play something that doesnt exist
        if (gridExists)
        {
            if (!play)
            {
                play = true;
            }
            else
            {
                play = false;
            }          
        }
    }

}
