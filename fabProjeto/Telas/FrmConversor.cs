using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace fabProjeto.Telas
{
    public partial class FrmConversor : Form
    {
        public FrmConversor()
        {
            InitializeComponent();
        }
        

        private string _response;
        private string _fromCurrencyCode; //From which currency I should convert
        private string _toCurrencyCode; //To which Countries’ currency format I should convert
        private decimal _valorEntrada;
        

        private decimal YahooConversionAPI(decimal amnt, string fromCurrencyCode, string toCurrencyCode)
        {

            try
            {

                const string yahooAPIUrl = "http://finance.yahoo.com/d/quotes.csv?s={0}{1}=X&f=l1";
                string url = String.Format(yahooAPIUrl, fromCurrencyCode, toCurrencyCode);


                // Get response as string
                _response = new WebClient().DownloadString(url);
                //Result is as explained above, it has calculated 1 unit from one currency code to other.

                decimal exchangeRate = decimal.Parse(_response, System.Globalization.CultureInfo.InvariantCulture);
                // Convert string to number

                return exchangeRate * amnt; //Here is the math happening as shown above example
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void FrmConversor_Load(object sender, EventArgs e)
        {
            cboFrom.SelectedIndex = 2;
            CboTo.SelectedIndex = 0;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuantiaEntrada.Text))
            {
                MessageBox.Show("Campo Quantia vazio", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _valorEntrada = decimal.Parse(txtQuantiaEntrada.Text);


            _fromCurrencyCode = cboFrom.SelectedItem.ToString().Substring(0, 3);
            _toCurrencyCode = CboTo.SelectedItem.ToString().Substring(0, 3);

            var valorSaida = YahooConversionAPI(_valorEntrada, _fromCurrencyCode, _toCurrencyCode);


            label5.Text = _toCurrencyCode + "  " + string.Format("{0:0,0.00}", valorSaida);

            txtQuantiaEntrada.Text = String.Empty;
            txtQuantiaEntrada.Select();
        }

        private void txtQuantiaEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (!char.IsDigit(e.KeyChar) && e.KeyChar!=13 && e.KeyChar !=8  && e.KeyChar!=44)
            {
                e.Handled = true;
            }
        }

        


    }
}
