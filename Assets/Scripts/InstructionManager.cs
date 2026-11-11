using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    public GameObject[] steps;
    private int currentStep = -1;

    void Start()
    {
        // Hide all steps except the first (welcome panel) at start
        for (int i = 0; i < steps.Length; i++)
        {
            steps[i].SetActive(i == 0);
        }
    }

    // Called by "Let's Go"
    public void StartInstructions()
    {
        // Hide welcome panel (step 0), show first instruction (step 1)
        steps[0].SetActive(false);
        currentStep = 1;
        if (currentStep < steps.Length)
        {
            steps[currentStep].SetActive(true);
        }
    }

    // Called by "Okay"
    public void NextStep()
    {
        steps[currentStep].SetActive(false);
        currentStep++;

        if (currentStep < steps.Length)
        {
            steps[currentStep].SetActive(true);
        }
        else
        {
            Debug.Log("All steps completed");
        }
    }
}
