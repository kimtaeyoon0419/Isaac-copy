using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;

    public static int collectedAmount;

    public GameObject bulletPrefab;
    private float lastFire;
    [SerializeField] float fireDelay;
    [SerializeField] float bulletSpeed;

    private float horizontal;
    private float vertical;
    private float shootHor;
    private float shootVer;


    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        shootHor = Input.GetAxis("ShootHorizontal");
        shootVer = Input.GetAxis("ShootVertical");

        PlayerMove();
        PlayerAttack();
    }

    void PlayerMove()
    {
        rb.velocity = new Vector3(horizontal * speed, vertical * speed, 0);
    }

    void PlayerAttack()
    {
        if ((shootHor != 0 || shootVer != 0) && Time.time > lastFire + fireDelay)
        {
            Shoot(shootHor, shootVer);
            lastFire = Time.time;
        }

    }
    void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * bulletSpeed : Mathf.Ceil(x) * bulletSpeed,
            (y < 0) ? Mathf.Floor(y) * bulletSpeed : Mathf.Ceil(y) * bulletSpeed,
            0
        );

    }
}
