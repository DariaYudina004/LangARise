using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dictionary : MonoBehaviour
{
    public List<NewWordsItemsConfig> configList;
    [SerializeField] private string searchText;
    [SerializeField] private TextMeshProUGUI inputText;

    [SerializeField] private NewWordsItems wordGenerate;
    [SerializeField] private TextMeshProUGUI textOfWord;
    [SerializeField] private TextMeshProUGUI translate;
    [SerializeField] private TextMeshProUGUI transcription;
    [SerializeField] private Button pronsance;
    private bool flag = false;

    //int i = 0;

    public void Search()
    {
        searchText = inputText.text;
        foreach (NewWordsItemsConfig conf in configList)
        {
            int i = 0;
            foreach (NewWordsItems item in conf.wordsList)
            {
                int j = 0;
                if (searchText == item.Words || searchText == item.Translate)
                {

                    Debug.Log("in");
                    flag = true;
                    wordGenerate = configList[i].wordsList[j];
                    textOfWord.text = wordGenerate.Words;
                    translate.text = wordGenerate.Translate;
                    transcription.text = wordGenerate.Transcription;
                    pronsance.GetComponent<AudioSource>().clip = wordGenerate.AudioClip;
                    Debug.Log("not in");
                }
                j++;
                Debug.Log("j=" + j);
            }
            i++;
            Debug.Log("i=" + i);
        }
        //for(int i = 0; i < configList.Count; i++)
        //{
        //    for (int j = 0; j < configList[i].wordsList.Count; j++)
        //    {
        //        if (searchText == configList[i].wordsList[j].Words || searchText == configList[i].wordsList[j].Translate)
        //        {
        //            Debug.Log("in");
        //            flag = true;
        //            wordGenerate = configList[i].wordsList[j];
        //            textOfWord.text = wordGenerate.Words;
        //            translate.text = wordGenerate.Translate;
        //            transcription.text = wordGenerate.Transcription;
        //            pronsance.GetComponent<AudioSource>().clip = wordGenerate.AudioClip;
        //            Debug.Log("not in");
        //        }
        //        Debug.Log("j=" + j);
               
        //    }
        //    Debug.Log("i=" + i);
        //}
        if(flag == false)
        {
            textOfWord.text = "Слово не найдено";
        }
    }

}
