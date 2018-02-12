using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	private float nextSpawn;

	public GameObject[] tiles;

    //If game is running and enought time has passed then create a new tile
	void Update () 
	{
		if (Controller.play) 
		{
			if (nextSpawn <= Time.time) 
			{
				nextSpawn = Time.time + 2.5f;
				Spawn ();
			}
		}
	}
    //Spawns new tile
	public void Spawn() 
	{
		int ran;
		ran = Random.Range (0, tiles.Length);

		Instantiate (tiles [ran], new Vector3 (0.014f, 8.17f, -0.8299313f), transform.rotation);
	}
}
