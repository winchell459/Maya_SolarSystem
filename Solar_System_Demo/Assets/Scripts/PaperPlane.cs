using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperPlane : MonoBehaviour
{
    public Text ScoreText;
    private int score = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            score += 1;
            ScoreText.text = score.ToString();
        }
    }
}
