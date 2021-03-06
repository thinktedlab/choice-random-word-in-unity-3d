using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public Text word;
    public Button btnChangeWord;

    void Start()
    {
        word.text = "Café";
        btnChangeWord.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {
    }

    private void TaskOnClick()
    {
        if (word.text == "Café")
        {
            word.text = "Leite";
        } 
        else
        {
            word.text = "Café";
        }
    }
}
