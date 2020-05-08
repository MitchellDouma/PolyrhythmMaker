using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //Declaration
    public InputField firstPolyInput;
    public InputField secondPolyInput;
    public Text errorMessages;

    void Start()
    {

    }

    public void GenerateGrid()
    {
        if (firstPolyInput.text == "" || secondPolyInput.text == "")
        {
            errorMessages.text = "Input field is empty";
        }
    }
}
