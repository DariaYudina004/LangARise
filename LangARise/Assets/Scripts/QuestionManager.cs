using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public QuestionsList qList;
    public Text QuestionText;

    public void OnClickPlay()
    {
        QuestionText.text = qList.questions[Random.Range(0, qList.questions.Count)].Questions;
    }
}
