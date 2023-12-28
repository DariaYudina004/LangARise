using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewWords : MonoBehaviour
{
    [SerializeField] private NewWordsItemsConfig config;

    [SerializeField] private int numberOfGeneration = 0;
    [SerializeField] private NewWordsItems wordGenerate;
    public NewWordsItems WordGenerate { get { return wordGenerate; } set { wordGenerate = value; } }
    [SerializeField] private TextMeshProUGUI textOfWord;
    public TextMeshProUGUI TextOfWord { get { return textOfWord; } set { textOfWord = value; } }
    [SerializeField] private TextMeshProUGUI translate;
    public TextMeshProUGUI Translate { get { return translate; } set { translate = value; } }
    [SerializeField] private TextMeshProUGUI transcription;
    public TextMeshProUGUI Transcription { get { return transcription; } set { transcription = value; } }
    [SerializeField] private Button pronsance;
    public Button Pronsance { get { return pronsance; } set { pronsance = value; } }
    [SerializeField] private GameObject currentAsset;
    public GameObject CurrentAsset { get { return currentAsset; } set { currentAsset = value; } }
    [SerializeField] private GameObject endPanel;
    public GameObject EndPanel { get { return endPanel; } set { endPanel = value; } }
    [SerializeField] private GameObject learningBlock;
    public GameObject LearningBlock { get { return learningBlock; } set { learningBlock = value; } }


    private List<object> oneFromList;
    public List<object> OneFromList { get { return oneFromList; } set { oneFromList = value; } }
    private int oneVersion;
    public int OneVersion { get { return oneVersion; } set { oneVersion = value; } }

    //[SerializeField] private GameObject target;
    //[SerializeField] private float distatce = 1;
    //[SerializeField] private GameObject cameraOfc;

    private void Start()
    {
        oneFromList = new List<object>(config.wordsList);
    }


    //private void Update()
    //{
    //    if (distatce < Vector3.Distance(currentAsset.transform.position, target.transform.position) && distatce < Vector2.Distance(currentAsset.transform.position, cameraOfc.transform.position))
    //    {
    //        distatce = 1;
    //    }
    //}

    public void Generate()
    {
        if (oneFromList.Count == 0)
        {
            LearningBlock.SetActive(false);
            EndPanel.SetActive(true);
        }

        OneVersion = Random.Range(0, OneFromList.Count);
        WordGenerate = OneFromList[OneVersion] as NewWordsItems;
        CurrentAsset = WordGenerate.ObjOfWord;
        Instantiate(CurrentAsset);
        numberOfGeneration += 1;
        TextOfWord.text = WordGenerate.Words;
        Translate.text = WordGenerate.Translate;
        Transcription.text = WordGenerate.Transcription;
        Pronsance.GetComponent<AudioSource>().clip = WordGenerate.AudioClip;
        Debug.Log(CurrentAsset.ToString());
    }

    public void Next()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("DeleteWordObject");
        for(int i = 0; i < obj.Length; i++)
        {
            Destroy(obj[i]);
        }

        Pronsance.GetComponent<AudioSource>().Stop();
        if (OneFromList.Count > 0)
        {
            OneFromList.Remove(WordGenerate);
            Generate();
        }
        else
        {
            LearningBlock.SetActive(false);
            EndPanel.SetActive(true);
        }

    }

    public void PronanceAudio()
    {
        Pronsance.GetComponent<AudioSource>().Play();
    }
}


//using Microsoft.MixedReality.Toolkit;
//using System.Collections.Generic;
//using TMPro;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.UI;

//public class NewWords : MonoBehaviour
//{
//    [SerializeField] private NewWordsItemsConfig config;

//    [SerializeField] private int numberOfGeneration = 0;
//    [SerializeField] private NewWordsItems wordGenerate;
//    public NewWordsItems WordGenerate { get { return wordGenerate; } set { wordGenerate = value; } }
//    [SerializeField] private TextMeshProUGUI textOfWord;
//    public TextMeshProUGUI TextOfWord { get { return textOfWord; } set { textOfWord = value; } }
//    [SerializeField] private TextMeshProUGUI translate;
//    public TextMeshProUGUI Translate { get { return translate; } set { translate = value; } }
//    [SerializeField] private TextMeshProUGUI transcription;
//    public TextMeshProUGUI Transcription { get { return transcription; } set { transcription = value; } }
//    [SerializeField] private Button pronsance;
//    public Button Pronsance { get { return pronsance; } set { pronsance = value; } }
//    [SerializeField] private GameObject currentAsset;
//    public GameObject CurrentAsset { get { return currentAsset; } set { currentAsset = value; } }
//    [SerializeField] private GameObject endPanel;
//    public GameObject EndPanel { get { return endPanel; } set { endPanel = value; } }
//    [SerializeField] private GameObject learningBlock;
//    public GameObject LearningBlock { get { return learningBlock; } set { learningBlock = value; } }
//    ////[SerializeField] private float time = 0;
//    //[SerializeField] private GameObject[] obj;
//    //private int i = 0;


//    private List<object> oneFromList;
//    public List<object> OneFromList { get { return oneFromList; } set { oneFromList = value; } }
//    private int oneVersion;
//    public int OneVersion { get { return oneVersion; } set { oneVersion = value; } }// Один Экземпляр

//    private void Start()
//    {
//        oneFromList = new List<object>(config.wordsList);
//    }

//    public void Generate()
//    {
//        if (OneFromList.Count <= 0)
//        {
//            Debug.Log("из генерации");
//            Debug.Log("Нет Элементов в списке ");
//            LearningBlock.SetActive(false);
//            EndPanel.SetActive(true);
//            Debug.Log("Нет Элементов в списке ");
//        }
//        else
//        {
//            Debug.Log("в генерации");
//            OneVersion = Random.Range(0, OneFromList.Count);
//            WordGenerate = OneFromList[OneVersion] as NewWordsItems;
//            CurrentAsset = WordGenerate.ObjOfWord;
//            Instantiate(CurrentAsset);
//            numberOfGeneration += 1;
//            TextOfWord.text = WordGenerate.Words;
//            Translate.text = WordGenerate.Translate;
//            Transcription.text = WordGenerate.Transcription;
//            Pronsance.GetComponent<AudioSource>().clip = WordGenerate.AudioClip;

//        }
//        Debug.Log(CurrentAsset.ToString());
//    }

//    public void Next()
//    {

//        Debug.Log("здесь кьюрент " + CurrentAsset + " ассет ");
//        //Debug.Log("Внутри некст");
//        //obj = GameObject.FindGameObjectsWithTag("DeleteWordObject");
//        Destroy(CurrentAsset);

//        Pronsance.GetComponent<AudioSource>().Stop();
//        if (OneFromList.Count > 0)
//        {
//            Debug.Log("Внутри условия");
//            //GetComponent<MeshFilter>().mesh = wordGenerate.ObjOfWord.GetComponent<MeshFilter>().mesh;
//            OneFromList.Remove(WordGenerate);
//            Debug.Log("Not Generation");
//            Generate();
//            Debug.Log("Generation");
//            Debug.Log("Вне условия");
//        }
//        else
//        {
//            Debug.Log("Нет Элементов в списке ");
//            LearningBlock.SetActive(false);
//            EndPanel.SetActive(true);
//            Debug.Log("Нет Элементов в списке ");
//        }

//    }

//    public void PronanceAudio()
//    {
//        Debug.Log("Внутри PronanceAudio");
//        Pronsance.GetComponent<AudioSource>().Play();
//        Debug.Log("вне PronanceAudio");
//    }
//}












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





