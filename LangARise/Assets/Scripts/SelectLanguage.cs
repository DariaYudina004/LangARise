using System.Collections.Generic;
using UnityEngine;


public class SelectLanguage : MonoBehaviour
{
    private bool active = false;
    int number;
    [SerializeField] private List<GameObject> panels;
    private void Start()
    {
        int ID = PlayerPrefs.GetInt("�hooseLang", 0);
        ChangeLocale(ID);
    }

    public void ChangeLocale(int localeID)
    {
        if (active == true)
        {
            return;
        }

        PlayerPrefs.SetInt("�hooseLang", localeID);
        active = false;

    }

    public void PressStart()
    {
        PlayerPrefs.GetInt("�hooseLang", number);
        for (int i = 0; i < panels.Count; i++)
        {
            if (number == i)
            {
                panels[i].SetActive(true);
                break;
            }
        }

    }

}
