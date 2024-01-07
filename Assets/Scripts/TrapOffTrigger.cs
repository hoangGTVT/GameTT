using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapOffTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] obm;
    public Animator animator;
    public BoxCollider2D bx;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TurnOn();
        }
    }
    public void TurnOn()
    {
        foreach (var obj in obm)
        {
            animator = obj.GetComponent<Animator>();
            bx = obj.GetComponent<BoxCollider2D>();
            animator.SetBool("IsOn", true);
            bx.isTrigger = false;

        }

    }
}
