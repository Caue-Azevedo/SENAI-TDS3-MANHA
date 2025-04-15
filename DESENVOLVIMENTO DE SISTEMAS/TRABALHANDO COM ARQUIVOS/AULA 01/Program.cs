using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.Clear();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|            MENU DE OPÇÕES            |");
            Console.WriteLine("| 1 - Criar ou sobrescrever arquivo    |");
            Console.WriteLine("| 2 - Ler arquivo                      |");
            Console.WriteLine("| 3 - Adicionar texto ao arquivo       |");
            Console.WriteLine("| 4 - Ver informações do arquivo       |");
            Console.WriteLine("| 5 - Salvar como .csv                 |");
            Console.WriteLine("| 6 - Sair                             |");
            Console.WriteLine("+--------------------------------------+");
            Console.Write("| Escolha uma opção: ");
            
            string opcao = Console.ReadLine();
            string caminhoArquivo = ObterNomeArquivo(opcao);

            switch (opcao)
            {
                case "1":
                    CriarOuSobrescreverArquivo(caminhoArquivo);
                    break;
                case "2":
                    LerArquivo(caminhoArquivo);
                    break;
                case "3":
                    AdicionarAoArquivo(caminhoArquivo);
                    break;
                case "4":
                    InformacoesArquivo(caminhoArquivo);
                    break;
                case "5":
                    SalvarComoCSV(caminhoArquivo);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("+------------------------+");
                    Console.WriteLine("|     Opção inválida!    |");
                    Console.WriteLine("+------------------------+");
                    break;
            }
            Thread.Sleep(2000);
        }
    }

    static string ObterNomeArquivo(string opcao)
    {
        Console.Clear();
        if (opcao == "1")
        {
            Console.WriteLine("+--------------------------------------------+");    
            Console.WriteLine("|   Opção escolhida: Criar ou Sobreescrever  |");
            Console.WriteLine("+--------------------------------------------+");
        }
        if (opcao == "2")
        {
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|        Opção escolhida: Ler Arquivo        |");
            Console.WriteLine("+--------------------------------------------+");
        }
        if (opcao == "3")
        {
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|      Opção escolhida: Adicionar Texto      |");
            Console.WriteLine("+--------------------------------------------+");
        }
        if (opcao == "4")
        {
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|      Opção escolhida: Ver Informações      |");
            Console.WriteLine("+--------------------------------------------+");
        }
        if (opcao == "5")
        {
            Console.WriteLine("+--------------------------------------------+");
            Console.WriteLine("|      Opção escolhida: Salvar como .csv     |");
            Console.WriteLine("+--------------------------------------------+");
        }

        Console.Write("| Digite o nome do arquivo (sem extensão):   |\n| ");
        string nomeArquivo = Console.ReadLine();
        return nomeArquivo + ".txt";
    }

    static void CriarOuSobrescreverArquivo(string caminho)
    {
        Console.Clear();
        Console.WriteLine("+--------------------------------------------+");
        Console.WriteLine("|   Opção escolhida: Criar ou Sobreescrever  |");
        Console.WriteLine("+--------------------------------------------+");

        if (File.Exists(caminho))
        {
            Console.Write("| O arquivo já existe. Deseja sobrescrevê-lo ou alterar o nome?\n| (s = sobrescrever / a = alterar nome): \n| ");
            string resposta = Console.ReadLine().ToLower();

            if (resposta == "s")
            {
                EscreverArquivo(caminho);
            }
            else if (resposta == "a")
            {
                caminho = ObterNomeArquivo("1");
                EscreverArquivo(caminho);
            }
            else
            {
                Console.WriteLine("+--------------------------------+");
                Console.WriteLine("|     Opção inválida. Nenhuma    |");
                Console.WriteLine("|         ação realizada.        |");
                Console.WriteLine("+--------------------------------+");
            }
        }
        else
        {
            EscreverArquivo(caminho);
        }
    }

    static void EscreverArquivo(string caminho)
    {
        Console.Clear();
        Console.WriteLine("+------------------------------------------+");
        Console.WriteLine("|     Digite o texto abaixo (fim p/ sair)  |");
        Console.WriteLine("+------------------------------------------+");

        using (StreamWriter writer = new StreamWriter(caminho))
        {
            string linha;
            while ((linha = Console.ReadLine()) != "fim")
            {
                writer.WriteLine(linha);
            }
        }

        Console.WriteLine("\n+--------------------------------+");
        Console.WriteLine("|   Texto gravado com sucesso!   |");
        Console.WriteLine("+--------------------------------+");
        Thread.Sleep(1000);
    }

    static void LerArquivo(string caminho)
    {
        Console.Clear();

        if (!File.Exists(caminho))
        {
            Console.WriteLine("+----------------------------+");
            Console.WriteLine("|     Arquivo não existe!    |");
            Console.WriteLine("+----------------------------+");
            return;
        }


        Console.WriteLine("\n+-------------------------------+");
        Console.WriteLine("|     Conteúdo do Arquivo:      |");
        Console.WriteLine("+-------------------------------+");

        using (StreamReader reader = new StreamReader(caminho))
        {
            string linha;
            while ((linha = reader.ReadLine()) != null)
            {
                Console.WriteLine($"| {linha}");
            }
        }

        Console.WriteLine("+-------------------------------+");
        Console.WriteLine("\n\n+------------------------------+");
        Console.WriteLine("| Aperter enter para continuar |");
        Console.WriteLine("+------------------------------+");
        Console.ReadKey();
    }

    static void AdicionarAoArquivo(string caminho)
    {
        Console.Clear();
        Console.WriteLine("+----------------------------------------------+");
        Console.WriteLine("|   Adicionar texto (digite 'fim' para sair)   |");
        Console.WriteLine("+----------------------------------------------+");

        using (StreamWriter writer = new StreamWriter(caminho, append: true))
        {
            string linha;
            while ((linha = Console.ReadLine()) != "fim")
            {
                writer.WriteLine(linha);
            }
        }

        Console.WriteLine("\n+------------------------------------+");
        Console.WriteLine("|   Texto adicionado com sucesso!    |");
        Console.WriteLine("+------------------------------------+");
    }

    static void InformacoesArquivo(string caminho)
    {
        Console.Clear();

        if (!File.Exists(caminho))
        {
            Console.WriteLine("+----------------------------+");
            Console.WriteLine("|     Arquivo não existe!    |");
            Console.WriteLine("+----------------------------+");
            return;
        }

        FileInfo info = new FileInfo(caminho);

        Console.WriteLine("+------------------------------+");
        Console.WriteLine("|     Informações do Arquivo   |");
        Console.WriteLine("+------------------------------+");
        Console.WriteLine($"| Nome: {info.Name}");
        Console.WriteLine($"| Caminho: {info.FullName}");
        Console.WriteLine($"| Tamanho: {info.Length} bytes");
        Console.WriteLine($"| Criado em: {info.CreationTime:G}");
        Console.WriteLine($"| Último acesso: {info.LastAccessTime:G}");
        Console.WriteLine($"| Última modificação: {info.LastWriteTime:G}");
        Console.WriteLine("+------------------------------+");
        Console.WriteLine("\n\n+------------------------------+");
        Console.WriteLine("| Aperter enter para continuar |");
        Console.WriteLine("+------------------------------+");
        Console.ReadKey();
    }

    static void SalvarComoCSV(string caminho)
    {
        Console.Clear();

        if (!File.Exists(caminho))
        {
            Console.WriteLine("+----------------------------+");
            Console.WriteLine("|     Arquivo não existe!    |");
            Console.WriteLine("+----------------------------+");
            return;
        }

        string caminhoCSV = Path.ChangeExtension(caminho, ".csv");
        File.Copy(caminho, caminhoCSV, overwrite: true);

        Console.WriteLine("+---------------------------------------+");
        Console.WriteLine($"|   Arquivo salvo como {Path.GetFileName(caminhoCSV),-16} |");
        Console.WriteLine("+---------------------------------------+");
    }
}
