using UnityEngine;

public class ExhauseFan : MonoBehaviour
{
    public AudioSource tvAudio;

    public void PlayTV()
    {
        tvAudio.Play();
    }

    public void StopTV()
    {
        tvAudio.Stop();
    }

    public void ToggleTV()
    {
        if (tvAudio.isPlaying)
            tvAudio.Stop();
        else
            tvAudio.Play();
    }
}
