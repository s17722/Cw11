IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Doctors] (
    [IdDoctor] int NOT NULL IDENTITY,
    [FirstName] nvarchar(100) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [Email] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Doctors] PRIMARY KEY ([IdDoctor])
);

GO

CREATE TABLE [Medicaments] (
    [IdMedicament] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Description] nvarchar(100) NOT NULL,
    [Type] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Medicaments] PRIMARY KEY ([IdMedicament])
);

GO

CREATE TABLE [Patients] (
    [IdPatient] int NOT NULL IDENTITY,
    [FirstName] nvarchar(100) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [BirthDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Patients] PRIMARY KEY ([IdPatient])
);

GO

CREATE TABLE [Prescriptions] (
    [IdPrescription] int NOT NULL IDENTITY,
    [Date] datetime2 NOT NULL,
    [DueDate] datetime2 NOT NULL,
    [IdPatient] int NOT NULL,
    [IdDoctor] int NOT NULL,
    CONSTRAINT [PK_Prescriptions] PRIMARY KEY ([IdPrescription]),
    CONSTRAINT [FK_Prescriptions_Doctors_IdDoctor] FOREIGN KEY ([IdDoctor]) REFERENCES [Doctors] ([IdDoctor]) ON DELETE CASCADE,
    CONSTRAINT [FK_Prescriptions_Patients_IdPatient] FOREIGN KEY ([IdPatient]) REFERENCES [Patients] ([IdPatient]) ON DELETE CASCADE
);

GO

CREATE TABLE [PrescriptionMedicaments] (
    [IdMedicament] int NOT NULL,
    [IdPrescription] int NOT NULL,
    [Ilosc] int NOT NULL,
    [Details] nvarchar(300) NOT NULL,
    [Dose] int NOT NULL,
    CONSTRAINT [PK_PrescriptionMedicaments] PRIMARY KEY ([IdPrescription], [IdMedicament]),
    CONSTRAINT [FK_PrescriptionMedicaments_Medicaments_IdMedicament] FOREIGN KEY ([IdMedicament]) REFERENCES [Medicaments] ([IdMedicament]) ON DELETE CASCADE,
    CONSTRAINT [FK_PrescriptionMedicaments_Prescriptions_IdPrescription] FOREIGN KEY ([IdPrescription]) REFERENCES [Prescriptions] ([IdPrescription]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_PrescriptionMedicaments_IdMedicament] ON [PrescriptionMedicaments] ([IdMedicament]);

GO

CREATE INDEX [IX_Prescriptions_IdDoctor] ON [Prescriptions] ([IdDoctor]);

GO

CREATE INDEX [IX_Prescriptions_IdPatient] ON [Prescriptions] ([IdPatient]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200620205440_InitialMigration', N'3.1.5');

GO

