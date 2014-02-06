
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/06/2014 18:23:58
-- Generated from EDMX file: C:\Code\Calorie Tracker\CalorieTracker\CalorieTracker\Models\CTDB.edmx
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

-- Creating table 'Activities'
CREATE TABLE [dbo].[Activities] (
    [ActivityID] varchar(45)  NOT NULL,
    [Name] varchar(256)  NOT NULL,
    [CalorieBurnRate] decimal(18,0)  NOT NULL,
    [ImageURL] varchar(256)  NULL
);
GO

-- Creating table 'ActivityLogs'
CREATE TABLE [dbo].[ActivityLogs] (
    [LogID] varchar(45)  NOT NULL,
    [ActivityID] varchar(45)  NOT NULL,
    [UserID] int  NOT NULL,
    [Duration] time  NOT NULL,
    [Distance] decimal(18,0)  NOT NULL,
    [Title] varchar(256)  NOT NULL,
    [Accent] decimal(18,0)  NOT NULL,
    [HeartRate] int  NOT NULL,
    [Notes] varchar(max)  NOT NULL,
    [FileURL] varchar(256)  NOT NULL,
    [StartDate] datetime  NOT NULL
);
GO

-- Creating table 'Foods'
CREATE TABLE [dbo].[Foods] (
    [FoodID] int  NOT NULL,
    [ParentID] int  NULL,
    [Name] varchar(256)  NOT NULL,
    [SourceID] int  NOT NULL,
    [GroupID] int  NOT NULL,
    [Description] varchar(256)  NOT NULL,
    [ManufacturerName] varchar(45)  NOT NULL
);
GO

