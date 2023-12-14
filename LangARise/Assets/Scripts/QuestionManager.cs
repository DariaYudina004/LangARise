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

    public void OnClickAnswerButton()
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
            List<string> answers = new List<string>(currentBase.answersOnBase);
            for (int i = 0; i < currentBase.answersOnBase.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersOfOneQuestion[i].text = answers[rand];
                answers.RemoveAt(rand);
                Debug.Log(i);
            }
        }
        else
        {
            questionText.text = "Тестирование окончено";
        }

    }

    public void DeleteQuestionFromListAfterClickNextButton(int index)
    {
        Debug.Log("answersOfOneQuestion[index]" , answersOfOneQuestion[index]);
        //if (answersOfOneQuestion[index].text.ToString() == currentBase.answersOnBase[0])
        //{
        //    questionText.text = "Правильный ответ";
        //}
        //else
        //{
        //    questionText.text = "Неправильный ответ :(";
        //}
        oneFromList.RemoveAt(oneVersion);
        GenerateQuestionFromList();
    }
}
