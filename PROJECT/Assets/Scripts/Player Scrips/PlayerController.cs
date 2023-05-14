using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int playerScore;

    public Text ScoreText;
    public Text scoreText;

    public SpawnEnemy logic;

    public GameObject Player_Bullet;
    public Transform attack_Point;

    public int player_health = 2;
    public int current_player_Health;

    public float attack_Timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack;

    public float speed = 5f;
    public float min_y, max_y;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.gameOver();
        ScoreText.text = "score:"+scoreText.text;
        scoreText.gameObject.SetActive(false);
    }
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<SpawnEnemy>();
        current_player_Health = player_health;
        current_Attack_Timer = attack_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();

    }
    void MovePlayer()
    {
        if (Input.GetAxis("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime * Input.GetAxis("Vertical");


            if (temp.y > max_y)
            {
                temp.y = max_y;
            }

            transform.position = temp;

        }
        else if (Input.GetAxis("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime * Input.GetAxis("Vertical");

            if (temp.y < min_y)
            {
                temp.y = min_y;
            }

            transform.position = temp;
        }
    }
    void Attack()
    {
        current_Attack_Timer += Time.deltaTime;
        if(current_Attack_Timer > attack_Timer)
        {
            canAttack = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {if(canAttack == true)
            {
                canAttack = false;
                current_Attack_Timer = 0;
                Instantiate(Player_Bullet, attack_Point.position, Quaternion.identity);
                // play sound
            }
            
        }



    }
}// class








