using UnityEngine;

public class Cheese : MonoBehaviour
{
    public GameObject rawDough;  // Assign RawDough here
    public GameObject flatDough; // Assign FlatDough here
    private bool isFlattened = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isFlattened && collision.gameObject.CompareTag("Cheese"))
        {
            rawDough.SetActive(false);
            flatDough.SetActive(true);
            isFlattened = true; // Prevent flipping back

            Destroy(collision.gameObject); // Destroy the tomato
        }
    }
}
