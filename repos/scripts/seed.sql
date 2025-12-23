IF NOT EXISTS (SELECT 1 FROM dbo.CatCategory WHERE Name = 'Cocina')
BEGIN
    INSERT INTO dbo.CatCategory (Id, Name, Description, CreateAt, EdithAt, Active)
    VALUES (1, 'Cocina', 'Productos para la cocina del hogar', GETDATE(), GETDATE(), 1);
END
IF NOT EXISTS (SELECT 1 FROM dbo.CatProducts WHERE Name = 'Sarten')
BEGIN
    INSERT INTO dbo.CatProducts (IdCategory, Name, Description, CreateAt, EdithAt, Active)
    VALUES (1, 'Sarten', 'Sarten ceramico de 5 pulgadas', GETDATE(), GETDATE(), 1);
END
IF NOT EXISTS (SELECT 1 FROM dbo.Inventory WHERE IdProduct = 1)
BEGIN
    INSERT INTO dbo.Inventory (IdProduct, Stock, StockMax, StockMin)
    VALUES (1, 6, 5, 3);
END
IF NOT EXISTS (SELECT 1 FROM dbo.InventoryMovements WHERE IdProduct = 1 AND Motion = -1)
BEGIN
    INSERT INTO dbo.InventoryMovements (IdProduct, Motion, UserId, CreatedAt)
    VALUES (1, -1, 10000, GETDATE());
END
IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Email = 'test@mail.com')
BEGIN
    INSERT INTO dbo.Users (Id, [User], Email, [Password], IsActive, CreatedAt)
    VALUES (NEWID(), 10000, 'test@mail.com', 0x41514141414149414159616741414141454633336A594A675855424B4778304D6A395033496975444F5A354C535A6A6C42364A427157633570514A587259314D796B5937494174513978536A424D4F4234513D3D, 1, GETDATE());
END

    INSERT INTO dbo.Sessions (Id, UserId, Token, ExpiresAt, CreatedAt)
    VALUES (NEWID(), (SELECT Id FROM dbo.Users WHERE Email='test@mail.com'), 
            N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJlNTA3MmE1Ni03ODYxLTRjMDktYjk4MC04YmJjMDU1NzY5NDgiLCJlbWFpbCI6InRlc3RAbWFpbC5jb20iLCJleHAiOjE3NjY1MTgyMTAsImlzcyI6IlByb2R1Y3RJbnZlbnRvcnkuQXBpIiwiYXVkIjoiUHJvZHVjdEludmVudG9yeS5DbGllbnQifQ.7OyVPvV2mLTvXkmE3rfXgXJvVXNpV_ujvhMsTfu8hww', 
            DATEADD(DAY, 1, GETDATE()), GETDATE());
