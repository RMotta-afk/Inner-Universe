using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    private Animator anim;
    public int bossHealth = 100;
    private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        bossHealth -= damage;

        if (bossHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        Debug.Log("Died");

        anim.SetBool("isDead", true);

        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0; // Remove a gravidade
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
    }
    public void StartStage()
    {

        if (player.position.x >= 2)
        {

            anim.SetBool("onStage", true);
        }
    }
}
