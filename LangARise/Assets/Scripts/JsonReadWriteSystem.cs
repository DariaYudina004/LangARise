using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonReadWriteSystem : MonoBehaviour
{
    public int NumberOfTextInfo;
    public int CountQuestionsInTestInfo;
    public string TextOfQuestionInfo;
    public List<string> RightAnswersInfo;
    public List<string> WrongAnswersInfo;

    public void SetData()
    {
        QuestionManager questionManager = new QuestionManager();
        NumberOfTextInfo = questionManager.NumberOfQuestion;
        CountQuestionsInTestInfo = questionManager.Count;
        TextOfQuestionInfo = questionManager.QuestionText.text;
        RightAnswersInfo = questionManager.RightAnswer;
        WrongAnswersInfo = questionManager.WrongAnswer;

    }
    public void SaveToJson()
    {
        TestsData data = new TestsData();
        data.NumberOfText = NumberOfTextInfo;
        data.CountQuestionsInTest = CountQuestionsInTestInfo;
        data.TextOfQuestion = TextOfQuestionInfo;
        data.RightAnswers = RightAnswersInfo;
        data.WrongAnswers = WrongAnswersInfo;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/TestsDataFile.json", json);
    }
    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/TestsDataFile.json");
        TestsData data = JsonUtility.FromJson<TestsData>(json);
        NumberOfTextInfo = data.NumberOfText;
        CountQuestionsInTestInfo = data.CountQuestionsInTest;
        TextOfQuestionInfo = data.TextOfQuestion;
        RightAnswersInfo = data.RightAnswers;
        WrongAnswersInfo = data.WrongAnswers;
    }

    public void GetData()
    {
        QuestionManager questionManager = new QuestionManager();
        questionManager.NumberOfQuestion = NumberOfTextInfo;
        questionManager.Count = CountQuestionsInTestInfo;
        questionManager.QuestionText.text = TextOfQuestionInfo;
        questionManager.RightAnswer = RightAnswersInfo;
        questionManager.WrongAnswer = WrongAnswersInfo;

    }
}

