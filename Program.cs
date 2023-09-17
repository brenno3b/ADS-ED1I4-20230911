using ADS_ED1I4_20231109.Controllers;

LivrosController controller = new LivrosController();

void addLivro()
{
    Console.WriteLine("--- Adicionar livro ---");
    Console.WriteLine();

    Console.Write("Digite o ISBN do livro: ");
    int isbn = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Console.Write("Digite o título do livro: ");
    string titulo = Console.ReadLine();
    Console.WriteLine();

    Console.Write("Digite o(a) autor(a) do livro: ");
    string autor = Console.ReadLine();
    Console.WriteLine();

    Console.Write("Digite a editora do livro: ");
    string editora = Console.ReadLine();
    Console.WriteLine();

    LivroController livro = new(isbn, titulo, autor, editora);

    controller.Adicionar(livro);

    Console.WriteLine("Livro adicionado.");

    Console.WriteLine("\n--- Fim da adição de livro ---\n");
}

void getLivroSintetico()
{
    Console.WriteLine("--- Pesquisa de livro sintético ---");
    Console.WriteLine();

    Console.Write("Digite o ISBN do livro: ");
    int isbn = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    LivroController searchLivro = new(isbn);

    LivroController foundLivro = controller.Pesquisar(searchLivro);

    if (foundLivro.Isbn == -1)
    {
        Console.WriteLine("Livro não encontrado.");

        return;
    }

    Console.WriteLine("ISBN: " + foundLivro.Isbn);
    Console.WriteLine("Título: " + foundLivro.Titulo);
    Console.WriteLine("Autor(a): " + foundLivro.Autor);
    Console.WriteLine("Editora: " + foundLivro.Editora);
    Console.WriteLine("Total de exemplares: " + foundLivro.Exemplares.Count + " (" + foundLivro.QtdeDisponiveis() + " disponíveis)");

    int totalEmprestimos = 0;

    foreach (ExemplarController element in foundLivro.Exemplares)
    {
        totalEmprestimos += element.QtdeEmprestimos();
    }

    Console.WriteLine("Total de empréstimos: " + totalEmprestimos);
    Console.WriteLine("Percental de disponibilidade: " + foundLivro.PercDisponibilidade() * 100 + "%");

    Console.WriteLine("\n--- Fim da pesquisa de livro sintético ---\n");
}

void getLivroAnalitico()
{

}

void addExemplar()
{
    Console.WriteLine("--- Adição de exemplar ---");
    Console.WriteLine();

    Console.Write("Digite o ISBN do livro: ");
    int isbn = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    LivroController searchLivro = new(isbn);

    LivroController foundLivro = controller.Pesquisar(searchLivro);

    if (foundLivro.Isbn == -1)
    {
        Console.WriteLine("Livro não encontrado.");

        return;
    }

    Console.Write("Digite o número do tombo: ");
    int tombo = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    ExemplarController newExemplar = new(tombo);

    foundLivro.AdicionarExemplar(newExemplar);

    Console.WriteLine("Exemplar adicionado ao livro: " + foundLivro.Titulo + "(ISBN: " + foundLivro.Isbn + ")");

    Console.WriteLine("\n--- Fim da adição de exemplar ---\n");
}

void registerEmprestimo()
{
    Console.WriteLine("--- Registro de empréstimo ---");
    Console.WriteLine();

    Console.Write("Digite o ISBN do livro: ");
    int isbn = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    LivroController searchLivro = new(isbn);

    LivroController foundLivro = controller.Pesquisar(searchLivro);

    if (foundLivro.Isbn == -1)
    {
        Console.WriteLine("Livro não encontrado.");

        return;
    }

    Console.Write("Digite o número do tombo: ");
    int tombo = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    int index = foundLivro.Exemplares.FindIndex(e => e.Tombo == tombo);

    if (index == -1)
    {
        Console.WriteLine("Tombo não encontrado");

        return;
    }

    bool isSuccess = foundLivro.Exemplares.ElementAt(index).Emprestar();

    Console.WriteLine(isSuccess ? "Empréstimo registrado." : "Operação não permitida.");

    Console.WriteLine("\n--- Fim do registro de empréstimo ---\n");
}

void registerDevolucao()
{
    Console.WriteLine("--- Registro de devolução ---");
    Console.WriteLine();

    Console.Write("Digite o ISBN do livro: ");
    int isbn = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    LivroController searchLivro = new(isbn);

    LivroController foundLivro = controller.Pesquisar(searchLivro);

    if (foundLivro.Isbn == -1)
    {
        Console.WriteLine("Livro não encontrado.");

        return;
    }

    Console.Write("Digite o número do tombo: ");
    int tombo = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    int index = foundLivro.Exemplares.FindIndex(e => e.Tombo == tombo);

    if (index == -1)
    {
        Console.WriteLine("Tombo não encontrado");

        return;
    }

    bool isSuccess = foundLivro.Exemplares.ElementAt(index).Devolver();

    Console.WriteLine(isSuccess ? "Devolução registrada." : "Operação não permitida.");

    Console.WriteLine("\n--- Fim do registro de devolução ---\n");
}

while (true)
{
    Console.WriteLine("0. Sair");
    Console.WriteLine("1. Adicionar livro");
    Console.WriteLine("2. Pesquisar livro (sintético)");
    Console.WriteLine("3. Pesquisar livro (analítico)");
    Console.WriteLine("4. Adicionar exemplar");
    Console.WriteLine("5. Registrar empréstimo");
    Console.WriteLine("6. Registrar devolução");

    Console.WriteLine();

    int option = Convert.ToInt32(Console.ReadLine());
    Console.Clear();

    if (option == 0) break;
    if (option == 1) addLivro();
    if (option == 2) getLivroSintetico();
    if (option == 3) getLivroAnalitico();
    if (option == 4) addExemplar();
    if (option == 5) registerEmprestimo();
    if (option == 6) registerDevolucao();
}