using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquationGenerator : GameBehaviour<EquationGenerator>
{
    public enum Difficulty { EASY, MEDIUM, HARD }
    public enum Equation { Addition, Subtraction, Division, Multiplication}

    public Difficulty difficulty;

    public Equation equat;

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
    public int playerHealth = 3;
    public TMP_Text firstText;
    public TMP_Text secondText;
    public int firstGuess;
    public int secondGuess;
    public int thirdGuess;
    public int fourthGuess;


    public List<int> dummyAnswers;

    private void Start()
    {
        
        Reset();
    }
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
        equat = Equation.Multiplication;


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
        equat = Equation.Addition;

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
        secondNumber.text = dummyAnswers[0].ToString();
        thirdNumber.text = numberTwo.ToString();
        fourthNumber.text = dummyAnswers[1].ToString();

      
    }

    public void CheckNumber(string number)
    {
        if (firstText.text == "")
            firstText.text = number;
        else
        {
            secondText.text = number;
            StartCoroutine(CheckAnswer());
        }
    }

    IEnumerator CheckAnswer()
    {
        if(equat == Equation.Addition || equat == Equation.Multiplication)
        {
            if (firstText.text == numberOne.ToString() || secondText.text == numberOne.ToString() && firstText.text == numberTwo.ToString() || secondText.text == numberTwo.ToString())
            {
                Debug.Log("correct");

            }
            else
                Debug.Log("Incorrect");
        }
        yield return new WaitForSeconds(1);
        Reset();
    }

    private void Reset()
    {
        firstNumber.gameObject.SetActive(true);
        secondNumber.gameObject.SetActive(true);
        thirdNumber.gameObject.SetActive(true);
        fourthNumber.gameObject.SetActive(true);
        firstText.text = "";
        secondText.text = "";
        GenerateRandomEquation();
        GenerateRandomNumbers();
    }




}