using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Lab1
{
    public partial class MainForm : Form
    {
        /// List of students
        private Student[] students;

        public MainForm()
        {
            InitializeComponent();
            InitializeStudents();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FillStudentList();
        }

        /// <summary>
        /// Generic method for searching an item in an array.
        /// </summary>
        /// <typeparam name="T">Type of items in the array</typeparam>
        /// <typeparam name="U">Type of the item to check equality</typeparam>
        /// <param name="array">Array to search from</param>
        /// <param name="item">Item to search for equality</param>
        /// <returns>Index of the item in the array; -1 if not found</returns>
        private int Search<T, U>(T[] array, U item) where T : IEquatable<U>
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Fill in the students list
        /// </summary>
        private void InitializeStudents()
        {
            students = new []
            {
                new Student(301058465, "Arshdeep Singh"),
                new Student(301012345, "Aman Bains"),
                new Student(301118847, "Param Sandhu")
            };
        }

        /// <summary>
        /// Populate the students list data in the students list and the combobox items
        /// </summary>
        private void FillStudentList()
        {
            List<string> autoComplete = new List<string>();

            foreach (Student student in students)
            {
                // add to the student list
                Label label = new Label
                {
                    AutoSize = true,
                    Text = $"{student.ID} {student.Name}"
                };
                studentListContainer.Controls.Add(label);

                // add to auto-complete
                autoComplete.Add(student.ID.ToString());
                autoComplete.Add(student.Name);
            }

            autoComplete.Sort();
            studentSearchInput.Items.AddRange(autoComplete.ToArray());
        }

        /// <summary>
        /// Wrapper of the Search method to do the parsing of the input
        /// </summary>
        /// <param name="input">Raw input from the user</param>
        /// <returns>The returned value from the Search method</returns>
        private int DoSearch(string input)
        {
            int searchResult;

            try
            {
                // If this succeeds, the input is a student ID
                int inputID = Convert.ToInt32(input);
                searchResult = Search(students, inputID);
            }
            catch
            {
                // If the input is not an integer, it is a student name
                searchResult = Search(students, input);
            }

            return searchResult;
        }

        /// <summary>
        /// Show the search result
        /// </summary>
        /// <param name="searchIndex">The returned value of the Search method</param>
        private void SetSearchResult(int searchIndex)
        {
            // show the index value
            studentIndexText.Text = searchIndex.ToString();

            if (searchIndex < 0)
            {
                // no item found in the array
                studentIdText.Text = "N/A";
                studentNameText.Text = "N/A";
            }
            else
            {
                // item found in the array
                studentIdText.Text = students[searchIndex].ID.ToString();
                studentNameText.Text = students[searchIndex].Name;
            }
        }

        /// <summary>
        /// Callback for when the user types in the combobox
        /// </summary>
        /// <param name="sender">The combobox being typed into</param>
        /// <param name="e">Arguments</param>
        private void studentSearchInput_TextUpdate(object sender, EventArgs e)
        {
            string input = ((ComboBox)sender).Text;
            int result = DoSearch(input);
            SetSearchResult(result);
        }

        /// <summary>
        /// Callback for when the user selects one of the items in the combobox
        /// </summary>
        /// <param name="sender">The combobox with the selected item</param>
        /// <param name="e">Arguments</param>
        private void studentSearchInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            string input = ((ComboBox)sender).Text;
            int result = DoSearch(input);
            SetSearchResult(result);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            string input = ((TextBox)sender).Text;

            StringBuilder sb = new StringBuilder();
            sb.Append(input);

            int numWords = sb.CountWords();
            numberOfWordsText.Text = numWords.ToString();
        }

        private void q1Group_Enter(object sender, EventArgs e)
        {

        }
    }
}
