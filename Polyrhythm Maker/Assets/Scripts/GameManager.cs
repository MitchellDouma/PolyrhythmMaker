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

        try
        {
            errorMessages.text = "";
        }
        catch(Exception e)
        {
            if (firstPolyInput.text == "" || secondPolyInput.text == "")
            {
                errorMessages.text = "Input field is empty";
            }
        }
       

    }
}
