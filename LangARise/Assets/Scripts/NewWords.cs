using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewWords : MonoBehaviour
{
    [SerializeField] private NewWordsItemsConfig config;
    [SerializeField] private int numberOfGeneration = 1;
    [SerializeField] private NewWordsItems wordGenerate;
    [SerializeField] private TextMeshProUGUI textOfWord;
    [SerializeField] private TextMeshProUGUI translate;
    [SerializeField] private TextMeshProUGUI transcription;
    [SerializeField] private Button pronsance;
    [SerializeField] private GameObject currentAsset;



    public void Generate()
    {
        Debug.Log("в генерации");
        wordGenerate = config.wordsList[Random.Range(0, numberOfGeneration - 1)];
        Instantiate(wordGenerate.ObjOfWord);
        numberOfGeneration += 1;
        textOfWord.text = wordGenerate.Words;
        translate.text = wordGenerate.Translate;
        transcription.text = wordGenerate.Transcription;
        pronsance.GetComponent<AudioSource>().clip = wordGenerate.AudioClip;
        Debug.Log("из генерации");
    }

    public void Next()
    {
        Debug.Log("Внутри некст");
        currentAsset = wordGenerate.ObjOfWord;
        if (numberOfGeneration > 1 || wordGenerate != null)
        {
            Debug.Log("Внутри условия");
            //GetComponent<MeshFilter>().mesh = wordGenerate.ObjOfWord.GetComponent<MeshFilter>().mesh;
            Destroy(currentAsset);
            pronsance.GetComponent<AudioSource>().Stop();
            Debug.Log("Вне условия");

        }
        Debug.Log("Not Generation");
        Generate();
        Debug.Log("Generation");
    }

    public void PronanceAudio()
    {
        Debug.Log("Внутри PronanceAudio");
        pronsance.GetComponent<AudioSource>().Play();
        Debug.Log("вне PronanceAudio");
    }
}


















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





