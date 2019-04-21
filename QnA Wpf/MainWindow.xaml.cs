using System.Windows;
using System.Windows.Controls;
using Questions.Controllers;
using Questions.Models;
using Questions.Utility;


namespace QnA_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private JsonController _jsonController;
        private RichTextUtility _textUtility;
        public MainWindow()
        {

            InitializeComponent();
            Init();
        }

        private void Init()
        {
            var fileHandler = new FileHandler();
            fileHandler.CreateJsonFile();

            _textUtility = new RichTextUtility();
            _jsonController = new JsonController(fileHandler);

            LoadAllQuestions();
        }

        private void LoadAllQuestions()
        {
            var questions = _jsonController.LoadQuestions();
            if(questions == null) return;

            listQuestions.Items.Clear();
            foreach (var question in questions)
            {
                listQuestions.Items.Add(question.Title);
            }
        }

        private void ButtonNewQuestion_Click(object sender, RoutedEventArgs e)
        {
            var answer = _textUtility.ConvertRichTextBoxToString(rtbAnswerBox);
            //_jsonController.NewQuestion(tbQuestionTitle.Text, tblQuestionDetails?.Text, tblAnswerBox?.Text);

            rtbAnswerBox.Document.Blocks.Clear();
            //tblAnswerBox.Text = "";
            //LoadAllQuestions();
            //rtbAnswerBox.AppendText(answer);
        }

        private void ListQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = listQuestions?.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(selectedItem))
                return;

            var result = _jsonController.FindQuestion(selectedItem);
            tbQuestionTitle.Text = result.Title;
            tblQuestionDetails.Text = result.Question;

            tblShowAnswer.Text = result.Answer;
            tblShowAnswer.Visibility = Visibility.Hidden;
            //tblAnswerBox.Text = "";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tblShowAnswer.Visibility = Visibility.Visible;
        }

        private void ButtonEditQuestion_Click(object sender, RoutedEventArgs e)
        {
            //var editQuestion = new QuestionObject
            //{ Title = tbQuestionTitle.Text, Question = tblQuestionDetails.Text, Answer = tblAnswerBox.Text };
            //_jsonController.EditQuestion(editQuestion);
        }
    }
}
