USE [C:\USERS\TINGK\SOURCE\REPOS\ENGVOCABAPP\BIN\DEBUG\ENGVOCAB.MDF]

select * from dbo.EngVocab;

drop table dbo.EngVocabExamples;

drop table dbo.EngVocabMeanings;


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

/****** Object: Table [dbo].[EngVocab] Script Date: 27/11/2021 10:04:25 pm ******/
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


-- Quiz generation SQL code here.

-- more difficult functions here.
