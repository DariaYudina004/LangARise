using UnityEngine;

public class AudioContinue : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Stop()
    {
        audioSource?.Stop();
        audioSource = null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
