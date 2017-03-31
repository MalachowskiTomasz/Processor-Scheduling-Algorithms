using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProcessorScheduling
{
    public partial class Form2 : Form
    {
        private String[] tab =
        {
            "Process ID",
            "Service Time",
            "Arrived Time",
        };

        public int[] value = new int[3];
        private List<ComboBox> combox = new List<ComboBox>(3);

        public Form2()
        {
            InitializeComponent();

            combox.Add(comboBox1);
            combox.Add(comboBox2);
            combox.Add(comboBox3);
            foreach (var item in combox)
            {
                item.Items.AddRange(tab);
                item.DropDownStyle = ComboBoxStyle.DropDownList;
                //item.SelectedIndex = k++;
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
            comboBox3.SelectedIndex = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            value[0] = Array.IndexOf(tab, comboBox1.Text);
            value[1] = Array.IndexOf(tab, comboBox2.Text);
            value[2] = Array.IndexOf(tab, comboBox3.Text);
            //value.Reverse();
        }
    }
}