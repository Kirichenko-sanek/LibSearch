using System.IO;
using LibSearch.Crawler.BL.Interfaces.Repository;

namespace LibSearch.Crawler.BL.Repository
{
    public class Repository : IRepository
    {
        public void WriteToFile(string info, string fileName, string folder)
        {
            var str = folder + "/" + fileName.Replace("/", "_") + ".csv";
            using (StreamWriter theWriter = new StreamWriter(@"" + str))
            {
                theWriter.Write(info);
                theWriter.Close();
            }
        }
    }
}
