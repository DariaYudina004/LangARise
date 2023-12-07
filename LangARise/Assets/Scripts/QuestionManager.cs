using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private QuestionsList qList; // �� ������ ������������� �������� ������ ������� 
    public QuestionsList QList => qList; //
    [SerializeField] private QuestionsBase oneVersion; // ���� ���������
    //
    [SerializeField] private TextMeshProUGUI questionText; // ���� ������ ��� ������
    public TextMeshProUGUI QuestText { get { return questionText; } set { questionText = value; } }

    public List<TextMeshPro> answersOfOneQuestion; // ���� �������� ������� 



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
