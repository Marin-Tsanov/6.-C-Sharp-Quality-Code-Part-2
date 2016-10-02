using System;

public class ExamResult
{
    public int Grade { get; /*private*/ set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; /*private*/ set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < minGrade || maxGrade < grade)
        {
            throw new ArgumentOutOfRangeException($"The value of grade cannot be less than the value of minGrade {minGrade} and bigger than the value of maxGrade {maxGrade}.");
        }

        if (minGrade < 0)
        {
            throw new ArgumentException("The value of mingrade cannot be less than zero.");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("The value of maxGrade cannot be less or equal to the value of minGrade.");
        }

        if (comments == null || comments == string.Empty)
        {
            throw new ArgumentException("Comments cannot be null or empty.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}