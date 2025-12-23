
CREATE TRIGGER TR_Sessions_SetExpiration
ON Sessions
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE s
    SET ExpiresAt = DATEADD(DAY, 1, i.CreatedAt)
    FROM Sessions s
    INNER JOIN inserted i ON s.Id = i.Id;
END;
GO
CREATE TRIGGER [dbo].[Inventory_UpdateStock]
ON [dbo].[InventoryMovements]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE i
    SET 
        i.Stock = i.Stock + s.Motion
    FROM Inventory i
    INNER JOIN inserted s ON s.IdProduct = i.IdProduct;
END;
GO
ALTER TABLE [dbo].[InventoryMovements] ENABLE TRIGGER [Inventory_UpdateStock]
GO
 CREATE TRIGGER [dbo].[InventoryMovements_UpdateDate]
ON [dbo].[InventoryMovements]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t
    SET CreateAt = GETDATE()
    FROM InventoryMovements t
    INNER JOIN inserted i ON t.Id = i.Id;
END;
GO
ALTER TABLE [dbo].[InventoryMovements] ENABLE TRIGGER [InventoryMovements_UpdateDate]
GO

  CREATE TRIGGER [dbo].[CatProducts_UpdateDate]
ON [dbo].[CatProducts]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t
    SET EdithAt = SYSDATETIME()
    FROM CatProducts t
    INNER JOIN inserted i ON t.Id = i.Id;
END;
GO
ALTER TABLE [dbo].[CatProducts] ENABLE TRIGGER [CatProducts_UpdateDate]
GO
ALTER TRIGGER [dbo].[CatCategory_UpdateDate]
ON [dbo].[CatCategory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE t
    SET EdithAt = SYSDATETIME()
    FROM CatCategory t
    INNER JOIN inserted i ON t.Id = i.Id;
END;
GO