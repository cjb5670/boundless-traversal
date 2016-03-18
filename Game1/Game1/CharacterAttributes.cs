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

        public CharacterAttributes()
        {
            InitializeComponent();
        }

        private void CharacterAttributes_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void healthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void strengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dexterityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            WriteData(file);
        }

        // Read data from file
        static void ReadData(String file)
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
        static void WriteData(String file)
        {
            StreamWriter output = null;

            try
            {
                output = new StreamWriter(file);
                output.WriteLine(""); //PUT SOMETHING HERE
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
