CREATE TABLE [dbo].[JobType] (
    [Identifier] BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_JobType] PRIMARY KEY CLUSTERED ([Identifier] ASC)
);

