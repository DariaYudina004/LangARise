using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private QuestionsList qList; // »з списка присваиваютс€ значени€ одному вопросу 
    public QuestionsList QList => qList; 
    private int oneVersion; // ќдин Ёкземпл€р

    [SerializeField] private TextMeshProUGUI questionText; // —юда уходит сам вопрос
    public TextMeshProUGUI QuestText { get { return questionText; } set { questionText = value; } }

    public List<TextMeshPro> answersOfOneQuestion; // —юда варианты ответов 



    public void GenerateQuestionFromList()
    {
        if(QList.questionsInList.Count > 0)
        {
            oneVersion = Random.Range(0, QList.questionsInList.Count);
            //oneVersion = qList.questionsInList[Random.Range(0, QList.questionsInList.Count)];
            QuestText.text = QList.questionsInList[oneVersion].QuestionsOnBase;
            for (int i = 0; i < QList.questionsInList[oneVersion].answersOnBase.Count; i++)
            {
                int rand = Random.Range(0, QList.questionsInList[oneVersion].answersOnBase.Count);
                answersOfOneQuestion[i].text = QList.questionsInList[oneVersion].answersOnBase[rand];
                QList.questionsInList[oneVersion].answersOnBase.RemoveAt(rand);
                Debug.Log(i);
            }
        }
        
    }

    public void DeleteQuestionFromListAfterClickNextButton(int index)
    {
        if (answersOfOneQuestion[index].text.ToString() == QList.questionsInList[oneVersion].answersOnBase[0]) Debug.Log("OK");
        else Debug.Log("Not OK");
        QList.questionsInList.RemoveAt(oneVersion);
        GenerateQuestionFromList();
    }
}
