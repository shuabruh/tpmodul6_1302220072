internal class Program
{
    private static void Main(string[] args)
    {
        SayaTubeVideo vid = new SayaTubeVideo("Tutorial Design By Contract - Joshua Daniel");
        vid.printVideoDetails();

        // Dimasukkan dalam blok comment karena hanya untuk menguji exception

        SayaTubeVideo vid2 = new SayaTubeVideo("The Quick Brown Fox and The Lazy Cat Jumps Over The Slow " +
            "Dog and The Fast Bison, and They Also Walk Over The Slow Cow");
        vid2.increasePlayCount(100000001);
        vid2.printVideoDetails();

        SayaTubeVideo vid3 = new SayaTubeVideo("Apa itu Stack Overflow? - Irvan");
        for (int i = 0; i < 25; i++)
        {
            vid3.increasePlayCount(100000000);
        }
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

        try
        {
            this.title = title;

            if (title == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (title.Length > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        catch (ArgumentNullException n_exc)
        {
            Console.WriteLine(n_exc.Message);
        }

        catch(ArgumentOutOfRangeException ofvexc)
        {
            Console.WriteLine(ofvexc.Message);
        }
    }
    public void increasePlayCount(int increment)
    {
        try
        { 
            checked
            {
                playCount += increment;
                if(playCount + increment > 10000000) throw new ArgumentOutOfRangeException();
            }
        }

        catch(ArgumentOutOfRangeException argex)
        {
            Console.WriteLine(argex.Message);
        }

        catch (OverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void printVideoDetails()
    {
        Console.WriteLine("ID: " + id + "\n" + "Judul: " + title + "\n" + "Play count: " + playCount + "\n");
    }
}