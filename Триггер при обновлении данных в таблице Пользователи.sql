USE БелкаФаворитСпичечнаяФабрикаБазаДанных
GO
CREATE TRIGGER [dbo].[TR_Пользователи_UPDATE]
ON [dbo].[Пользователи]
AFTER UPDATE
AS
BEGIN
SET NOCOUNT ON;

IF NOT UPDATE(Дата_последнего_входа)
BEGIN
UPDATE [dbo].[Пользователи]
SET [Дата_изменения] = GETDATE()
FROM [dbo].[Пользователи] u
INNER JOIN inserted i ON u.[id_Пользователя] = i.[id_Пользователя]
END
END
GO
