using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Utility;
using QuestionLogic.Models;

namespace QuestionLogic.Controllers
{
    public class JsonController
    {
        private readonly FileHandler _fileHandler;

        public JsonController(FileHandler fileHandler)
        {
            _fileHandler = fileHandler ?? throw new ArgumentNullException(nameof(fileHandler));
        }

        public void NewQuestion(string title ,string question, string answer)
        {
            var newQuestion = new QuestionObject {Title = title, Question = question, Answer = answer};
            _fileHandler.WriteToJson(newQuestion);
        }

        public List<QuestionObject> LoadQuestions()
        {
            var questions = _fileHandler.LoadQuestions();
            return questions;
        }

        public QuestionObject FindQuestion(string questionTitle)
        {
            var result = _fileHandler.FindQuestion(questionTitle);
            return result;
        }


    }
}
