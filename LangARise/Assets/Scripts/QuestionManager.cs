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

    [SerializeField] private int count;
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
                count = oneFromList.Count - i;
                CountText.text = "Осталось вопросов: " + count.ToString();
                int rand = Random.Range(0, answer.Count);
                answersOfOneQuestion[i].text = answer[rand];
                answer.RemoveAt(rand);
            }
        }
        else
        {
            LearningBlock.SetActive(false);
            EndPanel.SetActive(true);
            Debug.Log("Тестирование окончено");
        }

    }

    public void DeleteQuestionFromListAfterClickNextButton(int index)
    {
        if (answersOfOneQuestion[index].text.ToString() == currentBase.answersOnBase[0])
        {
            answersOfOneQuestion[index].GetComponent<AudioSource>().clip = buttonRightOrWrongAnswerClip[0];
            answersOfOneQuestion[index].GetComponent<AudioSource>().Play();
            QuestionText.text = "Правильный ответ";
            Debug.Log("Правильный ответ");
            RightAnswer.Add(answersOfOneQuestion[index].text.ToString());
        }
        else
        {
            answersOfOneQuestion[index].GetComponent<AudioSource>().clip = buttonRightOrWrongAnswerClip[1];
            answersOfOneQuestion[index].GetComponent<AudioSource>().Play();
            QuestionText.text = "Неправильный ответ :(";
            Debug.Log("Неправильный ответ :(");
            WrongAnswer.Add(answersOfOneQuestion[index].text.ToString());
        }
        oneFromList.RemoveAt(oneVersion);
        GenerateQuestionFromList();
    }
}
