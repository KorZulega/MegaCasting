CREATE TABLE [dbo].[Customer] (
    [Identifier] BIGINT     IDENTITY (1, 1) NOT NULL,
    [Name]       NCHAR (50) NOT NULL,
    [UserName]   NCHAR (50) NOT NULL,
    [Password]   NCHAR (50) NOT NULL,
    [Salt]       NCHAR (50) NULL,
    [Email]      NCHAR (50) NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Identifier] ASC)
);





