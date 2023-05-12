using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotCreator : MonoBehaviour
{
    [SerializeField] private GameObject dotPrefab;

    private List<GameObject> dots = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject dot = Instantiate(dotPrefab, transform.position, Quaternion.identity);
            dots.Add(dot);

            HideDots();
        }
    }

    public void ShowDots(Vector3 destination)
    {
        float distance = Vector3.Distance(transform.position, destination);
        Vector3 direction = (destination - transform.position).normalized;

        for (int i = 0; i < distance; i++)
        {
            GameObject dot = dots[i];
            dot.transform.position = transform.position + (direction * i);
            dot.SetActive(true);
        }
    }

    public void HideDots()
    {
        foreach (GameObject instantiatedDots in dots)
        {
            instantiatedDots.SetActive(false);
        }
    }
}
