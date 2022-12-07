using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   [SerializeField] private float attackCooldown ;
    private Animator anim;
    private mvcControll m_Controll;
    private float cooldownTimer = Mathf.Infinity;
    void Start()
    {
         anim = GetComponent<Animator>();
          m_Controll =GetComponent<mvcControll>();
    }

    void Update()
    {
         if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown ){
          Attack();
        }
        cooldownTimer += Time.deltaTime;
    }
   private void Attack(){
    anim.SetTrigger("attack");
     cooldownTimer = 0 ;
   }
}
