CREATE TABLE [dbo].[Users] (
	[UserId]		INT				NOT NULL	IDENTITY(1,1),
	[Username]		NVARCHAR(25)	NOT NULL

	CONSTRAINT [PK_Users_UserId] PRIMARY KEY CLUSTERED ([UserId] ASC),
	CONSTRAINT [UQ_Users_Username] UNIQUE ([Username])
)
