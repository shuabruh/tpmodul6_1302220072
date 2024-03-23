internal class Program
{
    private static void Main(string[] args)
    {
        SayaTubeVideo vid = new SayaTubeVideo("Tutorial Design By Contract - Joshua Daniel");
        vid.printVideoDetails();
    }
}

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        this.title = title;
        Random randomId = new Random();
        id = randomId.Next(10000, 99999);
    }

    public void increasePlayCount(int increment)
    {
        playCount += increment;
    }

    public void printVideoDetails()
    {
        Console.WriteLine("ID: " + id + "\n" + "Judul: " + title + "\n" + "Play count: " + playCount + "\n");
    }
}