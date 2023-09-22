using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private CrumbCreator crumbCreator;
    private void Start()
    {
        crumbCreator = GameObject.Find("Spawn").GetComponent<CrumbCreator>();
    }
    public void LoadNextLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        crumbCreator.crumbToUse++;
    }
}
