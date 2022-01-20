using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Primitive : MonoBehaviour
{
    public enum State { WALKING, SHOOTING };

    public State state;

    private Rigidbody2D rb;

    [SerializeField] private float speed = 2;
    private Transform target;
    private Vector3 lookDirection;


    [Header("Move")]
    [SerializeField] private float timeToMove = 5;
    [SerializeField] private float timeToWait = 3;
    private float timingToMove;
    private bool activeMove;

    [Header("Bullet")]
    [SerializeField] private float timeToSpawnBullet = 3;
    private float timingToSpawnBullet;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBullet;

    public float Invunerable = 5f;
    public float vunerable = 0;
    public bool receivedDamage;

    // Start is called before the first frame update
    void Start()
    {
        activeMove = true;
        timingToMove = 0;
        timingToSpawnBullet = 0;
        rb = this.GetComponent<Rigidbody2D>();
        try
        {
        target = GameObject.Find("Player").transform;

        } catch (MissingReferenceException e)
        {
            print("Player not found");
        }
    }

    void Update()
    {
        if (activeMove)
        {
            timingToMove += Time.deltaTime;
            MoveToTarget();
            if (timingToMove > timeToMove)
            {
                timingToMove = 0;
                state = State.SHOOTING;
                StartCoroutine(ChangeState());
            }
        }

        if (state == State.SHOOTING)
        {
            timingToSpawnBullet += Time.deltaTime;
            if (timingToSpawnBullet > timeToSpawnBullet)
            {
                timingToSpawnBullet = 0;
                GameObject clone = Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
                //clone.GetComponent<Bullet>().targetPos = target.position; 
            }
        }


    }

    IEnumerator ChangeState()
    {
        activeMove = false;
        yield return new WaitForSeconds(timeToWait);
        activeMove = true;
    }

    private void MoveToTarget()
    {
        state = State.WALKING;
        timingToSpawnBullet = 0;
        lookDirection = (target.position - transform.position).normalized;
        transform.Translate(lookDirection * Time.deltaTime * speed);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (receivedDamage == false)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                Debug.Log("Recibi daño");
                receivedDamage = true;
            }
        }
        /*
        if (receivedDamage == true)
        {
            vunerable++;
        }
        if (vunerable == Invunerable)
        {
            receivedDamage = false;
            vunerable = 0;
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (receivedDamage == false)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                receivedDamage = true;
            }
        }
        /*
        if (receivedDamage == true)
        {
            vunerable++;
        }
        if (vunerable == Invunerable)
        {
            receivedDamage = false;
            vunerable = 0;
        }
        */
    }

    public void checkDeath()
    {
            Destroy(this.gameObject);
    }
}
