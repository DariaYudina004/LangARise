using UnityEngine;

public class HideElements : MonoBehaviour
{
    [SerializeField] private GameObject model;
    [SerializeField] private GameObject target;
    [SerializeField] private float distatce = 2;

    private void Update()
    {
        if (distatce < Vector3.Distance(model.transform.position, target.transform.position))
        {
            distatce = 2;
        }
    }
}
