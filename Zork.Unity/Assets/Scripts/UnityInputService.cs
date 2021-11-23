using UnityEngine;
using Zork;
using TMPro;
using System;

public class UnityInputService : MonoBehaviour, IInputService
{
    [SerializeField]
    private TMP_InputField InputField;

    public event EventHandler<string> InputRecieved;

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            string inputString = InputField.text;
            if (string.IsNullOrWhiteSpace(inputString) == false)
            {
                InputRecieved?.Invoke(this, inputString);
            }

            InputField.text = string.Empty;
        }
    }
}
