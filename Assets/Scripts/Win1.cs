using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class Win1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float win = 0;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("Win");
            PlayerPrefs.SetFloat("LoadLevel", win);
            PlayManager.isnew = false;
            PlayManager.isWin = true;
            Invoke("CompleteLever", 2f);
           

        }
    }
    private void CompleteLever()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
