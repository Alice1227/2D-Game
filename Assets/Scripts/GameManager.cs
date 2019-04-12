using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public GameObject GameStartTitle;
	public GameObject GameOverTitle;
	public GameObject GameWinTitle;
	public GameObject PlayButton;
	public GameObject RestartButton;
	public GameObject ExitButton;
	public bool IsPlaying = false;

	public Text PlayerHPText;
	public Text CastleHPText;
	int current_playerHP;
	int current_castleHP;

	public GameObject Rabbit;
	public float time;

	// Use this for initialization
	void Start ()
	{
		instance = this;
		GameOverTitle.SetActive (false);
		GameWinTitle.SetActive (false);
		RestartButton.SetActive (false);
		ExitButton.SetActive (false);

		PlayerHPText.text = "HP: " + Unit.playerHP + " / " + Unit.playerHP;
		CastleHPText.text = "Castle: " + Unit.castleHP + " / " + Unit.castleHP;

		current_playerHP = Unit.playerHP;
		current_castleHP = Unit.castleHP;

	}
	
	// Update is called once per frame
	void Update ()
	{
		time += Time.deltaTime;
		if (time > 3 && IsPlaying == true) {
			Vector3 pos = new Vector3 (90, -5, 0);
			Instantiate (Rabbit, pos, transform.rotation);
			time = 0;
		}
	}

	public void GameStart ()
	{
		IsPlaying = true;
		GameStartTitle.SetActive (false);
		PlayButton.SetActive (false);
	}

	public void GameOver ()
	{
		IsPlaying = false;
		GameOverTitle.SetActive (true);
		RestartButton.SetActive (true);
		ExitButton.SetActive (true);
	}

	public void Win ()
	{
		IsPlaying = false;
		GameWinTitle.SetActive (true);
		RestartButton.SetActive (true);
		ExitButton.SetActive (true);
		GameObject.FindGameObjectWithTag("rabbit").SetActive (false);
		GameObject.FindGameObjectWithTag("cat").SetActive (false);
	}

	public void GameRestart ()
	{
		SceneManager.LoadScene ("Game");
	}

	public void GameExit (){
		Application.Quit ();
	}

	public int cauculatePlayerHP (int n)
	{
		current_playerHP -= n;
		PlayerHPText.text = "HP: " + current_playerHP + " / " + Unit.playerHP;
		return current_playerHP;
	}

	public int cauculateCastleHP (int n)
	{
		current_castleHP -= n;
		CastleHPText.text = "Castle: " + current_castleHP + " / " + Unit.castleHP;
		return current_castleHP;
	}
}