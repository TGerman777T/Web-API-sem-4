CREATE TABLE [dbo].[Companies] (
    [Id]              INT        NOT NULL,
    [Name]            NCHAR (20) NULL,
    [UsersNumber]     INT        NULL,
    [FoundationDate]  DATETIME   NULL,
    [Address]         NCHAR (20) NULL,
    [Capitalization]  INT        NULL,
    [EmployeesNumber] INT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

