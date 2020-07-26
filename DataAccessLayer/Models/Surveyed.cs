using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Surveyed
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Answer { get; set; }

        public Surveyed(string name, int questionId, string userName, string answer, int surveyId)
        {
            this.Name = name;
            this.QuestionId = questionId;
            this.UserName = userName;
            this.Answer = answer;
            this.SurveyId = surveyId;
        }

        public Surveyed()
        {

        }
    }
}
