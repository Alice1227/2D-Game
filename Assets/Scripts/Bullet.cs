using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed = 5;
	public float rotateAngle = 45;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(new Vector3(0, 0, rotateAngle * Time.deltaTime));
		this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag != "bullet") {
			Destroy (gameObject);
		}
	}
}
