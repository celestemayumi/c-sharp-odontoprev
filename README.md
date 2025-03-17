# **API OdontoPrev**

Esta � uma API desenvolvida com ASP.NET Core Web API para gerenciamento de dentistas, pacientes, unidades, consultas e outros recursos relacionados a um sistema odontol�gico.

## **Arquitetura da API**

A API foi desenvolvida utilizando uma **arquitetura monol�tica**. Optamos por essa abordagem devido � simplicidade de implementa��o e manuten��. O uso de microservices seria mais adequado em uma situa��o onde a aplica��o exigisse escalabilidade independente para diferentes componentes, o que n�o � o caso no momento.

### **Design Patterns Utilizados**

- **DTO (Data Transfer Object)**: Usado para transferir dados entre as camadas de apresenta��o e de dados, permitindo uma maior flexibilidade e seguran�a ao manipular informa��es.
  
- **Repository Pattern**: Utilizado para abstrair o acesso ao banco de dados, permitindo que a l�gica de acesso seja centralizada em reposit�rios espec�ficos. Isso facilita a manuten��o e a testabilidade da aplica��o.

## **Tecnologias Utilizadas**

- **ASP.NET Core Web API**: Framework para desenvolvimento da API.
- **Entity Framework Core**: ORM utilizado para a intera��o com o banco de dados.
- **Oracle Database**: Banco de dados relacional utilizado para armazenar as informa��es dos recursos.
- **Swagger/OpenAPI**: Usado para gerar a documenta��o da API e facilitar o consumo da mesma por outros desenvolvedores.

## **Endpoints da API**

### **1. Dentista**

- **GET /api/dentista**: Retorna todos os dentistas.
- **GET /api/dentista/{id}**: Retorna um dentista espec�fico pelo ID.
- **POST /api/dentista**: Cria um novo dentista.
- **PUT /api/dentista/{id}**: Atualiza um dentista espec�fico.
- **DELETE /api/dentista/{id}**: Deleta um dentista espec�fico.

### **2. Paciente**

- **GET /api/paciente**: Retorna todos os pacientes.
- **GET /api/paciente/{id}**: Retorna um paciente espec�fico pelo ID.
- **POST /api/paciente**: Cria um novo paciente.
- **PUT /api/paciente/{id}**: Atualiza um paciente espec�fico.
- **DELETE /api/paciente/{id}**: Deleta um paciente espec�fico.

### **3. Consulta**

- **GET /api/consulta**: Retorna todas as consultas.
- **GET /api/consulta/{id}**: Retorna uma consulta espec�fica pelo ID.
(Colocamos apenas o GET a fim de evitar fraudes.)

### **4. Unidade**

- **GET /api/unidade**: Retorna todas as unidades.
- **GET /api/unidade/{id}**: Retorna uma unidade espec�fica pelo ID.
- **POST /api/unidade**: Cria uma nova unidade.
- **PUT /api/unidade/{id}**: Atualiza uma unidade espec�fica.
- **DELETE /api/unidade/{id}**: Deleta uma unidade espec�fica.

### **5. Endere�o**

- **GET /api/endereco**: Retorna todos os endere�os.
- **GET /api/endereco/{id}**: Retorna um endere�o espec�fico pelo ID.
- **POST /api/endereco**: Cria um novo endere�o.
- **PUT /api/endereco/{id}**: Atualiza um endere�o espec�fico.
- **DELETE /api/endereco/{id}**: Deleta um endere�o espec�fico.

### **6. Login**

- **GET /api/login**: Retorna todos os logins.
- **GET /api/login/{id}**: Retorna um login espec�fico pelo ID.

### **7. Bairro**

- **GET /api/bairro**: Retorna todos os bairros.
- **GET /api/bairro/{id}**: Retorna um bairro espec�fico pelo ID.
- **POST /api/bairro**: Cria um novo bairro.
- **PUT /api/bairro/{id}**: Atualiza um bairro espec�fico.
- **DELETE /api/bairro/{id}**: Deleta um bairro espec�fico.

### **8. Cidade**

- **GET /api/cidade**: Retorna todas as cidades.
- **GET /api/cidade/{id}**: Retorna uma cidade espec�fica pelo ID.
- **POST /api/cidade**: Cria uma nova cidade.
- **PUT /api/cidade/{id}**: Atualiza uma cidade espec�fica.
- **DELETE /api/cidade/{id}**: Deleta uma cidade espec�fica.

### **9. Estado**

- **GET /api/estado**: Retorna todos os estados.
- **GET /api/estado/{id}**: Retorna um estado espec�fico pelo ID.
- **POST /api/estado**: Cria um novo estado.
- **PUT /api/estado/{id}**: Atualiza um estado espec�fico.
- **DELETE /api/estado/{id}**: Deleta um estado espec�fico.

## **Documenta��o da API com Swagger/OpenAPI**

A documenta��o da API foi gerada automaticamente utilizando o **Swagger**. Para acess�-la, basta rodar a aplica��o e acessar o seguinte link:

https://localhost:7157/swagger

## Como executar o projeto:

### 1. Clone o reposit�rio ou fa�a o download do projeto:
```bash
git clone https://github.com/celestemayumi/c-sharp-odontoprev.git
```
#### Caso tenha clonado o reposit�rio:
### 2. Navegue at� o diret�rio do projeto
```bash
cd c-sharp-odontoprev
```
### 3. Restaure as depend�ncias:
```bash
dotnet restore
```
### 4. Execute a aplica��o:
```bash
dotnet run
```

A aplica��o ir� abrir o navegador um localhost, caso n�o abra acesse:

https://localhost:7157/swagger

### **Integrantes**

- **Celeste Tanaka** - [GitHub](https://github.com/celestemayumi)
- **L�via Mariana Lopes** - [GitHub](https://github.com/LiviaMarianaLopes)
- **Luana Vieira** - [GitHub](https://github.com/luanavss)