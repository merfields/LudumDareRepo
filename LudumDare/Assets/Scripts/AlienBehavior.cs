using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBehavior : MonoBehaviour
{
    private EnemyManager enemyManager;
    private Animator animator;

    [SerializeField]
    private float movementSpeed = 6f;

    private void Awake()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        animator = GetComponent<Animator>();
        StartCoroutine(AlienQueue());
    }

    private IEnumerator AlienQueue()
    {

        //Выбрать точку

        Vector3 movePoint = enemyManager.BombLines[Random.Range(0, 2)].position + new Vector3(0, Random.Range(-6, 6));

        //Добраться

        while (Vector2.Distance(movePoint, transform.position) > 0.1f)
        {
            transform.position += (movePoint - transform.position).normalized * movementSpeed * Time.deltaTime;
            yield return null;
        }

        animator.SetTrigger("AnimAlienReachedTarget");

        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(1f);

            Vector3 theScale = transform.localScale;

            theScale.x *= 1.5f;

            theScale.y *= 1.5f;

            transform.localScale = theScale;
        }

        Color newColor = new Color(1, 0, 0, 1);
        GetComponent<SpriteRenderer>().color = newColor;

        yield return new WaitForSeconds(2f);

        Instantiate(enemyManager.explotionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
