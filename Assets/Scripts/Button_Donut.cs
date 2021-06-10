using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Donut : MonoBehaviour
{
    [SerializeField]
    private float ScoreCount = 0;
    [SerializeField]
    private float AUTOR = 0f;
    [SerializeField]
    private float ScoreCountIncrease = 1f;
    [SerializeField]
    private float UpgradeCost = 2f;
    [SerializeField]
    private float AutoCost = 27f;
    [SerializeField]
    public Text ScoreText;
    [SerializeField]
    public Text UpgradeCostText;
    [SerializeField]
    private GameObject Auto;
    [SerializeField]
    public Text AutoCostText;
    // Start is called before the first frame update
    void Start()
    {
        // Make Auto button disapear
        Auto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Display Donuts
        ScoreText.text = "Donuts " + (int)ScoreCount;
        // Display upgarde cost
        UpgradeCostText.text = "Upgrade Cost " + (int)UpgradeCost;
        // Display auto cost
        AutoCostText.text = "Auto Cost " + (int)AutoCost;
        // If donuts is 27 or greater
        if (ScoreCount >= 27)
        {
            // Reveal auto button
            Auto.SetActive(true);
        }
        // If Auto is revealed and AUTOR is equal to more then 1
        if (Auto == true && AUTOR >= 1)
        {
            // Acivate auto clicker
            ScoreCount +=  AUTOR * Time.deltaTime;
        }
    }
    public void IncreaseDonut()
    {
        // If Score is equal to or greater than upgrade cost
        if (ScoreCount >= UpgradeCost)
        {
            // Pay donuts to activate
            ScoreCount = (ScoreCount - UpgradeCost);
            // Increase 
            UpgradeCost = UpgradeCost + 5;
            // increase click value by 1
            ScoreCountIncrease = ScoreCountIncrease + 1;
        }
    }

    public void RaiseDonut()
    {
        // when clicked increase score
        ScoreCount = ScoreCount + ScoreCountIncrease;
    }

    public void AutoDonut()
    {
        // If Score is equal to or greater than auto cost
        if (ScoreCount >= AutoCost)
        {
            // Pay donuts
            ScoreCount = (ScoreCount - AutoCost);
            // Increase Auto value by 1
            AUTOR = AUTOR + 2;
            // Make Auto cost double its cost
            AutoCost = AutoCost * 2;
        }
    }
}
