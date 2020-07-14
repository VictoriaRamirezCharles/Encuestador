using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
   public class Survey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuestionQuantity { get; set; }
        public string UserName { get; set; }

        public Survey(string name, int QuestionQuantity, string userName)
        {
            this.Name = name;
            this.QuestionQuantity = QuestionQuantity;
            this.UserName = userName;
        }

        public Survey()
        {

        }
    }
}
