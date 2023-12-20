using Microsoft.MixedReality.Toolkit;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewWords : MonoBehaviour
{
    [SerializeField] private NewWordsItemsConfig config;
    [SerializeField] private int numberOfGeneration = 0;
    [SerializeField] private NewWordsItems wordGenerate;
    [SerializeField] private TextMeshProUGUI textOfWord;
    [SerializeField] private TextMeshProUGUI translate;
    [SerializeField] private TextMeshProUGUI transcription;
    [SerializeField] private Button pronsance;
    [SerializeField] private GameObject currentAsset;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject learningBlock;
    ////[SerializeField] private float time = 0;
    //[SerializeField] private GameObject[] obj;
    //private int i = 0;

    List<object> oneFromList;
    private int oneVersion; // Один Экземпляр

    public void CreateCopyOfDataBase()
    {
        oneFromList = new List<object>(config.wordsList);
        Generate();
    }


    public void Generate()
    {
        if (oneFromList.Count > 0)
        {
            Debug.Log("в генерации");
            oneVersion = Random.Range(0, oneFromList.Count);
            wordGenerate = oneFromList[oneVersion] as NewWordsItems;
            currentAsset = wordGenerate.ObjOfWord;
            Instantiate(currentAsset);
            numberOfGeneration += 1;
            textOfWord.text = wordGenerate.Words;
            translate.text = wordGenerate.Translate;
            transcription.text = wordGenerate.Transcription;
            pronsance.GetComponent<AudioSource>().clip = wordGenerate.AudioClip;
            Debug.Log("из генерации");
        }
        else
        {
            Debug.Log("Нет Элементов в списке ");
            learningBlock.SetActive(false);
            endPanel.SetActive(true);
            Debug.Log("Нет Элементов в списке ");
        }

    }

    public void Next()
    {
        Debug.Log("здесь кьюрент " + currentAsset + " ассет ");
        //Debug.Log("Внутри некст");
        //obj = GameObject.FindGameObjectsWithTag("DeleteWordObject");
        Destroy(currentAsset);
        pronsance.GetComponent<AudioSource>().Stop();
        if (oneFromList.Count > 0)
        {
            Debug.Log("Внутри условия");
            //GetComponent<MeshFilter>().mesh = wordGenerate.ObjOfWord.GetComponent<MeshFilter>().mesh;
            oneFromList.Remove(wordGenerate);
            Debug.Log("Not Generation");
            Generate();
            Debug.Log("Generation");
            Debug.Log("Вне условия");
        }
        else
        {
            Debug.Log("Нет Элементов в списке ");
            learningBlock.SetActive(false);
            endPanel.SetActive(true);
            Debug.Log("Нет Элементов в списке ");
        }
      
    }

    public void PronanceAudio()
    {
        Debug.Log("Внутри PronanceAudio");
        pronsance.GetComponent<AudioSource>().Play();
        Debug.Log("вне PronanceAudio");
    }
}




//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class NewWords : MonoBehaviour
//{
//    [SerializeField] private NewWordsItemsConfig config;
//    [SerializeField] private int numberOfGeneration = 0;
//    [SerializeField] private NewWordsItems wordGenerate;
//    [SerializeField] private TextMeshProUGUI textOfWord;
//    [SerializeField] private TextMeshProUGUI translate;
//    [SerializeField] private TextMeshProUGUI transcription;
//    [SerializeField] private Button pronsance;
//    [SerializeField] private GameObject currentAsset;
//    [SerializeField] private GameObject endPanel;
//    [SerializeField] private GameObject learningBlock;
//    List<object> oneFromList;
//    private void Start()
//    {
//        oneFromList = new List<object>(config.wordsList);
//    }


//    public void Generate()
//    {
//        if (config.wordsList.Count > 0)
//        {
//            Debug.Log("в генерации");
//            wordGenerate = config.wordsList[Random.Range(0, config.wordsList.Count)];
//            currentAsset = Instantiate(wordGenerate.ObjOfWord);
//            numberOfGeneration += 1;
//            textOfWord.text = wordGenerate.Words;
//            translate.text = wordGenerate.Translate;
//            transcription.text = wordGenerate.Transcription;
//            pronsance.GetComponent<AudioSource>().clip = wordGenerate.AudioClip;
//            Debug.Log("из генерации");
//        }
//        else
//        {
//            learningBlock.SetActive(false);
//            endPanel.SetActive(true);
//        }

