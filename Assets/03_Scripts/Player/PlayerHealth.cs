using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._03_Scripts.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        private int _totalHealth = 250;
        [SerializeField] private Animator _anim;
        public TextMeshProUGUI healthAmount;
        private int _currentHealth;
        private void Start()
        {
            _anim = GetComponent<Animator>();
            _currentHealth = _totalHealth;
            healthAmount.text = _currentHealth.ToString();

        }

        private void OnEnable()
        {
            PlayerEvents.OnPlayerHeal += Heal;
            PlayerEvents.OnPlayerAttacked += TakeDamage;
            PlayerEvents.OnPLayerKilled += Die;
            PlayerEvents.OnPlayerHealUp += Up;
        }

        private void OnDisable()
        {
            PlayerEvents.OnPlayerHeal -= Heal;
            PlayerEvents.OnPlayerAttacked -= TakeDamage;
            PlayerEvents.OnPLayerKilled -= Die;
            PlayerEvents.OnPlayerHealUp -= Up;

        }


        private void Update()
        {
            healthAmount.text = _currentHealth.ToString();
        }
        public void TakeDamage(int attackDamage)
        {
            _currentHealth -= attackDamage;

            _anim.SetTrigger("hurt");
            if (_currentHealth <= 0)
            {
                Die();
            }

        }

        public void Heal(int healingAmount)
        {
            _currentHealth += healingAmount;

            if (_currentHealth == _totalHealth)
            {
                Debug.LogWarning("Wasted healing");
            }

        }


        public void Die()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Up(int healingAmount)
        {
            _currentHealth += healingAmount;

            if (_currentHealth == _totalHealth)
            {
                Debug.LogWarning("Wasted healing");
            }

        }
    }
}
