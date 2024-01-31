using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
	[SerializeField] TMP_Text scoreText;
	[SerializeField] FloatVariable health;
	[SerializeField] PhysicsCharacterController characterController;

	[Header("Events")]
	[SerializeField] IntEvent scoreEvent = default;
	[SerializeField] Event gameStartEvent = default;
	[SerializeField] Event playerDeadEvent = default;

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
	}

	public void AddPoints(int points)
	{
		Score += points;
	}

	private void OnStartGame()
	{
		characterController.enabled = true;
	}

	public void Damage(float damage)
	{
		health.value -= damage;
		if (health <= 0)
		{
			playerDeadEvent.RaiseEvent();
		}
	}

	public void ApplyDamage(float damage)
	{
		health.value -= damage;
		if (health <= 0)
		{
			playerDeadEvent.RaiseEvent();
		}
	}

	public void OnRespawn(GameObject respawn)
	{
		transform.position = respawn.transform.position;
		transform.rotation = respawn.transform.rotation;

		characterController.Reset();
	}
}
