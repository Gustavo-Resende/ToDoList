namespace Program
{
    public class Program()
    {
        public static void Main()
        {
            List<string> lista = new List<string>();
            while (true)
            {
                Console.Write("Adicionar, remover ou tarefas: ");
                string acao = Console.ReadLine();

                Console.Clear();
                
                if (acao == "Adicionar"|| acao == "adicionar")
                {                   
                    Console.Write("Nome da tarefa: ");
                    string tarefa = Console.ReadLine();

                    lista.Add(tarefa);

                    foreach (var task in lista)
                    {
                        Console.WriteLine($"- {task}");
                    }
                }

                if (acao == "Remover" || acao == "remover")
                {
                    Console.Write("Remover tarefa: ");
                    string tarefa = Console.ReadLine();

                    lista.Remove(tarefa);
                    foreach (var task in lista)
                    {
                        Console.WriteLine($"- {task}");
                    }
                }

                if (acao == "Tarefas" || acao == "tarefas")
                {
                    foreach (var task in lista)
                    {
                        Console.WriteLine($"- {task}");
                    }
                }      
            }
        }
    }
} 