using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] int score;
    public void AddScore() { score++; }
    public int GetScore() { return score; }
}
