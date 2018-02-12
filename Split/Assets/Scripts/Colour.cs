using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colour : MonoBehaviour {

	public Image left;
	public Image right;
	public Text priceText;
	public bool locked;
	public bool def;
	public GameObject lockImage;
	public GameObject tick;

    public Colours item;
	public ShopContoller cont;


    //Sets information at game start
	void Awake()
	{
		SetInformation ();
	}

    //ets information from colour object
	public void SetInformation () 
	{
		left.color = item.leftColour;
		right.color = item.rightColour;
		priceText.text = item.price.ToString ();

		string selected;
		selected = PlayerPrefs.GetString ("SelectedColours", "Blue");

        if (selected == item.name)
        {
            Select();
        }
        else
        {
            tick.SetActive(false);
        }
	}
    
    //Sets lock or unlock status when it becomes visibile
	public void OnEnable()
	{
		SetLockUnlock ();

		if (cont.orbs > item.price) 
		{
			priceText.color = Color.green;
		}
		else 
		{
			priceText.color = Color.red;
		}
	}

    //Sets or unlocks when clicked
	public void Clicked () 
	{
		if (locked) 
		{
			Purchase ();
		} 
		else 
		{
			Select ();
		}

	}

    //Unlocks item
	void Purchase()
	{
		if(cont.orbs >= item.price)
		{
			Debug.Log (cont.orbs.ToString ());
			Debug.Log (item.price.ToString ());
			PlayerPrefs.SetString (item.name, "false");
			SetLockUnlock ();
			Controller.DeductOrbs (item.price);
			Select ();
		}
	}

    //Selects item
	void Select()
	{
		cont.SetColours(item.leftColour, item.rightColour, item.particleColour1, item.particleColour2, item.UIColour, item.obColour);
        cont.DisableTicks(tick);
        tick.SetActive(true);
        PlayerPrefs.SetString ("SelectedColours", item.name);

	}

    //Set lock and unlock status
	public void SetLockUnlock()
	{
		locked = bool.Parse(PlayerPrefs.GetString (item.name, "true"));

		if (def)
			locked = false;

		if (locked) 
		{
			lockImage.SetActive (true);
			priceText.gameObject.SetActive (true);
		} 
		else 
		{
			lockImage.SetActive (false);
			priceText.gameObject.SetActive (false);
		}
	}
}