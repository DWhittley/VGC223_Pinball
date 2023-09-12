using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    private static int score, currentScore;
    
    [SerializeField] TextMeshProUGUI textScore;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -30, 0);
    }

    public static void IncreaseScore(int amount)
    {
        score += amount;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore < score)
        {
            currentScore += (int)(1000 * Time.deltaTime);
            if (currentScore > score)
            {
                currentScore = score;
            }
            textScore.text = currentScore.ToString("00000000");
        }
    }
}
