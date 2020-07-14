using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
   public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SurveyId { get; set; }

        public Question(string name, int surveyId)
        {
            this.Name = name;
            this.SurveyId = surveyId;
        }
        public Question()
        {

        }
    }
}
