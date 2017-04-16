using System;
using System.Windows.Forms;
using Castle.Windsor;
using LibSearch.Crawler.BL.CW;
using LibSearch.Crawler.BL.Interfaces.Manager;

namespace LibSearch.Crawler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var container = new WindsorContainer().Install(new AdminInstaller());
            Application.Run(new CrawlerWF(container.Resolve<IInostrankabooksManager>()));
        }
    }
}
