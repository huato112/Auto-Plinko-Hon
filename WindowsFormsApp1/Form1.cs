using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.Text;
using System.IO;
using Memory;
using System.Linq;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static readonly HttpClient client = new HttpClient();

        int x = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => LoopRun());
            Task.Factory.StartNew(() => LoopRun());
            Task.Factory.StartNew(() => LoopRun());
            Task.Factory.StartNew(() => LoopRun());
            Task.Factory.StartNew(() => LoopRun());
            Task.Factory.StartNew(() => LoopRun());
            Task.Factory.StartNew(() => LoopRun());
            Task.Factory.StartNew(() => LoopRun());
            Task.Factory.StartNew(() => LoopRun());
        }

        public void LoopRun()
        {
            while (x != 0)
            {
                Run();
            }
        }



        string cookiee = "";

        public async void GetCookie()
        {

            Mem m = new Mem();
            m.OpenProcess(m.GetProcIdFromName("hon"));
            var a = "68 6F 6E 67 61 6D 65 63 6C 69 65 6E 74 63 6F 6F 6B 69 65 3D";
            IEnumerable<long> cookie = await m.AoBScan(a, true, true);
            if (cookie.FirstOrDefault() != 0)
            {
                cookiee = m.ReadString((cookie.FirstOrDefault() + 0x14).ToString("x"));
            }
        }


        public void Run(){


            var cookie = cookiee;
            var currency = "tickets";
            var web = "http://masterserver.sea.heroesofnewerth.com/master/casino/drop/";
            var request = (HttpWebRequest)WebRequest.Create(web);

            var postData = "cookie=" + Uri.EscapeDataString(cookie) + "&currency=" + Uri.EscapeDataString(currency);
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream()) { 
                stream.Write(data, 0, data.Length); 
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseSting = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetCookie();
        }
    }
}
