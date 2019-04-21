﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;
using QuestionLogic.Models;

namespace Persistence.Utility
{
    public class FileHandler
    {
        public string JsonPath;

        public FileHandler()
        {
            JsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "questions.json");
        }

        public void WriteToJson(QuestionObject newQuestion)
        {
            var list = LoadQuestions();
            if (CheckIfQuestionExist(list, newQuestion.Title))
            {
                MessageBox.Show("Question exist");
                return;
            }
            
            list.Add(newQuestion);
            var jsonData = JsonConvert.SerializeObject(list);
            File.WriteAllText(JsonPath, jsonData);
        }

        public List<QuestionObject> LoadQuestions()
        {
            var jsonData = File.ReadAllText(JsonPath);

            var list = JsonConvert.DeserializeObject<List<QuestionObject>>(jsonData)
                                  ?? new List<QuestionObject>();
            return list;
        }

        public void CreateJsonFile()
        {
            using (var file = File.Open(JsonPath, FileMode.OpenOrCreate, FileAccess.ReadWrite)) { }
        }

        public QuestionObject FindQuestion(string questionTitle)
        {
            var questions = LoadQuestions();
            var questionObject = questions.First(question => question.Title == questionTitle);

            return questionObject;
        }

        public bool CheckIfQuestionExist(List<QuestionObject> questions, string title)
        {
            return questions != null && questions.Any(question => question.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }


    }
}