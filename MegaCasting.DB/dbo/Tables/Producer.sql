CREATE TABLE [dbo].[Producer] (
    [Identifier] BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NULL,
    [UserName]   NVARCHAR (50) NULL,
    [Password]   NVARCHAR (50) NULL,
    [Salt]       NVARCHAR (50) NULL,
    CONSTRAINT [PK_Producer] PRIMARY KEY CLUSTERED ([Identifier] ASC)
);

