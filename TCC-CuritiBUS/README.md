# CuritiBUS – Sistema de Monitoramento do Transporte Público de Curitiba

Este projeto foi desenvolvido como Trabalho de Conclusão de Curso (TCC) do curso Técnico em Desenvolvimento de Sistemas – SENAI (Campus da Indústria – 2025).

## 🎯 Objetivo

Criar uma plataforma integrada que permita ao cidadão consultar informações de linhas de ônibus, horários, pontos e localização em tempo real na cidade de Curitiba, utilizando dados da API oficial da URBS.

## 🧩 Funcionalidades principais

- Consulta de linhas de ônibus disponíveis
- Visualização de pontos e horários por linha
- Rastreamento de ônibus em tempo real via API URBS
- Planejamento de viagens (em desenvolvimento)
- Cadastro e login de usuários
- Validação de CPF, email e senha
- Registro de erros em log
- Interface intuitiva em Windows Forms

## 🛠️ Tecnologias utilizadas

- Linguagem: C# (.NET Framework)
- Interface gráfica: Windows Forms
- Banco de dados: MySQL
- Integração: API REST URBS (Curitiba)
- Biblioteca JSON: Newtonsoft.Json
- Organização: Arquitetura em camadas

## 🗂️ Estrutura do projeto
/TCC-CuritiBUS/
├── /src/ # código-fonte principal (.cs, .sln, .Designer.cs)
├── /imgs/ # imagens de interface e telas do sistema
├── banco.sql # estrutura do banco de dados MySQL
├── log.txt # exemplo de log de execução
└── README.md # este documento

## 🚀 Como executar o sistema

1. Clone o repositório ou baixe o ZIP
2. Abra o projeto `.sln` no Visual Studio
3. Verifique a string de conexão no arquivo `Database.cs`
4. Configure o banco com base no `banco.sql` (opcional)
5. Compile e execute

> É necessário ter MySQL Server instalado e o Visual Studio com suporte a C# WinForms.

## 👨‍💻 Autor

**Cauê Carlos de Azevedo Guedes**  
Curso Técnico em Desenvolvimento de Sistemas – SENAI  
Curitiba – 2025
