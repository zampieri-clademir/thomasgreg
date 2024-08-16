using FluentMigrator;

using ThomasGregChallenge.Base.Constantes;

namespace ThomasGregChallenge.Migracoes.V1000
{
    [Migration(2024050000001, TransactionBehavior.Default)]
    public class Migracao2024050000001 : Migration
    {
        public Migracao2024050000001()
        {
        }

        public override void Down()
        {

        }

        public override void Up()
        {
            if (!Schema.Schema(Constantes.NomeSchema).Table("Logotipo").Exists())
            {
                string script = $@"CREATE TABLE [{Constantes.NomeSchema}].[Logotipo](
								[Id] [uniqueidentifier]  PRIMARY KEY DEFAULT NEWID(),
								[Imagem] [varbinary](max) NOT NULL)";

                Execute.Sql(script);
            }

            if (!Schema.Schema(Constantes.NomeSchema).Table("Cliente").Exists())
            {
                string script = $@"CREATE TABLE [{Constantes.NomeSchema}].[Cliente](
								[Id] [BigInt]  PRIMARY KEY IDENTITY(1,1),
								[Nome] [varchar](300) NOT NULL,
								[Email] [varchar](300) NULL,
								[LogotipoId] [uniqueidentifier] NULL,
                                CONSTRAINT FK_Cliente_Logotipo FOREIGN KEY ([LogotipoId]) REFERENCES [{Constantes.NomeSchema}].[Logotipo](Id))";

                Execute.Sql(script);
            }

            if (!Schema.Schema(Constantes.NomeSchema).Table("Logradouro").Exists())
            {
                string script = $@"CREATE TABLE [{Constantes.NomeSchema}].[Logradouro](
								    [Id] BigInt PRIMARY KEY IDENTITY(1,1),
                                    [ClienteId] BigInt NOT NULL, 
                                    [Descricao] NVARCHAR(200) NOT NULL,
                                    [CEP] CHAR(8) NOT NULL,
                                    [Bairro] NVARCHAR(100) NOT NULL,
                                    [Cidade] NVARCHAR(100) NOT NULL,
                                    [UF] CHAR(2) NOT NULL,
                                    [Pais] CHAR(2) NOT NULL,
                                    [Complemento] NVARCHAR(100) NULL,
                                    [DataCriacao] DATETIME DEFAULT GETDATE(),
                                    [DataAtualizacao] DATETIME DEFAULT GETDATE(),
                                    CONSTRAINT FK_Logradouro_Cliente FOREIGN KEY ([ClienteId]) REFERENCES [{Constantes.NomeSchema}].[Cliente](Id)
						        )";

                Execute.Sql(script);
            }
        }
    }
}
