using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ExplotionPlayer;
    public Transform Gun;
    public GameObject LaserShot;
    private float nextShoot;
    private float delay = 1f;
    private Rigidbody Enemy;
    private bool Left;

    void Start()
    {
        nextShoot = Time.time;
        Enemy = GetComponent<Rigidbody>();
        Left = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > 22)  Enemy.velocity = new Vector3(0, 0, -1) * 20f;
        else
        {
            if (Left)
            {
                if(transform.position.x > -49) Enemy.velocity = new Vector3(-1, 0, 0) * 20f;
                else Left = !Left;
            }
            else
            {
                if (transform.position.x < 49) Enemy.velocity = new Vector3(1, 0, 0) * 20f;
                else Left = !Left;
            }
        }


        if (Time.time > nextShoot)
        {
            Instantiate(LaserShot, Gun.position, Quaternion.Euler(90, 0, 0));
            nextShoot = Time.time + delay;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(ExplotionPlayer, other.transform.position, Quaternion.identity);
            Instantiate(ExplotionPlayer, transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.tag == "Asteroid" || other.tag == "GameBox" || other.tag == "Enemy")
        {
            return;
        }
        Instantiate(ExplotionPlayer, transform.position, Quaternion.identity);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
