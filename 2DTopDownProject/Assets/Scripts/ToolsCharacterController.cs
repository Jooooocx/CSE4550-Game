using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    PlayerController character;
    Rigidbody2D rigidbody;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadcontroller;

    private void Awake()
    {
        character = GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Marker();

        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    public void Marker()
    {
        Vector3Int gridPosistion = tileMapReadcontroller.GetGridPosition(Input.mousePosition, true);
        markerManager.markedCellPosition = gridPosistion;
    }

    private void UseTool()
    {
        Vector2 position = rigidbody.position + character.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }
}
