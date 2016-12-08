using System.IO;
using System.Windows.Forms;

namespace Calculator
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void engTab_Layout(object sender, LayoutEventArgs e)
        {
            engHelpRTB.LoadFile("doc_engineer.rtf");
        }

        private void matTab_Layout(object sender, LayoutEventArgs e)
        {
            engHelpRTB.LoadFile("Матрицы.rtf");
        }

        private void graTab_Layout(object sender, LayoutEventArgs e)
        {
            engHelpRTB.LoadFile("Графики.rtf");
        }

        private void curTab_Layout(object sender, LayoutEventArgs e)
        {
            engHelpRTB.LoadFile("Валюта.rtf");
        }

        private void datTab_Layout(object sender, LayoutEventArgs e)
        {
            engHelpRTB.LoadFile("Даты.rtf");
        }
    }
}
