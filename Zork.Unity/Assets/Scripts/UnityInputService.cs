using UnityEngine;
using Zork;
using TMPro;
using System;

public class UnityInputService : MonoBehaviour, IInputService
{
    [SerializeField]
    private TMP_InputField InputField;

    public event EventHandler<string> InputReceived;

    public string ReadLine()
    {
        throw new NotImplementedException();
        //if (Input.GetKey(KeyCode.Return))
        //{
        //    string inputString = InputField.text;
        //    if (string.IsNullOrWhiteSpace(inputString) == false)
        //    {
        //        return inputString;
        //    }
        //}
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            string inputString = InputField.text;
            if (string.IsNullOrWhiteSpace(inputString) == false)
            {
                InputReceived?.Invoke(this, inputString);
            }

            InputField.text = string.Empty;
        }
    }
}
