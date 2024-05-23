namespace ToDoListApp
{
    public class Program()
    {
        static List<string> lista = new List<string>();
        public static void Main()
        {
            while (true)
            {
                Console.Write("Adicionar, remover ou tarefas: ");
                string action = Console.ReadLine().ToLower();

                Console.Clear();

                switch (action)
                {
                    case "adicionar":
                        AddTask();
                        break;
                    case "remover":
                        RemoveTask();
                        break;
                    case "tarefas":
                        ShowTask();
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }        
            }
        }

        static void AddTask()
        {
            Console.Write("Nome da tarefa: ");
            var taskAdd = Console.ReadLine();

            lista.Add(taskAdd);
            Console.WriteLine("Adicionada com sucesso!");
        }

        static void RemoveTask()
        {
            foreach (var task in lista)
            {
                Console.WriteLine($"- {task}");
            } 

            Console.Write("Nome da tarefa: ");
            var taskRemove = Console.ReadLine();

            lista.Remove(taskRemove);
            Console.WriteLine("Removida com sucesso!");            
        }

        static void ShowTask()
        {
            foreach (var task in lista)
            {
                Console.WriteLine($"- {task}");
            }           
        }
    }
} 