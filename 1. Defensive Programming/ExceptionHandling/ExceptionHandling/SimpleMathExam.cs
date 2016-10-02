using System;

public class SimpleMathExam : IExam
{
    public int ProblemsSolved { get; private set; }

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0 || 2 < problemsSolved)
        {
            throw new ArgumentOutOfRangeException("The value of problemsSolved must be in the range [0,2]");
        }

        this.ProblemsSolved = problemsSolved; 
    }

    public/* override*/ ExamResult Check()
    {
        ExamResult examResult = new ExamResult(2, 2, 6, "Student has not taken the exam yet.");
        int grade = 2 + ProblemsSolved * 2;
        string comment = string.Empty;

        switch (ProblemsSolved)
        {
            case 0:
                {
                    examResult.Grade = grade;
                    comment = "Bad result: nothing done.";
                    examResult.Comments = comment;
                    return examResult;
                }

            case 1:
                {
                    examResult.Grade = grade;
                    comment = "Good result: 1 task was done.";
                    examResult.Comments = comment;
                    return examResult;
                }

            case 2:
                {
                    examResult.Grade = grade;
                    comment = "Excellent result: All tasks were done.";
                    examResult.Comments = comment;
                    return examResult;
                }

            default:
                throw new ArgumentException("The value of problemsSolved must be in the range[0,2] and there must be a proper comment set.");
        }
    }
}