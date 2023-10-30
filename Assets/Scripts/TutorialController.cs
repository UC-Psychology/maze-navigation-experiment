using UnityEngine.UI;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public TMPro.TextMeshProUGUI tutorialText;  // Assign in Inspector
    private string currentSequence = "";
    private int currentStep = 0;
    private string[] tutorialSteps = {"Press W", 
    "Press A to turn right", 
    "Press S to move backward", 
    "Press D to turn left",
    "Press Q to move left", 
    "Press E to move right"};

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                currentSequence += "W";
                if (currentStep == 0)
                {
                    tutorialText.text = tutorialSteps[++currentStep];
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                currentSequence += "A";
                if (currentStep == 1)
                {
                    tutorialText.text = tutorialSteps[++currentStep];
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                currentSequence += "S";
                if (currentStep == 2)
                {
                    tutorialText.text = tutorialSteps[++currentStep];
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                currentSequence += "D";
                if (currentStep == 3)
                {
                    tutorialText.text = tutorialSteps[++currentStep];
                }
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                currentSequence += "Q";
                if (currentStep == 4)
                {
                    tutorialText.text = tutorialSteps[++currentStep];
                }
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                currentSequence += "E";
                if (currentStep == 5)
                {
                    tutorialText.text = "Congratulations! You have completed the tutorial. Now, collect the coins to advance to the Maze Experiment!";
                }
            }
        }
    }
}
