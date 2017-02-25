using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;	
	private Vector3 PaddleToBallVector;
	private bool hasStarted = false;
	
	// Use this for initialization
	void Start () {
	
		paddle = GameObject.FindObjectOfType<Paddle>();
		PaddleToBallVector = this.transform.position - paddle.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (hasStarted == false) {
			this.transform.position = paddle.transform.position + PaddleToBallVector;
		
		
			if (Input.GetMouseButtonDown(0)) {
				print ("Mouse button clicked! launch ball!");
				hasStarted = true;
			
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
	
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
	
		if (hasStarted) {
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
