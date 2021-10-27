using UnityEngine;
using UnityEngine.UI;


public class ChoiceBoard : MonoBehaviour
{
    public int firstValue;
    public int secondValue;
    public int correctAnswer;
    public int wrongAnswer;
    public GameObject equation;
    public GameObject leftChoice;
    public GameObject rightChoice;

    void Start()
    {
        equation = GameObject.Find("Equation");
        leftChoice = GameObject.Find("LeftChoice");
        rightChoice = GameObject.Find("RightChoice");
        do {
            firstValue = Random.Range(1,6);
            secondValue = Random.Range(1,6);
        } while (secondValue >= firstValue); 
        string[] mathOperations = new [] {"+", "-"};
        string mathOperation = mathOperations[Random.Range(0, mathOperations.Length)];
        switch (mathOperation)
        {
            case "+":
                correctAnswer = firstValue + secondValue;
                break;
            case "-":
                correctAnswer = firstValue - secondValue;
                break;
        }
        do {
            wrongAnswer = Random.Range(0,20);
        } while (!(wrongAnswer != correctAnswer && wrongAnswer >= 0 && System.Math.Abs(wrongAnswer - correctAnswer) < 4));
        equation.GetComponent<TextMesh>().text = firstValue.ToString() + " " + mathOperation + " " + secondValue.ToString();

        switch (Random.Range(0, 2)) 
        {
            case 0:
                leftChoice.GetComponent<TextMesh>().text = correctAnswer.ToString();
                rightChoice.GetComponent<TextMesh>().text = wrongAnswer.ToString();
                break;
            case 1:
                leftChoice.GetComponent<TextMesh>().text = wrongAnswer.ToString();
                rightChoice.GetComponent<TextMesh>().text = correctAnswer.ToString();
                break;
        }
    }

    private void Update()
    {

    }

}