-- Creating table 'FoodLogs'
CREATE TABLE [dbo].[FoodLogs] (
    [FoodLogID] varchar(45)  NOT NULL,
    [MealID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [Quantity] decimal(18,0)  NOT NULL,
    [CreationTimestamp] datetime  NOT NULL
);
GO

-- Creating table 'MetricLogs'
CREATE TABLE [dbo].[MetricLogs] (
    [MetricLogID] varchar(45)  NOT NULL,
    [UserID] int  NULL,
    [MetricID] varchar(45)  NULL,
    [Value] decimal(18,0)  NOT NULL,
    [CreationTimestamp] datetime  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [Gender] bit  NOT NULL,
    [PasswordHash] varchar(64)  NOT NULL,
    [PasswordSalt] varchar(64)  NOT NULL,
    [AdminInt] bit  NOT NULL,
    [CreationTimestamp] datetime  NOT NULL,
    [ActivityLevel] int  NOT NULL,
    [PersonalityType] int  NOT NULL
);
GO

-- Creating table 'UserMetrics'
CREATE TABLE [dbo].[UserMetrics] (
    [MetricID] varchar(45)  NOT NULL,
    [MetricName] varchar(256)  NOT NULL,
    [MetricType] int  NOT NULL
);
GO

-- Creating table 'UserTargets'
CREATE TABLE [dbo].[UserTargets] (
    [TargetID] varchar(45)  NOT NULL,
    [UserID] int  NOT NULL,
    [MetricID] varchar(45)  NOT NULL,
    [ParentID] varchar(45)  NOT NULL,
    [GoalTimestamp] datetime  NOT NULL,
    [CreationTimestamp] varchar(45)  NOT NULL,
    [CompletedTimestamp] varchar(45)  NOT NULL
);
GO

-- Creating table 'FoodGroups'
CREATE TABLE [dbo].[FoodGroups] (
    [GroupID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(256)  NOT NULL,
    [SourceID] int  NOT NULL
);
GO

-- Creating table 'tbl_food_unit'
CREATE TABLE [dbo].[tbl_food_unit] (
    [food_unit] varchar(max)  NOT NULL
);
GO

-- Creating table 'Nutrients'
CREATE TABLE [dbo].[Nutrients] (
    [NutrientID] int IDENTITY(1,1) NOT NULL,
    [SourceID] int  NOT NULL,
    [UnitType] int  NOT NULL,
    [Name] varchar(256)  NOT NULL,
    [DecimalRounding] int  NOT NULL
);
GO

-- Creating table 'FoodNutrientLogs'
CREATE TABLE [dbo].[FoodNutrientLogs] (
    [NutrientLogID] int IDENTITY(1,1) NOT NULL,
    [FoodID] int  NOT NULL,
    [NutrientID] int  NOT NULL,
    [Value] decimal(18,0)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ActivityID] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [PK_Activities]
    PRIMARY KEY CLUSTERED ([ActivityID] ASC);
GO

-- Creating primary key on [LogID] in table 'ActivityLogs'
ALTER TABLE [dbo].[ActivityLogs]
ADD CONSTRAINT [PK_ActivityLogs]
    PRIMARY KEY CLUSTERED ([LogID] ASC);
GO

-- Creating primary key on [FoodID] in table 'Foods'
ALTER TABLE [dbo].[Foods]
ADD CONSTRAINT [PK_Foods]
    PRIMARY KEY CLUSTERED ([FoodID] ASC);
GO

-- Creating primary key on [FoodLogID] in table 'FoodLogs'
ALTER TABLE [dbo].[FoodLogs]
ADD CONSTRAINT [PK_FoodLogs]
    PRIMARY KEY CLUSTERED ([FoodLogID] ASC);
GO

-- Creating primary key on [MetricLogID] in table 'MetricLogs'
ALTER TABLE [dbo].[MetricLogs]
ADD CONSTRAINT [PK_MetricLogs]
    PRIMARY KEY CLUSTERED ([MetricLogID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [MetricID] in table 'UserMetrics'
ALTER TABLE [dbo].[UserMetrics]
ADD CONSTRAINT [PK_UserMetrics]
    PRIMARY KEY CLUSTERED ([MetricID] ASC);
GO

-- Creating primary key on [TargetID] in table 'UserTargets'
ALTER TABLE [dbo].[UserTargets]
ADD CONSTRAINT [PK_UserTargets]
    PRIMARY KEY CLUSTERED ([TargetID] ASC);
GO

-- Creating primary key on [GroupID] in table 'FoodGroups'
ALTER TABLE [dbo].[FoodGroups]
ADD CONSTRAINT [PK_FoodGroups]
    PRIMARY KEY CLUSTERED ([GroupID] ASC);
GO

-- Creating primary key on [food_unit] in table 'tbl_food_unit'
ALTER TABLE [dbo].[tbl_food_unit]
ADD CONSTRAINT [PK_tbl_food_unit]
    PRIMARY KEY CLUSTERED ([food_unit] ASC);
GO

-- Creating primary key on [NutrientID] in table 'Nutrients'
ALTER TABLE [dbo].[Nutrients]
ADD CONSTRAINT [PK_Nutrients]
    PRIMARY KEY CLUSTERED ([NutrientID] ASC);
GO

-- Creating primary key on [NutrientLogID] in table 'FoodNutrientLogs'
ALTER TABLE [dbo].[FoodNutrientLogs]
ADD CONSTRAINT [PK_FoodNutrientLogs]
    PRIMARY KEY CLUSTERED ([NutrientLogID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ActivityID] in table 'ActivityLogs'
ALTER TABLE [dbo].[ActivityLogs]
ADD CONSTRAINT [FK_activity_id]
    FOREIGN KEY ([ActivityID])
    REFERENCES [dbo].[Activities]
        ([ActivityID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_activity_id'
CREATE INDEX [IX_FK_activity_id]
ON [dbo].[ActivityLogs]
    ([ActivityID]);
GO

-- Creating foreign key on [MealID] in table 'FoodLogs'
ALTER TABLE [dbo].[FoodLogs]
ADD CONSTRAINT [FK_food_log_food_id]
    FOREIGN KEY ([MealID])
    REFERENCES [dbo].[Foods]
        ([FoodID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_food_log_food_id'
CREATE INDEX [IX_FK_food_log_food_id]
ON [dbo].[FoodLogs]
    ([MealID]);
GO

-- Creating foreign key on [GroupID] in table 'Foods'
ALTER TABLE [dbo].[Foods]
ADD CONSTRAINT [fk_food_group_id]
    FOREIGN KEY ([GroupID])
    REFERENCES [dbo].[FoodGroups]
        ([GroupID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_food_group_id'
CREATE INDEX [IX_fk_food_group_id]
ON [dbo].[Foods]
    ([GroupID]);
GO

-- Creating foreign key on [FoodID] in table 'FoodNutrientLogs'
ALTER TABLE [dbo].[FoodNutrientLogs]
ADD CONSTRAINT [fk_food_nutrient_food_id1]
    FOREIGN KEY ([FoodID])
    REFERENCES [dbo].[Foods]
        ([FoodID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_food_nutrient_food_id1'
CREATE INDEX [IX_fk_food_nutrient_food_id1]
ON [dbo].[FoodNutrientLogs]
    ([FoodID]);
GO

-- Creating foreign key on [MetricID] in table 'MetricLogs'
ALTER TABLE [dbo].[MetricLogs]
ADD CONSTRAINT [FK_tbl_metric_id]
    FOREIGN KEY ([MetricID])
    REFERENCES [dbo].[UserMetrics]
        ([MetricID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_metric_id'
CREATE INDEX [IX_FK_tbl_metric_id]
ON [dbo].[MetricLogs]
    ([MetricID]);
GO

-- Creating foreign key on [UserID] in table 'MetricLogs'
ALTER TABLE [dbo].[MetricLogs]
ADD CONSTRAINT [FK_tbl_user_id]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_user_id'
CREATE INDEX [IX_FK_tbl_user_id]
ON [dbo].[MetricLogs]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'ActivityLogs'
ALTER TABLE [dbo].[ActivityLogs]
ADD CONSTRAINT [FK_activity_user_id]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_activity_user_id'
CREATE INDEX [IX_FK_activity_user_id]
ON [dbo].[ActivityLogs]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'FoodLogs'
ALTER TABLE [dbo].[FoodLogs]
ADD CONSTRAINT [FK_food_log_user_id]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_food_log_user_id'
CREATE INDEX [IX_FK_food_log_user_id]
ON [dbo].[FoodLogs]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'UserTargets'
ALTER TABLE [dbo].[UserTargets]
ADD CONSTRAINT [FK_user_id]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_user_id'
CREATE INDEX [IX_FK_user_id]
ON [dbo].[UserTargets]
    ([UserID]);
GO

-- Creating foreign key on [MetricID] in table 'UserTargets'
ALTER TABLE [dbo].[UserTargets]
ADD CONSTRAINT [FK_metric_id]
    FOREIGN KEY ([MetricID])
    REFERENCES [dbo].[UserMetrics]
        ([MetricID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_metric_id'
CREATE INDEX [IX_FK_metric_id]
ON [dbo].[UserTargets]
    ([MetricID]);
GO

-- Creating foreign key on [ParentID] in table 'UserTargets'
ALTER TABLE [dbo].[UserTargets]
ADD CONSTRAINT [FK_parent_target_id]
    FOREIGN KEY ([ParentID])
    REFERENCES [dbo].[UserTargets]
        ([TargetID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_parent_target_id'
CREATE INDEX [IX_FK_parent_target_id]
ON [dbo].[UserTargets]
    ([ParentID]);
GO

-- Creating foreign key on [NutrientID] in table 'FoodNutrientLogs'
ALTER TABLE [dbo].[FoodNutrientLogs]
ADD CONSTRAINT [fk_food_nutrient_nutrient_id1]
    FOREIGN KEY ([NutrientID])
    REFERENCES [dbo].[Nutrients]
        ([NutrientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_food_nutrient_nutrient_id1'
CREATE INDEX [IX_fk_food_nutrient_nutrient_id1]
ON [dbo].[FoodNutrientLogs]
    ([NutrientID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------