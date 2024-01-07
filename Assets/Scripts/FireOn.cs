using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOn : MonoBehaviour
{
    public static Animator anim;
    public static Rigidbody2D rb;
    public static BoxCollider2D bx;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
        rb = GetComponent<Rigidbody2D>(); 
        bx = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        
    }

    
        
            
    
    // Update is called once per frame

}
