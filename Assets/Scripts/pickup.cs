using UnityEngine;

public class PickupGroup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add to inventory here if you want

            Destroy(gameObject); // This removes ALL 4 at once
        }
    }
}
