CREATE TABLE [dbo].[Producer] (
    [Identifier]     BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50) NULL,
    [UserName]       NVARCHAR (50) NULL,
    [Password]       NVARCHAR (50) NULL,
    [Salt]           NVARCHAR (50) NULL,
    [Fax]            NCHAR (15)    NULL,
    [Phone]          NCHAR (15)    NULL,
    [Email]          NCHAR (50)    NULL,
    [WebsiteAddress] NCHAR (250)   NULL,
    [Address]        NCHAR (100)   NOT NULL,
    [City]           NCHAR (100)   NOT NULL,
    [ZipCode]        NCHAR (10)    NOT NULL,
    CONSTRAINT [PK_Producer] PRIMARY KEY CLUSTERED ([Identifier] ASC)
);



