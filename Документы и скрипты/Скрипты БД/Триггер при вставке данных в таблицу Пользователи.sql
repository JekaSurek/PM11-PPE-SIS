USE БелкаФаворитСпичечнаяФабрикаБазаДанных
GO
CREATE TRIGGER [dbo].[TR_Пользователи_Insert]
ON [dbo].[Пользователи]
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE [dbo].[Пользователи]
    SET 
        [Дата_создания] = GETDATE(),
        [Дата_изменения] = GETDATE()
    FROM [dbo].[Пользователи] u
    INNER JOIN inserted i ON u.[id_Пользователя] = i.[id_Пользователя]
END
GO