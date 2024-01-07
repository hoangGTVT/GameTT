using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
   
    public static Animator anim;
    public static Rigidbody2D rb;
    public static int hpPlayer = 5;
    public Vector2 playerPosition;

    private int currentIndex = 0;
    public static BoxCollider2D boxPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }
    private void Update()
    {
        boxPlayer= GetComponent<BoxCollider2D>();
        PlayerPoS();
        PlayerPrefs.SetInt("HpPlayer", hpPlayer);
        
    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            int isCheck = collision.gameObject.GetComponent<Checkpoint>().index;
            if (isCheck > currentIndex)
            {
                currentIndex = isCheck;
                AudioManager.instance.Play("Items");
                PlayManager.isnew = true;
                PlayerPrefs.SetFloat("PlayerX", transform.position.x);
                PlayerPrefs.SetFloat("PlayerY", transform.position.y);

            }
            else
            {
                AudioManager.instance.Play("Items");
            }

        }
        if (collision.gameObject.CompareTag("Trap")) {
            if (hpPlayer == 0)
            {
                Die();
            }
            else
            {
                AudioManager.instance.Play("Items");
                hpPlayer--;
                
            }
           
        }
        if (collision.gameObject.CompareTag("Boss") )
        {
            AudioManager.instance.Play("Items");
            rb.AddForce(Vector3.up * 5f, ForceMode2D.Impulse);


        }
       

        if (collision.gameObject.CompareTag("Enemy")) {
            if (hpPlayer == 0)
            {
                Die();
            }
            else
            {
                AudioManager.instance.Play("Items");
                hpPlayer--;
            }
        }
        if (collision.gameObject.CompareTag("Heart"))
        {
            AudioManager.instance.Play("Items");
            hpPlayer++;
            Destroy(collision.gameObject);
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruits"))
        {
            AudioManager.instance.Play("Items");
            Destroy(collision.gameObject);
            PlayManager.fruits++;


        }

        if (collision.gameObject.CompareTag("TrapJump"))
        {
            AudioManager.instance.Play("Items");
            rb.AddForce(Vector3.up * 40f, ForceMode2D.Impulse);
            TrapJump.anim.SetBool("IsJump", true);

        }
        if (collision.gameObject.CompareTag("Slowly"))
        {
            PlayerMovement.MoveSpeed = 2f;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {

            AudioManager.instance.Play("Items");
            Destroy(collision.gameObject);
            PlayManager.fruits += 5;
        }

    }
   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TrapJump"))
        {
            TrapJump.anim.SetBool("IsJump", false);
        }
        if (collision.gameObject.CompareTag("Slowly"))
        {
            PlayerMovement.MoveSpeed = 7f;
        }
    }
    
  public static void Die()
    {
        AudioManager.instance.Play("Die");
        
        //rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        Time.timeScale = 0;
        PlayManager.isGameover = true;
        

    }

   public void PlayerPoS()
    {
        float PlayerX= transform.position.x;
        float PlayerY= transform.position.y;
        
    }
    

}
