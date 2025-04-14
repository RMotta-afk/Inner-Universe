using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets._03_Scripts.Player;
using UnityEngine;

namespace Assets._03_Scripts.Boss
{
    internal class BossAttack : MonoBehaviour
    {
        public int attackDamage = 200;


        public Vector3 attackOffset;
        public float attackRange = 1f;
        public LayerMask attackMask;

        public void Attack()
        {
            Vector3 pos = transform.position;
            pos += transform.right * attackOffset.x;
            pos += transform.up * attackOffset.y;

            Collider2D colli = Physics2D.OverlapCircle(pos, attackRange, attackMask);

            if (colli != null)
            {
                colli.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            }
        }
        public void OnDrawGizmosSelected()
        {
            Vector3 pos = transform.position;
            pos += transform.right * attackOffset.x;
            pos += transform.up * attackOffset.y;

            Gizmos.DrawWireSphere(pos, attackRange);
        }
    }
}
