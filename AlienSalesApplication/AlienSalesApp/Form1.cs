using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlienSalesApp
{
    public partial class alienSalesApplication : Form
    {
        private string input = string.Empty;
        private string output = string.Empty;

        public alienSalesApplication()
        {
            InitializeComponent();
        }

        // Check that string has only digits, space, \r, or \n
        public bool onlyDigits(string str)
        {
            foreach (char c in str)
            {
                if ((c < '0' || c > '9') && c != ' ' && c != '\r' && c != '\n')
                {
                    return false;
                }
            }

            return true;
        }

        // Find total number K of data sets
        public int findK(string input)
        {
            try
            {
                int k;
                k = Convert.ToInt32(input);
                return k;
            }
            catch
            {
                outputLabel.Text = "ERROR: Format exception\nMake sure that input contains only numbers and follows input format.";
                return -1;
            }
        }

        // Find total denominations D and total prices N
        public int[] findDN(string input)
        {
            int[] dn = new int[2];
            string[] totals_str = input.Split(' ');
            int D = Convert.ToInt32(totals_str[0]);
            int N = Convert.ToInt32(totals_str[1]);
            dn[0] = D;
            dn[1] = N;

            // Check constraints for D and N
            if (D < 2 || D > 7)
                throw new ArgumentOutOfRangeException("D");
            if (N < 2 || N > 10)
                throw new ArgumentOutOfRangeException("N");

            return dn;
        }

        // Find conversion constants
        public int[] findDenoms(string input, int D)
        {
            string[] denoms_str = input.Split(' ');
            int[] denoms = new int[D - 1];
            int i;
            for (i = 0; i < D - 1; i++)
            {
                denoms[i] = Convert.ToInt32(denoms_str[i]);
            }

            return denoms;
        }

        // Find price
        public int findPrice(string input, int D, int[] denoms)
        {
            // Obtain and convert input price into int array
            string[] price_str = input.Split(' ');
            int[] price_arr = new int[D];
            int i;
            for (i = 0; i < D; i++)
            {
                price_arr[i] = Convert.ToInt32(price_str[i]);
            }

            // Calculate price in lowest denomination
            int price = price_arr[0];
            for (i = 0; i < D - 1; i++)
            {
                price = denoms[i] * price + price_arr[i + 1];
            }

            return price;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (onlyDigits(input))
                {
                    string[] lines = input.Split('\n');

                    // Find total number K of data sets
                    int k = findK(lines[0]);

                    string dataset = "Data Set ";

                    // Start of data set
                    int lines_index = 1;

                    // Calculate for each data set
                    int i;
                    for (i = 0; i < k; i++)
                    {
                        output += dataset + Convert.ToString(i + 1) + ":\n";

                        // Find total denominations D and total prices N
                        int[] dn = findDN(lines[lines_index]);
                        int D = dn[0];
                        int N = dn[1];

                        // Find conversion constants
                        int[] denoms = findDenoms(lines[lines_index + 1], D);

                        // Find prices
                        int[] prices = new int[N];
                        int j;
                        for (j = 0; j < N; j++)
                        {
                            prices[j] = findPrice(lines[lines_index + 2 + j], D, denoms);
                        }

                        // Calculate largest difference
                        int maxSale = prices.Max() - prices.Min();
                        output += Convert.ToInt32(maxSale) + "\n";

                        // Update start of dataset
                        lines_index += 2 + j;
                    }

                    outputLabel.Text = output;
                }
                else
                {
                    throw new ArgumentException("input");
                }

            }
            catch (ArgumentOutOfRangeException)
            {
                outputLabel.Text = "ERROR: Argument out of range exception\nCheck D and N values. Make sure input follows input format.";
            }
            catch(ArgumentException)
            {
                outputLabel.Text = "ERROR: Argument exception\nMake sure that input contains only numbers.";
            }
            catch(FormatException)
            {
                outputLabel.Text = "ERROR: Format exception\nMake sure that input contains only numbers and follows input format.";
            }
            catch(IndexOutOfRangeException)
            {
                outputLabel.Text = "ERROR: Index out of range exception\nMake sure that input contains only numbers and follows input format.";
            }
            catch(Exception)
            {
                outputLabel.Text = "ERROR: Unknown error occurred\nMake sure that input contains only numbers and follows input format.";
            }
            finally
            {
                output = string.Empty;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            input = string.Empty;
            output = string.Empty;
            inputText.Text = input;
            outputLabel.Text = output;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            input = inputText.Text;
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            helpWindow f2 = new helpWindow();
            f2.ShowDialog();
        }
    }
}
