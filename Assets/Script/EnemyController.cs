using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Wander,

    Follow,

    Die
};


public class EnemyController : MonoBehaviour
{
    GameObject player;

    [SerializeField] EnemyState currState = EnemyState.Wander;

    [SerializeField] float range;
    [SerializeField] float speed;
    
    private bool chooseDir = false;
    private bool dead = false;
    private Vector3 randomDir;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        switch (currState)
        {
            case (EnemyState.Wander):
                Wender();
                break;
            case (EnemyState.Follow):
                Follow();
                break;
            case (EnemyState.Die):
                break;
        }

        if (IsPlayerInRange(range) && currState != EnemyState.Die)
        {
            currState = EnemyState.Follow;
        }
        else if (!IsPlayerInRange(range) && currState != EnemyState.Die)
        {
            currState = EnemyState.Wander;
        }
    }


    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    private IEnumerator ChoosDirection()
    {
        chooseDir = true;
        yield return new WaitForSeconds(Random.Range(2f , 8f));
        randomDir = new Vector3(0, 0, Random.Range(0, 360));
        Quaternion nextRotation = Quaternion.Euler(randomDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDir= false;
    }

    void Wender()
    {
        if(!chooseDir)
        {
            StartCoroutine(ChoosDirection());
        }

        transform.position += -transform.right * speed * Time.deltaTime;
        if (IsPlayerInRange(range))
        {
            currState = EnemyState.Follow;
        }
    }

    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void Death()
    {
        Destroy(gameObject);
    }

   
    
}
