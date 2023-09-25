using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //wtf u using for?? idk...
    [SerializeField] private CrumbCreator crumbCreator;

    private void Awake()
    {
    }

    private void Start()
    {
        // crumbCreator = GameObject.Find("Spawn").GetComponent<CrumbCreator>();
    }

    public void LoadNextLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //crumbCreator.crumbToUse++;
    }
}