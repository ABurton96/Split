using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleColour : MonoBehaviour {

	public SpriteRenderer ren;

    //Sets obstacle colours
	void Start () 
	{
		ren = GetComponent<SpriteRenderer> ();
		ren.color = ShopContoller.obColour;
	}
}
