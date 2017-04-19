using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            backgroundWorker.WorkerReportsProgress = true;

            _inostrankabooksManager = inostrankabooksManager;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            var a = new Thread(() =>
            {
                _inostrankabooksManager.GetInfo(path);
            });
            backgroundWorker.RunWorkerAsync();
            a.Start();
        }


        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(10000);
            for (;;)
            {
                var a = _inostrankabooksManager.GetProgressMax();
                var b = _inostrankabooksManager.GetProgressNow();
                if (a != 0 && b != 0)
                {
                    int c = b * 100 / a;
                    backgroundWorker.ReportProgress(c);
                }
                Thread.Sleep(2000);
                if (b >= a && a != 0)
                {
                    backgroundWorker.ReportProgress(0);
                    break;
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarResult.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
