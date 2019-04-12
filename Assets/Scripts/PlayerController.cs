using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 10;
	public GameObject bullet;
	Animator animator;
	bool facingRight = true;
	bool IsJump = false;
	int count = -1;
	int currentHP = Unit.playerHP;

	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//左右移動
		float move = Input.GetAxis ("Horizontal");
		animator.SetFloat ("Speed", Mathf.Abs (move));
		this.transform.position += new Vector3 (move * speed * Time.deltaTime, 0, 0);

		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();
		}

		//跳
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (!IsJump) {
				IsJump = true;
				count = 0;
			}
		}

		if (count >= 0) {
			if (count < 60) {
				this.transform.position += new Vector3 (0, speed * Time.deltaTime, 0);
			} else {
				this.transform.position += new Vector3 (0, -speed * Time.deltaTime, 0);
			}
			count++;

			if (count > 119) {
				animator.SetBool ("Jump", false);
				IsJump = false;
				count = -1;
			}
		}

		//攻擊
		if (facingRight) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				Vector3 pos = this.transform.position + new Vector3 (3, -1, 0);
				Instantiate (bullet, pos, this.transform.rotation);
			}
		}
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	void OnTriggerEnter2D (Collider2D other)
	{			
		if (other.tag == "rabbit") {
			currentHP = GameManager.instance.cauculatePlayerHP (Unit.rabbitATK);
		}

		if (other.tag == "cat") {
			currentHP = GameManager.instance.cauculatePlayerHP (Unit.catATK);
		}

		if (currentHP <= 0) {
			Destroy (gameObject);
			GameManager.instance.GameOver ();
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{			
		if (other.tag == "rabbit") {
			currentHP = GameManager.instance.cauculatePlayerHP (Unit.rabbitATK);
		}

		if (other.tag == "cat") {
			currentHP = GameManager.instance.cauculatePlayerHP (Unit.catATK);
		}

		if (currentHP <= 0) {
			Destroy (gameObject);
			GameManager.instance.GameOver ();
		}
	}
}
