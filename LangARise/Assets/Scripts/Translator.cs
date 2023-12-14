using UnityEngine;
using System.Collections;
using UnityEngine.Localization.Settings;
using TMPro;

public class Translator : MonoBehaviour
{
    private bool active = false;

    private void Start()
    {
        int ID = PlayerPrefs.GetInt("LocalizationKey", 0);
        ChangeLocale(ID);
    }

    public void ChangeLocale(int localeID)
    {
        if (active == true)
        {
            return;
        }
        //if (localeID == 2 )
        //{
        //    GetComponent<TextMeshProUGUI>().font = Resources.Load<TMP_FontAsset>("NotoSerifSC-Light");
        //    Debug.Log("2 SAcsess");
        //}
        //else
        //{
        //    GetComponent<TextMeshProUGUI>().font = Resources.Load<TMP_FontAsset>("Roboto-Light");
        //    Debug.Log("Other SAcsess");
        //}
        StartCoroutine(SetLocalization(localeID));
    }
    IEnumerator SetLocalization(int languageID) { 
    
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageID];
        PlayerPrefs.SetInt("LocalizationKey", languageID);
        active = false;
    }
}
