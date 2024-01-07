using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuEvents : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HighScore;
    [SerializeField] private float highScore;
    public static float loadLevel=0;
    [SerializeField] public float loadScore=0;
   
    private void Start()
    {
        highScore = PlayerPrefs.GetFloat("maxFruits", 0);

        
    }
    private void Update()
    {
       
        HighScore.text = highScore.ToString();
        loadLevel = PlayerPrefs.GetFloat("LoadLevel", 0);

    }
    public void LoadLevel()
    {
        AudioManager.instance.Play("Key");
        if (loadLevel == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else if (loadLevel == 1)
        {
            SceneManager.LoadScene(3);
        }
    }
       
}
