public class Program
{
    public static async Task Main(string[] args)
    {

        //Create a CancellationTokenSource
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken token = cancellationTokenSource.Token;

        try{
                
                cancellationTokenSource.CancelAfter(3000);
               Task.WhenAll(DonloadLargeFile(token), UploadLargeFile(token));
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Download cancelled");
        }

        Console.WriteLine("Press Enter to close the program");
        Console.ReadLine();
    }

    public static async Task DonloadLargeFile(CancellationToken cancellationToken)
    {
        for(int i = 0; i < 1000; i++)
        {
            Console.WriteLine("Downloading large file...");
            cancellationToken.ThrowIfCancellationRequested();
            Thread.Sleep(1000);
        }

        
    }

    public static async Task UploadLargeFile(CancellationToken cancellationToken)
    {
        for(int i = 0; i < 1000; i++)
        {
            Console.WriteLine("Uploading large file...");
            if(cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Upload cancelled");
                return;
            }
            Thread.Sleep(1000);
        }
    }
}