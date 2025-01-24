using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinalTaskNPC : MonoBehaviour
{
    public GameObject dialoguePanel; // Dialogue panel for congratulatory message
    public GameObject quizPanel; // Quiz panel for the question and answers
    public TextMeshProUGUI dialogueText; // Text for NPC dialogue
    public TextMeshProUGUI questionText; // Text for the quiz question
    public Button[] answerButtons; // Array for the answer buttons

    private bool isQuizActive = false; // Check if quiz is active
    private string correctAnswer = "C"; // Correct answer ID (Button 3)

    void Start()
    {
        // Ensure all panels are inactive at the start
        dialoguePanel.SetActive(false);
        quizPanel.SetActive(false);

        // Assign button listeners
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i; // Capture the index for the closure
            answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Robot")) // Ensure the robot is tagged as "Player"
        {
            ShowDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Robot")) // Ensure the robot is tagged as "Player"
        {
            HidePanels(); // Hide all active panels when the robot leaves
        }
    }

    private void ShowDialogue()
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = "Congratulations, Unit 01! You’ve completed all the tasks so far. But before you can proceed, I have one final challenge for you. Answer this question to unlock the truth about this area.";
        Invoke(nameof(ShowQuiz), 5f); // Show the quiz after 5 seconds
    }

    private void ShowQuiz()
    {
        dialoguePanel.SetActive(false);
        quizPanel.SetActive(true);

        questionText.text = "What caused the disappearance of all organic life in this area?";
        answerButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = "A. A massive solar flare";
        answerButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = "B. A deadly robotic uprising";
        answerButtons[2].GetComponentInChildren<TextMeshProUGUI>().text = "C. A global energy crisis";
    }

    private void CheckAnswer(int index)
    {
        string selectedAnswer = answerButtons[index].GetComponentInChildren<TextMeshProUGUI>().text;

        if (selectedAnswer.StartsWith(correctAnswer))
        {
            RevealTruth();
        }
        else
        {
            questionText.text = "Incorrect. Try again!";
        }
    }

    private void RevealTruth()
    {
        quizPanel.SetActive(false);
        dialoguePanel.SetActive(true);
        dialogueText.text = "Correct! This area was abandoned due to a global energy crisis. Robots like us have been searching for sustainable energy sources ever since. Head to the level transporter to face your next task!";
        Invoke(nameof(CompleteFinalTask), 5f); // After 5 seconds, allow level transfer
    }

    private void HidePanels()
    {
        dialoguePanel.SetActive(false); // Hide the dialogue panel
        quizPanel.SetActive(false); // Hide the quiz panel
    }

    private void CompleteFinalTask()
    {
        Debug.Log("Final task complete. Proceed to level transfer.");
        // Add your scene transfer logic here if needed
    }
}
