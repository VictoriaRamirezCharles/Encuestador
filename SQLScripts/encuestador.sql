Create database ENCUESTADOR
go
use ENCUESTADOR

CREATE TABLE [dbo].[Tbl_Users](
	[Id] [int] IDENTITY NOT NULL,
	[Name] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[UserName] [varchar](100)primary key  NOT NULL,
	[Password] [varchar](50) NULL)
go
CREATE TABLE [dbo].[Tbl_Surveys](
	[Id] [int] primary key IDENTITY NOT NULL,
	[Name] [varchar](100) NULL,
	[QuestionQuantity] [int] NULL,
	[UserName] [varchar](100) NULL,
FOREIGN KEY (UserName) REFERENCES Tbl_Users(UserName))
go
CREATE TABLE [dbo].[Tbl_Questions](
	[Id] [int] primary key IDENTITY NOT NULL,
	[Question] [varchar](500) NULL,
	[SurveyId] [int] NOT NULL,
CONSTRAINT fk_SurveyId FOREIGN KEY(SurveyId) 
REFERENCES Tbl_Surveys(Id) ON DELETE CASCADE ON UPDATE CASCADE)

go

CREATE TABLE [dbo].[Tbl_surveyed](
	[Id] [int] primary key IDENTITY( NOT NULL,
	[QuestionId] [int] NULL,
	[Name] [varchar](50) NULL,
	[Username] [varchar](50) NULL,
	[Answer] [varchar](200) NULL,
	[SurveyId] [int] NULL)