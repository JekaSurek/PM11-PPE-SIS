USE [БелкаФаворитСпичечнаяФабрикаБазаДанных]
GO
ALTER TABLE [dbo].[Выдача] WITH CHECK
ADD CONSTRAINT [CHK_ДатыВыдачи] CHECK 
(
    [Срок_износа] IS NULL OR [Срок_износа] >= [Дата_выдачи]
)
GO