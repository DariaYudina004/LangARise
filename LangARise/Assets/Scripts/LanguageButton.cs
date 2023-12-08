using UnityEngine;

public class LanguageButton : MonoBehaviour
{
    public int language;

    void Start()
    {
        GetLang();
    }

    private void GetLang()
    {
        language = PlayerPrefs.GetInt("Language", language);
    }
    public void RussianLanguage()
    {
        language = 0;
        PlayerPrefs.SetInt("language", language);
        GetLang();

    }

    public void EngLang()
    {
        language = 1;
        PlayerPrefs.SetInt("language", language);
        GetLang();
    }

    public void ChinaLang()
    {
        language = 2;
        PlayerPrefs.SetInt("language", language);
        GetLang();
    }

    public void ItalLang()
    {
        language = 3;
        PlayerPrefs.SetInt("language", language);
        GetLang();
    }
}
