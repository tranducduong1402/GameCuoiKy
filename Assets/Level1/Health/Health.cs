using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [SerializeField] private AudioClip deathSound;
   private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        // spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            // hurt
            anim.SetTrigger("hurt");
        }
<<<<<<< HEAD
      else {
        if(!dead){
           anim.SetTrigger("die");
           GetComponent<model>().enabled = false;
           dead = true;
            SoundManager.instance.PlaySound(deathSound);
        }     
=======
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<model>().enabled = false;
                dead = true;
                SceneManager.LoadScene("Lose");
            }

        }
    }
>>>>>>> 3f29d76f422cb173b07f5490dd7dc979dae137bf

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }

    }

}
