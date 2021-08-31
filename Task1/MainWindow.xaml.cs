using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Controls;

namespace Task1
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CountButton_Click(object sender, RoutedEventArgs e)
        {
            List<SomeString> someStrings = new List<SomeString>();
            CorrectUnput corrInpt = new CorrectUnput();
            SomeServer server = new SomeServer();

            TextRange range = new TextRange(idStringTextBox.Document.ContentStart, idStringTextBox.Document.ContentEnd);

            List<string> uniqIds = corrInpt.GetUniqIds(range.Text);
            corrInpt.HighlightIncorrectValue(range.Text, idStringTextBox);

            foreach(string id in uniqIds)
            {
                string str = server.GetResponseParse(id);
                SomeString someStr = new SomeString();
                someStr.StringContent = someStr.GetString(str);
                someStrings.Add(someStr);
            }

            foreach(SomeString str in someStrings)
            {
                str.CountVowel();
                str.CountWords();
            }

            ResultListView.ItemsSource = someStrings;
        }
    }
}
