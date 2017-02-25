using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	
	private int timesHit;
	private LevelManager levelmanager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.15f);
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		
		if (timesHit >= maxHits) {
			breakableCount--;
			levelmanager.BrickDestroyed();
			Destroy(gameObject);			
		} else {
			LoadSprites();
		}
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	// TODO remove this method when we can actually win
	void SimulateWin() {
		levelmanager.LoadNextLevel();
	}
}
