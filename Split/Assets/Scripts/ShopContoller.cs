using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopContoller : MonoBehaviour {

	public int orbs;
	public GameObject shopWindow;

	public Color leftColour;
	public Color rightColour;
	public Color particleColour1;
	public Color particleColour2;

	public SpriteRenderer leftImage;
	public SpriteRenderer rightImage;

	public SpriteRenderer leftSquare;
	public SpriteRenderer rightSquare;

	public ParticleSystem moveParticle;
	public ParticleSystem deathParticles;

	public Text scoreText;
	public Text title;
	public Text pushStart;
	public Text orbsAmount;

	public static Color obColour;

	public  List<Colour> colours = new List<Colour>();

    //Gets orbs at start and deactivates window
    void Start () 
	{
		orbs = PlayerPrefs.GetInt ("Orbs");
		shopWindow.SetActive (false);
	}

    //Gets update orb count when shop is opened
    public void OnEnable()
    {
        orbs = PlayerPrefs.GetInt("Orbs");
    }

    //Turns of ticks for unselected colours
    public void DisableTicks(GameObject selectedTick)
    {
        foreach (Colour col in colours)
        {
			if (col.tick.gameObject != selectedTick) 
			{
				col.tick.SetActive (false);
			} 
			else 
			{
				col.tick.SetActive (true);
			}
        }
    }


    //Sets colours for selected colour in shop
	public void SetColours(Color left, Color right, Color p1, Color p2, Color text, Color obs)
	{
		leftImage.color = left;
		rightImage.color = right;

		leftSquare.color = right;
		rightSquare.color = left;

		var moveMain = moveParticle.main;
		moveMain.startColor = new ParticleSystem.MinMaxGradient (p1,p2);

		var deathMain = deathParticles.main;
		deathMain.startColor = new ParticleSystem.MinMaxGradient (p1,p2);

		scoreText.color = text;
		title.color = text;
		pushStart.color = text;
		orbsAmount.color = text;

		obColour = obs;
	}
}