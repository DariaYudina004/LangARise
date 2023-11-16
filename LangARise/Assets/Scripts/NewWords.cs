//using Microsoft.MixedReality.Toolkit.Utilities;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class NewWords : MonoBehaviour
//{
//    [SerializeField] private NewWordsItemsConfig newWordsItemsConfig;
//    private int i = 0 ;
//    private int j;
//    // Start is called before the first frame update
//    void Start()
//    {
//        Instantiate(newWordsItemsConfig.newWordsItems[i]);
//    }
    
//    public void Continue()
//    {
//        Destroy(newWordsItemsConfig.newWordsItems[i]);
//        if (newWordsItemsConfig.newWordsItems.Count == 0 )
//        Instantiate(newWordsItemsConfig.newWordsItems[i + 1]);
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





