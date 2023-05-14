using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public Text ScoreText;
    public Text scoreText;
    public SpawnEnemy logic;
    public GameObject Enemy_Bullet;
    public Transform Enemy_Attack_Point;
    public Transform Enemy_Attack_Point2;
    public float attack_Timer = 0.7f;
    private float current_Attack_Timer;
    private bool canAttack;
    private Animator animator;
    public float speed = 5f;
    public float rotate_Speed = 50f;
    public int enemy_Health = 2;
    private int current_enemy_Health = 0;

    // Start is called before the first frame update

    void delete_enemy_ship()
    {
        gameObject.SetActive(false);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<SpawnEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        Attack();
        if (transform.position.x < -8.5) //game over if enemy reaches the end
        {
            logic.gameOver();
            scoreText.gameObject.SetActive(false);
            ScoreText.text = "score:" + scoreText.text;
        }
    }
    void MoveEnemy()
    {
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

        }

    }
    void Attack()
    {
        current_Attack_Timer += Time.deltaTime;
        if (current_Attack_Timer > attack_Timer)
        {
            canAttack = true;
        }
        if (canAttack == true)
        {
            canAttack = false;
            current_Attack_Timer = 0;
            Instantiate(Enemy_Bullet, Enemy_Attack_Point.position, Quaternion.identity);
            Instantiate(Enemy_Bullet, Enemy_Attack_Point2.position, Quaternion.identity);
            // play sound
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(current_enemy_Health == 1) //check if enemy has been hit before, if it has, trigger animation and delete gameobject
        {
            animator.SetTrigger("Destroyed");
            Invoke("delete_enemy_ship", 0.5f);
            logic.addScore();
        }
        if(current_enemy_Health == 0)
        {
            current_enemy_Health += 1;
        }
 
    }
} // class
