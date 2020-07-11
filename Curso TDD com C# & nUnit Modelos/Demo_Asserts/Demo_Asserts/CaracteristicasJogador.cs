using System;
using System.Collections.Generic;

namespace Demo_Asserts
{
    /*Estaremos simulando um jogo nesta classe*/
    public class CaracteristicasJogador
    {
        /* Atributos do Jogador */
        public int Vida { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public bool NovoJogador { get; set; }
        public List<string> Armas { get; set; }

        /* Classe Construtor  */
        public CaracteristicasJogador()
        {
            Nome = GerarNome();
            NovoJogador = true;
            CriarArmasIniciais();
        }

        /* Método responsável por aumentar a vida do jogado, qdo ele for dormir */
        public void Dormir()
        {
            var random = new Random();
            // queremos aumentar a vida do jogador
            var aumentarVida = random.Next(1, 101);
            Vida += aumentarVida;
        }

        /* Método responsável por tirar vida do jogador */
        public void PerderVida(int perderVida)
        {
            Vida = Math.Max(1, Vida -= perderVida); 
        }

        /* método responsável por gerar nomes dos jogadores de maneira randômica */
        private string GerarNome()
        {
            var nomes = new[]
            {
                "Spider-Man",
                "Homem de Ferro",
                "Capitão América",
                "Homem Formiga",
                "Hulk"
            };
            return nomes[new Random().Next(0,nomes.Length)];
        }

        /* Método responsável por listar armas disponíveis para jogador */
        private void CriarArmasIniciais()
        {
            Armas = new List<string>() 
            {
                "Agilidade",
                "Agilidade Força",
                "Força",                
                "Inteligência Artificial",
                "Teia de Aranha"                
            };
        }
    }
}
