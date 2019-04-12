using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
	public float speed;
	public int HP;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "bullet") {
			HP -= Unit.bulletATK;
		}

		if (other.tag == "leftwall" || HP <= 0) {
			Destroy (gameObject);
		}
	}
		
}
