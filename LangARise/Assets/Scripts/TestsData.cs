using System.Collections.Generic;

[System.Serializable]
public class TestsData
{
    public int NumberOfText; // ID
    public int CountQuestionsInTest;
    public string TextOfQuestion;
    public List<string> RightAnswers;
    public List<string> WrongAnswers;
}
