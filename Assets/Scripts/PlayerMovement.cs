using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	[SerializeField] private int _playerMovementValue;
	[SerializeField] private GridGenerator _gridGenerator;

	private void Start () {
		MovementCheck.Check(_gridGenerator.GridDataArray, _playerMovementValue, transform.position);
	}

	private void Update()
	{
		if (!Input.GetMouseButtonDown(0)) return;
		
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (!Physics.Raycast(ray, out hit)) return;
		print(hit.point);
		if (!MovementCheck.CheckedTiles[Mathf.RoundToInt(hit.point.x), Mathf.RoundToInt(hit.point.y)])return;

		transform.position = new Vector3(Mathf.RoundToInt(hit.point.x), Mathf.RoundToInt(hit.point.y), transform.position.z);
		MovementCheck.Check(_gridGenerator.GridDataArray, _playerMovementValue, transform.position);
	}
}
