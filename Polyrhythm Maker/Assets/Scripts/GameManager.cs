﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //Declaration
    public InputField firstPolyInput;
    public InputField secondPolyInput;
    public Text errorMessages;
    public Text polyGrid;

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
            //clear everything
            errorMessages.text = "";
            polyGrid.text = "";

            //make 2d array based on input 
            string[,] polyRhythm = new string[int.Parse(firstPolyInput.text), int.Parse(secondPolyInput.text)];
            int iterateThroughBeats = 0;
            
            //create the grid
            for(int i = 0; i < int.Parse(secondPolyInput.text); i++)
            {         
                for (int j = 0; j < int.Parse(firstPolyInput.text); j++)
                {
                    //check if it is the first beat of the second rhythm              
                    if(iterateThroughBeats < int.Parse(secondPolyInput.text) && iterateThroughBeats != 0)
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
}
