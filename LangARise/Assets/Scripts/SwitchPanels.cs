using UnityEngine;

public class SwitchPanels : MonoBehaviour
{
    [SerializeField] private GameObject panelTrue;
    [SerializeField] private GameObject[] panelsFalse;

    public void SwitchPanel()
    {
        for(int i = 0; i < panelsFalse.Length; i++)
        {
            panelsFalse[i].SetActive(false);
        }
        panelTrue.SetActive(true);
    }
}
