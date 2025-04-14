using Assets._03_Scripts.Boss;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public float attackRange = 0.5f;
    public LayerMask bossLayer;
    public Transform attackPoint;
    public int attackDamage = 10;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        PlayerEvents.OnPlayerAttack += Attack;
    }

    private void OnDisable()
    {
        PlayerEvents.OnPlayerAttack -= Attack;

    }
    private void Attack()
    {
        anim.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bossLayer);
        Boss boss = GetComponent<Boss>();

        if (boss != null)
        {
            boss.TakeDamage(attackDamage);
        }

    }
}
    
