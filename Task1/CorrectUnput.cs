using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Task1
{
    class CorrectUnput
    {
        List<string> SplitInput(string inputString)
        {
            List<string> ids = new List<string>();
            inputString.Trim();
            foreach (var stringId1 in inputString.Split(';'))
            {
                foreach (var stringId2 in stringId1.Split(','))
                {
                    //convert to int because delete 0 and spaces
                    ids.Add(Convert.ToInt32(stringId2).ToString());
                }
            }
            return ids;
        }

        public List<string> GetUniqIds(string inputString)
        {
            List<string> stringIds = SplitInput(inputString);
            List<string> uniqIds = new List<string>();
            uniqIds.Add(stringIds[0]);
            bool checkCorrectIndex = false;

            foreach (string id in stringIds)
            {
                bool copyCheck = true;
                foreach (string id1 in uniqIds)
                {
                    if (id == id1)
                        copyCheck = false;
                }
                if (copyCheck)
                {
                    if (Convert.ToInt32(id) < 21 && Convert.ToInt32(id) > 0)
                        uniqIds.Add(id);
                    else
                        checkCorrectIndex = true;
                }
            }
            if (checkCorrectIndex)
            {
                MessageBox.Show("Incorrect index value entered, the index must be in range from 1 to 20", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return uniqIds;
        }

        public void HighlightIncorrectValue(string inputString, RichTextBox textBox)
        {
            List<string> inputIds = SplitInput(inputString);
            textBox.Document.Blocks.Clear();
            bool checkCorrectIndex = false;

            foreach (string id in inputIds)
            {
                int copyCheckCount = 0;
                foreach (string id1 in inputIds)
                {
                    if (id == id1)
                        copyCheckCount++;
                }
                if (copyCheckCount > 1)
                {
                    TextRange tr = new TextRange(textBox.Document.ContentEnd, textBox.Document.ContentEnd);
                    tr.Text = id;
                    tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
                    textBox.AppendText($", ");
                }
                else
                {
                    TextRange tr = new TextRange(textBox.Document.ContentEnd, textBox.Document.ContentEnd);
                    tr.Text = id;
                    tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);
                    textBox.AppendText($", ");
                }
            }
            if (checkCorrectIndex)
            {
                MessageBox.Show("Incorrect index value entered, the index must be in range from 1 to 20", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
