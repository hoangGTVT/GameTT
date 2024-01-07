using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

public class PlayManager : MonoBehaviour
{
   
    public GameObject[] playPrefabs;
    public static Vector2 lastCheckpointPos; 
    int characterIndex;
    public static long fruits =0;
    public static long maxFruits;
    [SerializeField] private TextMeshProUGUI cherriesText;
    [SerializeField] private TextMeshProUGUI hpPlayer;
    public static bool isGameover;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;
    public float load;
    public static bool isnew=false;
    public static bool isWin = false;


    // Start is called before the first frame update
    private void Awake()
    {
        isGameover = false;
        BossLV2.hPBossLV2 = 15;
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        if (isnew==false)
        {
            lastCheckpointPos= new Vector2(-35, -12);
            
        }
        else
        {
            lastCheckpointPos.x = PlayerPrefs.GetFloat("PlayerX", 0);
            lastCheckpointPos.y= PlayerPrefs.GetFloat("PlayerY", 0);
        }
        GameObject player = Instantiate(playPrefabs[characterIndex], lastCheckpointPos, Quaternion.identity);
        if (isnew==false && isWin==false)
        {
            PlayerLife.hpPlayer = 5;
        }
        else if(isnew==true)
        {
            PlayerPrefs.GetInt("HpPlayer", 0);
        }else if (isWin == true)
        {
            PlayerLife.hpPlayer = 5;
        }
        
        fruits = 0;
       

    }
    private void Update()
    {
        if (fruits>PlayerPrefs.GetFloat("maxFruits"))
        {
            PlayerPrefs.SetFloat("maxFruits", fruits);
        }
        cherriesText.text = ""+ fruits;
        hpPlayer.text = "" + PlayerPrefs.GetInt("HpPlayer",0);
        
        if (isGameover)
        {
            gameOverScreen.SetActive(true);
        }
        
        
    }
    
    public void ReturnSences()
    {
        SceneManager.LoadScene(1);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
        
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

   

    // Gọi hàm này khi cần lưu tọa độ của người chơi
   
    

}
