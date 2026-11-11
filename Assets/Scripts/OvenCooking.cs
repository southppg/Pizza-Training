using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class OvenCooking : MonoBehaviour
{
    public XRSocketInteractor ovenSocket;
    public float cookingTime = 15f;

    public AudioSource cookingAudio;
    public AudioSource doneAudio;

    private bool isCooking = false;
    private GameObject currentPizza = null;

    void Update()
    {
        if (!isCooking && ovenSocket.hasSelection)
        {
            GameObject pizza = ovenSocket.GetOldestInteractableSelected()
                .transform.gameObject;

            // Only start cooking if this is a new pizza (not the one we're already tracking)
            if (pizza.CompareTag("UncookedPizza") && pizza != currentPizza)
            {
                currentPizza = pizza;
                isCooking = true;  // Set this BEFORE starting coroutine to prevent multiple triggers
                StartCoroutine(CookPizza(pizza));
            }
        }
    }

    IEnumerator CookPizza(GameObject uncookedPizza)
    {
        // Play cooking sound
        cookingAudio.Play();

        yield return new WaitForSeconds(cookingTime);

        // Spawn cooked pizza
        Transform socketTransform = ovenSocket.attachTransform;
        Instantiate(Resources.Load<GameObject>("CookedPizza"),
            socketTransform.position,
            socketTransform.rotation);

        // Stop cooking sound
        cookingAudio.Stop();

        // Play done sound
        doneAudio.Play();

        Destroy(uncookedPizza);

        currentPizza = null;
        isCooking = false;
    }
}