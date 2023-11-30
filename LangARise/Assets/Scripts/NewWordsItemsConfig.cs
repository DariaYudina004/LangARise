//using System.Collections.Generic;
//using UnityEngine;

//[CreateAssetMenu(menuName = "NewWordsItemsConfig")]
//public class NewWordsItemsConfig : ScriptableObject
//{
//    public List<NewWordsItems> newWordsItems;
//}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/NewWordsItemsConfig", fileName = "NewWordsItems")]
public class NewWordsItemsConfig : ScriptableObject
{
    public List<NewWordsItems> wordsList;
    [SerializeField] private NewWordsItems currentWord;

    private int currentIndex = 0;

    public void AddElement()
    {
        if (wordsList == null)
        {
            wordsList = new List<NewWordsItems>();
        }

        currentWord = new NewWordsItems();
        wordsList.Add(currentWord);
        currentIndex = currentIndex - 1;
    }

    public NewWordsItems GetNext()
    {
        if(currentIndex < wordsList.Count - 1) {
        currentIndex++;}
        currentWord = this[currentIndex];
        return currentWord;
    }

    public NewWordsItems GetPrev()
    {
        if(currentIndex >0 )
        {
            currentIndex--;
        }
        currentWord = this[currentIndex];
        return currentWord;
    }

    public void ClearDatabase()
    {
        wordsList.Clear();
        wordsList.Add(new NewWordsItems());
        currentWord = wordsList[0];
        currentIndex = 0;
    }

    public NewWordsItems GetRandomElement()
    {
        int random = UnityEngine.Random.Range(0, wordsList.Count);
        return wordsList[random];
    }
    public void RemoveElement()
    {
        if (currentIndex > 0)
        {
            currentWord = wordsList[--currentIndex];
            wordsList.RemoveAt(++currentIndex);
        }
        else
        {
            wordsList.Clear();
            currentWord = null;
        }
    }

    public NewWordsItems this[int index]
    {
        get
        {
            if(wordsList != null && index >=0 && index < wordsList.Count)
            {
                return wordsList[index];
            }
            return null;
        }

        set
        {
            if(wordsList == null)
            {
                wordsList = new List<NewWordsItems>();
            }

            if (index >= 0 && index < wordsList.Count && value != null)
            {
                wordsList[index] = value;
            }
            else Debug.Log("Пипец");
        }
    }
}


