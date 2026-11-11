using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PotCooking : MonoBehaviour
{
    public GameObject soup;
    public float cookTime = 5f;
    public AudioSource cookingAudio;
    public AudioSource tingAudio;
    public Slider timerSlider;  // Drag your timer slider here in Inspector
    public ParticleSystem tomatoParticle; // Assign in Inspector

    private bool isCooking = false;
    private Vector3 finalScale;   // ✅ DECLARED HERE (class level)

    void Start()
    {
        
        // Hide timer bar initially
        if (timerSlider != null)
        {
            timerSlider.gameObject.SetActive(false);
        }
        finalScale = soup.transform.localScale;  // Inspector size
        soup.SetActive(false);
        // Ensure particle is not emitting at start
        if (tomatoParticle != null)
        {
            tomatoParticle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tomato") && !isCooking)
        {
            Destroy(other.gameObject);
            StartCoroutine(CookSoup());
        }
    }

    IEnumerator CookSoup()
    {
        isCooking = true;
        soup.SetActive(true);

        // Play particle effect for the entire cooking duration
        if (tomatoParticle != null)
        {
            tomatoParticle.Play();
        }
        
        // Show timer bar
        if (timerSlider != null)
        {
            timerSlider.gameObject.SetActive(true);
            timerSlider.value = 1f;  // Start full
        }

        // Play cooking audio
        if (cookingAudio != null)
        {
            cookingAudio.Play();
        }

        float timer = 0f;

        while (timer < cookTime)
        {
            timer += Time.deltaTime;
            float progress = timer / cookTime;

            soup.transform.localScale = new Vector3(
                finalScale.x,
                Mathf.Lerp(0.01f, finalScale.y, progress),
                finalScale.z
            );
            
            // Update timer bar (decreases from 1 to 0)
            if (timerSlider != null)
            {
                timerSlider.value = 1f - progress;
            }

            yield return null;
        }

        soup.transform.localScale = finalScale; // lock final size

        // Stop particle effect after cooking is done
        if (tomatoParticle != null)
        {
            tomatoParticle.Stop();
        }
        
        // Hide timer bar when done
        if (timerSlider != null)
        {
            timerSlider.gameObject.SetActive(false);
        }

        // Play ting sound after cooking is done
        if (tingAudio != null)
        {
            tingAudio.Play();
        }
    }
}
