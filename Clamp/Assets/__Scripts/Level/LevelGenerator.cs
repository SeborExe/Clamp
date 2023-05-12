using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : SingletonMonobehaviour<LevelGenerator>
{
    [SerializeField] GameObject[] levelParts;

    private float yOffset = 11.5f;

    protected override void Awake()
    {
        base.Awake();
    }

    public void GeneratePart(Vector2 partPosition)
    {
        Instantiate(levelParts[Random.Range(0, levelParts.Length)], new Vector2(partPosition.x, partPosition.y + yOffset), Quaternion.identity,
            transform);

        DeletePart();
    }

    private void DeletePart()
    {
        if (transform.childCount > 2)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
