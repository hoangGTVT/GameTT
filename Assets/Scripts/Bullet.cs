using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed = 5f;
    public float bulletLifetime = 5f;
    public float fireRate = 2f;
    private float timer = 0f;
    public static BoxCollider2D boxBullet;
    public AudioSource BulletSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            if (PlayerLife.hpPlayer == 0)
            {
               BulletSound.Play();
                Destroy(gameObject);
                PlayerLife.Die();
            }
            else
            {
                BulletSound.Play();
                Destroy(gameObject);
                PlayerLife.hpPlayer--;
            }


        }
    }
     void Start()
    {
        boxBullet = GetComponent<BoxCollider2D>();  
        BulletSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        MoveBullet();
        CheckLifetime();
    }

    void MoveBullet()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    void CheckLifetime()
    {
        timer += Time.deltaTime;
        if (timer >= bulletLifetime)
        {
            Destroy(gameObject);
        }
    }
    

}
