using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

    public float time;

	public void Start () 
	{
        StartCoroutine(RemoveItem());	
	}

    public IEnumerator RemoveItem()
    {
        //Destoys game object after set time
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
