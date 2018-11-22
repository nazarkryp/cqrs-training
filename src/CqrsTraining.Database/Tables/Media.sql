CREATE TABLE [dbo].[Media] (
	[MediaId]		INT				NOT NULL	IDENTITY(1,1),
	[Url]			NVARCHAR(200)	NOT NULL,
	[UserId]		INT				NOT NULL,

	CONSTRAINT [PK_Media_MediaId] PRIMARY KEY CLUSTERED ([MediaId] ASC),
	CONSTRAINT [UQ_Media_Url] UNIQUE ([Url]),
	CONSTRAINT [FK_Media_UserId_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE
)
