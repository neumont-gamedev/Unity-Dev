using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] TMP_Text scoreText;
	[SerializeField] FloatVariable health;
	[SerializeField] PhysicsCharacterController characterController;

	[Header("Events")]
	[SerializeField] IntEvent scoreEvent = default;
	[SerializeField] VoidEvent gameStartEvent = default;

	private int score = 0;

	public int Score 
	{ 
		get { return score; } 
		set { 
			score = value; 
			scoreText.text = score.ToString();
			scoreEvent.RaiseEvent(score);
		} 
	}

	private void OnEnable()
	{
		gameStartEvent.Subscribe(OnStartGame);
	}


	private void Start()
	{
		health.value = 50;
	}

	public void AddPoints(int points)
	{
		Score += points;
	}

	private void OnStartGame()
	{
		characterController.enabled = true;
	}
}
