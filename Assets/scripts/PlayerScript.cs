using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour
{
    public Rigidbody player;
    public float till = 0.7f;

    public GameObject LaserShot;
    public Transform Gun1;
    public Transform Gun2;
    public float Delay;
    private float nextShoot;

    public GameObject LoseMenu;

    private float xMin = -49f, xMax = 49f, zMin = -24f, zMax = 24f;
    float MoveHorizontal;
    float MoveVertical;

    void Start()
    {
        nextShoot = Time.time;
        LoseMenu.SetActive(false);
    }

    void Update()
    {
        MoveHorizontal = Input.GetAxis("Horizontal");
        MoveVertical = Input.GetAxis("Vertical");

        player.velocity = new Vector3(MoveHorizontal, 0, MoveVertical) * 45f;
        player.rotation = Quaternion.Euler(player.velocity.z * till, 0, -player.velocity.x * till);

        float PositionX = Mathf.Clamp(player.position.x, xMin, xMax);
        float PositionZ = Mathf.Clamp(player.position.z, zMin, zMax);

        player.position = new Vector3(PositionX, 0, PositionZ);

        if ((Input.GetButton("Fire1") || Input.GetButton("Jump")) && Time.time > nextShoot)
        {
            Instantiate(LaserShot, Gun1.position, Quaternion.Euler(90, 0, 0));
            Instantiate(LaserShot, Gun2.position, Quaternion.Euler(90, 0, 0));
            nextShoot = Time.time + Delay;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid" || other.tag == "Enemy")
        {
            Time.timeScale = 0;
            LoseMenu.SetActive(true);
            GameObject menu = GameObject.Find("EndGameMenu");
            menu.GetComponentInChildren<Text>().text = "Score: " + GameObject.Find("Score").GetComponent<Text>().text;
            string score = GameObject.Find("Score").GetComponent<Text>().text;
            
            GameManager.NewTopList(GameManager.Name, Convert.ToInt32(score));
        }
    }
}

