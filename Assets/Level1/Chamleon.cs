using UnityEngine;

public class Chamleon : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attrackCooldown;
    [SerializeField] public float range;
    [SerializeField] private float damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerPlayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private Health playeHealth;

    private bool hit;

    private EnemyPatrol enemyPatrol;
    // Update is called once per frame
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }


    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attrackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("ChamleonAttrack");
            }
        }

        if(enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {


        *//*if (collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(1);
        }*//*

        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(1);
        }
        else
        {
            hit = true;
            anim.SetTrigger("ChamleonDie");

            if (collision.tag == "Enemy")
            {
                collision.GetComponent<Health>().TakeDamage(1);
            }
        }
    }*/

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
        0, Vector2.left, 0, playerPlayer);

        if(hit.collider != null)
        {
            playeHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
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
