using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPartTrigger : MonoBehaviour
{
    [SerializeField] private int score = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelGenerator.Instance.GeneratePart(transform.position);
            GameManager.Instance.AddScore(score);
        }
    }
}
