using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitch : MonoBehaviour
{
    [SerializeField] private AudioSource currentAudioSourse;
    public AudioSource CurrentAudioSourse => currentAudioSourse;
    [SerializeField] private AudioClip[] audioSourcesList;
    public AudioClip[] AudioSourcesList => audioSourcesList;
    private int number = 0;

    public void StopPlayAudio(int index)
    {
        currentAudioSourse.GetComponent<AudioSource>().clip = AudioSourcesList[index];
        currentAudioSourse.Play();
    }
    
    public void Pause()
    {
        number++;
        if (number == 1)
        {
            currentAudioSourse.Pause();

        }
        if (number ==2 )
        {
            currentAudioSourse.UnPause();
            number = 0;
        }
    }
}
