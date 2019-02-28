/**
 * 
 * name         :   MarkSummary.cs
 * author       :   Kevin McDonald
 * email        :   kevin.mcdonald@dundeeandangus.ac.uk
 * version      :   1.0
 * date         :   15th February 2019
 * description  :   View Model class for collating calculated data for student marks.
 * MODIFIED BY  :   !!  YOUR NAME HERE  !!
 *
 * */

using Assessment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Assessment.ViewModels
{
    [NotMapped]
    public class MarkSummary
    {
        public int ID { get; set; }
        public int Count { get; set; }
        public int TotalMarks { get; set; }
        public double Average { get; set; }
        public int Highest { get; set; }
        public int Lowest { get; set; }

        public MarkSummary(List<Mark> marks)
        {
            Count = marks.Count;
            TotalMarks = marks.Sum(m => m.Total);
            Average = TotalMarks / Count;
            Lowest = CalcLowest(marks.ToArray());
            Highest = CalcHighest(marks.ToArray());
        }

        public int CalcHighest(Mark[] marks)
        {
            //  Complete the algorithm and remove the exception
            throw new NotImplementedException();
        }

        public int CalcLowest(Mark[] marks)
        {
            //  Complete the algorithm and remove the exception
            throw new NotImplementedException();
        }
    }
}
//--    End of File --//