using UnityEngine;
using UnityEngine.UI;

public class Localization : MonoBehaviour
{
    [SerializeField] private int language;
    [SerializeField] private string[] text;
    private Text textLine;

    void Start()
    {
        language = PlayerPrefs.GetInt("Language", language);
        textLine = GetComponent<Text>();
        textLine.text = "" + text[language];
    }

}
