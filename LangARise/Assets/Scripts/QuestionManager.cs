using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public QuestionsList Qlist;
    public TextMeshPro[] answersOfOneQuestion; // Сюда варианты ответов                                          
    [SerializeField] private TextMeshProUGUI questionText;
    public TextMeshProUGUI QuestionText { get { return questionText; } set { questionText = value; } }
    [SerializeField] private List<string> rightAnswer;
    public List<string> RightAnswer { get { return rightAnswer; } set { rightAnswer = value; } }
    [SerializeField] private List<string> wrongAnswer;
    public List<string> WrongAnswer { get { return wrongAnswer; } set { wrongAnswer = value; } }
    [SerializeField] private GameObject endPanel;
    public GameObject EndPanel { get { return endPanel; } set { endPanel = value; } }
    [SerializeField] private GameObject learningBlock;
    public GameObject LearningBlock { get { return learningBlock; } set { learningBlock = value; } }
    [SerializeField] private TextMeshProUGUI CountText;
    [SerializeField] private AudioClip[] buttonRightOrWrongAnswerClip;
    [SerializeField] private AudioSource sourse;
    [SerializeField] private int count;
    [SerializeField] private GameObject[] hideButtons;
    [SerializeField] private GameObject[] nowButtons = new GameObject[2];
    [SerializeField] private TextMeshProUGUI questionText1;
    public int Count { get { return count; } set { count = value; } }
    [SerializeField] private int numberOfQuestion;
    public int NumberOfQuestion { get { return count; } set { count = value; } }
    List<object> oneFromList;
    QuestionsBase currentBase;
    private int oneVersion; // Один Экземпляр

    public void ClickButoons()
    {
        oneFromList = new List<object>(Qlist.questionsInList);
        RightAnswer = new List<string>();
        WrongAnswer = new List<string>();
        Debug.Log("НАЖАЛИ НА КНОПКУ СРАБОТАЛА ГЕНЕРАЦИЯ ВОПРОСА");
        GenerateQuestionFromList();
        for (int i = 0; i < hideButtons.Length; i++)
        {
            hideButtons[i].SetActive(true);
        }
        nowButtons[0].SetActive(false);
        nowButtons[1].SetActive(false);
        Debug.Log("Тестирование окончено");

    }

    public void GenerateQuestionFromList()
    {
        Debug.Log("Количество oneFromList.Count" + oneFromList.Count);
        if (oneFromList.Count > 0)
        {
            oneVersion = Random.Range(0, oneFromList.Count);
            currentBase = oneFromList[oneVersion] as QuestionsBase;
            QuestionText.text = currentBase.QuestionsOnBase;
            List<string> answer = new List<string>(currentBase.answersOnBase);
            for (int i = 0; i < currentBase.answersOnBase.Length; i++)
            {
                Debug.Log(" oneFromList.Count - i;" + oneFromList.Count);
                count = oneFromList.Count - 1;
                CountText.text = "Осталось вопросов: " + count.ToString();
                int rand = Random.Range(0, answer.Count);
                answersOfOneQuestion[i].text = answer[rand];
                answer.RemoveAt(rand);
            }
        }
        else
        {
            for (int i = 0; i < hideButtons.Length; i++)
            {
                hideButtons[i].SetActive(false);
            }
            QuestionText.text = "Тестирование окончено";
            nowButtons[0].SetActive(true);
            nowButtons[1].SetActive(true);
            CountText.text = "";
            Debug.Log("Тестирование окончено");
        }

    }

    public void DeleteQuestionFromListAfterClickNextButton(int index)
    {
        if (answersOfOneQuestion[index].text.ToString() == currentBase.answersOnBase[0])
        {
            sourse.clip = buttonRightOrWrongAnswerClip[0];
            sourse.Play();
            QuestionText.text = "Правильный ответ";
            Debug.Log("Правильный ответ");
            RightAnswer.Add(answersOfOneQuestion[index].text.ToString());
        }
        else
        {
            sourse.clip = buttonRightOrWrongAnswerClip[1];
            sourse.Play();
            QuestionText.text = "Неправильный ответ :(";
            Debug.Log("Неправильный ответ :(");
            WrongAnswer.Add(answersOfOneQuestion[index].text.ToString());
        }
        oneFromList.RemoveAt(oneVersion);
        GenerateQuestionFromList();
    }
    public void WriteData()
    {
        QuestionText.text = "Неправильные ответы: ";
        questionText1.text = "";
        for (int i = 0; i < wrongAnswer.Count; i++)
        {
            questionText1.text += wrongAnswer[i] + "\n";

        }
    }
}
