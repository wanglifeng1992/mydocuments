using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms ;
using System.Text.RegularExpressions;

namespace Solution
{
    public class Common
    {
        public  string InputBox(string Caption, string Hint, string Default)
        {
            Form InputForm = new Form();
            InputForm.MinimizeBox = false;
            InputForm.MaximizeBox = false;
            InputForm.ControlBox = false;
            InputForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            InputForm.StartPosition = FormStartPosition.CenterScreen;
            InputForm.Width = 500;
            InputForm.Height = 150;
            //InputForm.Font.Name = "宋体";
            //InputForm.Font.Size = 10;

            InputForm.Text = Caption;
            System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
            lbl.Text = Hint;
            lbl.Left = 10;
            lbl.Top = 20;
            lbl.Parent = InputForm;
            lbl.AutoSize = true;
            System.Windows.Forms.TextBox tb = new System.Windows.Forms.TextBox();
            tb.Left = 30;
            tb.Top = 45;
            tb.Width = 400;
            tb.Parent = InputForm;
            tb.Text = Default;
            tb.SelectAll();
            System.Windows.Forms.Button btnok = new System.Windows.Forms.Button();
            btnok.Left = 30;
            btnok.Top = 80;
            btnok.Parent = InputForm;
            btnok.Text = "确定";
            InputForm.AcceptButton = btnok;//回车响应

            btnok.DialogResult = DialogResult.OK;
            System.Windows.Forms.Button btncancal = new System.Windows.Forms.Button();
            btncancal.Left = 120;
            btncancal.Top = 80;
            btncancal.Parent = InputForm;
            btncancal.Text = "取消";
            btncancal.DialogResult = DialogResult.Cancel;
            try
            {
                if (InputForm.ShowDialog() == DialogResult.OK)
                {
                    return tb.Text;
                }
                else
                {
                    return null;
                }
            }
            finally
            {
                InputForm.Dispose();
            }

        }


        public bool isNumber(string n)
        {
            Regex reg = new Regex("^[0-9]+$");
            Match ma = reg.Match(n);
            return ma.Success;

        }

    }
}
