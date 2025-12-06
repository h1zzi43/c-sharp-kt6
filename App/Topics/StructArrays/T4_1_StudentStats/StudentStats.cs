// Тема 4, Задача T4.1_StudentStats
// Работа с массивами структур и простыми аналитическими функциями.

namespace App.Topics.StructArrays.T4_1_StudentStats;

public readonly struct Student
{
    public string Name { get; }
    public int Score { get; }

    public Student(string name, int score)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        if (score < 0 || score > 100)
            throw new ArgumentOutOfRangeException(nameof(score), "Score must be between 0 and 100.");

        Name = name;
        Score = score;
    }
}

public static class StudentAnalytics
{
    public static double AverageScore(Student[] students)
    {
        if (students == null)
            throw new ArgumentNullException(nameof(students));

        if (students.Length == 0)
            throw new InvalidOperationException("Array cannot be empty.");

        double sum = 0;
        foreach (var student in students)
        {
            sum += student.Score;
        }
        return sum / students.Length;
    }

    public static int MaxScore(Student[] students)
    {
        if (students == null)
            throw new ArgumentNullException(nameof(students));

        if (students.Length == 0)
            throw new InvalidOperationException("Array cannot be empty.");

        int max = students[0].Score;
        for (int i = 1; i < students.Length; i++)
        {
            if (students[i].Score > max)
                max = students[i].Score;
        }
        return max;
    }

    public static int CountPassed(Student[] students)
    {
        if (students == null)
            return 0;

        int count = 0;
        foreach (var student in students)
        {
            if (student.Score >= 60)
                count++;
        }
        return count;
    }
}
