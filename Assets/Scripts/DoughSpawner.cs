using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoughSpawner : MonoBehaviour
{
    [Header("Dough Prefab")]
    public GameObject rawDoughPrefab; // Assign the RawDough prefab here
    
    [Header("Spawn Settings")]
    public Transform spawnPoint; // Where to spawn the dough (can be this object's transform)
    public Vector3 spawnOffset = Vector3.zero; // Optional offset from spawn point
    
    [Header("Optional: Limit Spawns")]
    public bool limitSpawns = false;
    public int maxSpawns = 5;
    private int currentSpawnCount = 0;

    private XRSimpleInteractable interactable;

    void Awake()
    {
        // If no spawn point is set, use this object's position
        if (spawnPoint == null)
        {
            spawnPoint = transform;
        }

        // Set up XR interaction if available
        interactable = GetComponent<XRSimpleInteractable>();
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelectEntered);
        }
    }

    void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    // Called when object is grabbed/selected in XR
    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        SpawnDough();
    }

    // Public method that can be called from buttons or other scripts
    public void SpawnDough()
    {
        // Check spawn limit
        if (limitSpawns && currentSpawnCount >= maxSpawns)
        {
            Debug.Log("Maximum spawn limit reached!");
            return;
        }

        if (rawDoughPrefab == null)
        {
            Debug.LogError("Raw Dough Prefab is not assigned in DoughSpawner!");
            return;
        }

        // Calculate spawn position
        Vector3 spawnPosition = spawnPoint.position + spawnOffset;
        
        // Spawn the dough
        GameObject newDough = Instantiate(rawDoughPrefab, spawnPosition, spawnPoint.rotation);
        
        // Optional: Add a small upward force to make it "pop up"
        Rigidbody rb = newDough.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * 2f, ForceMode.Impulse);
        }

        currentSpawnCount++;
        Debug.Log($"Spawned dough at {spawnPosition}. Total spawned: {currentSpawnCount}");
    }

    // Alternative: Use OnMouseDown for non-XR interaction
    void OnMouseDown()
    {
        SpawnDough();
    }

    // Optional: Show spawn point in editor
    void OnDrawGizmos()
    {
        if (spawnPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(spawnPoint.position + spawnOffset, 0.1f);
        }
    }
}
