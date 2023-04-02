using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsClient {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            HttpClient client = new HttpClient();
            Dictionary<string, string> data = new Dictionary<string, string> {
                ["X"] = textBox1.Text,
                ["Y"] = textBox2.Text
            };
            HttpContent content = new FormUrlEncodedContent(data);
            HttpResponseMessage res = await client.PostAsync("https://localhost:44320/task4", content);
            if(res.IsSuccessStatusCode) {
                label1.Text = await res.Content.ReadAsStringAsync();
            }
        }
    }
}
