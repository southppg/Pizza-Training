using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatCutted : MonoBehaviour
{
    [Header("Cutting Settings")]
    [SerializeField] private float cutThreshold = 0.5f; // Minimum velocity to cut
    [SerializeField] private GameObject[] cutPieces; // Pre-made cut pieces to spawn
    [SerializeField] private bool isCut = false;

    [Header("Audio")]
    [SerializeField] private AudioClip cuttingSound;
    private AudioSource audioSource;

    [Header("Effects")]
    [SerializeField] private ParticleSystem cutEffect; // Optional particle effect

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is a knife
        if (other.CompareTag("Knife") && !isCut)
        {
            // Get the knife's velocity (requires Rigidbody on knife)
            Rigidbody knifeRb = other.GetComponent<Rigidbody>();
            
            if (knifeRb != null && knifeRb.velocity.magnitude > cutThreshold)
            {
                CutMeat();
            }
        }
    }

    private void CutMeat()
    {
        isCut = true;

        // Play cutting sound
        if (cuttingSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(cuttingSound);
        }

        // Spawn particle effect
        if (cutEffect != null)
        {
            Instantiate(cutEffect, transform.position, Quaternion.identity);
        }

        // Spawn cut pieces
        if (cutPieces != null && cutPieces.Length > 0)
        {
            foreach (GameObject piece in cutPieces)
            {
                if (piece != null)
                {
                    GameObject cutPiece = Instantiate(piece, transform.position, transform.rotation);
                    
                    // Add some force to separate the pieces
                    Rigidbody pieceRb = cutPiece.GetComponent<Rigidbody>();
                    if (pieceRb != null)
                    {
                        Vector3 randomDirection = new Vector3(
                            Random.Range(-1f, 1f),
                            Random.Range(0f, 1f),
                            Random.Range(-1f, 1f)
                        ).normalized;
                        pieceRb.AddForce(randomDirection * 2f, ForceMode.Impulse);
                    }
                }
            }
        }

        // Destroy the original meat object
        Destroy(gameObject);
    }

    // Optional: Visual feedback while knife is in contact
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Knife") && !isCut)
        {
            Rigidbody knifeRb = other.GetComponent<Rigidbody>();
            
            if (knifeRb != null && knifeRb.velocity.magnitude > cutThreshold)
            {
                CutMeat();
            }
        }
    }
}
