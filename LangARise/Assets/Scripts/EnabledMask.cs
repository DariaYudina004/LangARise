using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class EnabledMask : MonoBehaviour
{
    [SerializeField] private GameObject fuckingScrollingPanel;

    public void SOS()
    {
        fuckingScrollingPanel.GetComponent<ScrollingObjectCollection>().MaskEnabled = true;
    }
    
}
