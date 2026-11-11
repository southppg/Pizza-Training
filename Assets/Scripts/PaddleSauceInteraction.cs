using UnityEngine;

public class PaddleSauceInteraction : MonoBehaviour
{
    [Header("Sauce Visual Settings")]
    public GameObject sauceVisual;  // Assign the sauce mesh/particle system on the paddle
    public Material sauceMaterial;  // Optional: Material to apply when sauce is added
    public Color sauceColor = Color.red;  // Color of the sauce (red by default)
    
    [Header("Sauce Detection")]
    public string sauceTag = "Sauce";  // Tag for the sauce object
    
    private bool hasSauce = false;
    private Renderer paddleRenderer;
    private Renderer sauceRenderer;

    private void Start()
    {
        // Hide the sauce visual initially
        if (sauceVisual != null)
        {
            sauceVisual.SetActive(false);
        }
        
        paddleRenderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Paddle collision detected with: " + collision.gameObject.name + " (Tag: " + collision.gameObject.tag + ")");
        
        // Check if we hit the sauce
        if (!hasSauce && collision.gameObject.CompareTag(sauceTag))
        {
            Debug.Log("Sauce tag matched! Applying sauce...");
            ApplySauceToPaddle();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Paddle trigger detected with: " + other.gameObject.name + " (Tag: " + other.gameObject.tag + ")");
        
        // Alternative trigger-based detection
        if (!hasSauce && other.CompareTag(sauceTag))
        {
            Debug.Log("Sauce tag matched! Applying sauce...");
            ApplySauceToPaddle();
        }
    }

    private void ApplySauceToPaddle()
    {
        hasSauce = true;
        
        // Show the sauce visual on the paddle
        if (sauceVisual != null)
        {
            sauceVisual.SetActive(true);
            
            // Apply red color to the sauce visual
            sauceRenderer = sauceVisual.GetComponent<Renderer>();
            if (sauceRenderer != null)
            {
                sauceRenderer.material.color = sauceColor;
            }
        }

        // Optional: Change the paddle material to show sauce
        if (sauceMaterial != null && paddleRenderer != null)
        {
            paddleRenderer.material = sauceMaterial;
            paddleRenderer.material.color = sauceColor;
        }

        Debug.Log("Sauce applied to paddle!");
    }

    // Public method to remove sauce if needed
    public void RemoveSauce()
    {
        hasSauce = false;
        
        if (sauceVisual != null)
        {
            sauceVisual.SetActive(false);
        }
    }

    // Check if paddle has sauce
    public bool HasSauce()
    {
        return hasSauce;
    }
}
