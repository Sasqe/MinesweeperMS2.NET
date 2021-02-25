CREATE TABLE [dbo].[tblUsers] (
    [Id]       INT        IDENTITY (1, 1) NOT NULL,
	[FirstName] NTEXT NULL,
    [LastName] NTEXT NULL,
    [Gender] NTEXT NULL,
	[Age] INT NULL,
    [State] NTEXT NULL,
	[EmailAddress] VARCHAR(50) NULL,

    [USERNAME] NTEXT NULL,
    [PASSWORD] NCHAR (40) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);