using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public QuestionsList Qlist;
    public TextMeshPro[] answersOfOneQuestion; // Сюда варианты ответов                                          
    [SerializeField] private TextMeshProUGUI questionText; // Сюда уходит сам вопрос

    List<object> oneFromList;
    QuestionsBase currentBase;
    private int oneVersion; // Один Экземпляр

    public void ClickButoons()
    {
        oneFromList = new List<object>(Qlist.questionsInList);
        Debug.Log("НАЖАЛИ НА КНОПКУ СРАБОТАЛА ГЕНЕРАЦИЯ ВОПРОСА");
        GenerateQuestionFromList();
    }

    public void GenerateQuestionFromList()
    {
        Debug.Log("Количество oneFromList.Count" + oneFromList.Count);
        if (oneFromList.Count > 0)
        {
            oneVersion = Random.Range(0, oneFromList.Count);
            //oneVersion = qList.questionsInList[Random.Range(0, QList.questionsInList.Count)];
            currentBase = oneFromList[oneVersion] as QuestionsBase;
            questionText.text = currentBase.QuestionsOnBase;
            List<string> answer = new List<string>(currentBase.answersOnBase);
            for (int i = 0; i < currentBase.answersOnBase.Length; i++)
            {
                int rand = Random.Range(0, answer.Count);
                answersOfOneQuestion[i].text = answer[rand];
                answer.RemoveAt(rand);
                //if (answer.Count <= 2)
                //{
                //    answersOfOneQuestion[i].text = currentBase.answersOnBase[i];

                //}
                Debug.Log(i);
            }
        }
        else
        {
            questionText.text = "Тестирование окончено";
            Debug.Log("Тестирование окончено");
        }

    }

    public void DeleteQuestionFromListAfterClickNextButton(int index)
    {
        if (answersOfOneQuestion[index].text.ToString() == currentBase.answersOnBase[0])
        {
            questionText.text = "Правильный ответ";
            Debug.Log("Правильный ответ");
        }
        else
        {
            questionText.text = "Неправильный ответ :(";
            Debug.Log("Неправильный ответ :(");
        }
        oneFromList.RemoveAt(oneVersion);
        GenerateQuestionFromList();
    }
}
