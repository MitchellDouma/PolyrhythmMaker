using System;
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

            //so we can highlight the first beat of the second rhythm
            bool[] firstBeat = new bool[int.Parse(firstPolyInput.text) + int.Parse(secondPolyInput.text)];

            for(int i = 0; i < firstBeat.Length; i++)
            {
                for(int j = 0; j < int.Parse(secondPolyInput.text); j++)
                {
                    if(j == 0)
                    {
                        firstBeat[i] = true;
                    }
                    else
                    {
                        firstBeat[i] = false;
                    }
                }
            }
            
            //create the grid
            for(int i = 0; i < int.Parse(secondPolyInput.text); i++)
            {         
                for (int j = 0; j < int.Parse(firstPolyInput.text); j++)
                {
                    polyGrid.text += "| " + (j + 1) + " |";
                }
                //make a new line
                polyGrid.text += "\n";
            }
        }
           
    }
}
