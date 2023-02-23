#region Mutex (Internal threads)

/*

Mutex mutexObject = new Mutex();
Thread[] threads = new Thread[5];


for (int i = 0; i < 5; i++)
{
    threads[i] = new Thread(Count);
    threads[i].Name = "Thread " + i;
}


for (int i = 0; i < 5; i++)
    threads[i].Start();



void Count()
{
    int x = 1;

    mutexObject.WaitOne();

    for (int i = 0; i < 9; i++)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} : {x++}");
        Thread.Sleep(100);
    }

    mutexObject.ReleaseMutex();
}

*/

#endregion




#region Mutex (External threads)

/*

string mutexName = "Shalom";
using var m = new Mutex(false, mutexName);


if (m.WaitOne(7000))
{
    Console.WriteLine("Run some amazing code");
    Console.ReadLine();
    m.ReleaseMutex();
}
else
{
    Console.WriteLine("Second instance is running!");
    Environment.Exit(0);
}

*/

#endregion














#region Semaphore

/*

Semaphore semaphore = new Semaphore(3, 3, "SEMAPHORE");

for (int i = 0; i < 6; i++)
    ThreadPool.QueueUserWorkItem(SomeMethod, semaphore);


Console.ReadKey();



void SomeMethod(object? state)
{
    var semaphore = state as Semaphore;
    
    if (semaphore is null) 
        return;

   
    bool isFinish = false;

    while (!isFinish)
    {
        if (semaphore.WaitOne(2000))
        {
            try
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} got the key");
                Thread.Sleep(6000);
            }
            finally
            {
                isFinish = true;
                semaphore.Release();
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} returned the key");

            
            }
        }
        else
        {
            Console.WriteLine($"Mister Thread number {Thread.CurrentThread.ManagedThreadId}, we have not enough keys. Please wait ...");
        }

    }
}

*/

#endregion





#region SemaphoreSlim

/*

SemaphoreSlim _semaSlim = new SemaphoreSlim(3);


for (int i = 0; i < 16; i++)
{
    var name = "Thread " + i;

    new Thread(() =>
    {
        AccessDatebase(name, 5);
    }).Start();
}


void AccessDatebase(string name, int seconds)
{
    Console.WriteLine($"{name} waits for access");

    _semaSlim.Wait();
    Console.WriteLine($"{name} is working on database...");

    Thread.Sleep(seconds * 1000);

    _semaSlim.Release();
    Console.WriteLine($"{name} is completed...");
}

*/

#endregion