CREATE TABLE [dbo].[Contact] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [ContactType]      VARCHAR (120) NOT NULL,
    [Address1]         VARCHAR (120) NOT NULL,
    [Address2]         VARCHAR (120) NULL,
    [Address3]         VARCHAR (120) NULL,
    [City]             VARCHAR (100) NOT NULL,
    [State]            CHAR (2)      NOT NULL,
    [Country]          CHAR (2)      NOT NULL,
    [PostalCode]       VARCHAR (16)  NOT NULL,
    [MobileNumber]     VARCHAR (50)  NULL,
    [EmailId]          VARCHAR (50)  NULL,
    [EmergencyContact] VARCHAR (250) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Id]>(0))
);

