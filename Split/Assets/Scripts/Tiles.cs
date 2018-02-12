using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour {

	void Update () 
	{
        //Removes tile if it goes off of the screen
		if(transform.position.y <= -17)
		{
			Destroy(this.gameObject);
		}
	}
}
