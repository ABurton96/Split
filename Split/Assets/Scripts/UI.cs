using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

	public GameObject shop;

    //Sets shop active at start so information can be loaded
    void Awake () 
	{
		shop.SetActive (true);
	}
	
    //Show shop
	public void ShopButton () 
	{
		shop.SetActive (true);
	}

    //Close shop
	public void Close()
	{
		shop.SetActive (false);
	}
}
