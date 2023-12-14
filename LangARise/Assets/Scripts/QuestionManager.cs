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
            questionText.text = "������������ ��������";
        }

    }

    public void DeleteQuestionFromListAfterClickNextButton(int index)
    {
        Debug.Log("answersOfOneQuestion[index]" , answersOfOneQuestion[index]);
        //if (answersOfOneQuestion[index].text.ToString() == currentBase.answersOnBase[0])
        //{
        //    questionText.text = "���������� �����";
        //}
        //else
        //{
        //    questionText.text = "������������ ����� :(";
        //}
        oneFromList.RemoveAt(oneVersion);
        GenerateQuestionFromList();
    }
}
