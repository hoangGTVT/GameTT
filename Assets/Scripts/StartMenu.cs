using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
   
{
    public AudioSource startSound;
    private void Start()
    {
        startSound = GetComponent<AudioSource>();
    }
    public void StartGame()

    {
        startSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
   
}
