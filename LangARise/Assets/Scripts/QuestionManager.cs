using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public QuestionsList Qlist;
    public TextMeshPro[] answersOfOneQuestion; // ���� �������� �������                                          
    [SerializeField] private TextMeshProUGUI questionText; // ���� ������ ��� ������

    List<object> oneFromList;
    QuestionsBase currentBase;
    private int oneVersion; // ���� ���������

    public void OnClickAnswerButton()
    {
        oneFromList = new List<object>(Qlist.questionsInList);
        Debug.Log("������ �� ������ ��������� ��������� �������");
        GenerateQuestionFromList();
    }
    
    public void GenerateQuestionFromList()
    {
        Debug.Log("���������� oneFromList.Count" + oneFromList.Count);
        if (oneFromList.Count > 0)
        {
            oneVersion = Random.Range(0, oneFromList.Count);
            //oneVersion = qList.questionsInList[Random.Range(0, QList.questionsInList.Count)];
            currentBase = oneFromList[oneVersion] as QuestionsBase;
            questionText.text = currentBase.QuestionsOnBase;
            for (int i = 0; i < currentBase.answersOnBase.Count; i++)
            {
                int rand = Random.Range(0, currentBase.answersOnBase.Count);
                answersOfOneQuestion[i].text = currentBase.answersOnBase[rand];
                //currentBase.answersOnBase.RemoveAt(rand);
                Debug.Log(i);
            }
        }
        else
        {
            questionText.text = "������������ ��������";
        }

    }

    public void DeleteQuestionFromListAfterClickNextButton(int index)
    {
        if (answersOfOneQuestion[index].text.ToString() == currentBase.answersOnBase[0])
        {
            questionText.text = "���������� �����";
        }
        else
        {
            questionText.text = "������������ ����� :(";
        }
        oneFromList.RemoveAt(oneVersion);
        GenerateQuestionFromList();
    }
}
