using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CursoCSharpContinueGoldAula8WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }  


        // AULA 08.01 - EQUALIDADE DE OBJETOS
        private void button1_Click(object sender, EventArgs e)
        {
            Cliente c1 = new Cliente();
            c1.Id = 1;
            c1.Nome = "João";
            c1.CPF = "90090090090";

            Cliente c2 = new Cliente();
            c2.Id = 2;
            c2.Nome = "Pedro";
            c2.CPF = "80080080080";

            // clonamos o c2, para o c3
            Cliente c3 = new Cliente();
            c3.Id = 2;
            c3.Nome = "Pedro";
            c3.CPF = "80080080080";
            //if (c1.CPF == c2.CPF)
            //{
            //    // fazendo esta comparação de igualdade acima, é simples,
            //    // o if vai consultar na área de memória chamada de RIP, onde possui o 
            //    // endereço de memória, que a stack está apontando
            //    // na stack temos as structs e os ponteiros das classes
            //}
            //if (Cliente.ReferenceEquals(c2,c3)) // seria a mesma coisa se utilizarmos (c3 == c2)
            //{
            //   // nesta situação, estamos comparando dois objetos
            //   // neste caso especifico, o c# não vai entrar neste if, retornaria false, pois os objetos seriam diferentes, mesmo que possuam as mesmas propriedades
            //   // pois quando verificamos dois ponteiros o C# vai verificar se estamos apontamos para a mesma instância,
            //   // ou seja, para a mesma área de memória na RIP (por ser uma class), caso fosse uma struct,
            //   // seria um caso diferente, pois seria armazenados na stack, percorrendo todas as propriedades da struct.
            //}
            //if (c2.Equals(c3)) // caso de sobreescrever o equals, senão seria a mesma coisa que c2 == c3
            //{

            //}

            // AULA 08.02 - EQUALIDADE DE OBJETOS 2
            // o hashset é um objeto que garante que todos as instancia que ali entrarem, devem ser unicas
            // caso contrario, o count não incrementará
            // cada vez que chamamos o add, o hashset chama por baixo dos panos o gethashcode
            //HashSet<Cliente> clientes = new HashSet<Cliente>();
            //clientes.Add(c1);
            //clientes.Add(c2);
            //clientes.Add(c3); // neste caso, não deveria aceitar o c3, pois ele possui as mesmas propriedades que o c2, seguindo nossas regras de igualdade criadas


            // AULA 08.03 - SERIALIZAÇÃO BINÁRIA
            // EXEMPLO 01 - GRAVANDO
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("teste5.txt", FileMode.Create)) // o using, implementa automaticamente o dispose, no final
            {
                formatter.Serialize(fs, c1);
            }

            // EXEMPLO 02 - LENDO A INFORMAÇÃO
            //BinaryFormatter formatter = new BinaryFormatter();
            //using (FileStream fs = new FileStream("teste5.txt", FileMode.Open)) 
            //{
            //    Cliente c1 = 
            //    formatter.Deserialize(fs) as Cliente;
            //}
        }


        // AULA 08.04 - CLASSE GENÉRICA
        private void button2_Click(object sender, EventArgs e)
        {
            Cliente c1 = new Cliente();
            c1.Id = 1;
            c1.Nome = "Joao";
            Cliente c2 =
            ObjectCloner<Cliente>.CloneWithReflection(c1); // queremos aqui clonar o c1, para o c2
            c2.Email = "lasdnvfonwv"; // podemos agora alterar o c2, sem afetar o c1
           
        }


        // AULA 08.05 - SERIALIZAÇÃO XML
        private void button3_Click(object sender, EventArgs e)
        {
            //List<Cliente> clientes = new List<Cliente>()
            //{
            //    new Cliente()
            //    {
            //        Id = 1,
            //        Nome = "A",
            //        Email = "asdfj@kbcnjd.com",
            //        CPF = "1"
            //    },
            //    new Cliente()
            //    {
            //        Id = 2,
            //        Nome = "B",
            //        Email = "bsdfj@kbcnjd.com",
            //        CPF = "2"
            //    },
            //    new Cliente()
            //    {
            //        Id = 3,
            //        Nome = "C",
            //        Email = "csdfj@kbcnjd.com",
            //        CPF = "3"
            //    },
            //};
            //XmlSerializer serializer = new XmlSerializer(typeof(List<Cliente>));
            //FileStream fs = new FileStream("test.xml", FileMode.Create);
            //serializer.Serialize(fs, clientes);
            //fs.Dispose();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Cliente>));
            FileStream fs = new FileStream("test.xml", FileMode.Open);
            List<Cliente> clientes = (List<Cliente>)serializer.Deserialize(fs);
            fs.Dispose();
        }

    }
    [Serializable]
    public class Cliente //: ISerializable      // : IEqualityComparer<Cliente> estudar
    {
        [XmlAttribute]
        public int Id { get; set; }
        public string Nome { get; set; }
        [XmlIgnore]
        public string Email { get; set; }
        public string CPF { get; set; }
        // podemos sobrescrever o método equals do object
        // responsável por comprar duas instâncias
        public override bool Equals(object obj)
        {
            Cliente other = obj as Cliente; // o "cast" lançaria uma exceção, caso a conversão não funcione. Já o "as" retorna null, caso a conversão não funcione
           
            return this.Id == other.Id &&
                this.CPF == other.CPF;
        }

        // AULA 08.02 - EQUALIDADE DE OBJETOS 2
        // sobrescrever operador == e !=
        public static bool operator==(Cliente c1, Cliente c2)
        {
            return c1.Id == c2.Id &&
                c1.CPF == c2.CPF;
        }
        public static bool operator !=(Cliente c1, Cliente c2)
        {
            return c1.Id != c2.Id ||
                c1.CPF != c2.CPF;
        }

        public override int GetHashCode()
        {
            // multiplique por valores diferentes, cada propriedade, qure queremos validar.
            return this.Id.GetHashCode() * 2 + this.CPF.GetHashCode() * 3;
        }

        // AULA 08.03 - SERIALIZAÇÃO BINÁRIA
        // customizando a serialização
        public Cliente()
        { }
        // serialização
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", this.Id);
            info.AddValue("Nome", this.Nome);
            info.AddValue("CPF", this.CPF.Replace(".", "").Replace("-", ""));            
        }
        // deserialização
        protected Cliente(SerializationInfo info, StreamingContext context)
        {
            this.Id = info.GetInt32("Id");
            this.Nome = info.GetString("Nome");
            this.CPF = info.GetString("CPF").Insert(3,".").Insert(7,".").Insert(11,"-");            
        }

       
    }


    // AULA 08.04 - CLASSE GENÉRICA
    // Clonando de maneira genérica, para usarmos com qualquer classe
    public static class ObjectCloner<T> where T : class, new() // usando aqui constraint no where T : class. Quando usamos o new(), obrigamos a ter um construtor padrão, necessário no caso do CloneWithReflection
    {
        public static T CloneWithSerialization(T instance)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, instance);
            ms.Position = 0;
            return formatter.Deserialize(ms) as T;
        }
        public static T CloneWithReflection(T instance)
        {
            T t = new T();
            foreach (PropertyInfo propriedade in typeof(T).GetProperties())
            {
                // c2.Id = c1.Id é o que se faz abaixo:
                propriedade.SetValue(t, propriedade.GetValue(instance));
            }
            return t;
        }
    }

    // AULA 08.05 - SERIALIZAÇÃO XML

}
