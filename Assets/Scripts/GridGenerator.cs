using UnityEngine;

public class GridGenerator : MonoBehaviour
{

    [SerializeField] private int _width, _height;

    [SerializeField] private TileData[] _tileData;
    [SerializeField] private bool _hardCodedMap;
    [SerializeField] private GameObject _walkableVisual;

    public static TileData[] TileData { get; private set; }
    public GridData[,] GridDataArray { get; private set; }

    private void Awake()
    {
        TileData = _tileData;
        GenerateMapData();
        GenerateMapVisuals();
    }

    private void GenerateMapData()
    {
        GridDataArray = new GridData[_width, _height];

        for (var x = 0; x < _width; x++)
        {
            for (var y = 0; y < _height; y++)
            {
                GridDataArray[x, y] = new GridData(new Vector2(x, y), Random.Range(0,4));
            }
        }
        //Debug.Log(GridDataArray[0,1]);
        
        if (!_hardCodedMap)return;
        
        //place hard coded map here for example: TileID[0,1] = 2;
    }

    private void GenerateMapVisuals()
    {
        for (var x = 0; x < _width; x++)
        {
            for (var y = 0; y < _height; y++)
            {
                GridDataArray[x, y].Visual = Instantiate(_tileData[GridDataArray[x, y].TileDataID].visualPrefab, new Vector3(x, y), Quaternion.identity, transform);
                GridDataArray[x, y].WalkableVisual = Instantiate(_walkableVisual, new Vector3(x, y, -0.1f), Quaternion.identity, transform);
            }
        }
    }
}
