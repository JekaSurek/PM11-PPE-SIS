USE [БелкаФаворитСпичечнаяФабрикаБазаДанных]
GO
CREATE TRIGGER [dbo].[TR_Выдача_Insert]
ON [dbo].[Выдача]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE [dbo].[Выдача]
    SET 
        [Дата_создания] = GETDATE(),
        [Дата_изменения] = GETDATE()
    FROM [dbo].[Выдача] v
    INNER JOIN inserted i ON v.[id_Выдачи] = i.[id_Выдачи]
END
GO