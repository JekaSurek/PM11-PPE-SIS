USE БелкаФаворитСпичечнаяФабрикаБазаДанных
ALTER TABLE Выдача ADD CONSTRAINT CHK_ДатаВыдачи CHECK (Дата_выдачи <= GETDATE());
ALTER TABLE Выдача ADD CONSTRAINT CHK_Количество CHECK (количество > 0);