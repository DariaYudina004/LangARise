//using System;
//using UnityEngine;


//[Serializable]
//public class NewWordsItems
//{
//    public string word;
//    public GameObject objOfWord;
//    [SerializeField] private string translate;
//    [SerializeField] private string transcription;
//}

using System;
using UnityEngine;

[Serializable]
public class NewWordsItems
{
    [SerializeField] private string word;
    [SerializeField] private GameObject objOfWord;
    [SerializeField] private string translate;
    [SerializeField] private string transcription;
    [SerializeField] private AudioClip audioClip;
}


