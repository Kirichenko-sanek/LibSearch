namespace LibSearch.Crawler.BL.Interfaces.Manager
{
    public interface IManager
    {
        void GetInfo(string folder);
        int GetProgressMax();
        int GetProgressNow();
    }
}
