using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourShift : MonoBehaviour {

    public GameObject leftSide;
    public GameObject rightSide;
    public GameObject center;

    public float centerPoint;

    //Sets what square to be visible
    void Update()
    {
        if(center.transform.position.x > centerPoint + 0.5f)
        {
            leftSide.transform.localScale = new Vector3(0, 0, 0);
            rightSide.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (center.transform.position.x < centerPoint - 0.5f)
        {
            leftSide.transform.localScale = new Vector3(1, 1, 1);
            rightSide.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    //Resets back to starting sizes
	public void Reset()
	{
		leftSide.transform.localScale = new Vector3(0.5f, 1, 1);
		rightSide.transform.localScale = new Vector3(0.5f, 1, 1);
	}
}
