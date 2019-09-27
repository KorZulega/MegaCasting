CREATE TABLE [dbo].[ContractType] (
    [Identifier] BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NULL,
    CONSTRAINT [PK_ContractType] PRIMARY KEY CLUSTERED ([Identifier] ASC)
);

