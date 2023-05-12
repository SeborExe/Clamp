using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [field: SerializeField] public float RotationSpeed { get; private set; }
    [field: SerializeField] public float ForwardSpeed { get; private set; }

    private DotCreator dotCreator;

    private bool canMoveForward = true;
    private bool canPlayerInteract = true;

    private Vector2 destination;
    private float timeToWaitBeforeMove = 1f;
    private float moveTimer;

    private void Awake()
    {
        dotCreator = GetComponent<DotCreator>();
    }

    private void Update()
    {
        HandleRotate();
        HandleMovement();
        HandleTimers();
    }

    private void HandleRotate()
    {
        transform.Rotate(new Vector3(transform.localRotation.x, transform.localRotation.y, RotationSpeed * Time.deltaTime));
    }

    private void HandleMovement()
    {
        if (canMoveForward)
            transform.position += new Vector3(0, ForwardSpeed * Time.deltaTime);

        if (canPlayerInteract && Input.GetMouseButtonDown(0))
        {
            canPlayerInteract = false;
            canMoveForward = false;

            moveTimer = timeToWaitBeforeMove;
            Vector3 mouseClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination = new Vector3(mouseClickPosition.x, mouseClickPosition.y, 0);

            dotCreator.ShowDots(destination);
        }

        if (destination != default && moveTimer <= 0)
        {
            transform.position = Vector3.Lerp(transform.position, destination, 3 * ForwardSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, destination) <= 0.25f)
            {
                canPlayerInteract = true;
                canMoveForward = true;
                destination = default;

                dotCreator.HideDots();
            }
        }
    }

    private void HandleTimers()
    {
        if (moveTimer > 0)
        {
            moveTimer -= Time.deltaTime;
            if (moveTimer < 0)
                moveTimer = 0;
        }
    }
}
