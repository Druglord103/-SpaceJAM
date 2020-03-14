using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 40f;
    public GameObject ExplotionPlayer;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.back * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(ExplotionPlayer, other.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

    }
}
