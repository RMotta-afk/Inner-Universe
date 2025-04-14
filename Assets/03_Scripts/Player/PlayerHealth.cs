using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 100;


    public void OnDamageTaken(int amount)
    {
        _health -= amount;
        if (_health <= 0)
            Die();
    }

    public void OnHeal(int amount)
    {
        if (_health < 100)
            _health += amount;
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

