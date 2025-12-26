class Program
{
    // Ponto de entrada da aplicação console
    static void Main(string[] args)
    {
        // Cria uma instância do serviço que identifica a bandeira do cartão
        var validator = new CreditCardService();

        // Mensagens iniciais para o usuário
        Console.WriteLine("=== Validador de Cartão de Crédito (DIO Challenge) ===");
        Console.WriteLine("Digite o número do cartão para identificar a bandeira:");
        Console.Write("> ");

        // Lê a entrada do usuário (pode ser null se a entrada for encerrada)
        string input = Console.ReadLine();

        // Chama o serviço para identificar a bandeira.
        // Usa coalescência nula para enviar string vazia caso input seja null
        string result = validator.IdentifyBrand(input ?? "");

        // Exibe o resultado para o usuário
        Console.WriteLine();
        Console.WriteLine($"Resultado: {result}");
        
        // Aguarda o usuário pressionar qualquer tecla antes de encerrar
        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}