using UnityEngine;

public class Player_Character : MonoBehaviour {
    public float health = 100.0f;
    public float lossRate = 1.0f;
    public float healthRecoveredByObjects = 30.0f;
    public int totalItems = 6;
    private int initialTotalItems;
    private float nextLoss = 0.0f;
    public float levelTime = 120.0f;

    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
        initialTotalItems = totalItems;
    }

    void Update()
    {
        if (Time.time >= nextLoss)
        {
            health -= lossRate;
            nextLoss += 1.0f;
            if (health % 10 != 0)
                Debug.Log(health);
        }
        if (health <= 1)
        {
            GameOver();
            Debug.Log("game loss");
        }
    }

    public void OnPickUp()
    {
        if (health <= 70.0f)
            health += healthRecoveredByObjects;
        else
            health = 100;
        totalItems -= 1;
        if (totalItems == 0)
            Debug.Log("game won");
    }

    public void GameOver()
    {
        Debug.Log("game over called");
        
        // reset loction, stop everything for 5 seconds, put up lose screen
        health = 101.0f;
        totalItems = initialTotalItems;
    }
}
