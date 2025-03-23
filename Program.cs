using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > 100)
            throw new ArgumentException("Judul video harus memiliki maksimal 100 karakter dan tidak boleh null.");

        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count > 10000000)
            throw new ArgumentException("Penambahan play count tidak boleh lebih dari 10.000.000 per panggilan method.");

        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Terjadi overflow pada play count!");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video Details:");
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Play Count: " + playCount);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - Khalish Tianto W");
            video.IncreasePlayCount(10000000);
            video.PrintVideoDetails();

            for (int i = 0; i < 3; i++)
            {
                video.IncreasePlayCount(int.MaxValue);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}


