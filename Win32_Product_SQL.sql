﻿DROP TABLE dbo.Win32_Product
GO

CREATE TABLE dbo.Win32_Product(
	[Id] [int] IDENTITY(1, 1) NOT NULL,
	[ComputerName] [varchar](15) NOT NULL,
	[Name] [varchar](128) NULL,
	[Vendor] [varchar](48) NULL,
	[Version] [varchar](24) NULL,
	[IdentifyingNumber] [varchar](38) NOT NULL,
	[InstallDate] [varchar](8) NULL,
	[InstallLocation] [varchar](96) NULL,
	[InstallSource] [varchar](160) NULL,
	[LocalPackage] [varchar](48) NULL,
	[PackageCache] [varchar](48) NULL,
	[PackageCode] [varchar](48) NULL,
	[PackageName] [varchar](160) NULL,
	[HelpLink] [varchar](64) NULL,
	[URLInfoAbout] [varchar](64) NULL,
	[URLUpdateInfo] [varchar](64) NULL,
	CONSTRAINT [PK_Win32_Product] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
