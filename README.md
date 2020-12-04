# MongoDB

## Projeto para apresentar a usabilidade do MongoDB:

- Todas as execuções de um CRUD
- Padrão genérico do repositório Mongo implementado no .NET Core.

## Como executar o projeto

- Faça checkout desse repositório.
- Tenha o docker instalado na sua máquina.
- Rode este comando no seu terminal do docker:

   ```xml
   docker run --name mongo-db -d mongo:latest
   ```

- Caso você tenha um servidor do mongo ou database diferente, deve alterar os valores no seu appsettings.json:

    Exemplo:
    ```xml
    "NoSQLConnection": "mongodb://localhost:17017/?safe=true",
    "NoSQLDataBaseName": "mongodb-workshop",
    ```

### Referência: https://medium.com/@marekzyla95/mongo-repository-pattern-700986454a0e


