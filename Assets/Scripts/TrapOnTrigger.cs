using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapOnTrigger : MonoBehaviour
{
    public GameObject[] obm;
    public Animator animator;
    public BoxCollider2D bx;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            TurnOff();
        }
    }
    public void TurnOff()
    {
        foreach (var obj in obm)
        {
            animator=obj.GetComponent<Animator>();
            bx = obj.GetComponent<BoxCollider2D>();
            animator.SetBool("IsOn", false);
            bx.isTrigger = true;
          
        }
       
    }

}
