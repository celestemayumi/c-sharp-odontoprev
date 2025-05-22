# **API OdontoPrev**

Esta é uma API desenvolvida com ASP.NET Core Web API para gerenciamento de dentistas, pacientes, unidades, consultas e outros recursos relacionados a um sistema odontológico.

## **Arquitetura da API**

A API foi desenvolvida utilizando uma **arquitetura monolítica**. Optamos por essa abordagem devido à simplicidade de implementação e manutenção. O uso de microservices seria mais adequado em uma situação onde a aplicação exigisse escalabilidade independente para diferentes componentes, o que não é o caso no momento.

### **Design Patterns Utilizados**

- **DTO (Data Transfer Object)**: Usado para transferir dados entre as camadas de apresentação e de dados, permitindo uma maior flexibilidade e segurança ao manipular informações.
  
- **Repository Pattern**: Utilizado para abstrair o acesso ao banco de dados, permitindo que a lógica de acesso seja centralizada em repositórios específicos. Isso facilita a manutenção e a testabilidade da aplicação.

## **Tecnologias Utilizadas**

- **ASP.NET Core Web API**: Framework para desenvolvimento da API.
- **Entity Framework Core**: ORM utilizado para a interação com o banco de dados.
- **ML.NET**: Framework de machine learning integrado na api para predicoes.
- **Oracle Database**: Banco de dados relacional utilizado para armazenar as informações dos recursos.
- **Swagger/OpenAPI**: Usado para gerar a documentação da API e facilitar o consumo da mesma por outros desenvolvedores.

## **Endpoints da API**

### **1. Dentista**

- **GET /api/dentista**: Retorna todos os dentistas.
- **GET /api/dentista/{id}**: Retorna um dentista específico pelo ID.
- **POST /api/dentista**: Cria um novo dentista.
- **PUT /api/dentista/{id}**: Atualiza um dentista específico.
- **DELETE /api/dentista/{id}**: Deleta um dentista específico.

### **2. Paciente**

- **GET /api/paciente**: Retorna todos os pacientes.
- **GET /api/paciente/{id}**: Retorna um paciente específico pelo ID.
- **POST /api/paciente**: Cria um novo paciente.
- **PUT /api/paciente/{id}**: Atualiza um paciente específico.
- **DELETE /api/paciente/{id}**: Deleta um paciente específico.

### **3. Consulta**

- **GET /api/consulta**: Retorna todas as consultas.
- **GET /api/consulta/{id}**: Retorna uma consulta específica pelo ID.
(Colocamos apenas o GET a fim de evitar fraudes.)

### **4. Unidade**

- **GET /api/unidade**: Retorna todas as unidades.
- **GET /api/unidade/{id}**: Retorna uma unidade específica pelo ID.
- **POST /api/unidade**: Cria uma nova unidade.
- **PUT /api/unidade/{id}**: Atualiza uma unidade específica.
- **DELETE /api/unidade/{id}**: Deleta uma unidade específica.

### **5. Endereço**

- **GET /api/endereco**: Retorna todos os endereços.
- **GET /api/endereco/{id}**: Retorna um endereço específico pelo ID.
- **POST /api/endereco**: Cria um novo endereço.
- **PUT /api/endereco/{id}**: Atualiza um endereço específico.
- **DELETE /api/endereco/{id}**: Deleta um endereço específico.

### **6. Login**

- **GET /api/login**: Retorna todos os logins.
- **GET /api/login/{id}**: Retorna um login específico pelo ID.

### **7. Bairro**

- **GET /api/bairro**: Retorna todos os bairros.
- **GET /api/bairro/{id}**: Retorna um bairro específico pelo ID.
- **POST /api/bairro**: Cria um novo bairro.
- **PUT /api/bairro/{id}**: Atualiza um bairro específico.
- **DELETE /api/bairro/{id}**: Deleta um bairro específico.

### **8. Cidade**

- **GET /api/cidade**: Retorna todas as cidades.
- **GET /api/cidade/{id}**: Retorna uma cidade específica pelo ID.
- **POST /api/cidade**: Cria uma nova cidade.
- **PUT /api/cidade/{id}**: Atualiza uma cidade específica.
- **DELETE /api/cidade/{id}**: Deleta uma cidade específica.

### **9. Estado**

- **GET /api/estado**: Retorna todos os estados.
- **GET /api/estado/{id}**: Retorna um estado específico pelo ID.
- **POST /api/estado**: Cria um novo estado.
- **PUT /api/estado/{id}**: Atualiza um estado específico.
- **DELETE /api/estado/{id}**: Deleta um estado específico.

### **10. ConsultasML**

- **POST /api/consultasML/treinar**: Treina o modelo (deve ser utilizado antes de fazer a predicao).
- **POST /api/consultasML/prever-falta**: Retorna a predicao para dizer se um paciente ira faltar ou nao.


## **Documentação da API com Swagger/OpenAPI**

A documentação da API foi gerada automaticamente utilizando o **Swagger**. Para acessá-la, basta rodar a aplicação e acessar o seguinte link:

https://localhost:7157/swagger

## Como executar o projeto:

### 1. Clone o repositório ou faça o download do projeto:
```bash
git clone https://github.com/celestemayumi/c-sharp-odontoprev.git
```
#### Caso tenha clonado o repositório:
### 2. Navegue até o diretório do projeto
```bash
cd c-sharp-odontoprev
```
### 3. Restaure as dependências:
```bash
dotnet restore
```
### 4. Execute a aplicação:
```bash
dotnet run
```

A aplicação irá abrir o navegador um localhost, caso não abra acesse:

https://localhost:7157/swagger

### **Integrantes**

- **Celeste Tanaka** - [GitHub](https://github.com/celestemayumi)
- **Lívia Mariana Lopes** - [GitHub](https://github.com/LiviaMarianaLopes)
- **Luana Vieira** - [GitHub](https://github.com/luanavss)
