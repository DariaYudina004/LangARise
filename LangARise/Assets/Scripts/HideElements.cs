using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideElements : MonoBehaviour
{
    public GameObject ZoneOfComfort;

    private void OnTriggerEnter(Collider other)
    {
        ZoneOfComfort.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        ZoneOfComfort.SetActive(false);
    }
}
