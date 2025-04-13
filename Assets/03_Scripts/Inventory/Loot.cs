using System.Collections;
using UnityEngine;

public class Loot: MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private float moveSpeed;

    private Item item;

    public void Initialize(Item item)
    {
        this.item = item;
        sr.sprite = item.image;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(MoveAndCollect(collision.transform));
        }
    }

    private IEnumerator MoveAndCollect(Transform target)
    {
        Destroy(coll);

        while(transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            yield return 0;
        }

        Destroy(gameObject);
    }
}
