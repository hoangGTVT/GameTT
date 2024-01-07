using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] playPrefabs;
    public Vector2 lastCheckpointPos;
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
        lastCheckpointPos = new Vector2(-19, -12);
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
    }
}
