﻿﻿﻿# Conta Corrente 💰 

Este app simula operações bancárias básicas, como depósitos, saques, transferências e geração de extratos para contas correntes.

## Sumário

- [Visão geral](#visão-geral)
  - [Mídia](#mídia-)
  - [Funcionalidades](#funcionalidades)
  - [Desenvolvido com](#desenvolvido-com-)
  - [Estrutura do projeto](#estrutura-do-projeto-)
- [Como rodar o código?](#como-rodar-o-código-)
  - [Passo a passo - Clone ou baixe o projeto](#passo-a-passo---clone-ou-baixe-o-projeto--)
  - [Uso](#uso-)
- [Autor](#autor-)

## Visão geral

### Mídia 📷
##### GIF da aplicação - Clique no GIF para dar Play/Pause
![Image](https://i.imgur.com/aqsjtt3.gif)

### Funcionalidades✅ 
 - Cria múltiplas contas bancárias com controle separado.
 - Realiza depósitos e saques com verificação de saldo e limite.
 - Permite transferência entre contas, impedindo transferências para a mesma conta.
 - Gera e exibe extrato de movimentações por conta.
 - Consulta de saldo atual e número da conta.


### Desenvolvido com 🚀

[![My Skills](https://skillicons.dev/icons?i=cs,dotnet,git&theme=light)](https://skillicons.dev)


### Estrutura do projeto 📁
```
ContaCorrente.ConsoleApp/
├── Program.cs         
├── CriarConta.cs      
├── Operacoes.cs       
└── README.md
```


### Como rodar o código? 🤖

#### ❗❗Obs: Há a necessidade de ter o .NET SDK instalado em sua máquina previamente!

#### Passo a passo - Clone ou baixe o projeto  👞👞

1. Abra o terminal do seu editor de código;
2. Navegue até a pasta onde deseja instalar o projeto;
3. Clone o projeto 
ex:``` git clone git@github.com:alexandreSouza31/Conta-Corrente.git```
 ou se preferir, baixe clicando no botão verde chamado "Code" no repositório desse projeto, e depois "Download zip.


#### Uso 💻
1. Inicie o App:
Certifique-se de estar na pasta do projeto, e navegue pelo terminal até o caminho do arquivo Program.cs
```
cd ContaCorrente.ConsoleApp
```
2. Compile e execute o programa: ```dotnet run```

    ou, com o arquivo Program.cs aberto clique no botão verde(Current Document(Program.cs)) para iniciar

3. Exemplos para executar na Main:
```
// Criação de contas
CriarConta conta1 = new CriarConta();
CriarConta conta2 = new CriarConta();

// Depositar valores
Operacoes.Depositar(conta1, 500);
Operacoes.Depositar(conta2, 300);

// Realizar saque
Operacoes.Sacar(conta1, 100);

// Transferir entre contas
Operacoes.Transferir(conta1, conta2, 150);

// Consultar saldo
Operacoes.ConsultarSaldo(conta1);
Operacoes.ConsultarSaldo(conta2);

// Emitir extrato
Operacoes.EmitirExtrato(conta1);
Operacoes.EmitirExtrato(conta2);

```


## Autor 😏 

<main>
<div style="display: flex; align-items: center; gap: 20px;padding-bottom: 2em">
  <img src="https://github.com/user-attachments/assets/74c712a4-9e48-4ae3-839c-46089b850a27" width="80" />
  <h3 style="margin: 0;"><i>Alexandre Mariano</i></h4>
</div>

  <p>
    <a href="https://www.linkedin.com/in/alexandresouza31/">
      <img src="https://skillicons.dev/icons?i=linkedin&theme=dark" width="50"/>
      LinkedIn
    </a> &nbsp;  |  &nbsp;
    <a href="https://github.com/alexandreSouza31">
      <img src="https://skillicons.dev/icons?i=github&theme=dark" width="50"/>
      GitHub
    </a>
  </p>
</main>


<a href="#Conta-Corrente" 
   style="position: fixed; right: 10px; bottom: 20px; background-color:rgba(99, 102, 99, 0.32); color: white; padding: 1px 5px 5px; text-decoration: none; border-radius: 5px; font-size: 16px;">
   🔝Voltar ao topo🔝
</a># ContaCorrente