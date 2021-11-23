using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Zork;
using System;
using TMPro;
using System.Linq;

public class UnityOuputService : MonoBehaviour, IOutputService
{
    [SerializeField]
    private TextMeshProUGUI OutputText;
    [SerializeField]
    private Transform OutputContainer;
    [SerializeField]
    private int MaxLines;
    [SerializeField]
    private TextMeshProUGUI CurrentLocationText;

    private readonly List<GameObject> _line;

    //public event EventHandler<Room> LocationChanged;

    public UnityOuputService()
    {
        _line = new List<GameObject>();
    }
    public void Clear()
    {
        throw new System.NotImplementedException();
    }

    public void Write(string value)
    {
        WritingNewLine(value);
    }

    public void Write(object value) => WriteLine(value.ToString());
    public void WriteLine(string value)
    {
        WritingNewLine(value);
    }
    public void WriteLine(object value) => WriteLine(value.ToString());

    private void WritingNewLine(string value)
    {
        string[] delimiter = { "\n" };
        var lines = value.Split(delimiter, StringSplitOptions.None);
        foreach (var line in lines)
        {
            if (_line.Count >= MaxLines)
            {
                var mEntry = _line.First();
                Destroy(mEntry);
                _line.Remove(mEntry);
            }

            else
            {
                NewEntry(line);
            }
        }
    }

    public void NewEntry(string value)
    {
        var textObject = GameObject.Instantiate(OutputText);
        textObject.transform.SetParent(OutputContainer, false);
        textObject.text = value;
        _line.Add(textObject.gameObject);
    }

    //void Update()
    //{
    //    string locationString = CurrentLocationText.text;
    //}
}
