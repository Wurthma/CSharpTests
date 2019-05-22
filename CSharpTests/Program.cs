using System;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpTests
{
    class Program
    {
        static string hello;
        static string world;

        //Para mudar o Main para assíncrono usar: static async Task Main(string[] args)
        static void Main(string[] args)
        {
            Hello(); //utilizar await aqui para para que o método funcione de forma assíncrona
            World(); //esse método apesar de marcado com async roda de foma síncrona já que não faz uso do await

            /*
             * Apenas "World" será impresso abaixo se o método main não for assíncrono e chamar o Hello() com await. O método assíncrono não está recebendo o ponto de suspensão para receber seu resultado posteriormente
             * O "World" é impresso pois seu método é síncrono já que não faz uso do await
            */
            Console.WriteLine(hello + " " + world);


            /* dispara uma nova thread para executar 
             * Threads executam tarefas de forma paralela, funciona de forma diferente dos métodos assíncronos
             * Exemplo abaixo de 2 tarefas executadas em paralelo.
            */
            Thread t = new Thread(NovaThread);
            t.Start();

            // Simultaneamente, executa uma tarefa na thread principal
            for (int i = 0; i < 300; i++) Console.Write("1");
        }

        /* Métodos assincronos devem utilizar Task. Evitar o uso de void e quando necessário retornar um tipo utilizar Task<TResult>
         * Eviatar: static async Task Hello()
         * Para que um método de fato execute de forma assincrona deve ser utilizada a keyword await
         * AWAIT: O operador await é aplicado a uma tarefa em um método assíncrono para inserir um ponto de suspensão na execução do método até que a tarefa aguardada seja concluída. A tarefa representa um trabalho em andamento.
        */
        static async Task Hello()
        {
            await Task.Delay(5);
            hello = "Hello";
        }

        /* Se um método assíncrono não faz uso do await ele funcionará de forma síncrona
        */
        static async Task World()
        {
            //Thread: é uma forma de um processo dividir a si mesmo em duas ou mais tarefas que podem ser executadas concorrentemente.
            Thread.Sleep(5);
            world = "World";
        }

        /*
         * Método a ser executado como uma thread (paralelismo)
         * http://www.macoratti.net/10/09/c_thd1.htm
         */
        static void NovaThread()
        {
            for (int i = 0; i < 300; i++) Console.Write("2");
        }
    }
}
