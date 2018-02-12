using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public GameObject player;
	public GameObject menu;
	public GameObject end;
    public GameObject level;
	public Text scoreText;

	public Text scoreEnd;
	public Text highscoreEnd;
    public GameObject newHS;

    public ColourShift shift;

	public static bool play;

	private float startTime;
    private float endTime;

	public static int orbs;
	public Text orbsText;
    public Text inLevelOrbText;

    //Loads orbs collected
    public void Start()
	{
		orbs = PlayerPrefs.GetInt ("Orbs");
	}

    //Updates score and sets texts. 
	void Update () 
	{
		if (play) 
		{
			scoreText.text = CalculateScore(startTime, Time.time);
		}

		orbsText.text = "Orbs: " + orbs.ToString ("0000");
        inLevelOrbText.text = orbs.ToString ();

        //TODO Remove debug keys
		if(Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.DeleteAll();
        }

		if (Input.GetKeyDown (KeyCode.A)) 
		{
			Controller.AddOrbs (50);
		}

		if (Input.GetKeyDown (KeyCode.D)) 
		{
			Controller.DeductOrbs (50);
		}
    }

    //Adds orbs
	public static void AddOrbs(int amount)
	{
		orbs = orbs + amount;
		PlayerPrefs.SetInt ("Orbs", orbs);
	}

    //Deducts orbs
    public static void DeductOrbs(int amount)
	{
		orbs = orbs - amount;
		Debug.Log (orbs.ToString());
		PlayerPrefs.SetInt ("Orbs", orbs);
	}

    //Sets information to play the game
	public void Play()
	{
		player.transform.position = new Vector3 (1.714f, -0.94f, -2.43f);
		player.GetComponent<Rigidbody2D>().gravityScale = 1;
		menu.SetActive (false);
		level.SetActive (true);
		play = true;
		startTime = Time.time;
		Movement.canMove = true;
		Movement.right = true;
	}

    //Sets information at game end
	public void End()
	{
		play = false;
		player.GetComponent<Animation> ().Play();
        Scores();
        endTime = Time.time;
		StartCoroutine (DisableItems ());
    }

    //Removes spawned objects
    public IEnumerator DisableItems()
	{
		yield return new WaitForSeconds (0.5f);

		GameObject[] spawnedTiles;
		spawnedTiles = GameObject.FindGameObjectsWithTag ("Tiles");

		for (int i = 0; i < spawnedTiles.Length; i++) 
		{
			Destroy (spawnedTiles [i]);
		}
	}

    //Checks scores 
    public void Scores()
    {
        end.SetActive(true);
        scoreEnd.text = "Score: \n" + scoreText.text;

        int hs;
        hs = PlayerPrefs.GetInt("Highscore");

        highscoreEnd.text = "Highscore: \n" + hs.ToString();

        if(int.Parse(scoreText.text) > hs)
        {
            PlayerPrefs.SetInt("Highscore", int.Parse(scoreText.text));
            newHS.SetActive(true);
            highscoreEnd.text = "Highscore: \n" + scoreText.text;
        }
        else
        {
            newHS.SetActive(false);
        }
    }

    //Resets back to menu
    public void Reset()
	{
        if (Time.time >= endTime + 1f)
        {
            player.transform.position = new Vector3(0f, -0.888f, -2.43f);
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            menu.SetActive(true);
            level.SetActive(false);
            shift.Reset();
            newHS.SetActive(false);
            end.SetActive(false);
            endTime = 0;
        }
    }

    //Calculates score
    public string CalculateScore(float startTime, float currentTime)
	{
		return Mathf.FloorToInt(currentTime - startTime).ToString();
	}
}
