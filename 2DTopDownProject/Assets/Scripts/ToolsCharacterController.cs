using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolsCharacterController : MonoBehaviour
{
    PlayerController character;
    Rigidbody2D rigidbody;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadcontroller;
    [SerializeField] float maxDistance = 1.5f;
    [SerializeField] CropsManager cropsManager;
    [SerializeField] TileData plowableTile;

    Vector3Int selectedTilePosition;
    bool selectable;

    private void Awake()
    {
        character = GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();

        if (Input.GetMouseButtonDown(0))
        {
            if(UseToolWorld() == true) 
            {
                return;
            }
            UseToolGrid();
        }
    }

    public void Marker()
    {
        //Vector3Int gridPosistion = tileMapReadcontroller.GetGridPosition(Input.mousePosition, true);
        markerManager.markedCellPosition = selectedTilePosition;
    }

    private void SelectTile()
    {
        selectedTilePosition = tileMapReadcontroller.GetGridPosition(Input.mousePosition, true);

    }

    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectable);
    }



    private bool UseToolWorld()
    {
        Vector2 position = rigidbody.position + character.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null)
            {
                hit.Hit();
                return true;
            }
        }
        return false;
    }

    private void UseToolGrid()
    {
        if(selectable == true)
        {
            TileBase tileBase = tileMapReadcontroller.GetTileBase(selectedTilePosition);
            TileData tileData = tileMapReadcontroller.GetTileData(tileBase);
            if (tileData != plowableTile)
            {
                return;
            }

            if(cropsManager.Check(selectedTilePosition))
            {
                cropsManager.Seed(selectedTilePosition);
            }
            else
            {
                cropsManager.Plow(selectedTilePosition);
            }
            

        }
    }
}
