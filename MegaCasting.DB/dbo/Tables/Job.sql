CREATE TABLE [dbo].[Job] (
    [Identifier]        BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (50) NOT NULL,
    [IdentifierJobType] BIGINT        NOT NULL,
    CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED ([Identifier] ASC),
    CONSTRAINT [FK_Job_JobType] FOREIGN KEY ([IdentifierJobType]) REFERENCES [dbo].[JobType] ([Identifier])
);





