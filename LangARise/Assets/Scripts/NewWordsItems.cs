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
    public string Words => word;
    [SerializeField] private GameObject objOfWord;
    public GameObject ObjOfWord => objOfWord;
    [SerializeField] private string translate;
    public string Translate => translate;
    [SerializeField] private string transcription;
    public string Transcription => transcription;
    [SerializeField] private AudioClip audioClip;
    public AudioClip AudioClip => audioClip;
}


