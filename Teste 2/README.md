
.NET Core 3.1 + EF In-Memory + Swagger

** Ferramentas Necessárias **
- Visual Studio 2019
- Visual Studio Code

** Certificar-se que a versão do .NET Core seja 3.0 ou superior
- Atualizar a versão do SDK .NET Core para a versão mais recente(3.1.2 atualmente) 
	https://dotnet.microsoft.com/download



** Executando a Aplicação **

-Aplicação será redirecionada para uma tela de login.
Usuário: admin
Senha: admin

-Será possível conferir a documentação do projeto através do botão "Documentação".



** Considerações **

-Aplicação desenvolvida em .NET CORE por tratar-se de um framework moderno, open-source, performático, que disponibiliza diversos micro-serviços na nuvem em multiplataformas e utilização de containers de forma simplificada.

-Para a base de dados, o sistema foi desenvolvido em EntityFramework In-Memory. Trata-se de um provedor de banco de dados extremamente util para a realização de testes, aproximando seu funcionamento ao de uma base de dados real.

-Foi utilizada para modelagem da aplicação um modelo baseado na arquitetura DDD, por se tratar de um modelo que representa a regra de negócio da aplicação bem como facilitar a implementação de novas regras. 

-Testes com XUnit buscando mitigar falhas e erros durante o desenvolvimento.


** Pontos de evolução **

-Implementar resiliência para tratamento de falhas nas requisições

-Utilizar um framework para interfaces, afim de automatizar tarefas e facilitar o desenvolvimento das mesmas.
