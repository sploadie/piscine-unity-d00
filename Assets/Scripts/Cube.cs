using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	public string letter   = "x";
	public float min_speed = -0.01f;
	public float max_speed = -0.03f;

	public float speed = 0.0f;

	// Use this for initialization
	void Start () {
//		speed = Random.Range(min_speed, max_speed);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(0, speed, 0);
	}
}
