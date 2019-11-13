CREATE TABLE [dbo].[Offer] (
    [Identifier]             BIGINT          IDENTITY (1, 1) NOT NULL,
    [Name]                   NVARCHAR (50)   NOT NULL,
    [Reference]              NVARCHAR (50)   NULL,
    [PublishDateTime]        DATETIME2 (7)   NOT NULL,
    [Duration]               INT             NULL,
    [StartContractDate]      DATE            NULL,
    [PostCount]              INT             NOT NULL,
    [JobDescription]         NVARCHAR (2000) NULL,
    [ProfilDescription]      NVARCHAR (2000) NULL,
    [Street]                 NVARCHAR (70)   NULL,
    [City]                   NVARCHAR (50)   NULL,
    [ZipCode]                NCHAR (10)      NULL,
    [IdentifierJob]          BIGINT          NOT NULL,
    [IdentifierContractType] BIGINT          NOT NULL,
    [IdentifierProducer]     BIGINT          NOT NULL,
    [IdentifierCustomer]     BIGINT          NULL,
    CONSTRAINT [PK_Offer] PRIMARY KEY CLUSTERED ([Identifier] ASC),
    CONSTRAINT [FK_Offer_ContractType] FOREIGN KEY ([IdentifierContractType]) REFERENCES [dbo].[ContractType] ([Identifier]),
    CONSTRAINT [FK_Offer_Customer] FOREIGN KEY ([IdentifierCustomer]) REFERENCES [dbo].[Customer] ([Identifier]),
    CONSTRAINT [FK_Offer_Job] FOREIGN KEY ([IdentifierJob]) REFERENCES [dbo].[Job] ([Identifier]),
    CONSTRAINT [FK_Offer_Producer] FOREIGN KEY ([IdentifierProducer]) REFERENCES [dbo].[Producer] ([Identifier])
);





