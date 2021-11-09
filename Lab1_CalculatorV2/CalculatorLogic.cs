using System.Globalization;
using System.Windows.Forms;

namespace Lab1_CalculatorV2
{
    public class CalculatorLogic
    {
        public bool IsOperationPerformed { get; set; }
        public double ResultValue { get; set; }
        public string OperationPerformed { get; set; } = "";

        private double SavedValue { get; set; }
        
        public string ClearTextField() => @"0";
        public void ResetResultValue() => ResultValue = 0;

        public void SaveValue() => SavedValue = ResultValue;
        
        public double LoadValue() => SavedValue;
        public string GetResultValueString() => ResultValue.ToString();

        public void PerformOperation(TextBox textBox)
        {
            switch (OperationPerformed)
            {
                case "+":
                    textBox.Text = (ResultValue + double.Parse(textBox.Text)).ToString();
                    break;
                case "-":
                    textBox.Text = (ResultValue - double.Parse(textBox.Text)).ToString();
                    break;
                case "*":
                    textBox.Text = (ResultValue * double.Parse(textBox.Text)).ToString();
                    break;
                case "/":
                    textBox.Text = (ResultValue / double.Parse(textBox.Text)).ToString();
                    break;
                default:
                    break;
            }
            
            ResultValue = double.Parse(textBox.Text);
        }
    }
}