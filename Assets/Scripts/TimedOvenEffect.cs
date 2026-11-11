using UnityEngine;
using System.Collections;

public class TimedOvenEffect : MonoBehaviour
{
    void Start()
    {
        if (timerSlider != null)
        {
            timerSlider.gameObject.SetActive(false);
        }
    }
    public GameObject fireParticles;
    public GameObject ovenLight;
    public AudioSource ovenAudio;
    public AudioSource tingAudio;

    public GameObject cookedPizzaPrefab; // Assign your cooked pizza prefab here
    public float activeDuration = 5f; // seconds

    private GameObject uncookedPizza = null;

    // Timer slider UI
    public UnityEngine.UI.Slider timerSlider;
    private float timerElapsed = 0f;

    public void StartEffects(GameObject pizza)
    {
        uncookedPizza = pizza;

        fireParticles.SetActive(true);
        ovenLight.SetActive(true);
        ovenAudio.Play();

        // Initialize timer slider
        if (timerSlider != null)
        {
            timerSlider.maxValue = activeDuration;
            timerSlider.value = 0f;
            timerSlider.gameObject.SetActive(true);
            timerElapsed = 0f;
        }

        StartCoroutine(StopEffectsAfterTime());
    }

    IEnumerator StopEffectsAfterTime()
    {
        while (timerElapsed < activeDuration)
        {
            yield return null;
            timerElapsed += Time.deltaTime;
            if (timerSlider != null)
            {
                timerSlider.value = timerElapsed;
            }
        }

        ovenLight.SetActive(false);
        ovenAudio.Stop();

        tingAudio.Play();

        // Replace uncooked pizza with cooked version
        if (uncookedPizza != null && cookedPizzaPrefab != null)
        {
            Debug.Log("Instantiating cooked pizza at: " + uncookedPizza.transform.position + ", parent: " + uncookedPizza.transform.parent);
            GameObject cookedPizza = Instantiate(cookedPizzaPrefab, uncookedPizza.transform.position, uncookedPizza.transform.rotation);
            if (cookedPizza == null)
            {
                Debug.LogError("Cooked pizza instantiation failed!");
            }
            else
            {
                cookedPizza.transform.SetParent(uncookedPizza.transform.parent);
                cookedPizza.SetActive(true); // Ensure the cooked pizza is active
                Debug.Log("Cooked pizza instantiated, parent set, and activated. Active: " + cookedPizza.activeInHierarchy);
            }

            // Destroy uncooked pizza
            Destroy(uncookedPizza);
        }
        else
        {
            Debug.LogWarning("Uncooked pizza or cookedPizzaPrefab is null! uncookedPizza: " + uncookedPizza + ", cookedPizzaPrefab: " + cookedPizzaPrefab);
        }

        // Hide timer slider
        if (timerSlider != null)
        {
            timerSlider.gameObject.SetActive(false);
        }
    }
}
