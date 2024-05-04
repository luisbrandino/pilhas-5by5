using Pilhas;

Stack[] stacks = new Stack[2] { new Stack(), new Stack() };

populateStack(stacks[0]);
populateStack(stacks[1]);

int inputInteger(string message, int? min = null, int? max = null)
{
    Console.Write(message);
    int value = int.Parse(Console.ReadLine());

    while (true)
    {
        bool correctValue = (min != null ? value >= min : true) && (max != null ? value <= max : true);

        if (correctValue)
            break;

        string invalid = min != null ? $"Valor precisa ser maior ou igual a {min}" : "";
        invalid += invalid == "" ? "Valor precisa ser " : " e ";
        invalid += max != null ? $"menor ou igual a {max}" : "";
        invalid += ": ";

        Console.Write(invalid);
        value = int.Parse(Console.ReadLine());
    }

    return value;
}

void waitForAnyKey()
{
    Console.WriteLine("\n\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}

void populateStack(Stack stack)
{
    int length = new Random().Next(5, 15);

    for (int i = 0; i < length; i++)
        stack.Push(new Random().Next(-50, 50));
}

void quantityOfEven()
{
    int index = selectStackMenu();
    Stack stack = stacks[index];

    Console.Clear();

    Console.WriteLine($"Quantidade de números pares da pilha {index + 1}: {stack.EvenCount()}");

    waitForAnyKey();
}

void quantityOfOdd()
{
    int index = selectStackMenu();
    Stack stack = stacks[index];

    Console.Clear();

    Console.WriteLine($"Quantidade de números ímpares da pilha {index + 1}: {stack.OddCount()}");

    waitForAnyKey();
}

void transferSelectedStackToNewStack()
{
    int index = selectStackMenu();
    Stack stack = stacks[index];

    Stack clonedStack = stack.Clone();

    Console.Clear();

    Console.WriteLine($"Nova pilha baseada na pilha {index + 1}:");
    clonedStack.Display();

    waitForAnyKey();
}

void displayStackSummary()
{
    int index = selectStackMenu();
    Stack stack = stacks[index];

    Console.Clear();

    Console.WriteLine($"Estatísticas da pilha {index + 1}:\n");

    Console.WriteLine($"Maior elemento: {stack.Max()}");
    Console.WriteLine($"Menor elemento: {stack.Min()}");
    Console.WriteLine($"Média: {stack.Average().ToString("0.0")}");

    waitForAnyKey();
}

void compareStacks()
{
    int indexA = selectStackMenu();
    int indexB = selectStackMenu();

    Console.Clear();

    Stack stackA = stacks[indexA];
    Stack stackB = stacks[indexB];

    if (stackA.Equals(stackB))
        Console.WriteLine($"Pilha {indexA + 1} e pilha {indexB + 1} são iguais");
    else if (stackA.Count() > stackB.Count())
        Console.WriteLine($"Pilha {indexA + 1} é maior que pilha {indexB + 1}");
    else
        Console.WriteLine($"Pilha {indexA + 1} é menor que pilha {indexB + 1}");

    waitForAnyKey();
}

void displayStack()
{
    int index = selectStackMenu();
    Stack stack = stacks[index];
    Console.Clear();

    Console.WriteLine($"Pilha {index + 1}:");
    stack.Display();
    waitForAnyKey();
}

int selectStackMenu()
{
    Console.Clear();
    for (int i = 0; i < stacks.Length; i++)
        Console.WriteLine($"[ {i + 1} ] Pilha {i + 1}");

    return inputInteger("Sua opção: ", min: 1, max: stacks.Length) - 1;
}

int selectOperationMenu()
{
    Console.Clear();
    Console.WriteLine("[ 1 ] Imprimir pilha\n[ 2 ] Comparar pilhas\n[ 3 ] Maior, menor e média aritmética\n[ 4 ] Transferir elementos de uma pilha para uma nova\n[ 5 ] Quantidade de pares\n[ 6 ] Quantidade de ímpares\n[ 0 ] Sair");

    return inputInteger("Sua opção: ", min: 0, max: 6);
}

while (true)
{
    switch (selectOperationMenu())
    {
        case 1:
            displayStack();
            break;
        case 2:
            compareStacks();
            break;
        case 3:
            displayStackSummary();
            break;
        case 4:
            transferSelectedStackToNewStack();
            break;
        case 5:
            quantityOfEven();
            break;
        case 6:
            quantityOfOdd();
            break;
        default:
            Environment.Exit(0);
            break;
    }
}