using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public float win = 1;
   
    // Start is called before the first frame update
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("Win");
            PlayerPrefs.SetFloat("LoadLevel", win);
            Invoke("CompleteLever", 2f);
            PlayManager.isnew = false;
            
        }
    }
    private void CompleteLever()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
