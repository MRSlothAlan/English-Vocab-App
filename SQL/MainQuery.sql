-- finally, yes, this is the editor.
-- query editing

DROP TABLE EngVocab;

CREATE TABLE EngVocab (
	Id uniqueidentifier,
	Vocab varchar(50),
	Meaning varchar(MAX),
	InsertDate datetime,
	UpdateDate datetime
);


-- create logic for picking words for quizzes.
SELECT * FROM EngVocab;
