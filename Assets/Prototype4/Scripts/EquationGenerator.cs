using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquationGenerator : MonoBehaviour
{
    public enum Difficulty { EASY, MEDIUM, HARD }

    public Difficulty difficulty;

    public int numberOne;
    public int numberTwo;
    public int correctAnswer;
    public TMP_Text answer;
    public float currentAnswer;
    public TMP_Text equation;
    public TMP_Text firstNumber;
    public TMP_Text secondNumber;
    public TMP_Text thirdNumber;
    public TMP_Text fourthNumber;
    

    public List<int> dummyAnswers;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            GenerateMultiplication();
            
            GenerateRandomNumbers();
        }
            
        if (Input.GetKeyDown(KeyCode.A))
        {
            GenerateAddition();
            GenerateRandomNumbers();
        }
            
        if (Input.GetKeyDown(KeyCode.D))
        {
            GenerateDivision();
            GenerateRandomNumbers();
        }
            
        if (Input.GetKeyDown(KeyCode.R))
        {
            GenerateRandomEquation();
            GenerateRandomNumbers();
        }

        
            
    }

    void GenerateRandomEquation()
    {
        int rnd = Random.Range(1, 100);
        if (rnd <= 35)
            GenerateAddition();
        else if (rnd <= 60)
            GenerateSubtraction();
        else if (rnd <= 90)
            GenerateMultiplication();
        else
            GenerateDivision();

        
    }

    void GenerateMultiplication()
    {
        numberOne = GetRandomNumbers();
        numberTwo = GetRandomNumbers();
        correctAnswer = numberOne * numberTwo;

        Debug.Log(numberOne + " x " + numberTwo + " = " + correctAnswer);

        answer.text = correctAnswer.ToString();
        equation.text = "x";


        GenerateDummyAnswers();
    }

    void GenerateAddition()
    {
        numberOne = GetRandomNumbers();
        numberTwo = GetRandomNumbers();
        correctAnswer = numberOne + numberTwo;

        Debug.Log(numberOne + " + " + numberTwo + " = " + correctAnswer);

        answer.text = correctAnswer.ToString();
        equation.text = "+";

        GenerateDummyAnswers();
    }

    void GenerateSubtraction()
    {
        numberOne = GetRandomNumbers();
        numberTwo = GetRandomNumbers();
        correctAnswer = numberOne - numberTwo;

        Debug.Log(numberOne + " - " + numberTwo + " = " + correctAnswer);

        answer.text = correctAnswer.ToString();
        equation.text = "-";

        GenerateDummyAnswers();
    }

    void GenerateDivision()
    {
        numberOne = GetRandomNumbers();
        numberTwo = GetRandomNumbers();
        correctAnswer = numberOne / numberTwo;
        correctAnswer = Mathf.RoundToInt(correctAnswer);
        Debug.Log(numberOne + " / " + numberTwo + " = " + correctAnswer);

        answer.text = correctAnswer.ToString();
        equation.text = "/";

        GenerateDummyAnswers();
    }

    /// <summary>
    /// Gets a random number based on our difficulty
    /// </summary>
    /// <returns>A random number</returns>
    int GetRandomNumbers()
    {
        switch (difficulty)
        {
            case Difficulty.EASY:
                return (Random.Range(1, 10));
            case Difficulty.MEDIUM:
                return (Random.Range(1, 20));
            case Difficulty.HARD:
                return (Random.Range(1, 100));
            default:
                return (Random.Range(1, 10));
        }
    }

    /// <summary>
    /// This will generate a set of dummy answers
    /// </summary>
    private void GenerateDummyAnswers()
    {
        for (int i = 0; i < dummyAnswers.Count; i++)
        {
            int dummy;
            do
            {
                dummy = Random.Range(correctAnswer - 10, correctAnswer + 10);
            }
            while (dummy == correctAnswer || dummyAnswers.Contains(dummy));
            dummyAnswers[i] = dummy;
            Debug.Log("Dummy answer: " + dummyAnswers[i]);
        }
    }

    void GenerateRandomNumbers()
    {

            firstNumber.text = numberOne.ToString();
            secondNumber.text = GetRandomNumbers().ToString();
            thirdNumber.text = numberTwo.ToString();
            fourthNumber.text = GetRandomNumbers().ToString();

        
    }

   
}