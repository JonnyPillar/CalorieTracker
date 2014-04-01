
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/01/2014 16:56:41
-- Generated from EDMX file: C:\Code\Calorie Tracker\CalorieTracker\CalorieTracker\Utils\NewFolder1\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CALTRACK];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [DOB] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [PasswordHash] nvarchar(max)  NOT NULL,
    [Admin] nvarchar(max)  NOT NULL,
    [CreationDateTime] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Logs'
CREATE TABLE [dbo].[Logs] (
    [LogID] int IDENTITY(1,1) NOT NULL,
    [UserID] nvarchar(max)  NOT NULL,
    [ActivityID] nvarchar(max)  NOT NULL,
    [MetricID] nvarchar(max)  NOT NULL,
    [FoodID] nvarchar(max)  NOT NULL,
    [Quantity] nvarchar(max)  NOT NULL,
    [CreationDateTIme] nvarchar(max)  NOT NULL,
    [User_UserID] int  NOT NULL
);
GO

-- Creating table 'Activities'
CREATE TABLE [dbo].[Activities] (
    [ActivityID] int IDENTITY(1,1) NOT NULL,
    [ActivityName] nvarchar(max)  NOT NULL,
    [CalorieBurnRate] nvarchar(max)  NOT NULL,
    [Log_LogID] int  NOT NULL
);
GO

-- Creating table 'Metrics'
CREATE TABLE [dbo].[Metrics] (
    [MetricID] int IDENTITY(1,1) NOT NULL,
    [MetricName] nvarchar(max)  NOT NULL,
    [MetricType] nvarchar(max)  NOT NULL,
    [Log_LogID] int  NOT NULL
);
GO

-- Creating table 'Foods'
CREATE TABLE [dbo].[Foods] (
    [FoodID] int IDENTITY(1,1) NOT NULL,
    [FoodName] nvarchar(max)  NOT NULL,
    [FoodDescription] nvarchar(max)  NOT NULL,
    [Log_LogID] int  NOT NULL,
    [FoodNutrient_FoodNutrientID] int  NOT NULL
);
GO

-- Creating table 'FoodNutrients'
CREATE TABLE [dbo].[FoodNutrients] (
    [FoodNutrientID] int IDENTITY(1,1) NOT NULL,
    [FoodID] nvarchar(max)  NOT NULL,
    [NutrientID] nvarchar(max)  NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [Nutrient_NutrientID] int  NOT NULL
);
GO

-- Creating table 'Nutrients'
CREATE TABLE [dbo].[Nutrients] (
    [NutrientID] int IDENTITY(1,1) NOT NULL,
    [NutrientName] nvarchar(max)  NOT NULL,
    [NutrientValueType] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [LogID] in table 'Logs'
ALTER TABLE [dbo].[Logs]
ADD CONSTRAINT [PK_Logs]
    PRIMARY KEY CLUSTERED ([LogID] ASC);
GO

-- Creating primary key on [ActivityID] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [PK_Activities]
    PRIMARY KEY CLUSTERED ([ActivityID] ASC);
GO

-- Creating primary key on [MetricID] in table 'Metrics'
ALTER TABLE [dbo].[Metrics]
ADD CONSTRAINT [PK_Metrics]
    PRIMARY KEY CLUSTERED ([MetricID] ASC);
GO

-- Creating primary key on [FoodID] in table 'Foods'
ALTER TABLE [dbo].[Foods]
ADD CONSTRAINT [PK_Foods]
    PRIMARY KEY CLUSTERED ([FoodID] ASC);
GO

-- Creating primary key on [FoodNutrientID] in table 'FoodNutrients'
ALTER TABLE [dbo].[FoodNutrients]
ADD CONSTRAINT [PK_FoodNutrients]
    PRIMARY KEY CLUSTERED ([FoodNutrientID] ASC);
GO

-- Creating primary key on [NutrientID] in table 'Nutrients'
ALTER TABLE [dbo].[Nutrients]
ADD CONSTRAINT [PK_Nutrients]
    PRIMARY KEY CLUSTERED ([NutrientID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_UserID] in table 'Logs'
ALTER TABLE [dbo].[Logs]
ADD CONSTRAINT [FK_UserLog]
    FOREIGN KEY ([User_UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserLog'
CREATE INDEX [IX_FK_UserLog]
ON [dbo].[Logs]
    ([User_UserID]);
GO

-- Creating foreign key on [Log_LogID] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [FK_LogActivity]
    FOREIGN KEY ([Log_LogID])
    REFERENCES [dbo].[Logs]
        ([LogID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LogActivity'
CREATE INDEX [IX_FK_LogActivity]
ON [dbo].[Activities]
    ([Log_LogID]);
GO

-- Creating foreign key on [Log_LogID] in table 'Metrics'
ALTER TABLE [dbo].[Metrics]
ADD CONSTRAINT [FK_LogMetric]
    FOREIGN KEY ([Log_LogID])
    REFERENCES [dbo].[Logs]
        ([LogID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LogMetric'
CREATE INDEX [IX_FK_LogMetric]
ON [dbo].[Metrics]
    ([Log_LogID]);
GO

-- Creating foreign key on [Log_LogID] in table 'Foods'
ALTER TABLE [dbo].[Foods]
ADD CONSTRAINT [FK_LogFood]
    FOREIGN KEY ([Log_LogID])
    REFERENCES [dbo].[Logs]
        ([LogID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LogFood'
CREATE INDEX [IX_FK_LogFood]
ON [dbo].[Foods]
    ([Log_LogID]);
GO

-- Creating foreign key on [FoodNutrient_FoodNutrientID] in table 'Foods'
ALTER TABLE [dbo].[Foods]
ADD CONSTRAINT [FK_FoodNutrientFood]
    FOREIGN KEY ([FoodNutrient_FoodNutrientID])
    REFERENCES [dbo].[FoodNutrients]
        ([FoodNutrientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FoodNutrientFood'
CREATE INDEX [IX_FK_FoodNutrientFood]
ON [dbo].[Foods]
    ([FoodNutrient_FoodNutrientID]);
GO

-- Creating foreign key on [Nutrient_NutrientID] in table 'FoodNutrients'
ALTER TABLE [dbo].[FoodNutrients]
ADD CONSTRAINT [FK_NutrientFoodNutrient]
    FOREIGN KEY ([Nutrient_NutrientID])
    REFERENCES [dbo].[Nutrients]
        ([NutrientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NutrientFoodNutrient'
CREATE INDEX [IX_FK_NutrientFoodNutrient]
ON [dbo].[FoodNutrients]
    ([Nutrient_NutrientID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------