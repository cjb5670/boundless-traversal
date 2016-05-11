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

namespace EnemyAttributes
{
    public partial class Form1 : Form
    {
        // fields
        public decimal health;
        public decimal previousHealth;
        public decimal dexterity;
        public decimal previousDexterity;

        // fields for reading data
        int count = 0;
        string h;
        string d;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // disable pointsNumeric so player can't add extra points
            pointsNumeric.Enabled = false;

            // set initial values
            health = healthNumericUpDown.Value;
            previousHealth = health;
            dexterity = dexterityNumericUpDown.Value;
            previousDexterity = dexterity;
        }

        // change value of pointsNumeric based on healthNumeric value
        private void healthNumericUpDown_ValueChanged_1(object sender, EventArgs e)
        {
            health = healthNumericUpDown.Value;
            if (health < previousHealth)
            {
                pointsNumeric.Value++;
            }
            if (health > previousHealth)
            {
                pointsNumeric.Value--;
            }
            previousHealth = health;
        }

        // change value of pointsNumeric based on dexterityNumeric value
        private void dexterityNumericUpDown_ValueChanged_1(object sender, EventArgs e)
        {
            dexterity = dexterityNumericUpDown.Value;
            if (dexterity < previousDexterity)
            {
                pointsNumeric.Value++;
            }
            if (dexterity > previousDexterity)
            {
                pointsNumeric.Value--;
            }
            previousDexterity = dexterity;
        }

        private void submitButton_Click_1(object sender, EventArgs e)
        {
            // write data to file and display message confirming the submission
            WriteData();
            label6.Visible = true;
            label7.Visible = false;
        }

        private void clearButton_Click_1(object sender, EventArgs e)
        {
            pointsNumeric.Value = 3;
            healthNumericUpDown.Value = 1;
            dexterityNumericUpDown.Value = 1;
            pointsNumeric.Value = 3;

            healthNumericUpDown.Enabled = true;
            dexterityNumericUpDown.Enabled = true;

            label6.Visible = false;
            label7.Visible = false;
        }

        private void loadButton_Click_1(object sender, EventArgs e)
        {
            ReadData();

            // convert loaded data into decimals so it can be used by the numerics
            decimal loadHealth = System.Convert.ToDecimal(h);
            decimal loadDexterity = System.Convert.ToDecimal(d);

            // change numeric values
            healthNumericUpDown.Value = loadHealth;
            dexterityNumericUpDown.Value = loadDexterity;

            // change initial values
            health = healthNumericUpDown.Value;
            previousHealth = health;
            dexterity = dexterityNumericUpDown.Value;
            previousDexterity = dexterity;

            // ensure pointsNumeric is set to proper number of points left after loading data
            pointsNumeric.Value = 6 - health - dexterity;

            label7.Visible = true;
        }

        private void pointsNumeric_ValueChanged_1(object sender, EventArgs e)
        {
            // disable all numerics if pointsNumeric is 0
            if (pointsNumeric.Value == 0)
            {
                healthNumericUpDown.Enabled = false;
                dexterityNumericUpDown.Enabled = false;
            }
        }

        // Write data to file
        public void WriteData()
        {
            StreamWriter output = null;

            try
            {
                output = new StreamWriter("../../../../attributes.txt");
                output.WriteLine(dexterityNumericUpDown.Value);
                output.WriteLine(healthNumericUpDown.Value);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error writing to file: " + e.Message);
            }
            finally
            {
                if (output != null)
                    output.Close();
            }
        }

        // read data from file
        public void ReadData()
        {
            StreamReader input = null;

            try
            {
                input = new StreamReader("../../../../attributes.txt");

                String line = null;
                while ((line = input.ReadLine()) != null)
                {
                    // count determines where the current line is stored
                    if (count == 0)
                    {
                        d = line;
                    }
                    if (count == 1)
                    {
                        h = line;
                    }
                    count++;
                }
                // reset count for next use
                count = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading file: " + e.Message);
            }
            finally
            {
                if (input != null)
                    input.Close();
            }
        }
    }
}
