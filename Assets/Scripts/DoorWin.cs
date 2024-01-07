using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorWin : MonoBehaviour
{
    private Transform boss;
    private BoxCollider2D boxWin;
    
    // Start is called before the first frame update
    void Start()
    {
      boxWin = GetComponent<BoxCollider2D>();
      boss = GameObject.FindGameObjectWithTag("Boss").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (boss == null)
        {
            boxWin.isTrigger = true;
        }
    }
}
