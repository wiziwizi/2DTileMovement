using UnityEngine;

[System.Serializable]
public class TileData
{
    public string name;
    public GameObject visualPrefab;

    [SerializeField]private int movementCost;

    public int GetMovementCost {get { return movementCost; }}
}
