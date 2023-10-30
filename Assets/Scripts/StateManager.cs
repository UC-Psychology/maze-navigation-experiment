using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StateManager : MonoBehaviour
{
    public enum WorldState
    {
        TutorialState,
        ExperimentState
    }
  
    public WorldState currentState = WorldState.TutorialState;

    // Update is called once per frame
    void Update()
    {        
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        int coinCount = coins.Length;
        
        if (coinCount == 0 && currentState == WorldState.TutorialState)
        {
            ChangeState(WorldState.ExperimentState);
        }
    }

    public void ChangeState(WorldState newState)
    {
        Debug.Log("Changing state to: " + newState);
        currentState = newState;

        if (newState == WorldState.ExperimentState)
        {
           StartCoroutine(LoadSceneAfterDelay("Experiment", 3));
    }


    IEnumerator LoadSceneAfterDelay(string sceneName, int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    }
}
