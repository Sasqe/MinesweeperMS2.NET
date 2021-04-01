CREATE TABLE [dbo].[Users] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [FirstName]    TEXT         NULL,
    [LastName]     TEXT         NULL,
    [USERNAME]     TEXT         NULL,
    [PASSWORD]     VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

