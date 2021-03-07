using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

using System;
using System.IO;

using System.Threading.Tasks;

public class ShowText : MonoBehaviour
{
    public Text word;
    public Button btnChangeWord;
    private static List<string> wordList;

    void Start()
    {
        wordList = new List<string>();
        
        async_read_file();

        choiceRandomWorld;

        btnChangeWord.onClick.AddListener(choiceRandomWorld);
    }

    void Update()
    {
    }

    private void choiceRandomWorld()
    {
        if (wordList.Count > 0)
        {
            System.Random rd = new System.Random();
            int index = rd.Next(wordList.Count);
            word.text = wordList[index];
            wordList.RemoveAt(index);
        }
    }


    static async Task async_read_file()
    {
        await ReadAndDisplayFilesAsync();
    }

    static async Task ReadAndDisplayFilesAsync()
    {
        String filename = Application.dataPath + "/resources/pt_BR_dic_1.txt";

        using (StreamReader sr = new StreamReader(filename))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                wordList.Add(line);
                // Debug.Log(line);
            }
        }
    }
}
