using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get;  private set; }
    private Animator anim;
    private bool dead;

    /*[Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;*/

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    //private bool invulnerable;


    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        //spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {   
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
        if(currentHealth> 0 ){
            // hurt
            anim.SetTrigger("hurt");
            //StartCoroutine(Invunerability());
        }
        else {
            if(!dead) 
            {
                anim.SetTrigger("die");

                // Player
                if (GetComponent<model>().enabled != null)
                {
                    GetComponent<model>().enabled = false;
                }

                // Enemy
                /*if (GetComponentInParent<EnemyPatrol>() != null)
                    GetComponentInParent<EnemyPatrol>().enabled = false;

                if(GetComponent<Chamleon>() != null)
                {
                    GetComponent<Chamleon>().enabled = false;
                }

                if (GetComponent<AngryPigLevel1>() != null)
                {
                    GetComponent<AngryPigLevel1>().enabled = false;
                }

                if (GetComponent<BatLevel2>() != null)
                    GetComponent<BatLevel2>().enabled = false;*/

                // Deactivate all attached components classes
                foreach(Behaviour component in components)
                    component.enabled = false;

                anim.SetBool("grounded", true);
                dead = true;

            }     

        }
    } 
    
    public void AddHealth(float _value) {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0 , startingHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            TakeDamage(1);
        }
        
    }

    /*private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }*/

}
