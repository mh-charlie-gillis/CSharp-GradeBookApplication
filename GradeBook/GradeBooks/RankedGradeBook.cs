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
