using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSword : MonoBehaviour
{
    public static BoxCollider2D doorSword;
    // Start is called before the first frame update
    void Start()
    {
        doorSword = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
