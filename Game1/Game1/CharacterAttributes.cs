using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Game1
{
    public partial class CharacterAttributes : Form
    {
        // external file to save data
        string file = "attributes.txt";

        public double points = 10; // number of points to allocate (can be altered later)
        public double health;
        public double strength;
        public double dexterity;

        public CharacterAttributes()
        {
            InitializeComponent();
        }

        private void CharacterAttributes_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox1.Text = points.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void healthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(points == 0)
            {
                healthNumericUpDown.Enabled = false;
            }
            double previousHealth = (double)healthNumericUpDown.Value;
            if(previousHealth < health)
            {
                points -= 1;
            }
            if(previousHealth > health)
            {
                points += 1;
            }
            textBox1.Text = points.ToString();
            previousHealth = health;
        }

        private void strengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(points == 0)
            {
                strengthNumericUpDown.Enabled = false;
            }
            double previousStrength = (double)strengthNumericUpDown.Value;
            if(previousStrength < strength)
            {
                points -= 1;
            }
            if(previousStrength > strength)
            {
                points += 1;
            }
            textBox1.Text = points.ToString();
            previousStrength = strength;
        }

        private void dexterityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(points == 0)
            {
                dexterityNumericUpDown.Enabled = false;
            }
            double previousDexterity = (double)dexterityNumericUpDown.Value;
            if(previousDexterity < dexterity)
            {
                points -= 1;
            }
            if(previousDexterity > dexterity)
            {
                points += 1;
            }
            textBox1.Text = points.ToString();
            previousDexterity = dexterity;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            WriteData(file);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            points = 10;
            healthNumericUpDown.Value = 100;
            strengthNumericUpDown.Value = 0;
            dexterityNumericUpDown.Value = 0;
        }

        // Read data from file
        public void ReadData(String file)
        {
            StreamReader input = null;

            try
            {
                input = new StreamReader(file);

                String line = null;
                while ((line = input.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

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

        // Write data to file
        public void WriteData(String file)
        {
            StreamWriter output = null;

            try
            {
                output = new StreamWriter(file);
                output.WriteLine(health);
                output.WriteLine(strength);
                output.WriteLine(dexterity);
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
    }
}
