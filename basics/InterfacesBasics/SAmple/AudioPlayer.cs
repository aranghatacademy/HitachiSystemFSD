public interface IAudioPlayer
{
    void Play(string audioFile);
    void Pause();
    void Stop();
}

public interface IVideoPlayer
{
    void Play(string videoFile);
    void Pause();
    void Stop();
}


public class IPodPlayer : IAudioPlayer 
{
    public void Play(string audioFile)
    {
        Console.WriteLine($"IPodPlayer - > Playing {audioFile}");
    }

    public void Pause()
    {
        Console.WriteLine($"IPodPlayer - Pausing");
    }
    
    public void Stop()
    {
        Console.WriteLine($"IPodPlayer - Stopping");
    }
}

public class IPhone : IAudioPlayer, IVideoPlayer {
    public void Play(string audioFile)
    {
        Console.WriteLine($"IPhone - > Playing {audioFile}");
    }

    public void Pause()
    {
        Console.WriteLine($"IPhone - Pausing");
    }

    public void Stop()
    {
        Console.WriteLine($"IPhone - Stopping");
    }
    
    
    
    
}
