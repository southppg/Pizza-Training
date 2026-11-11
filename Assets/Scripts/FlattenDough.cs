using UnityEngine;

public class DoughSwap : MonoBehaviour
{
    public GameObject rawDough;  // Assign RawDough here
    public GameObject flatDough; // Assign FlatDough here
    public AudioSource flattenAudio; // Audio to play when flattening
    
    private bool isFlattened = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isFlattened && collision.gameObject.CompareTag("RollingPin"))
        {
            // Play flatten audio BEFORE deactivating
            if (flattenAudio != null)
            {
                flattenAudio.Play();
            }
            
            rawDough.SetActive(false);
            flatDough.SetActive(true);
            isFlattened = true; // Prevent flipping back
        }
    }
}
