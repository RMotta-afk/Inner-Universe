using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets._03_Scripts.Core.Events;
using UnityEngine;

namespace Assets._03_Scripts.Boss
{
    internal class BossWalk : StateMachineBehaviour
    {
        public float speed = 2.5f;
        public float attackRange = 6f;
        Transform player;
        Rigidbody2D rb;
        Boss boss;

        private void OnEnable()
        {
            BossEvents.OnPlayerKilled += Stop;
            ;
        }

        private void OnDisable()
        {
            BossEvents.OnPlayerKilled -= Stop;

        }

        private void Stop()
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            rb = animator.GetComponent<Rigidbody2D>();
            boss = animator.GetComponent<Boss>();
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            boss.LookAtPlayer();
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);

            var debugDistance = Vector2.Distance(player.position, rb.position);

            if (Vector2.Distance(player.position, rb.position) <= attackRange)
            {
                animator.SetTrigger("Attack");
            }

        }
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.ResetTrigger("Attack");
        }
    }
}
