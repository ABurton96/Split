using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public bool isOrb;
    public Controller cont;
    public GameObject death;

    //Gets camera at start of game and sets orb visibility
    public void Start()
    {
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        cont = cam.GetComponent<Controller>();

        bool show;
        show = Show();

        if (show)
            Destroy(this.gameObject);
    }

    //If hit player call end game
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(!isOrb)
            {
                cont.End();
                Movement.canMove = false;
            }
        }
    }

    //if trigger hits player add orb
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (isOrb)
            {
				Controller.AddOrbs(1);
                Instantiate(death, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }

    //Returns if the orb should be shown or not
    public bool Show()
    {
        int ran;
        ran = Random.Range(0, 4);

        if (ran == 2)
        {
            return true;
        }
        else
        {
            return false;
        }


    }
}
