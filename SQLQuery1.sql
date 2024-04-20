CREATE TABLE [dbo].[AppUsers] (
    [Id]                   INT IDENTITY(1,1) PRIMARY KEY,
    [FirstName]            NVARCHAR (MAX)     NOT NULL,
    [LastName]             NVARCHAR (MAX)     NOT NULL,
    [UserName]             NVARCHAR (256)     NULL,
    [Email]                NVARCHAR (256)     NULL,
    [PasswordHash]         NVARCHAR (MAX)     NULL,
    [Gender]               NVARCHAR (MAX)     NULL,
    [DOB]                  nvarchar(255)      NOT NULL,              
    [EducationLevel]       nvarchar(255)      NOT NULL
);