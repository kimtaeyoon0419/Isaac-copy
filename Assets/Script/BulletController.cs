using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float lifeTime;
    [SerializeField] float bulletAtkDmg;
    [SerializeField] GameObject player;

    void Start()
    {
        StartCoroutine(DeathDelay());
    }

    void Update()
    {
        
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().Death();
            Destroy(gameObject);
        }
    }
}
