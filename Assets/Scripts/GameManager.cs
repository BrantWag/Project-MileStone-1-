using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<TankData> AI;
    public List<TankData> player;

    public int score;

	// Use this for initialization
	void Start ()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
