CREATE TABLE [dbo].[Tasks]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[AuthorId] INT,
	CONSTRAINT [FK_Task_Author] FOREIGN KEY ([AuthorId]) REFERENCES [Users]([Id])
)
