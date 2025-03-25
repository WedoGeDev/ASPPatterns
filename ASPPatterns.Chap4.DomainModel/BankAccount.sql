create database BankAccount
go

CREATE TABLE [dbo].[BankAccounts] (
    [BankAccountId] UNIQUEIDENTIFIER NOT NULL,
    [Balance]       MONEY         NOT NULL,
    [CustomerRef]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_BankAccounts] PRIMARY KEY CLUSTERED ([BankAccountId] ASC)
);
go;

CREATE TABLE [dbo].[Transactions] (
    [BankAccountId] UNIQUEIDENTIFIER NOT NULL,
    [Deposit]       MONEY            NOT NULL,
    [Withdrawal]    MONEY            NOT NULL,
    [Reference]     NVARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([BankAccountId] ASC)
);

ALTER TABLE [Transactions]
ADD FOREIGN KEY ([BankAccountId]) REFERENCES [BankAccounts]([BankAccountId]);
