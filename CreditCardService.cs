/**
 * Validador de Cartão de Crédito
 * Este script valida números de cartão de crédito e identifica suas bandeiras
 * Suporta as seguintes bandeiras:
 * - MasterCard
 * - Visa
 * - American Express
 * - Diners Club
 * - Discover
 * - enRoute
 * - JCB
 * - Voyager
 * - HiperCard
 * - Aura
 */

using System.Text.RegularExpressions;

public class CreditCardService
{
    // Dicionário que mapeia o nome da bandeira para a expressão regular correspondente.
    // Cada regex tenta detectar padrões de BIN/Comprimento típicos para a bandeira.
    private readonly Dictionary<string, Regex> _cardPatterns = new()
    {
        // Visa: começa com 4, 13 ou 16 dígitos
        { "Visa", new Regex(@"^4[0-9]{12}(?:[0-9]{3})?$") },

        // MasterCard: séries 51-55 e intervalos 2221-2720 (incluídos pela segunda parte)
        { "MasterCard", new Regex(@"^5[1-5][0-9]{14}$|^2(?:2(?:2[1-9]|[3-9][0-9])|[3-6][0-9][0-9]|7(?:[01][0-9]|20))[0-9]{12}$") },

        // American Express: começa com 34 ou 37 e tem 15 dígitos
        { "American Express", new Regex(@"^3[47][0-9]{13}$") },

        // Diners Club: 300-305, 36 ou 38, geralmente 14 dígitos
        { "Diners Club", new Regex(@"^3(?:0[0-5]|[68][0-9])[0-9]{11}$") },

        // Discover: 6011 ou 65 seguido de 12 dígitos
        { "Discover", new Regex(@"^6(?:011|5[0-9]{2})[0-9]{12}$") },

        // Elo: vários BINs possíveis (expressão que cobre prefixos conhecidos)
        { "Elo", new Regex(@"^((((636368)|(438935)|(504175)|(451416)|(636297))\d{0,10})|((5067)|(4576)|(4011))\d{0,12})$") }
    };

    /// <summary>
    /// Identifica a bandeira de um número de cartão.
    /// Remove espaços/traços, verifica se contém apenas dígitos, testa contra
    /// padrões conhecidos e aplica validação Luhn para verificar integridade.
    /// </summary>
    public string IdentifyBrand(string cardNumber)
    {
        // Remove espaços em branco e traços para ficar apenas com dígitos
        string cleanNumber = Regex.Replace(cardNumber, @"\s+|-", "");

        // Verifica se a string resultante contém apenas dígitos
        if (!long.TryParse(cleanNumber, out _))
            return "Erro: O número contém caracteres inválidos.";

        // Testa cada padrão conhecido
        foreach (var card in _cardPatterns)
        {
            if (card.Value.IsMatch(cleanNumber))
            {
                // Se o padrão bateu, faz a verificação de Luhn para checar a validade matemática
                bool isValid = IsValidLuhn(cleanNumber);
                return isValid 
                    ? $"Bandeira: {card.Key} (Válido)" 
                    : $"Bandeira: {card.Key} (Número Inválido)";
            }
        }

        // Se nenhum padrão corresponde, retorna desconhecido
        return "Bandeira Desconhecida";
    }

    /// <summary>
    /// Implementação do algoritmo de Luhn.
    /// Percorre os dígitos da direita para a esquerda, dobra a cada segundo dígito,
    /// subtrai 9 se o resultado for maior que 9 e soma tudo. Se a soma for múltipla de 10,
    /// o número é válido segundo Luhn.
    /// </summary>
    private bool IsValidLuhn(string number)
    {
        int sum = 0;
        bool alternate = false;

        // Percorre do último ao primeiro dígito
        for (int i = number.Length - 1; i >= 0; i--)
        {
            char c = number[i];

            // Converte caractere para inteiro (assume que já é dígito)
            int n = c - '0'; 

            // Dobra o dígito alternado (2º, 4º, ...) e ajusta se > 9
            if (alternate)
            {
                n *= 2;
                if (n > 9) n -= 9;
            }

            sum += n;
            alternate = !alternate; // alterna para o próximo dígito
        }

        // Válido se soma for múltipla de 10
        return (sum % 10 == 0);
    }
}