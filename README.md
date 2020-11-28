# Api-Modelo-DDD :rocket:
API .NET CORE 3.1 utilizando conceitos de DDD (Domain-Driven Design) 

## :page_facing_up: Exemplo:

![Alt text](https://github.com/LuuanOliveira/ApiModeloDDD/blob/master/ApiModeloDDD.API/Image/swagger.png)

## 🛠️ Construção:

* [Swagger] - Documentação
* [.NET CORE] - O framework usado
* [C#] - Linguagem de programação
* [Dapper] - ORM
* [IOC] - Injeção de dependência
* [SQL Server] - Banco de dados

## :wrench: Util:

CREATE TABLE [Produtos](
	[id] [uniqueidentifier] NOT NULL,
	[dataEntrega] [datetime] NOT NULL,
	[descricao] [varchar](50) NOT NULL,
	[quantidade] [int] NOT NULL,
	[valorUnitario] [decimal](8,2) NOT NULL,
	[dataImportacao] [datetime] NOT NULL,
	[valorTotal] [decimal](8,2) NOT NULL,
	[ativo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Produtos] ADD CONSTRAINT [pd_Id]  DEFAULT (newid()) FOR [id]
GO

ALTER TABLE [dbo].[Produtos] ADD DEFAULT (getdate()) FOR [dataImportacao]
GO

ALTER TABLE [dbo].[Produtos] ADD DEFAULT ((1)) FOR [ativo]
GO

## ✒️ Autor:

* **Desenvolvedor** - [Luan Oliveira](https://github.com/LuuanOliveira)
* Não há nada que uma boa dose de criatividade não resolva 📢

---
console.log(alert('Developer 💙'));
