﻿using System;
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

        // fields
        public decimal health;
        public decimal previousHealth;
        public decimal strength;
        public decimal previousStrength;
        public decimal dexterity;
        public decimal previousDexterity;

        int count = 0;
        string h;
        string s;
        string d;

        public CharacterAttributes()
        {
            InitializeComponent();
        }

        private void CharacterAttributes_Load(object sender, EventArgs e)
        {
            // disable pointsNumeric so player can't add extra points
            pointsNumeric.Enabled = false;

            // set initial values
            health = healthNumericUpDown.Value;
            previousHealth = health;
            strength = strengthNumericUpDown.Value;
            previousStrength = strength;
            dexterity = dexterityNumericUpDown.Value;
            previousDexterity = dexterity;

        }

        private void healthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            health = healthNumericUpDown.Value;
            if(health < previousHealth)
            {
                pointsNumeric.Value++;
            }
            if(health > previousHealth)
            {
                pointsNumeric.Value--;
            }
            previousHealth = health;
        }

        private void strengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            strength = strengthNumericUpDown.Value;
            if (strength < previousStrength)
            {
                pointsNumeric.Value++;
            }
            if (strength > previousStrength)
            {
                pointsNumeric.Value--;
            }
            previousStrength = strength;
        }

        private void dexterityNumericUpDown_ValueChanged(object sender, EventArgs e)
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

        private void submitButton_Click(object sender, EventArgs e)
        {
            WriteData(file);
            label6.Visible = true;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            pointsNumeric.Value = 5;
            healthNumericUpDown.Value = 0;
            strengthNumericUpDown.Value = 0;
            dexterityNumericUpDown.Value = 0;
            pointsNumeric.Value = 5;

            healthNumericUpDown.Enabled = true;
            strengthNumericUpDown.Enabled = true;
            dexterityNumericUpDown.Enabled = true;

            label6.Visible = false;
        }

        // Write data to file
        public void WriteData(String file)
        {
            StreamWriter output = null;

            try
            {
                output = new StreamWriter(file);
                output.WriteLine(healthNumericUpDown.Value);
                output.WriteLine(strengthNumericUpDown.Value);
                output.WriteLine(dexterityNumericUpDown.Value);
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

        public void ReadData(String file)
        {
            StreamReader input = null;

            try
            {
                input = new StreamReader(file);

                String line = null;
                while ((line = input.ReadLine()) != null)
                {
                    if(count == 0)
                    {
                        h = line;
                    }
                    if(count == 1)
                    {
                        s = line;
                    }
                    if(count == 2)
                    {
                        d = line;
                    }
                    count++;
                }
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

        private void pointsNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (pointsNumeric.Value == 0)
            {
                healthNumericUpDown.Enabled = false;
                strengthNumericUpDown.Enabled = false;
                dexterityNumericUpDown.Enabled = false;
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            ReadData(file);

            decimal loadHealth = System.Convert.ToDecimal(h);
            decimal loadStrength = System.Convert.ToDecimal(s);
            decimal loadDexterity = System.Convert.ToDecimal(d);

            healthNumericUpDown.Value = loadHealth;
            strengthNumericUpDown.Value = loadStrength;
            dexterityNumericUpDown.Value = loadDexterity;

            health = healthNumericUpDown.Value;
            previousHealth = health;
            strength = strengthNumericUpDown.Value;
            previousStrength = strength;
            dexterity = dexterityNumericUpDown.Value;
            previousDexterity = dexterity;

            pointsNumeric.Value = 5 - health - strength - dexterity;
        }
    }
}
