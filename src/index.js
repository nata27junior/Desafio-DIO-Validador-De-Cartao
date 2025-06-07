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

function validarCartao(numeroCartao) {
    // Verifica se o número foi fornecido
    if (!numeroCartao) {
        return {
            valido: false,
            mensagem: 'Número do cartão não fornecido'
        };
    }

    // Remove espaços e caracteres não numéricos
    numeroCartao = numeroCartao.replace(/\D/g, '');

    // Verifica se o número tem pelo menos 13 dígitos
    if (numeroCartao.length < 13) {
        return {
            valido: false,
            mensagem: 'Número do cartão muito curto'
        };
    }

    // Verifica se o número tem no máximo 19 dígitos
    if (numeroCartao.length > 19) {
        return {
            valido: false,
            mensagem: 'Número do cartão muito longo'
        };
    }

    /**
     * Implementação do Algoritmo de Luhn para validação do número do cartão
     * @param {string} numero - Número do cartão a ser validado
     * @returns {boolean} - Retorna true se o número for válido
     */
    function validarLuhn(numero) {
        let soma = 0;
        let deveDobrar = false;

        // Percorre os dígitos da direita para a esquerda
        for (let i = numero.length - 1; i >= 0; i--) {
            let digito = parseInt(numero.charAt(i));

            if (deveDobrar) {
                digito *= 2;
                if (digito > 9) {
                    digito -= 9;
                }
            }

            soma += digito;
            deveDobrar = !deveDobrar;
        }

        return soma % 10 === 0;
    }

    // Padrões de identificação das bandeiras
    const padroes = {
        'MasterCard': /^5[1-5]\d{14}$/,          // Começa com 51-55 e tem 16 dígitos
        'Visa': /^4\d{15}$/,                     // Começa com 4 e tem 16 dígitos
        'American Express': /^3[47]\d{13}$/,     // Começa com 34 ou 37 e tem 15 dígitos
        'Diners Club': /^3(?:0[0-5]|[68]\d)\d{11}$/, // Começa com 300-305, 36 ou 38
        'Discover': /^6(?:011|5\d{2})\d{12}$/,  // Começa com 6011 ou 65 e tem 16 dígitos
        'enRoute': /^2(?:014|149)\d{11}$/,      // Começa com 2014 ou 2149
        'JCB': /^35\d{14}$/,                    // Começa com 35 e tem 16 dígitos
        'Voyager': /^8699\d{12}$/,              // Começa com 8699
        'HiperCard': /^(606282\d{10}(\d{3})?)|(3841\d{15})$/, // Padrões específicos do HiperCard
        'Aura': /^50\d{14}$/                    // Começa com 50 e tem 16 dígitos
    };

    // Verifica se o número é válido usando o algoritmo de Luhn
    if (!validarLuhn(numeroCartao)) {
        return {
            valido: false,
            mensagem: 'Número de cartão inválido'
        };
    }

    // Identifica a bandeira do cartão
    for (const [bandeira, padrao] of Object.entries(padroes)) {
        if (padrao.test(numeroCartao)) {
            return {
                valido: true,
                bandeira: bandeira,
                numero: numeroCartao
            };
        }
    }

    return {
        valido: false,
        mensagem: 'Bandeira não identificada'
    };
}

// Exemplo de uso
const resultado = validarCartao('4111111111111111');
console.log(resultado); 