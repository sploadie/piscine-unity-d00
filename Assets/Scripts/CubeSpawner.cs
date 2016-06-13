using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour {

	public Cube cube;
	public string letter  = "x";
	public float min_time = 1.0f;
	public float max_time = 3.0f;
	public float min_speed = -0.01f;
	public float max_speed = -0.03f;

	public GameObject line;
	public float derivation = 0.2f;

	private ArrayList cubes = new ArrayList();
	private float tick = 0;
	private float interval;

	// Use this for initialization
	void Start () {
		interval = Random.Range(min_time, max_time);
	}
	
	// Update is called once per frame
	void Update () {
		Cube tmp_cube;
		float y_pos;
		tick += Time.deltaTime;
		if (tick > interval) {
			tick = 0;
			interval = Random.Range(1.0f, 3.0f);
			tmp_cube = GameObject.Instantiate(cube, transform.position, transform.rotation) as Cube;
			tmp_cube.speed = Random.Range(min_speed, max_speed);
			cubes.Add(tmp_cube);
		}
		float precision = 10;
		float tmp_precision;
		for (int i = 0; i < cubes.Count; i++) {
			tmp_cube = cubes[i] as Cube;
			y_pos = tmp_cube.transform.position.y;
			if (Input.GetKeyDown(letter)) {
				tmp_precision = y_pos - line.transform.position.y;
				if (tmp_precision < precision)
					precision = tmp_precision;
				if (y_pos < (line.transform.position.y + derivation) && y_pos > (line.transform.position.y - derivation)) {
					cubes.RemoveAt(i);
					i--;
					GameObject.Destroy(tmp_cube.gameObject);
					continue;
				}
			}
			if (y_pos < (line.transform.position.y - derivation)) {
				cubes.RemoveAt(i);
				i--;
				GameObject.Destroy(tmp_cube.gameObject);
			}
		}
		if (Input.GetKeyDown(letter))
			Debug.Log("Precision: " + (precision * 10.0f));
//		if (cubes.Count > 0) {
//			tmp_cube = cubes [0] as Cube;
//			y_pos = tmp_cube.transform.position.y;
//			if (Input.GetKeyDown (letter) && cubes.Count > 0) {
//				if (y_pos < (line.transform.position.y + derivation) && y_pos > (line.transform.position.y - derivation)) {
//					cubes.RemoveAt (0);
//					GameObject.Destroy (tmp_cube.gameObject);
//				}
//				Debug.Log ("Precision:  " + (y_pos - line.transform.position.y));
//			}
//			tmp_cube = cubes [0] as Cube;
//			y_pos = tmp_cube.transform.position.y;
//			if (y_pos < (line.transform.position.y - derivation)) {
//				cubes.RemoveAt (0);
//				GameObject.Destroy (tmp_cube.gameObject);
//			}
//		}
	}
}
