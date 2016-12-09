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
           // engHelpRTB.LoadFile("doc_matrix.rtf");
        }

        private void graTab_Layout(object sender, LayoutEventArgs e)
        {
           // engHelpRTB.LoadFile("doc_graphics.rtf");
        }

        private void curTab_Layout(object sender, LayoutEventArgs e)
        {
            curHelpRTB.LoadFile("doc_currencies.rtf");
        }

        private void datTab_Layout(object sender, LayoutEventArgs e)
        {
            datHelpRTB.LoadFile("doc_dates.rtf");
        }
    }
}
