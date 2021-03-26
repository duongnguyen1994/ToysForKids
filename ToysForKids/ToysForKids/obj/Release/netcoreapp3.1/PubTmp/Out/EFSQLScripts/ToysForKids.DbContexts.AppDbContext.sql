IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE TABLE [Categories] (
        [CategoryId] int NOT NULL IDENTITY,
        [CategoryName] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE TABLE [Roles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE TABLE [Users] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [Fullname] nvarchar(50) NOT NULL,
        [Address] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE TABLE [Products] (
        [ProductId] int NOT NULL IDENTITY,
        [ProductName] nvarchar(100) NOT NULL,
        [UnitPrice] bigint NOT NULL,
        [QuantityPerUnit] bigint NOT NULL,
        [UnitInStock] bigint NOT NULL,
        [UnitOnOrder] bigint NOT NULL,
        [Description] nvarchar(500) NOT NULL,
        [FileAvatarName] nvarchar(50) NOT NULL,
        [CategoryId] int NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId]),
        CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE TABLE [RoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_RoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_RoleClaims_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE TABLE [Orders] (
        [OrderId] int NOT NULL IDENTITY,
        [OrderDate] datetime2 NOT NULL,
        [ShippedDate] datetime2 NOT NULL,
        [Freight] bigint NOT NULL,
        [ShippedAddress] nvarchar(max) NOT NULL,
        [UserId] nvarchar(450) NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]),
        CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE TABLE [UserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_UserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE TABLE [UserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_UserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE TABLE [UserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_UserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE TABLE [UserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_UserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE TABLE [OrderDetails] (
        [OrderDetailId] int NOT NULL IDENTITY,
        [ProductRefId] int NOT NULL,
        [OrderRefId] int NOT NULL,
        [Quantity] bigint NOT NULL,
        CONSTRAINT [PK_OrderDetails] PRIMARY KEY ([OrderDetailId]),
        CONSTRAINT [FK_OrderDetails_Orders_OrderRefId] FOREIGN KEY ([OrderRefId]) REFERENCES [Orders] ([OrderId]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderDetails_Products_ProductRefId] FOREIGN KEY ([ProductRefId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE INDEX [IX_OrderDetails_OrderRefId] ON [OrderDetails] ([OrderRefId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE INDEX [IX_OrderDetails_ProductRefId] ON [OrderDetails] ([ProductRefId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE INDEX [IX_Orders_UserId] ON [Orders] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE INDEX [IX_RoleClaims_RoleId] ON [RoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [Roles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE INDEX [IX_UserClaims_UserId] ON [UserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE INDEX [IX_UserLogins_UserId] ON [UserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE INDEX [IX_UserRoles_RoleId] ON [UserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE INDEX [EmailIndex] ON [Users] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [Users] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210312093101_InitDb')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210312093101_InitDb', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210320160739_Dataseed_Product_CategoryTable')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryId', N'CategoryName') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    INSERT INTO [Categories] ([CategoryId], [CategoryName])
    VALUES (1, N'Tank'),
    (2, N'Car'),
    (3, N'Aircraft'),
    (4, N'Destroyer');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryId', N'CategoryName') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210320160739_Dataseed_Product_CategoryTable')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductId', N'CategoryId', N'Description', N'FileAvatarName', N'ProductName', N'QuantityPerUnit', N'UnitInStock', N'UnitOnOrder', N'UnitPrice') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    INSERT INTO [Products] ([ProductId], [CategoryId], [Description], [FileAvatarName], [ProductName], [QuantityPerUnit], [UnitInStock], [UnitOnOrder], [UnitPrice])
    VALUES (1, 1, N'USA-World War 1', N'M1917.jpg', N'M1917', CAST(20 AS bigint), CAST(20 AS bigint), CAST(0 AS bigint), CAST(120000 AS bigint)),
    (2, 1, N'USA-World War 1', N'M1918.jpg', N'M1918', CAST(20 AS bigint), CAST(20 AS bigint), CAST(0 AS bigint), CAST(150000 AS bigint)),
    (3, 2, N'Made in China', N'RADCLO_RC_Car.jpg', N'RADCLO RC Car 2.4Ghz 1/20', CAST(20 AS bigint), CAST(20 AS bigint), CAST(0 AS bigint), CAST(120000 AS bigint)),
    (4, 3, N'USA', N'Airforce 1.jpg', N'Airforce 1', CAST(20 AS bigint), CAST(20 AS bigint), CAST(0 AS bigint), CAST(220000 AS bigint));
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductId', N'CategoryId', N'Description', N'FileAvatarName', N'ProductName', N'QuantityPerUnit', N'UnitInStock', N'UnitOnOrder', N'UnitPrice') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210320160739_Dataseed_Product_CategoryTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210320160739_Dataseed_Product_CategoryTable', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325185948_drop_orderTable')
BEGIN
    ALTER TABLE [OrderDetails] DROP CONSTRAINT [FK_OrderDetails_Orders_OrderRefId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325185948_drop_orderTable')
BEGIN
    ALTER TABLE [Orders] DROP CONSTRAINT [FK_Orders_Users_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325185948_drop_orderTable')
BEGIN
    ALTER TABLE [Orders] DROP CONSTRAINT [PK_Orders];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325185948_drop_orderTable')
BEGIN
    EXEC sp_rename N'[Orders]', N'Order';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325185948_drop_orderTable')
BEGIN
    EXEC sp_rename N'[Order].[IX_Orders_UserId]', N'IX_Order_UserId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325185948_drop_orderTable')
BEGIN
    ALTER TABLE [Order] ADD CONSTRAINT [PK_Order] PRIMARY KEY ([OrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325185948_drop_orderTable')
BEGIN
    ALTER TABLE [Order] ADD CONSTRAINT [FK_Order_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325185948_drop_orderTable')
BEGIN
    ALTER TABLE [OrderDetails] ADD CONSTRAINT [FK_OrderDetails_Order_OrderRefId] FOREIGN KEY ([OrderRefId]) REFERENCES [Order] ([OrderId]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325185948_drop_orderTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210325185948_drop_orderTable', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325190116_Add_OrderTable_afterAlter')
BEGIN
    ALTER TABLE [Order] DROP CONSTRAINT [FK_Order_Users_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325190116_Add_OrderTable_afterAlter')
BEGIN
    ALTER TABLE [OrderDetails] DROP CONSTRAINT [FK_OrderDetails_Order_OrderRefId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325190116_Add_OrderTable_afterAlter')
BEGIN
    ALTER TABLE [Order] DROP CONSTRAINT [PK_Order];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325190116_Add_OrderTable_afterAlter')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Order]') AND [c].[name] = N'Freight');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Order] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Order] DROP COLUMN [Freight];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325190116_Add_OrderTable_afterAlter')
BEGIN
    EXEC sp_rename N'[Order]', N'Orders';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325190116_Add_OrderTable_afterAlter')
BEGIN
    EXEC sp_rename N'[Orders].[IX_Order_UserId]', N'IX_Orders_UserId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325190116_Add_OrderTable_afterAlter')
BEGIN
    ALTER TABLE [Orders] ADD CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325190116_Add_OrderTable_afterAlter')
BEGIN
    ALTER TABLE [OrderDetails] ADD CONSTRAINT [FK_OrderDetails_Orders_OrderRefId] FOREIGN KEY ([OrderRefId]) REFERENCES [Orders] ([OrderId]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325190116_Add_OrderTable_afterAlter')
BEGIN
    ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325190116_Add_OrderTable_afterAlter')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210325190116_Add_OrderTable_afterAlter', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325190446_setNullShippedDate')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'ShippedDate');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Orders] ALTER COLUMN [ShippedDate] datetime2 NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210325190446_setNullShippedDate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210325190446_setNullShippedDate', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    ALTER TABLE [OrderDetails] DROP CONSTRAINT [FK_OrderDetails_Orders_OrderRefId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    ALTER TABLE [OrderDetails] DROP CONSTRAINT [FK_OrderDetails_Products_ProductRefId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    ALTER TABLE [Orders] DROP CONSTRAINT [FK_Orders_Users_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    ALTER TABLE [Orders] DROP CONSTRAINT [PK_Orders];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    ALTER TABLE [OrderDetails] DROP CONSTRAINT [PK_OrderDetails];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'UnitOnOrder');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Products] DROP COLUMN [UnitOnOrder];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    EXEC sp_rename N'[Orders]', N'Order';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    EXEC sp_rename N'[OrderDetails]', N'OrderDetail';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    EXEC sp_rename N'[Order].[IX_Orders_UserId]', N'IX_Order_UserId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    EXEC sp_rename N'[OrderDetail].[IX_OrderDetails_ProductRefId]', N'IX_OrderDetail_ProductRefId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    EXEC sp_rename N'[OrderDetail].[IX_OrderDetails_OrderRefId]', N'IX_OrderDetail_OrderRefId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    ALTER TABLE [Order] ADD CONSTRAINT [PK_Order] PRIMARY KEY ([OrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    ALTER TABLE [OrderDetail] ADD CONSTRAINT [PK_OrderDetail] PRIMARY KEY ([OrderDetailId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    ALTER TABLE [Order] ADD CONSTRAINT [FK_Order_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    ALTER TABLE [OrderDetail] ADD CONSTRAINT [FK_OrderDetail_Order_OrderRefId] FOREIGN KEY ([OrderRefId]) REFERENCES [Order] ([OrderId]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    ALTER TABLE [OrderDetail] ADD CONSTRAINT [FK_OrderDetail_Products_ProductRefId] FOREIGN KEY ([ProductRefId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210326074803_drop_orderTable_orderDetailTable_RemoveUnitOnOrder', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074946_add_orderTable_orderDetailTable')
BEGIN
    ALTER TABLE [Order] DROP CONSTRAINT [FK_Order_Users_UserId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074946_add_orderTable_orderDetailTable')
BEGIN
    ALTER TABLE [OrderDetail] DROP CONSTRAINT [FK_OrderDetail_Order_OrderRefId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074946_add_orderTable_orderDetailTable')
BEGIN
    ALTER TABLE [OrderDetail] DROP CONSTRAINT [FK_OrderDetail_Products_ProductRefId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074946_add_orderTable_orderDetailTable')
BEGIN
    ALTER TABLE [OrderDetail] DROP CONSTRAINT [PK_OrderDetail];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074946_add_orderTable_orderDetailTable')
BEGIN
    ALTER TABLE [Order] DROP CONSTRAINT [PK_Order];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074946_add_orderTable_orderDetailTable')
BEGIN
    EXEC sp_rename N'[OrderDetail]', N'OrderDetails';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074946_add_orderTable_orderDetailTable')
BEGIN
    EXEC sp_rename N'[Order]', N'Orders';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074946_add_orderTable_orderDetailTable')
BEGIN
    EXEC sp_rename N'[OrderDetails].[IX_OrderDetail_ProductRefId]', N'IX_OrderDetails_ProductRefId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074946_add_orderTable_orderDetailTable')
BEGIN
    EXEC sp_rename N'[OrderDetails].[IX_OrderDetail_OrderRefId]', N'IX_OrderDetails_OrderRefId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074946_add_orderTable_orderDetailTable')
BEGIN
    EXEC sp_rename N'[Orders].[IX_Order_UserId]', N'IX_Orders_UserId', N'INDEX';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074946_add_orderTable_orderDetailTable')
BEGIN
    ALTER TABLE [OrderDetails] ADD CONSTRAINT [PK_OrderDetails] PRIMARY KEY ([OrderDetailId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074946_add_orderTable_orderDetailTable')
BEGIN
    ALTER TABLE [Orders] ADD CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074946_add_orderTable_orderDetailTable')
BEGIN
    ALTER TABLE [OrderDetails] ADD CONSTRAINT [FK_OrderDetails_Orders_OrderRefId] FOREIGN KEY ([OrderRefId]) REFERENCES [Orders] ([OrderId]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074946_add_orderTable_orderDetailTable')
BEGIN
    ALTER TABLE [OrderDetails] ADD CONSTRAINT [FK_OrderDetails_Products_ProductRefId] FOREIGN KEY ([ProductRefId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074946_add_orderTable_orderDetailTable')
BEGIN
    ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326074946_add_orderTable_orderDetailTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210326074946_add_orderTable_orderDetailTable', N'3.1.13');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326173636_AlterOrderTable_AddColumnTotalAmount')
BEGIN
    ALTER TABLE [Orders] ADD [TotalAmount] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210326173636_AlterOrderTable_AddColumnTotalAmount')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210326173636_AlterOrderTable_AddColumnTotalAmount', N'3.1.13');
END;

GO

