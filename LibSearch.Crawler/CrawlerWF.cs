using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibSearch.Crawler.BL.Interfaces.Manager;

namespace LibSearch.Crawler
{
    public partial class CrawlerWF : Form
    {
        private readonly IInostrankabooksManager _inostrankabooksManager;

        private string path = "D:\\Work\\LibSearch\\LibSearch.Crawler\\Result";

        public CrawlerWF(IInostrankabooksManager inostrankabooksManager)
        {
            InitializeComponent();

            _inostrankabooksManager = inostrankabooksManager;
        }













        private void button1_Click(object sender, EventArgs e)
        {
            _inostrankabooksManager.GetInfo(path);
        }
    }
}
