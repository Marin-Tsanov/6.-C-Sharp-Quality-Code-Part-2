using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IList<IExam> Exams { get; set; }

    public Student(string firstName, string lastName, IList<IExam> exams/* = null*/)
    {
        if (firstName == null || firstName == string.Empty || !(firstName.All(char.IsLetter)))
        {
            throw new ArgumentException("The firstName must contain only letters, it cannot be empty or null.");
        }

        if (lastName == null || lastName == string.Empty || !(lastName.All(char.IsLetter)))
        {
            throw new ArgumentException("The lastName must contain only letters, it cannot be empty or null.");
        }

        if (exams == null || exams.Count == 0)
        {
            throw new ArgumentException("The student's examResults cannot be null or empty");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public IList<ExamResult> CheckExams()
    {
        IList<ExamResult> results = new List<ExamResult>();

        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = CheckExams();

        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] =
                (double)((examResults[i].Grade - examResults[i].MinGrade) /
                (examResults[i].MaxGrade - examResults[i].MinGrade));
        }

        return examScore.Average();
    }
}