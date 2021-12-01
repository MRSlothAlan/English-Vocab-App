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
INSERT INTO [dbo].[EngVocabMeanings] 
([Id], [VocabId], [WordForm], [Meaning])
VALUES (NEWID(), 
(SELECT TOP(1) Id FROM [dbo].[EngVocab]), 
'phrase', 'This is a joke')

INSERT INTO [dbo].EngVocabExamples 
(Id, VocabId, Content)
VALUES (NEWID(), (SELECT TOP(1) Id FROM [dbo].EngVocab), 'fucking assignment')

-- now the update
-- update meaning flow.
/* 
DELETE FROM dbo.EngVocabExamples WHERE
VocabId = (SELECT TOP(1) Id FROM [dbo].[EngVocab]);
*/
-- generate Quiz
-- GENERATE QUIZ LOGIC!
-- think about the format later.

/*
Quiz requirement:
(for now)
1 questions for each click
4~5 options (random meanings, pick any one)
display a word, pick an option, check for answers.
Like a medium question on leetcode.
try NOT to make any testing data
just come up with a logic
let's test whether I am smart enough as a DB admin.
*/


SELECT * FROM (
	SELECT * FROM dbo.EngVocab

	JOIN (
		SELECT * FROM dbo.EngVocabMeanings
	) as M
	ON M.VocabId = Id
) AS result; 

-- no data is correct, because I just create a new schema, no data is being loaded into those things.


	SELECT M.Meaning, E.VocabId, E.Content FROM dbo.EngVocabExamples AS E
	JOIN (
		SELECT Meaning, VocabId FROM dbo.EngVocabMeanings
	) AS M
	ON E.VocabId = M.VocabId
	WHERE E.VocabId IN (SELECT TOP 5 Id FROM dbo.EngVocab ORDER BY NEWID())


	SELECT Id, Vocab, RES.Content, RES.Meaning FROM dbo.EngVocab
	JOIN (
		SELECT M.Meaning, E.VocabId, E.Content FROM dbo.EngVocabExamples AS E
		JOIN (
			SELECT Meaning, VocabId FROM dbo.EngVocabMeanings
		) AS M
		ON E.VocabId = M.VocabId
		WHERE E.VocabId IN ('3ea5d2f1-0a91-4e0f-92ad-a896683368a6',
	'b5655eeb-adcb-4a9b-8aaf-36e60bb7421f',
	'5419704c-64e4-4a72-ac06-fa768c5e3382',
	'ef652d8a-08d3-4a8a-bf6f-02033293a863',
	'f1d7b999-3a07-458b-9abd-5858124e35bd')
	) AS RES
	ON RES.VocabId = Id
	ORDER BY NEWID()


	/*
SELECT 
	Meaning,
	VocabId,
	ROW_NUMBER() OVER (ORDER BY Id, VocabId) - 
	RANK() OVER (ORDER BY VocabId) AS ROW_NUM

FROM dbo.EngVocabMeanings;
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
