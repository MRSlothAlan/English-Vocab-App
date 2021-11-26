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
