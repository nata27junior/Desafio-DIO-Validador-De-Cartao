# Validador de Cartão de Crédito

Este projeto implementa um validador de cartões de crédito em JavaScript que identifica a bandeira do cartão e valida o número usando o algoritmo de Luhn.

## Funcionalidades

- Validação de números de cartão de crédito usando o algoritmo de Luhn
- Identificação automática da bandeira do cartão
- Suporte para 10 bandeiras diferentes:
  - MasterCard
  - Visa
  - American Express
  - Diners Club
  - Discover
  - enRoute
  - JCB
  - Voyager
  - HiperCard
  - Aura

## Função validarCartao

A função `validarCartao` é o coração deste projeto. Ela recebe um número de cartão de crédito como parâmetro e realiza as seguintes operações:

### Parâmetros
- `numeroCartao` (string): O número do cartão de crédito a ser validado

### Processo de Validação
1. **Limpeza do Número**:
   - Remove espaços e caracteres não numéricos
   - Mantém apenas os dígitos do cartão

2. **Verificações Iniciais**:
   - Verifica se o número foi fornecido
   - Valida o comprimento (entre 13 e 19 dígitos)

3. **Algoritmo de Luhn**:
   - Implementa o algoritmo de Luhn para validação matemática
   - Verifica se o número segue o padrão correto

4. **Identificação da Bandeira**:
   - Verifica o padrão do número contra as regras de cada bandeira
   - Retorna a bandeira correspondente se encontrada

### Retorno
A função retorna um objeto com as seguintes propriedades:

```javascript
// Para cartões válidos:
{
    valido: true,
    bandeira: 'Nome da Bandeira',
    numero: 'Número do Cartão'
}

// Para cartões inválidos:
{
    valido: false,
    mensagem: 'Mensagem de Erro'
}
```


## Como Usar

1. Clone este repositório
2. Abra o arquivo `index.js` em seu editor de código
3. Para validar um cartão, use a função `validarCartao()`:

```javascript
const resultado = validarCartao('4111111111111111');
console.log(resultado);
```

## Formato do Resultado

A função retorna um objeto com as seguintes propriedades:

```javascript
// Para cartões válidos:
{
    valido: true,
    bandeira: 'Visa',
    numero: '4111111111111111'
}

// Para cartões inválidos:
{
    valido: false,
    mensagem: 'Número de cartão inválido'
}
```


## Como Funciona

1. **Limpeza do Número**:
   - Remove espaços e caracteres não numéricos
   - Mantém apenas os dígitos do cartão

2. **Validação Luhn**:
   - Implementa o algoritmo de Luhn para verificar a validade do número
   - Verifica se o número segue o padrão matemático correto

3. **Identificação da Bandeira**:
   - Verifica o padrão do número contra as regras de cada bandeira
   - Retorna a bandeira correspondente se encontrada

## Contribuindo

Sinta-se à vontade para contribuir com este projeto:

1. Faça um Fork do projeto
2. Crie uma Branch para sua Feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a Branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.


## Agradecimentos

- [4Devs](https://www.4devs.com.br/gerador_de_numero_cartao_credito) - Gerador de números de cartão de crédito para testes
- Algoritmo de Luhn - Método de validação de números de cartão de crédito 
