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
    public GameObject ObjOfWord { get { return objOfWord; } }
    [SerializeField] private string translate;
    public string Translate { get { return translate; } }
    [SerializeField] private string transcription;
    public string Transcription { get { return transcription; } }
    [SerializeField] private AudioClip audioClip;
    public AudioClip AudioClip { get { return audioClip; } }
}


