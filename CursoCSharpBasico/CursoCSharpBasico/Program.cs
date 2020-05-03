using System;
using System.IO;

namespace CursoCSharpBasico
{
    class Program
    {
        // Código a ser executado
        static void Main(string[] args)
        {
            // podemos chamar diretamente o método desejado a ser executado
            EstruturasRepeticao_Aula_3_7();
        }

        void Tipos_Aula_2_1()
        {
            // principais variaveis: int, double, string
            string nome = "Fulano"; // usando sempre para armazenar um texto, até mesmo um número ao qual não será feito cálculo, ex: número de casa
            string teste = "10";
            string teste2 = "20";
            string teste3 = teste + teste2; // resultado 1020

            int numero = 10;
            int numero2 = 20;
            int numero3 = numero + numero2; // resultado 30

            double d = 10.4; // numero com ponto flutuante
        }

        static void EntradaDados_Aula_2_2()
        {
            Console.WriteLine("Digite um nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Olá sr." + nome);
        }

        static void Conversao_Aula_2_3()
        {
            Console.WriteLine("Digite o primeiro valor");
            string a = Console.ReadLine();
            Console.WriteLine("Digite o segundo valor");
            string b = Console.ReadLine();
            int aConvertido = Convert.ToInt32(a);
            int bConvertido = Convert.ToInt32(b);
            int c = aConvertido + bConvertido;
            Console.WriteLine("O Valor Total é:");
            Console.WriteLine(c);
        }

        static void EstruturaControle_Aula_3_1()
        {
            // dentro de um if no C#, é obrigatório o uso de uma estrutura booleana ou uma instrução lógica
            if (File.Exists("C:\\teste.txt"))
            {
                Console.WriteLine("Arquivo Existente");
            }
            else
            {
                Console.WriteLine("Arquivo Inexistente");
            }
        }

        static void EstruturaControle_Aula_3_2()
        {
            // 50km/h - isento
            // 70 km/h - 120 reais
            // 90 km/h - 150 reais
            // 110 km/h - 400 reais
            // acima de 110 km/h - 1000 reais

            Console.WriteLine("Digite a velocidade");
            string velocidadeDigitada = Console.ReadLine();
            int velocidade = Convert.ToInt32(velocidadeDigitada);

            if (velocidade <= 50)
            {
                Console.WriteLine("Isento");
            }
            else if (velocidade <= 70)
            {
                Console.WriteLine("120,00");
            }
            else if (velocidade <= 90)
            {
                Console.WriteLine("150,00");
            }
            else if (velocidade <= 110)
            {
                Console.WriteLine("400,00");
            }
            else
            {
                Console.WriteLine("1.000,00 e perda da carteira de habilitação");
            }
        }

        static void EstruturaControle_Aula_3_3()
        {
            // Triângulo
            // Verificar se a soma de dois lados não pode ser maior que o terceiro lado
            // Equilátero, Isósceles, Escaleno

            Console.WriteLine("Informe o lado 1");
            string lado1Digitado = Console.ReadLine();

            Console.WriteLine("Informe o lado 2");
            string lado2Digitado = Console.ReadLine();

            Console.WriteLine("Informe o lado 3");
            string lado3Digitado = Console.ReadLine();

            int lado1 = Convert.ToInt32(lado1Digitado);
            int lado2 = Convert.ToInt32(lado2Digitado);
            int lado3 = Convert.ToInt32(lado3Digitado);

            if (lado1 > lado2 + lado3
                        ||
                lado2 > lado1 + lado3
                        ||
                lado3 > lado1 + lado2)
            {
                Console.WriteLine("Os lados informados não formam um triângulo Válido");
            }
            else
            {
                // Se entrou aqui é um triângulo
                if (lado1 == lado2 && lado2 == lado3)
                {
                    Console.WriteLine("O Triângulo é Equilátero");
                }
                else if (lado1 == lado2 || lado2 == lado3 || lado1 == lado3)
                {
                    Console.WriteLine("O Triângulo é Isósceles");
                }
                else
                {
                    Console.WriteLine("O Trinângulo é Escaleno");
                }
            }

        }

        static void EstruturasRepeticao_Aula_3_4()
        {
            double alturaJoao = 1.30;
            double crescimentoJoao = 0.03;
            double alturaPedro = 1.15;
            double crescimentoPedro = 0.04;
            int anos = 5;

            while (alturaJoao >= alturaPedro)
            {
                alturaJoao += crescimentoJoao;
                alturaPedro += crescimentoPedro;
                anos++;
            }

            Console.WriteLine("Altura João:");
            Console.WriteLine(alturaJoao);
            Console.WriteLine("Altura Pedro:");
            Console.WriteLine(alturaPedro);
            Console.WriteLine("Idade em que Pedro ficou mais alto que João:");
            Console.WriteLine(anos);
        }

        static void EstruturasRepeticao_Aula_3_5()
        {
            // utilizando for            
            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine(i);
            }

            // usando forr seria um for reverse (forr tab tab) 
            for (int i = 100; i >= 0; i--)
            {
                Console.WriteLine(i);
            }

            // utilizando while
            int numero = 0;
            while (numero <= 100)
            {
                Console.WriteLine(numero);
                numero++;
            }
        }

        static void EstruturasRepeticao_Aula_3_6()
        {
            // 5 pessoas intrevistadas
            // M - F
            // Idade

            int maisNovo = 99999;
            int maisVelho = -1;
            int qtdM = 0;
            int qtdF = 0;
            
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Digite M para Gênero Masculino ou  F para Gênero Feminino");
                string genero = Console.ReadLine();
                if (genero == "M")
                {
                    qtdM++;
                }
                else if (genero == "F")
                {
                    qtdF++;
                }
                else
                {
                    Console.WriteLine("Gênero não informado");
                    i--;
                }
            }

            int n = 0;
            while (n < 5)
            {
                Console.WriteLine("Informe a sua idade:");
                string idadeInformada = Console.ReadLine();
                int idade = Convert.ToInt32(idadeInformada);

                if (idade > maisVelho)
                {
                    maisVelho = idade;
                }
                else if (idade < maisNovo)
                {
                    maisNovo = idade;
                }
                n++;
            }

            Console.WriteLine("Mais novo: " + maisNovo);
            Console.WriteLine("Mais velho: " + maisVelho);

            double pMasculino = ((double)qtdM / 5) * 100;
            double pFeminino = ((double)qtdF / 5) * 100;

            Console.WriteLine("Percentual de Homens: " + pMasculino);
            Console.WriteLine("Percentual de Mulheres: " + pFeminino);
        }

        static void EstruturasRepeticao_Aula_3_7()
        {
            // USANDO SWITCH CASE
            // switch, não é muito indicado para uso de números caso case tente fazer um maior ou menor que determinado número.
            // switch utilizado apenas em caso de igualdade

            Console.WriteLine("Informe uma letra:");
            string letra = Console.ReadLine();

            switch (letra)
            {
                case "a":
                    Console.WriteLine("Você selecionou a primeira letra do alfabeto");
                    break;
                case "b":
                    Console.WriteLine("Você selecionou a segunda letra do alfabeto");
                    break;
                default:
                    Console.WriteLine("Você selecionou uma letra diferente de a ou b");
                    break;
            }
        }
    }
}
