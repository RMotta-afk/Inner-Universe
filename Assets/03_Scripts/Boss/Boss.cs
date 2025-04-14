using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets._03_Scripts.Core.Events;
using TMPro;
using UnityEngine;

namespace Assets._03_Scripts.Boss
{
    public class Boss : MonoBehaviour
    {
        public Transform player;
        public bool isFlipped = false;
        private Animator anim;
        private Rigidbody2D rb;
        private int _totalHealth = 250;
        public GameObject healthUI;
        [SerializeField] private Animator _anim;
        public TextMeshProUGUI healthAmount;
        private int _currentHealth;

        public void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            _currentHealth = _totalHealth;
            healthAmount.text = _currentHealth.ToString();
        }


        private void OnEnable()
        {
            BossEvents.OnAttacked += TakeDamage;

        }

        private void OnDisable()
        {
            BossEvents.OnAttacked -= TakeDamage;

        }

        public void Update()
        {
            StartStage();

        }

        public void LookAtPlayer()
        {
            Vector3 flipped = transform.localScale;
            flipped.z *= -1f;

            if (transform.position.x > player.position.x && isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
            }
            else if (transform.position.x < player.position.x && !isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
            }
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            
            if(_currentHealth >= 0)
            {
                UpdateUI();
            }
            
        }

        private void Die()
        {
            Debug.Log("Died");

            anim.SetBool("IsDead", true);

            rb.linearVelocity = Vector2.zero;
            rb.gravityScale = 0; // Removes gravity
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            Destroy(gameObject);

        }
        public void StartStage()
        {

            if (player.position.x >= 33)
            {
                if (healthUI != null)
                {
                    UpdateUI();
                }

                anim.SetBool("OnStage", true);
            }
        }
        private void UpdateUI()
        {

            if (!healthUI.activeSelf)
                healthUI.SetActive(true);
            var uiTextHP = healthUI.GetComponentInChildren<TextMeshProUGUI>();

            uiTextHP.text = _currentHealth.ToString();
        }
    }
}
