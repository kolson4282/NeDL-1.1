using System;

//Keith Olson
//9/15/22
//Homework Grade Calculation

//1. Take in the number of students to calculate grades for.
//2. For each student, get 
// a. Name.
// b. 5 homework grades
// c. 3 quiz grades
// d. 2 exam grades
//all grades will be between 0 and 100
//3. Calculate final grade.
//4. Get final grade letter.
//5. display student name, hw average, quiz average, exam average, final average and grade 
namespace homeworkGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get number of students to calculate grades for.
            int students;
            do
            {
                Console.Write("How many students do you have? ");
                students = Convert.ToInt32(Console.ReadLine());
                if (students < 1)
                {
                    Console.WriteLine("You must enter at least 1 student");
                }
            } while (students < 1);

            //for that many students
            for (int i = 1; i <= students; i++)
            {
                //Get name
                Console.Write($"Enter the name of student number {i}: ");
                string name = Console.ReadLine()!;
                Console.WriteLine();

                //Get 5 homework grades and average
                double homeworkAverage = GetGradeAverage("homework", 5);
                Console.WriteLine();

                //Get 3 quiz grades and average
                double quizAverage = GetGradeAverage("quiz", 3);
                Console.WriteLine();

                //Get 2 exam grades and average
                double examAverage = GetGradeAverage("exam", 2);
                Console.WriteLine();

                //calculate final average
                double finalAverage = .5 * homeworkAverage + .3 * quizAverage + .2 * examAverage;

                //calculate final letter grade
                string finalGrade = "F";

                if (finalAverage >= 90)
                {
                    finalGrade = "A";
                }
                else if (finalAverage >= 80)
                {
                    finalGrade = "B";
                }
                else if (finalAverage >= 70)
                {
                    finalGrade = "C";
                }
                else if (finalAverage >= 60)
                {
                    finalGrade = "D";
                }

                //print out student
                Console.WriteLine($"NAME: {name}, HOMEWORK: {Math.Round(homeworkAverage, 2)}%, QUIZ: {Math.Round(quizAverage, 2)}%, " +
                                $"EXAM: {Math.Round(examAverage, 2)}%, FINAL: {Math.Round(finalAverage, 2)}%, {finalGrade}");
            }//end of the for
        }
        static double GetGradeAverage(string type, int numberOfGrades)
        {
            double total = 0;
            Console.WriteLine($"---Enter {type} Grades--");
            for (int i = 1; i <= numberOfGrades; i++)
            {
                double grade;
                do
                {
                    Console.Write($"Enter {type} grade number {i}: ");
                    grade = Convert.ToDouble(Console.ReadLine());
                    if (grade < 0 || grade > 100)
                    {
                        Console.WriteLine("Grade must be between 0 and 100");
                    }
                } while (grade < 0 || grade > 100);
                total += grade;
            }
            return total / numberOfGrades;
        }
    }
}