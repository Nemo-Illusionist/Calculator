using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Currencies;
using GrammarOfArithmetic;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator(Parser parser)
        {
            InitializeComponent();
            _parser = parser;
        }
        private readonly Parser _parser;
        readonly Hashtable _highlight = new Hashtable()
        {
            {"symbols", @"(\(|\)|\[|\]|\<|\>|\{|\}|\+|\-|\*|\/|\:|\^|\!|\!\!|mod|div|\=)"},
            {"functions", @"(sin\(|cos\(|tg\(|ctg\(|asin\(|acos\(|atg\(|actg\(|sh\(|ch\(|th\(|cth\(" +
                             @"|sec\(|csec\(|sech\(|csch\(|div\(|mod\(|abs\(|exp\(|root\(|pow\(|max\(|min\(|sqr\(|sqrt\(|log\(|lg\(|ln\()"
            },
            {"constants", @"(pi|e)"},
        };

        #region Engineer

        void HighlightText()
        {
            var currentSelStart = calculationsRTB.SelectionStart;
            var currentSelLength = calculationsRTB.SelectionLength;
            calculationsRTB.SelectAll();
            calculationsRTB.ForeColor = SystemColors.WindowText;

            foreach (var key in _highlight.Keys)
            {
                var symbols = Regex.Matches(calculationsRTB.Text, _highlight[key].ToString());
                foreach (var match in symbols.Cast<Match>())
                {
                    if (key.ToString() == "functions")
                        calculationsRTB.Select(match.Index, match.Length - 1);
                    else calculationsRTB.Select(match.Index, match.Length);
                    switch (key.ToString())
                    {
                        case "symbols":
                            calculationsRTB.SelectionColor = Color.DarkOrange;
                            break;
                        case "functions":
                            calculationsRTB.SelectionColor = Color.Blue;
                            break;
                        case "constants":
                            calculationsRTB.SelectionColor = Color.Green;
                            break;
                    }
                }
            }
            calculationsRTB.Select(currentSelStart, currentSelLength);
            calculationsRTB.SelectionColor = SystemColors.WindowText;
        }

        private void trigonometrics_Click(object sender, EventArgs e)
        {
            calculationsRTB.SelectedText = (sender as Button).Text + "()";
        }

        private void multiParameter_Click(object sender, EventArgs e)
        {
            calculationsRTB.SelectedText = (sender as Button).Text + "( ; )";
        }

        private void oneParameter_Click(object sender, EventArgs e)
        {
            calculationsRTB.SelectedText = (sender as Button).Tag.ToString();
        }

        private void calculationsRTB_TextChanged(object sender, EventArgs e)
        {
            HighlightText();
        }

        private void calculationsRTB_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    var line = calculationsRTB.GetLineFromCharIndex(calculationsRTB.SelectionStart);
                    var s = calculationsRTB.GetFirstCharIndexOfCurrentLine() + calculationsRTB.Lines[line].Length;
                    calculationsRTB.SelectionStart = s;
                    calculationsRTB.SelectedText = _parser.SolveEngineer(calculationsRTB.Lines[line]);
                    break;
                case Keys.Z:
                    if (e.Control) calculationsRTB.Undo();
                    break;
            }
        }

        private void eng_ShowBtnsTSMI_Click(object sender, EventArgs e)
        {
            if (eng_ShowBtnsTSMI.Checked)
            {
                engineerTLP.ColumnStyles[0].Width = 0;
                eng_ShowBtnsTSMI.Checked = false;
            }
            else
            {
                engineerTLP.ColumnStyles[0].Width = 230;
                eng_ShowBtnsTSMI.Checked = true;
            }
        }

        #endregion

        #region Matrix



        #endregion

        #region Graph

        private void buildGraphBtn_Click(object sender, EventArgs e)
        {
            if (fxTB.Text == "" || xTB.Text == "")
                MessageBox.Show("Введите выражение и задайте область определения!", "STOP!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else;
        }

        #endregion

        #region Dates



        #endregion

        #region Currencies

        private void updateER_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                CurrenciesAPI.DownloadJson(DateTime.Now);
                actualDateLabel.Text = DateTime.Now.ToString("dd.MM.yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void currencyDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CurrenciesAPI.DownloadJson(currencyDate.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void curTabPage_Layout(object sender, LayoutEventArgs e)
        {
            currencyDate.MaxDate = DateTime.Now;
            DateTime actual = new DateTime(1999, 01, 01);
            var json = Properties.Resources.currencies;
            JObject o = JObject.Parse(json);
            foreach (var token in o)
            {
                currenciesList.Items.Add(new ListViewItem(token.Key) { SubItems = { token.Value.ToString() } });
            }
            foreach (var file in Directory.GetFiles(Environment.CurrentDirectory + "\\CurrenciesHistory\\"))
            {
                var filedate = Convert.ToDateTime(file.Substring(file.Length - 15, 10));
                if (filedate > actual)
                {
                    actual = filedate;
                }
                actualDateLabel.Text = actual.ToString("dd.MM.yyyy");
            }
        }
        private void currenciesRTB_TextChanged(object sender, EventArgs e)
        {
            this.Focus();
            currenciesRTB.Focus();
        }
        private void currenciesRTB_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    var line = currenciesRTB.GetLineFromCharIndex(currenciesRTB.SelectionStart);
                    var s = currenciesRTB.GetFirstCharIndexOfCurrentLine() + currenciesRTB.Lines[line].Length;
                    currenciesRTB.SelectionStart = s;
                    string str = currenciesRTB.Lines[line];
                    currenciesRTB.SelectedText = _parser.SolveCurrency(str);
                    break;
                case Keys.Z:
                    if (e.Control) currenciesRTB.Undo();
                    break;
                case Keys.Y:
                    if (e.Control) currenciesRTB.Redo();
                    break;
            }
        }
        #endregion

        #region Misc
        private void helpTSMI_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.Show();
        }
        private void aboutTSMI_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
        #endregion

        private void calcDateBtn_Click(object sender, EventArgs e)
        {

        }

        private void RUP_Value_TextChanged(object sender, EventArgs e)
        {
            CurrenciesAPI.RupValue = Double.Parse(RUP_Value.Text);
        }



    }
}
