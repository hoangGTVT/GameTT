using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject[] playPrefabs;
    public  Vector2 lastCheckpointPos;
    int characterIndex;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("Items");
            Destroy(collision.gameObject);
            GameObject player = Instantiate(playPrefabs[characterIndex], lastCheckpointPos, Quaternion.identity);
        }
    }
    void Start()
    {
        lastCheckpointPos= new Vector2(-84,-19);
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
