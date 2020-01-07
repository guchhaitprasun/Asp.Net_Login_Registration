CREATE TABLE [dbo].[ApplicationUser]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[FirstName] NVARCHAR(50) NULL, 
	[LastName] NVARCHAR(50) NULL, 
	[EmailAddress] NVARCHAR(256) UNIQUE NOT NULL, 
	[ProfilePicture] NVARCHAR(MAX) NULL, 
	[PasswordHash] NVARCHAR(MAX) NOT NULL, 
	[UserName] NVARCHAR(50) NULL, 
	[IsActive] BIT NOT NULL
)
