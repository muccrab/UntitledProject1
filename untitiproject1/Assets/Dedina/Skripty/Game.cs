using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    #region SIngleton:Game

	public static Game Instance;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}
    #endregion

    public int Coins;


    void Start()
    {

    }

    public void UseCoins(int amount)
    {
        Coins -= amount;
    }

    public bool HasEnoughCoins(int amount)
    {
        return (Coins >= amount);
    }

}
