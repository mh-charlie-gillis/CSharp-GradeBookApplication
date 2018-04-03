using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades" +
                                  " in order to properly calculate a student's overall grade.");
            }
            else
            {
            base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades" +
                                  " in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }

        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            else
            {

                var dropCount = (int)Math.Ceiling(Students.Count * 0.2);

                var gradeList = (from student in Students
                          orderby student.AverageGrade descending
                          select student.AverageGrade).ToList();

                if (gradeList[dropCount - 1] <= averageGrade)
                    return 'A';
                else if (gradeList[(dropCount * 2) - 1] <= averageGrade)
                    return 'B';
                else if (gradeList[(dropCount * 3) - 1] <= averageGrade)
                    return 'C';
                else if (gradeList[(dropCount * 4) - 1] <= averageGrade)
                    return 'D';
                else
                    return 'F';
            }
        }
    }
}
