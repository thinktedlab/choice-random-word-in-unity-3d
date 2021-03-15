using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

using System;
using System.IO;

using System.Threading.Tasks;

using static Syllable;

public class ShowText : MonoBehaviour
{
    public Text word;
    public Button btnChangeWord;
    private static List<string> wordList;
    private Syllable syllable;

    void Start()
    {
        wordList = new List<string>();
        syllable = new Syllable();

        ReadAndDisplayFilesAsync();

        choiceRandomWord();

        btnChangeWord.onClick.AddListener(choiceRandomWord);
    }

    void Update()
    {
    }

    private void choiceRandomWord()
    {
        if (wordList.Count > 0)
        {
            System.Random rd = new System.Random();
            int index = rd.Next(wordList.Count);
            var split = syllable.word2syllables(wordList[index]);
            var splitString = string.Join("-", split.ToArray());
            // word.text = wordList[index];
            word.text = splitString;
            Debug.Log(splitString);
            wordList.RemoveAt(index);
        }
    }

    void ReadAndDisplayFilesAsync()
    {
        String filename = Application.dataPath + "/resources/pt_BR_dic_1.txt";

        using (StreamReader sr = new StreamReader(filename))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                wordList.Add(line);
                //Debug.Log(line);
            }
        }
    }
}
