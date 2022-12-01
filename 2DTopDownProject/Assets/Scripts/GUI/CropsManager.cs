using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Crops
{
    //this class stores all info about crops and plowed tiles in the scene


}
public class CropsManager : MonoBehaviour
{
    [SerializeField] TileBase plowed;
    [SerializeField] TileBase seeded;
    [SerializeField] Tilemap targetTilemap;

    //to interact with crop, find position with dictionary
    Dictionary<Vector2Int, Crops> crops;

    private void Start()
    {
        //initialize dictionary
        crops = new Dictionary<Vector2Int, Crops>();
    }

    public bool Check(Vector3Int position)
    {
        return crops.ContainsKey((Vector2Int)position);

    }

    public void Seed(Vector3Int position)
    {
        targetTilemap.SetTile(position, seeded);
    }

    public void Plow(Vector3Int position)
    {
        //check if there is already a crop present
        if (crops.ContainsKey((Vector2Int)position))
        {
            return;
        }

        CreatePlowedTile(position);
    }

    private void CreatePlowedTile(Vector3Int position)
    {
        Crops crop = new Crops();
        crops.Add((Vector2Int)position, crop);
        targetTilemap.SetTile(position, plowed);
    }
}

