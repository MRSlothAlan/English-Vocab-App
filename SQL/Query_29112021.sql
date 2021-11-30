USE [C:\USERS\TINGK\SOURCE\REPOS\ENGVOCABAPP\BIN\DEBUG\ENGVOCAB.MDF]

-- SET ANSI_NULLS ON
-- GO;

-- select * from dbo.EngVocab;

-- drop table dbo.EngVocabExamples;

-- drop table dbo.EngVocabMeanings;

/*
CREATE TABLE [dbo].[EngVocabMeanings]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[VocabId] uniqueidentifier NOT NULL,
	[WordForm] varchar(max),	-- adv, adj, etc.
	[Meaning] varchar(max) NOT NULL
);


CREATE TABLE [dbo].[EngVocabExamples]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	[VocabId] uniqueidentifier NOT NULL,
	[Content] varchar(max) NOT NULL
);
*/

/*
insert test data first, then derive the logic
to update entries
*/

-- use the first entry as the data
INSERT INTO [dbo].[EngVocabMeanings] ([Id], [VocabId], [WordForm], [Meaning])
VALUES (NEWID(), (SELECT TOP(1) Id FROM [dbo].[EngVocab]), 'phrase', 'This is a joke')
INSERT INTO [dbo].EngVocabExamples (Id, VocabId, Content)
VALUES (NEWID(), (SELECT TOP(1) Id FROM [dbo].EngVocab), 'fucking assignment')

-- now the update
-- update meaning flow.
/*
DELETE FROM dbo.EngVocabExamples WHERE
VocabId = (SELECT TOP(1) Id FROM [dbo].[EngVocab]);

-- generate Quiz
-- think about the format later.
SELECT * FROM dbo.EngVocab
JOIN (
	SELECT * FROM dbo.EngVocabMeanings
) as M
ON M.VocabId = Id;
*/


/****** Object: Table [dbo].[EngVocab] Script Date: 27/11/2021 10:04:25 pm ******/

/*
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EngVocab] (
    [Id]         UNIQUEIDENTIFIER NULL,
    [Vocab]      VARCHAR (50)     NULL,
    [Meaning]    VARCHAR (MAX)    NULL,	-- well, save the first meaning exist in the entry.
    [InsertDate] DATETIME         NULL,
    [UpdateDate] DATETIME         NULL
);
*/

-- Quiz generation SQL code here.

-- more difficult functions here.
