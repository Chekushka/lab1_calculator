using System;
using System.Windows.Forms;

namespace Lab1_CalculatorV2
{
    public partial class Calculator : Form
    {
        private readonly CalculatorLogic _logic;

        public Calculator()
        {
            _logic = new CalculatorLogic();
            InitializeComponent();
        }

        private void NumberButtonClick(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (_logic.IsOperationPerformed))
                textBox_Result.Clear();

            _logic.IsOperationPerformed = false;
            var button = (Button)sender;
            if (button.Text == ".")
            { 
               if(!textBox_Result.Text.Contains("."))
                   textBox_Result.Text += button.Text;
            }
            else
             textBox_Result.Text += button.Text;
        }

        private void OperatorButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (_logic.ResultValue != 0)
            {
                _logic.OperationPerformed = button.Text;
                labelCurrentOperation.Text = _logic.ResultValue + @" " + _logic.OperationPerformed;
                _logic.IsOperationPerformed = true;
                textBox_Result.Text = _logic.ClearTextField();
            }
            else
            {
                _logic.OperationPerformed = button.Text;
                _logic.ResultValue = double.Parse(textBox_Result.Text);
                labelCurrentOperation.Text = _logic.ResultValue + @" " + _logic.OperationPerformed;
                _logic.IsOperationPerformed = true;
            }
        }

        private void ClearButtonClick(object sender, EventArgs e) => ClearField();

        private void SaveButtonClick(object sender, EventArgs e)
        {
            _logic.SaveValue();
            _logic.ResetResultValue();
            textBox_Result.Text = _logic.ClearTextField();
        }

        private void LoadButtonClick(object sender, EventArgs e) => textBox_Result.Text = _logic.LoadValue().ToString();

        private void EqualsButtonClick(object sender, EventArgs e)
        {
            _logic.PerformOperation(textBox_Result);
            labelCurrentOperation.Text = "";
        }

        private void ClearField()
        {
            textBox_Result.Text = _logic.ClearTextField();
            labelCurrentOperation.Text = "";
            _logic.ResultValue = 0;
        }
    }
}