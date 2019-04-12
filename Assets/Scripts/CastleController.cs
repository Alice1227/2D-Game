using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{
	public GameObject Cat;
	public GameObject Explosion;
	bool catAppear = false;
	int currentHP = Unit.castleHP;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "bullet") {
			currentHP = GameManager.instance.cauculateCastleHP (Unit.bulletATK);	
		}
			
		if (currentHP <= 80) {
			if (!catAppear) {
				Vector3 pos = new Vector3 (100, -0.5f, 0);
				Instantiate (Cat, pos, transform.rotation);
				catAppear = true;
			}

			if (currentHP <= 0) {
				Vector3 pos = new Vector3 (80, 2, 0);
				Instantiate(Explosion, pos, transform.rotation);
				Destroy (gameObject);
				GameManager.instance.Win ();
			}
		}
	}
}
