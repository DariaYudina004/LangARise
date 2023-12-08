using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/QuestionsList", fileName = "QuestionsList")]
public class QuestionsList : ScriptableObject
{
    public QuestionsBase[] questionsInList;
}
