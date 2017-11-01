using UnityEngine;

public class GridData
{
	public Vector2 Pos;
	public int TileDataID;
	public GameObject Visual;
	public GameObject WalkableVisual;

	public GridData(Vector2 _Pos, int _TileDataID)
	{
		Pos = _Pos;
		TileDataID = _TileDataID;
	}
}