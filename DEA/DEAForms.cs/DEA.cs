using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CenterSpace.NMath.Core;

namespace DEAForms.cs
{
    public partial class DEA : Form
    {
        private static int NumberOfObjects = 0;
        private static int NumberOfEntries = 0;
        private static int NumberOfExits = 0;
        private static Conclusion conclusion;
        public SaveFileDialog saveFileDialog;
        public DEA()
        {
            InitializeComponent();
        }

        private void createInputButton_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(numberOfObjects.Text) &&
               !String.IsNullOrWhiteSpace(numberOfEntryParams.Text) &&
               !String.IsNullOrWhiteSpace(numberOfExitParams.Text))
            {
                try
                {
                    if(Controls.Find("inputConfirm", false) != null)
                    {
                        Controls.RemoveByKey("inputConfirm");
                    }
                    NumberOfObjects = Convert.ToInt32(numberOfObjects.Text);
                    NumberOfEntries = Convert.ToInt32(numberOfEntryParams.Text);
                    NumberOfExits = Convert.ToInt32(numberOfExitParams.Text);
                    int diff = 0;
                    for (int i = 1; i < NumberOfObjects + 1; i++)
                    {
                        AddObjectLabel(i, 100, 100 + diff);
                        AddInput(i, "Entries", NumberOfEntries, 100, 130 + diff);
                        AddInput(i, "Exits", NumberOfExits, 100, 160 + diff);
                        diff += 100;
                    }
                    Button inputConfirmButton = new Button()
                    {
                        Text = "Analyze",
                        Left = 855,
                        Top = diff + 100,
                        Width = 100,
                        Height = 30,
                        Name = "inputConfirm"
                    };
                    Controls.Add(inputConfirmButton);
                    inputConfirmButton.Click += new EventHandler(Analize);
                }
                catch
                {
                    MessageBox.Show("Please, make sure all fields have correct input",
                                "Input error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please, make sure all fields are filled", 
                                "Input error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void newTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void AddObjectLabel(int number, int marginLeft, int marginTop)
        {
            Label objectNumber = new Label();
            Controls.Add(objectNumber);
            objectNumber.Text = "Object " + number;
            objectNumber.Name = "Object" + "_" + number;
            objectNumber.Left = marginLeft;
            objectNumber.Top = marginTop;
        }

        public void Analize(object sender, EventArgs e)
        {
            Dictionary<int, DoubleVector> exitsList = new Dictionary<int, DoubleVector>();
            Dictionary<int, DoubleVector> entriesList = new Dictionary<int, DoubleVector>();
            string textEntries = "Entries_";
            string textExits = "Exits_";
            double tmpExit;
            DoubleVector tmpExits;
            double tmpEntry;
            DoubleVector tmpEntries;
            for (int i = 1; i < NumberOfObjects + 1; i++)
            {
                tmpExits = new DoubleVector();
                for (int j = 1; j < NumberOfExits + 1; j++)
                {
                    tmpExit = Convert.ToDouble(Controls.Find((textExits + i.ToString() + j.ToString()), false).First().Text);
                    tmpExits.Append(tmpExit);

                }
                exitsList.Add(i, tmpExits);
                tmpEntries = new DoubleVector();
                for (int j = 1; j < NumberOfEntries + 1; j++)
                {
                    tmpEntry = Convert.ToDouble(Controls.Find((textEntries + i.ToString() + j.ToString()), false).First().Text);
                    tmpEntries.Append(tmpEntry);

                }
                entriesList.Add(i, tmpEntries);
            }
            Analyzer analyzer = new Analyzer();            
            conclusion = analyzer.GetConclusion(entriesList, exitsList, NumberOfObjects, NumberOfEntries, NumberOfExits);

            saveFileDialog = new SaveFileDialog()
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            saveFileDialog.FileOk += new CancelEventHandler(SaveFile);
            saveFileDialog.ShowDialog();
        }

        public void  SaveFile(object sender, CancelEventArgs  args) 
        {
            string fileName = saveFileDialog.FileName;
            File.WriteAllText(fileName, conclusion.ToString());
        }

        public void RemoveText(object sender, EventArgs e)
        {
            var input = sender as TextBox;
            input.Text = "";
            input.ForeColor = Color.Black;
        }

        public void AddText(object sender, EventArgs e)
        {
            var input = sender as TextBox;
            if (String.IsNullOrWhiteSpace(input.Text))
            {
                input.Text = input.Tag.ToString();
                input.ForeColor = Color.LightGray;
            }
        }

        private void AddInput(int objectNumber, string inputTitle, int numberOfInputs, int marginLeft, int marginTop)
        {
            Label label = new Label() { Text = inputTitle };
            Controls.Add(label);
            label.Left = marginLeft;
            label.Top = marginTop;
            int leftDiff = 0;
            TextBox input;

            for (int i = 0; i < numberOfInputs; i++)
            {
                input = new TextBox();
                Controls.Add(input);
                input.Left = marginLeft + 100 + leftDiff;
                input.Top = marginTop;
                input.Width = 50;
                input.Text = (i + 1).ToString();
                input.ForeColor = Color.LightGray;
                input.Tag = (i + 1).ToString();
                input.Name = inputTitle + "_" + objectNumber.ToString() + (i + 1).ToString();
                input.GotFocus += new EventHandler(RemoveText);
                input.LostFocus += new EventHandler(AddText);
                input.KeyPress += new KeyPressEventHandler(DotsToCommas);
                leftDiff += 100;
            }
        }

        public void DotsToCommas(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar('.'))
            {
                e.KeyChar = Convert.ToChar(',');
            }
        }
    }
}
