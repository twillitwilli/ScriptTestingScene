using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public enum SceneSelection { sampleScene, anotherScene, junkScene, randomScene, scriptTestingScene }
    public SceneSelection loadWhichScene;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != (int)loadWhichScene)
        {
            SceneManager.LoadScene((int)loadWhichScene);
        }
    }
}
