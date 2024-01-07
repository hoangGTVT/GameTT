using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemies;
    public int characterEnemy;
    public Transform Player;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player")){
            GameObject collidedEnemy = collision.gameObject;
            if (ArrayContainsEnemy(collidedEnemy))
            {
                AudioManager.instance.Play("EnemyDie");
                Destroy(collidedEnemy);
                PlayManager.fruits += 5;
            }
            
        }
    }
   
          
   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            if (PlayerLife.hpPlayer == 0)
            {
                PlayerLife.Die();
            }
            else
            {
                PlayerLife.hpPlayer--;
            }
    }*/
    bool ArrayContainsEnemy(GameObject enemy)
    {
        foreach (GameObject e in enemies)
        {
            if (e == enemy)
            {
                return true;
            }
        }
        return false;
    }


}
