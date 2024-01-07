using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class BossController : MonoBehaviour
{
    // Start is called before the first frame update
 
    public float maxChaseDistance = 50f;
    public  Animator bossAni;
    private Transform player;
    public static int hpBoss = 3;
    private enum MovementState { idle, running, dead}
    public GameObject bulletPrefab;
    public float fireRate=1f;
    public Transform bulletSpawnPoint;
    public bool isPlayer=false;
    public float distanceToPlayerX;
    public float distanceToPlayerY;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("Die");
            Destroy(gameObject);
        }
    }
   
void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bossAni = GetComponent<Animator>();
        // Tìm player có tag là "Player" trong scene và lưu tham chiếu vào biến player
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Shoot", fireRate, fireRate);

    }
    void Update()
    {

        Vector2 playerPosition = player.transform.position; // Vị trí của người chơi hoặc đối tượng cần kiểm tra

        Vector2 areaTopLeft = new Vector2(4.4f, 39.5f);
        Vector2 areaBottomRight = new Vector2(25f, 35.6f);

        if (IsInsideArea(playerPosition, areaTopLeft, areaBottomRight))
        {
            isPlayer = true;
        }
        else
        {
            isPlayer= false;
        }
    }
    void Shoot()
    {
        if (isPlayer)
        {
            GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
       
    }
    private bool IsInsideArea(Vector2 point, Vector2 topLeft, Vector2 bottomRight)
    {
        return point.x >= topLeft.x && point.x <= bottomRight.x && point.y >= bottomRight.y && point.y <= topLeft.y;
    }


}
