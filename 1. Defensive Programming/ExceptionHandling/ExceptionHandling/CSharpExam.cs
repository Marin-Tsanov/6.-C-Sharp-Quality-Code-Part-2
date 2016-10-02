using System;

public class CSharpExam : IExam
{
    public int Score { get; private set; }

    public CSharpExam(int score)
    {
        if (score < 0 || 100 < score)
        {
            throw new ArgumentOutOfRangeException("Score's value cannot be less than zero.");
        }

        this.Score = score;
    }

    public/*override*/ ExamResult Check()
    {
        var examResult = new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        return examResult;
    }
}