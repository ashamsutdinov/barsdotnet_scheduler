﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Login] NVARCHAR(64),
	[PasswordHash] NVARCHAR(64),
	[Salt] NVARCHAR(64)
)
