using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossLV2 : MonoBehaviour
{
    public static int hPBossLV2=15;
    private Transform player;
    public TextMeshProUGUI hpBoss;
    [SerializeField] private GameObject[] waypoint;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;
    private SpriteRenderer Sp;
    public float distanceToPlayerX;
    public float distanceToPlayerY;
    public bool isPlayer = false;
    public Canvas cava;
    public GameObject imageBoss;
    public GameObject textBoss;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (hPBossLV2 == 0)
            {
               
                Destroy(gameObject);
            }
            else
            {
                
                hPBossLV2--;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerLife.hpPlayer == 0)
            {
                AudioManager.instance.Play("Items");
                Destroy(gameObject);
                PlayerLife.Die();
            }
            else
            {
                AudioManager.instance.Play("Items");

                PlayerLife.hpPlayer--;
            }
        }
        
    }
    void Start()

    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hpBoss.text = ""+hPBossLV2;
        if (Vector2.Distance(waypoint[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            Sp.flipX = true;
            if (currentWaypointIndex >= waypoint.Length)
            {
                currentWaypointIndex = 0;
                Sp.flipX = false;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoint[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        Vector2 playerPosition = player.position; // Vị trí của người chơi hoặc đối tượng cần kiểm tra

        Vector2 areaTopLeft = new Vector2(-85.2f, -24.7f);
        Vector2 areaBottomRight = new Vector2(-43.7f, -53f);

        if (IsInsideArea(playerPosition, areaTopLeft, areaBottomRight))
        {
            imageBoss.SetActive(true);
            textBoss.SetActive(true);
        }
        else
        {
            imageBoss.SetActive(false);
            textBoss.SetActive(false);
        }
    }
    private bool IsInsideArea(Vector2 point, Vector2 topLeft, Vector2 bottomRight)
    {
        return point.x >= topLeft.x && point.x <= bottomRight.x && point.y >= bottomRight.y && point.y <= topLeft.y;
    }
}
