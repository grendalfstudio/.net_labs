using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Threads
{
    public class FileReader
    {
        private readonly string _filePath;
        private readonly object _locker = String.Empty;
        private readonly Mutex _mutex = new Mutex();
        private readonly Semaphore _semaphore = new Semaphore(1, 2);

        public FileReader(string filePath)
        {
            _filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, filePath);
        }

        public void DoTask1()
        {
            Console.WriteLine("First task:");
            Thread thread1 = new Thread(WriteOnFile);
            Thread thread2 = new Thread(WriteOnFile);
            thread1.Start("Line 1");
            thread2.Start("Line 2");
        }

        public void DoTask2()
        {
            Console.WriteLine("With locker:");
            Thread thread1 = new Thread(WriteWithLocker);
            Thread thread2 = new Thread(WriteWithLocker);
            thread1.Start("Line 1");
            thread2.Start("Line 2");
        }

        public void DoTask3()
        {
            Console.WriteLine("With mutex:");
            Thread thread1 = new Thread(WriteWithMutexs);
            Thread thread2 = new Thread(WriteWithMutexs);
            thread1.Start("Line 1");
            thread2.Start("Line 2");
        }

        public void DoTask4()
        {
            Console.WriteLine("With semaphore:");
            Thread thread1 = new Thread(WriteWithSemaphore);
            Thread thread2 = new Thread(WriteWithSemaphore);
            Thread thread3 = new Thread(WriteWithSemaphore);
            Thread thread4 = new Thread(WriteWithSemaphore);
            Thread thread5 = new Thread(WriteWithSemaphore);
            thread1.Start("Line 1");
            thread2.Start("Line 2");
            thread3.Start("Line 3");
            thread4.Start("Line 4");
            thread5.Start("Line 5");
        }

        private string ReadFromFile()
        {
            var fileText = "";
            
            using (var sr = new StreamReader(_filePath, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    fileText += line;
                }
            }

            return fileText;
        }

        private void WriteOnFile(object line)
        {
            using (var sw = new StreamWriter(_filePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(line.ToString());
            }

            Console.WriteLine(ReadFromFile());
        }

        private void WriteWithLocker(object line)
        {
            lock (_locker)
            {
                WriteOnFile(line);
            }
        }

        private void WriteWithMutexs(object line)
        {
            _mutex.WaitOne();
            WriteOnFile(line);
            _mutex.ReleaseMutex();
        }

        private void WriteWithSemaphore(object line)
        {
            _semaphore.WaitOne();
            WriteOnFile(line);
            _semaphore.Release();
        }
    }
}