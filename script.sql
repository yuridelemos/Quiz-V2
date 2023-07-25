IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Category] (
    [Id] int NOT NULL IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Question] (
    [Id] int NOT NULL IDENTITY,
    [Body] NVARCHAR(2000) NOT NULL,
    [CategoryId] int NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Question_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Answer] (
    [Id] int NOT NULL IDENTITY,
    [AnswerOrder] int NOT NULL DEFAULT 0,
    [Body] NVARCHAR(2000) NOT NULL,
    [IsCorrect] bit NOT NULL DEFAULT CAST(0 AS bit),
    [QuestionId] int NULL,
    CONSTRAINT [PK_Answer] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Answers_Question] FOREIGN KEY ([QuestionId]) REFERENCES [Question] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Answer_QuestionId] ON [Answer] ([QuestionId]);
GO

CREATE UNIQUE INDEX [IX_Answers_Body] ON [Answer] ([Body]);
GO

CREATE UNIQUE INDEX [IX_Category_Name] ON [Category] ([Name]);
GO

CREATE UNIQUE INDEX [IX_Question_Body] ON [Question] ([Body]);
GO

CREATE INDEX [IX_Question_CategoryId] ON [Question] ([CategoryId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230720003257_InitialCreation', N'7.0.9');
GO

COMMIT;
GO

