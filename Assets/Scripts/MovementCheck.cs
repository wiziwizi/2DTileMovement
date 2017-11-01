using UnityEngine;

public static class MovementCheck
{
    private static GridData[,] _gridData;
    public static bool[,] CheckedTiles { get; private set; }

    public static void Check(GridData[,] gridData, int playerMovement, Vector2 playerPos)
    {
        _gridData = gridData;
        
        ClearCheckedTiles();
        CheckedTiles = new bool[gridData.GetLength(0), gridData.GetLength(1)];
        
        FloodFill(playerPos + Vector2.left, playerMovement);
        FloodFill(playerPos + Vector2.up, playerMovement);
        FloodFill(playerPos + Vector2.right, playerMovement);
        FloodFill(playerPos + Vector2.down, playerMovement);
    }
    private static void FloodFill(Vector2 Position, int playerMovement)
    {
        var scopedPlayerMovement = playerMovement;
        
        //Debug.Log(Position);
        //Debug.Log(_gridData.GetLength(0) + " : " + _gridData.GetLength(1));
        
        //out of bounds check
        if (Position.x >= _gridData.GetLength(0) || Position.x < 0)return;
        if (Position.y >= _gridData.GetLength(1) || Position.y < 0)return;
        
        
        scopedPlayerMovement -=  GridGenerator.TileData[_gridData[(int) Position.x, (int) Position.y].TileDataID].GetMovementCost;
        if (scopedPlayerMovement < 0)return;

        //Debug.Log(scopedPlayerMovement);
        
        CheckedTiles[(int) Position.x, (int) Position.y] = true;
        _gridData[(int)Position.x,(int)Position.y].WalkableVisual.SetActive(true);
        
        FloodFill(Position + Vector2.left, scopedPlayerMovement);
        FloodFill(Position + Vector2.up, scopedPlayerMovement);
        FloodFill(Position + Vector2.right, scopedPlayerMovement);
        FloodFill(Position + Vector2.down, scopedPlayerMovement);
    }

    private static void ClearCheckedTiles()
    {
        for (var x = 0; x < _gridData.GetLength(0); x++)
        {
            for (var y = 0; y < _gridData.GetLength(1); y++)
            {
                _gridData[x,y].WalkableVisual.SetActive(false);
            }   
        }
    }
}