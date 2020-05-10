using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CursoCSharpContinueGoldAula6ConsoleApp
{
    class Program
    {
        // devemos favor uma sincronização destas variáveis que serão acessadas pelas threads
        static int valor = 0;
        // para isso, criamos uma variável chamada locker
        static object locker = new object();

        static void Main(string[] args)
        {
            // AULA 06.02 - Threading - 2
            // AULA 06.03 - Threading - 3            
            // não temos controle de qdo o sistema operacional escalona para executar cada thread
            Console.WriteLine("Inicio da corrida");
            int nThreads = 10;
            Thread[] threads = new Thread[10];
            for (int i = 0; i < nThreads; i++)
            {
                threads[i] = new Thread(ExecutarCorrida);
                threads[i].Name = "Thread" + (i);
                if (i % 2 == 0) // caso par - dando preferencia
                {
                    threads[i].Priority = ThreadPriority.Highest;
                }
                else
                {
                    threads[i].Priority = ThreadPriority.Lowest;
                }
            }
            for (int i = 0; i < nThreads; i++)
            {
                // aqui o start inicia as threads.
                threads[i].Start();
            }
            for (int i = 0; i < nThreads; i++)
            {
                // aqui este join diz que enquanto a primeira thread que foi delegada a executar,
                // não acabar, essa linha da thread principal é travada.
                threads[i].Join();
            }
            Console.WriteLine(valor);
            Console.WriteLine("Final da corrida");
        }
        // Leitura adicional sobre ManualEventReset, Mutex Semaphore
        static void ExecutarCorrida()
        {
            Console.WriteLine(Thread.CurrentThread.Name + "começou.");
            for (int i = 0; i < 10000000; i++)
            {
                // o trecho de código lock, pede qualquer objeto que seja referencia do sistema
                // o lock garante que apenas um cara vai executar por vez
                lock (locker)
                {
                    valor++;
                }

                // poderia ser utilizado da mesma forma:
                //Monitor.Enter(locker);
                //valor++;
                //Monitor.Exit(locker);

                //para operações matemáticas
                //Interlocked.Increment(ref valor);
            }
            Console.WriteLine(Thread.CurrentThread.Name + "terminou.");
        }
    }
}
