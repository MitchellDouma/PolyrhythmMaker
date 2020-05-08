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
            errorMessages.text = "";

            string[,] polyRhythm = new string[int.Parse(firstPolyInput.text), int.Parse(secondPolyInput.text)];
        }
           
    }
}
