using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject player;
    public GameObject LevelPanel;
    PauseScript pauseScript;

    private void Start()
    {
        pauseScript = GameObject.Find("UICanvas (working)").GetComponent<PauseScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pauseScript.Pause();
            pauseScript.pausePanel.SetActive(false);
            LevelPanel.SetActive(true);
        }
    }

   
}
