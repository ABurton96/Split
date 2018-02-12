using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovetoPos : MonoBehaviour {

	public bool move;
	public Vector3 pos;
	public float speed;

    //Moves object to position
	void Update () 
	{
		transform.position = Vector3.MoveTowards (transform.position, pos, speed * Time.deltaTime);
	}
}
