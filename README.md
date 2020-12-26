
# 7194 - Criando APIs Data Driven com ASP.NET Core 3 e EF Core 3
### Curso Balta
https://app.balta.io/

### Descrição
Projeto do curso. API DotNetCore para um eCommerce, com usuários, categorias e produtos.

### Desenvolvido em
 - DotNetCore 5
 - Docker  
   - Microsoft SQL Server 17

### Como configurar e rodar

1. Instalar o DotNetCore 5 (SDK ou Runtime);

2. Instalar o Docker (para rodar o SQL Server, ou instalar o SQL Server localmente);
   1. Se for instalar via docker, execute um dos seguintes comandos (escolha sabiamente, jovem Padawan). Se instalar o SQL localmente, pule para o item 3:
      1. **Linux** -> sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=!SecretPass' --name sqlserver -p 1433:1433 -d
    mcr.microsoft.com/mssql/server:2017-latest
      2. **Windows** -> docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=!SecretPass' --name sqlserver -p 1433:1433 -d
    mcr.microsoft.com/mssql/server:2017-latest
      3. **Dockerfile** -> Se preferir, pode usar o Docker Compose, com o código abaixo:
         1. Crie uma pasta para armazenar os arquivos do Docker localmente, exemplo: ```mkdir SqlServer```
         2. Crie um arquivo chamado `Dockerfile.yml`, e insira as linhas abaixo, dentro dele:
            ```
            version: "3.2"
            services:
              sql-server-db:
                container_name: sqlserver
                image: microsoft/mssql-server-linux:2017-latest
                ports:
                  - "1433:1433"
                environment: 
                  SA_PASSWORD: "!SecretPass"
                  ACCEPT_EULA: "Y"
                volumes:
                  - ./db-data:/var/opt/mssql
            ```
   2. Se você precisar ligar o SQL Server no Docker futuramente, basta executar: `docker start sqlserver` no **Windows** ou `sudo docker start sqlserver` no Linux.

3. Acesse o SQL Server e crie um novo Banco de Dados, chamado `shop` (em minúsculo mesmo);
    3. *Só uma pequena observação, existem diferentes formas de acessar o Banco de Dados. Se precisar de ajuda com isso, crie uma **issue** que te ajudo.*

4. Próximo passo é a migração. O DotNetCore tem um ORM que já cria e persiste as tabelas no banco pra você. Primeiro você precisará instalar algumas coisas no seu computador (ou servidor) para que tudo funcione perfeitamente. Os comandos a seguir, deverão ser executados no terminal, na pasta raiz do projeto;
    ```
    # Para instalar a ferramenta do Entity Framework globalmente
    dotnet tool install --global dotnet-ef

    # Para instalar o pacote do Entity Framework Design no projeto  
    dotnet add package Microsoft.EntityFrameworkCore.Design
    ```
    
    E depois, vamos executar uns comandos para ver se está tudo bem com o código, pra saber se compila tudo direitinho:
    ```
    # Para dar uma limpa
    dotnet clean 
    
    # Para compilar o projeto
    dotnet build 
    ```

    Agora nós vamos fazer o Migration, criar as tabelas e relacionamentos automaticamente no banco com os códigos abaixo:
    ```
    dotnet ef migrations add InitialCreate

    dotnet ef database update
    ```
    

