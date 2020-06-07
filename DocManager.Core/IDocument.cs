namespace DocManager.Core
{
    public interface IDocument
    {
        string Species { get; set; }
        string Name { get; set; }
        string Date { get; set; }
        string Dates { get; set; }
        string Perfomer { get; set; }

        WeatherInfo WeatherInfo { get; set; }
    }
}