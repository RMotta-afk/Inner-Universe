using Assets._03_Scripts.Boss;
using Assets._03_Scripts.Core.Events;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public float attackRange = 1f;
    public LayerMask bossLayer;
    public Transform attackPoint;
    public int attackDamage = 100;
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
    private void Attack(string trigger)
    {
        anim.SetTrigger(trigger);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bossLayer);
        BossEvents.TriggerBossAttacked(attackDamage);

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

