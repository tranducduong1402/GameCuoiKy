using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatLevel2 : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private int damage;

    private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerPlayer;

    private Animator anim;
    private Health playeHealth;

    private EnemyPatrol enemyPatrol;
    // Update is called once per frame
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponent<EnemyPatrol>();
    }


    private void Update()
    {
        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * transform.localScale.x,
        new Vector3(boxCollider.bounds.size.x, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
        0, Vector2.left, 0, playerPlayer);

        if (hit.collider != null)
        {
            playeHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private void DamagePlayer()
    {
        // if player still in range damage him
        if (PlayerInSight())
        {
            // damage player health
            playeHealth.TakeDamage(damage);
        }
    }
}
