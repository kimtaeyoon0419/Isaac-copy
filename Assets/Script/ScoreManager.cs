using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text collectedText;
    public static int collectedAmount;

    void Start()
    {
        
    }

    void Update()
    {
        collectedText.text = "Items Collected: " + collectedAmount;
    }
}
