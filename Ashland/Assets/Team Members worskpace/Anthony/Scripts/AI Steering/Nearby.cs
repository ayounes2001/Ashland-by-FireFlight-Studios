using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AnthonyY;
using UnityEngine;

public class Nearby : MonoBehaviour
{
	public Transform                     origin;
	public List<PlayerMovement> players;
	public bool                          useTriggerInGetClosest = false;

	public event Action PlayerListUpdated;

	private void Awake()
	{
		if (origin == null)
		{
			origin = transform;
		}
	}

	public PlayerMovement GetClosest()
	{
		float                   closestDistance = 99999999f;
		PlayerMovement closestPlayer   = null;

		

		foreach (PlayerMovement playerControllerTopDown in players)
		{
			float distance = Vector3.Distance(origin.position, playerControllerTopDown.transform.position);

			if (distance < closestDistance)
			{
				closestDistance = distance;
				closestPlayer   = playerControllerTopDown;
			}
		}

		return closestPlayer;
	}

	private void OnTriggerEnter(Collider other)
	{
		// Because the player's main collider isn't on the root GO, but he has other colliders
		if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
		{
			PlayerMovement playerControllerTopDown = other.transform.root.GetComponent<PlayerMovement>();

			if (playerControllerTopDown)
			{
				players.Add(playerControllerTopDown);
				PlayerListUpdated?.Invoke();

				//Debug.Log("I have entered the trigger zone");
				//Debug.Log(playerControllerTopDown.gameObject.name);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Gameplay relevant colliders"))
		{
			PlayerMovement playerControllerTopDown = other.transform.root.GetComponent<PlayerMovement>();

			if (playerControllerTopDown)
			{
				players.Remove(playerControllerTopDown);
				PlayerListUpdated?.Invoke();

				//Debug.Log("I have exited the trigger zone");
				//Debug.Log(playerControllerTopDown.gameObject.name);
			}
		}
	}
}