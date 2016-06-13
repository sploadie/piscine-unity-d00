using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public float wind = 10.0f;
	public bool  game_over = false;

	// Update is called once per frame
	void Update () {
		if (this.transform) {
			if (Input.GetKeyDown ("space") && this.wind >= 1 && game_over == false) {
//				Debug.Log ("Space is pressed!");
				this.wind -= 1.0f;
//				this.transform.localScale += new Vector3 (0.1f, 0.1f, 0.0f);
				this.transform.localScale += new Vector3 (0.15f, 0.15f, 0.0f);
			} else {
				this.wind += 0.1f;
				this.transform.localScale += new Vector3 (-0.01f, -0.01f, 0.0f);
			}
			if (this.wind > 10.0f) {
				this.wind = 10.0f;
			}
			if (this.transform.localScale.x < 0.5f) {
				this.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
			}
			if (this.transform.localScale.x >= 5.0f && game_over == false) {
				GameObject.Destroy (this.gameObject);
				game_over = true;
				Debug.Log ("Balloon life time: " + Mathf.RoundToInt(Time.fixedTime) + "s");
			}
			if (this.transform.localScale.x < (Time.fixedTime / 10.0f) && game_over == false) {
				game_over = true;
				Debug.Log ("Balloon life time: " + Mathf.RoundToInt(Time.fixedTime) + "s");
			}
		}
	}
}
