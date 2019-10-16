IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF SCHEMA_ID(N'Argon') IS NULL EXEC(N'CREATE SCHEMA [Argon];');

GO

CREATE TABLE [Argon].[Actions] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Actions] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Argon].[JobTypes] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_JobTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Argon].[Statuses] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Statuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Argon].[JobDetails] (
    [Id] int NOT NULL IDENTITY,
    [Identifier] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [EffectiveStartDate] datetime2 NOT NULL,
    [Description] nvarchar(max) NULL,
    [Type] int NOT NULL,
    CONSTRAINT [PK_JobDetails] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_JobDetails_JobTypes_Type] FOREIGN KEY ([Type]) REFERENCES [Argon].[JobTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Argon].[ActionStates] (
    [Id] int NOT NULL IDENTITY,
    [ActionId] int NOT NULL,
    [JobId] int NOT NULL,
    [StatusId] int NOT NULL,
    [ActionDateTime] datetime2 NOT NULL,
    [UserName] nvarchar(max) NULL,
    [EIN] int NOT NULL,
    [Notes] nvarchar(max) NULL,
    CONSTRAINT [PK_ActionStates] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ActionStates_Actions_ActionId] FOREIGN KEY ([ActionId]) REFERENCES [Argon].[Actions] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ActionStates_JobDetails_JobId] FOREIGN KEY ([JobId]) REFERENCES [Argon].[JobDetails] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ActionStates_Statuses_StatusId] FOREIGN KEY ([StatusId]) REFERENCES [Argon].[Statuses] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_ActionStates_ActionId] ON [Argon].[ActionStates] ([ActionId]);

GO

CREATE INDEX [IX_ActionStates_JobId] ON [Argon].[ActionStates] ([JobId]);

GO

CREATE INDEX [IX_ActionStates_StatusId] ON [Argon].[ActionStates] ([StatusId]);

GO

CREATE INDEX [IX_JobDetails_Type] ON [Argon].[JobDetails] ([Type]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190716094500_DataAccess.EntityFramework.JobContext', N'2.2.6-servicing-10079');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Argon].[Statuses]') AND [c].[name] = N'Name');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Argon].[Statuses] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Argon].[Statuses] ALTER COLUMN [Name] nvarchar(100) NOT NULL;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Argon].[JobTypes]') AND [c].[name] = N'Name');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Argon].[JobTypes] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Argon].[JobTypes] ALTER COLUMN [Name] nvarchar(100) NOT NULL;

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Argon].[Actions]') AND [c].[name] = N'Name');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Argon].[Actions] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Argon].[Actions] ALTER COLUMN [Name] nvarchar(100) NOT NULL;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Argon].[Actions]'))
    SET IDENTITY_INSERT [Argon].[Actions] ON;
INSERT INTO [Argon].[Actions] ([Id], [Name])
VALUES (1, N'Approve'),
(2, N'Create'),
(3, N'Delete'),
(4, N'Import'),
(5, N'Issue'),
(6, N'Reject'),
(7, N'RequestApproval'),
(8, N'Update'),
(9, N'Rollback'),
(10, N'Upload'),
(11, N'Download'),
(12, N'BackendStateUpdate');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Argon].[Actions]'))
    SET IDENTITY_INSERT [Argon].[Actions] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Argon].[JobTypes]'))
    SET IDENTITY_INSERT [Argon].[JobTypes] ON;
INSERT INTO [Argon].[JobTypes] ([Id], [Name])
VALUES (2, N'OFFER');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Argon].[JobTypes]'))
    SET IDENTITY_INSERT [Argon].[JobTypes] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Argon].[Statuses]'))
    SET IDENTITY_INSERT [Argon].[Statuses] ON;
INSERT INTO [Argon].[Statuses] ([Id], [Name])
VALUES (1, N'NEW'),
(2, N'DRAFT'),
(3, N'APPROVED'),
(4, N'SUBMITTED'),
(5, N'REJECTED'),
(6, N'ISSUED'),
(7, N'IMPORTED'),
(8, N'PREPARING_TO_ISSUE'),
(9, N'ARGON_PROCESSING_FAILED'),
(10, N'DELETED'),
(11, N'EXPIRED'),
(12, N'SUPERSEDED');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Argon].[Statuses]'))
    SET IDENTITY_INSERT [Argon].[Statuses] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190719111556_DataAccess.EntityFramework.JobContextSeed', N'2.2.6-servicing-10079');

GO

DELETE FROM [Argon].[JobTypes]
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Argon].[JobTypes]'))
    SET IDENTITY_INSERT [Argon].[JobTypes] ON;
INSERT INTO [Argon].[JobTypes] ([Id], [Name])
VALUES (1, N'OFFER');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Argon].[JobTypes]'))
    SET IDENTITY_INSERT [Argon].[JobTypes] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190719142916_DataAccess.EntityFramework.SeedData', N'2.2.6-servicing-10079');

GO

CREATE TABLE [Argon].[JobIdentiferSequences] (
    [Id] int NOT NULL IDENTITY,
    CONSTRAINT [PK_JobIdentiferSequences] PRIMARY KEY ([Id])
);

GO

UPDATE [Argon].[JobTypes] SET [Name] = N'DISCOUNT_OFFER'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190721072418_DataAccess.EntityFramework.SeedUpdatedData', N'2.2.6-servicing-10079');

GO

