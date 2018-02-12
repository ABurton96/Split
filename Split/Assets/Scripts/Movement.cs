using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public static bool right = true;
	public Rigidbody2D player;

	public Controller cont;

	public bool moving;

	public static bool canMove;

    //If game is running and screen is tapped then push player to other side
	void Update () 
	{
		if (Controller.play) 
		{
			if (Input.GetMouseButtonDown (0) && !moving && canMove) 
			{
				if (right) 
				{
					player.velocity = Vector2.zero;
					player.AddForce (new Vector2 (-500, 100));
					moving = true;
					right = false;
					StartCoroutine (MoveDelay ());
				} 
				else 
				{
					player.velocity = Vector2.zero;
					player.AddForce (new Vector2 (500, 100));
					moving = true;
					right = true;
					StartCoroutine (MoveDelay ());
				}
			}
		}
	}

    //Adds delay before you can move again
	public IEnumerator MoveDelay() 
	{
		yield return new WaitForSeconds (0.325f);
		moving = false;
	}
}
