using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private QuestionsList qList; // »з списка присваиваютс€ значени€ одному вопросу 
    public QuestionsList QList => qList; //
    [SerializeField] private QuestionsBase oneVersion; // ќдин Ёкземпл€р
    //
    [SerializeField] private TextMeshProUGUI questionText; // —юда уходит сам вопрос
    public TextMeshProUGUI QuestText { get { return questionText; } set { questionText = value; } }

    public List<TextMeshPro> answersOfOneQuestion; // —юда варианты ответов 



    public void OnClickPlay()
    {
        oneVersion = qList.questionsInList[Random.Range(0, QList.questionsInList.Count)];
        QuestText.text = oneVersion.QuestionsOnBase;
        for (int i = 0; i < oneVersion.answersOnBase.Count; i++)
        {
            answersOfOneQuestion[i].text = oneVersion.answersOnBase[i];
        }


    }
}
