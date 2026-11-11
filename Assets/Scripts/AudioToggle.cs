using UnityEngine;

public class AudioToggle : MonoBehaviour
{
    public AudioSource audioSource;

    public void ToggleAudio()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
        else
            audioSource.Play();
    }
}
