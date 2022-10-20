using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    PlayerController playerController;
    Rigidbody2D rigidbody;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1f;
    Character character;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Vector2 position = rigidbody.position + playerController.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable interact = c.GetComponent<Interactable>();
            if (interact != null)
            {
                interact.Interact(character);
                break;
            }
        }
    }
}