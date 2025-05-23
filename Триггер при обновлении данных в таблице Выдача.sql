CREATE TRIGGER [dbo].[TR_Выдача_Update]
ON [dbo].[Выдача]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NOT (UPDATE(Дата_изменения) OR UPDATE(Кем_создана))
    BEGIN
        UPDATE [dbo].[Выдача]
        SET [Дата_изменения] = GETDATE()
        FROM [dbo].[Выдача] v
        INNER JOIN inserted i ON v.[id_Выдачи] = i.[id_Выдачи]
    END
END
GO