//    }

//    public void Next()
//    {
//        Debug.Log("Внутри некст");
//        if (GameObject.FindWithTag("DeleteWordObject") != null)
//        {
//            Debug.Log("Внутри условия");
//            //GetComponent<MeshFilter>().mesh = wordGenerate.ObjOfWord.GetComponent<MeshFilter>().mesh;
//            Destroy(currentAsset.gameObject);
//            pronsance.GetComponent<AudioSource>().Stop();
//            config.wordsList.Remove(wordGenerate);
//            Debug.Log("Вне условия");

//        }
//        Debug.Log("Not Generation");
//        Generate();
//        Debug.Log("Generation");
//    }

//    public void PronanceAudio()
//    {
//        Debug.Log("Внутри PronanceAudio");
//        pronsance.GetComponent<AudioSource>().Play();
//        Debug.Log("вне PronanceAudio");
//    }
//}

















//using Microsoft.MixedReality.Toolkit.Utilities;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[CreateAssetMenu(menuName = "Config/NewWords", fileName = "NewWords ")]
//public class NewWords : ScriptableObject
//{
//    private NewWordsItems m_NewWordsItems;

//    public void Init(NewWordsItems newWordsItems)
//    {
//        m_NewWordsItems = newWordsItems;
//        GetComponent<MeshFilter>().mesh = m_NewWordsItems.ObjOfWord.GetComponent<MeshFilter>().mesh;//
//    }
//}


//public class NewWords : MonoBehaviour
//{
//    [SerializeField] private NewWordsItemsConfig newWordsItemsConfig;
//    private int i = 0;
//    private int j;
//    // Start is called before the first frame update
//    void Start()
//    {

//        Instantiate(newWordsItemsConfig.newWordsItems[i]);
//    }

//    public void Continue()
//    {
//        Destroy(newWordsItemsConfig.newWordsItems[i]);
//        if (newWordsItemsConfig.newWordsItems.Count == 0)
//            Instantiate(newWordsItemsConfig.newWordsItems[i + 1]);
//        Debug.Log(i);
//    }

//    public void Back()
//    {
//        j = newWordsItemsConfig.newWordsItems.Count;
//        Destroy(newWordsItemsConfig.newWordsItems[j]);
//        Instantiate(newWordsItemsConfig.newWordsItems[j - 1]);
//        Debug.Log(j);
//    }
//}





//using Microsoft.MixedReality.Toolkit.Utilities;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using UnityEngine;
//using UnityEngine.UI;
//using Debug = UnityEngine.Debug;

//public class MenuOfWeapon : MonoBehaviour
//{
//    [SerializeField] private WeaponItemsConfig weaponItemsConfig;
//    [SerializeField] private GameObject buttonPrefab;
//    [SerializeField] private Transform root;
//    [SerializeField] private GridObjectCollection gridObjectCollection;
//    [SerializeField] private PlayerMoney playerMoney;

//    private void Start()
//    {
//        UpdateButtons();
//    }

//    private void UpdateButtons()
//    {
//        for (int i = 0; i < root.childCount; i++)
//        {
//            Destroy(root.GetChild(i).gameObject);
//        }
//        foreach (var weaponItems in weaponItemsConfig.weaponItem)
//        {
//            Debug.Log("dddd");
//            if (!playerMoney.CanBuy(weaponItems.Praice))
//            {
//                continue;
//            }

//            Debug.Log("aaaa");
//            var button = Instantiate(buttonPrefab, root);

//            if (button.TryGetComponent(out ArButton arButton))
//            {
//                arButton.Initialize(weaponItems);
//            }
//            arButton.OnButtonsClicked += () => ProcessBuy(weaponItems.Praice);
//        }
//        StartCoroutine(UpdateCollection());
//    }

//    private void ProcessBuy(int price)
//    {
//        playerMoney.ProcessBuy(price);
//        UpdateButtons();
//    }

//    private IEnumerator UpdateCollection()
//    {
//        yield return new WaitForEndOfFrame();
//        gridObjectCollection.UpdateCollection();
//    }
//}





