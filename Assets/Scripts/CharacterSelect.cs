using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int selectdCharacter;
   
   
    private void Awake()
    {
        Time.timeScale = 1;
        
        selectdCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject player in skins) { 
            player.SetActive(false);
            skins[selectdCharacter].SetActive(true);
        }
    }
    public void ChangeNext()
    {
        AudioManager.instance.Play("Key");
        skins[selectdCharacter].SetActive(false);
        selectdCharacter++;
        if (selectdCharacter == skins.Length)
        {
            selectdCharacter = 0;
        }
        skins[selectdCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectdCharacter);
    }
    public void PreviousNext()
    {
        AudioManager.instance.Play("Key");
        skins[selectdCharacter].SetActive(false);
        selectdCharacter--;
        if (selectdCharacter == -1)
        {
            selectdCharacter = skins.Length-1;
        }
        skins[selectdCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectdCharacter);
    }
}
