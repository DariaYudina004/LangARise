using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Accaunt : MonoBehaviour
{
    public static string Name;
    public static string Email;
    public static string Password;
    [SerializeField] private List<TextMeshProUGUI> dataOfUser;
    [SerializeField] private GameObject noData;
    [SerializeField] private GameObject noInput;
    [SerializeField] private TextMeshProUGUI finalAccaunt;    



    public void Read()
    {
        for (int i = 0; i < dataOfUser.Count; i++)
        {
            dataOfUser[i] = GetComponent<TextMeshProUGUI>();
        }
    }

    public void Save()
    {
       
        for(int i = 0;i < dataOfUser.Count; i++)
        {
            if (dataOfUser[i] != null)
            {
                Name = dataOfUser[0].text.ToString();
                Email = dataOfUser[1].text.ToString();
                Password = dataOfUser[2].text.ToString();
                Debug.Log("FFF");
            }
            

        }
       if (dataOfUser[0] == null || dataOfUser[1] == null || dataOfUser[2] == null )
       {
            noData.SetActive(true);
            noInput.SetActive(false);
       }
       else
       {
            Debug.Log("Co[hfyty");
       }
       
    }   
   
}
