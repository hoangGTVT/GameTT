using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBoss : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("Items");
            DoorBoss.box.isTrigger = true;
            Destroy(gameObject);
            
        }
    }
    

}
